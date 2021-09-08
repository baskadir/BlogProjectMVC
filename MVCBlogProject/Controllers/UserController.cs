using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using MVCBlogProject.Models;
using System.IO;
using MVCBlogProject.Services;

namespace MVCBlogProject.Controllers
{
    public class UserController : Controller
    {
        IUserRepository userRepository;
        ITopicRepository topicRepository;
        IEmailService emailService;
        public UserController(IUserRepository userRepository, ITopicRepository topicRepository, IEmailService emailService)
        {
            this.emailService = emailService;
            this.userRepository = userRepository;
            this.topicRepository = topicRepository;
        }
        public IActionResult Index()
        {
            int userId = (int)HttpContext.Session.GetInt32("loginId");
            List<Topic> topics = topicRepository.GetTopicsByUser(userId);

            if (topics.Count == 0)
            {
                return RedirectToAction("AddTopicForUser", "User");
            }
            else
            {
                ViewBag.Topics = topics;
                return View();
            }
        }

        public IActionResult GetArticlesPartial(int? id)
        {
            int userId = (int)HttpContext.Session.GetInt32("loginId");

            List<ArticleVM> articles;
            if (id == null)
            {
                articles = GetListArticleVM(topicRepository.GetArticlesForUserByTopics(userId));
            }
            else
            {
                articles = GetListArticleVM(topicRepository.GetArticlesByTopic(id.Value, userId));
            }
            return PartialView("_articleListPartial", articles);
        }

        private List<ArticleVM> GetListArticleVM(List<Article> articleList)
        {
            List<ArticleVM> articles = new List<ArticleVM>();
            ArticleVM article;
            foreach (var item in articleList)
            {
                article = new ArticleVM()
                {
                    ArticleId = item.ArticleID,
                    Title = item.Title,
                    Content = item.Content,
                    UserId = item.UserID,
                    CreatedDate = (DateTime)item.CreatedTime,
                    UserName = userRepository.GetUserById(item.UserID).UserName,
                    ImageName = userRepository.GetUserById(item.UserID).PhotoName
                };
                articles.Add(article);
            }
            return articles;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserVM newUser)
        {
            User user = new User()
            {
                Email = newUser.Email,
                FullName = newUser.FullName,
                UserName = newUser.UserName,
                PhotoName = newUser.PhotoPath
            };
            bool check = userRepository.Register(user);
            if (check)
            {
                bool emailCheck = emailService.SendEmail(user.Email, user.UserID, UserTypeEnum.Register);
                if (emailCheck)
                {
                    return RedirectToAction("Confirm", "User");
                }
                else
                {
                    ViewBag.Message = "İşlem sırasında hata oluştu.";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = userRepository.IsUserRegistered(user.Email) ? "Daha önceden bu mail adresiyle kayıt yapılmış." : "Kayıt işlemi yapılırken hata oluştu.";
            }
            return View();
        }

        public IActionResult Confirm()
        {
            ViewBag.Message = "Email adresinize doğrulama linki gönderildi.";
            return View();
        }

        public IActionResult RegisterConfirm(int id)
        {
            userRepository.ConfirmUser(id);
            return View();
        }

        public IActionResult Login()
        {
            if (Request.Cookies["email"] != null)
            {
                UserVM userVM = new UserVM();
                userVM.Email = Request.Cookies["email"];
                userVM.IsRemember = true;
                return View(userVM);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserVM loginUser)
        {
            try
            {
                User user = userRepository.Login(loginUser.Email);
                if (user != null)
                {
                    bool emailCheck = emailService.SendEmail(user.Email, user.UserID, UserTypeEnum.Login);
                    if (emailCheck)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Mail gönderilemedi";
                    }
                }
                else
                {
                    ViewBag.Message = "Giriş yapılamadı.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }

        public IActionResult LoginConfirm(int id, UserVM loginUser)
        {
            User user = userRepository.GetUserById(id);
            HttpContext.Session.SetString("email", user.Email);
            HttpContext.Session.SetString("userName", user.UserName);
            HttpContext.Session.SetInt32("loginId", user.UserID);
            HttpContext.Session.SetString("image", user.PhotoName);
            if (loginUser.IsRemember)
            {
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Append("email", loginUser.Email, cookieOptions);
            }
            return RedirectToAction("Index", "User");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("email");
            HttpContext.Session.Remove("userName");
            HttpContext.Session.Remove("loginId");
            HttpContext.Session.Remove("image");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Settings()
        {
            int currentUserId = (int)HttpContext.Session.GetInt32("loginId");
            User currentUser = userRepository.GetUserById(currentUserId);
            return View(currentUser);
        }

        public IActionResult UpdateUser(User loginUser)
        {
            bool check = userRepository.Update(loginUser);
            HttpContext.Session.SetString("userName", loginUser.UserName);
            if (check)
            {
                return Json("ok");
            }
            else
            {
                return Json("fail");
            }
        }

        public IActionResult DeleteUser(int id)
        {
            bool check = userRepository.Delete(id);
            if (check)
            {
                return Json(new { result = "Redirect", url = Url.Action("Logout", "User") });
            }
            else
            {
                return Json("fail");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            int currentUserId = (int)HttpContext.Session.GetInt32("loginId");
            string currentUserName = HttpContext.Session.GetString("userName");
            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);
                string imageName = $"{currentUserName}{currentUserId}" + DateTime.Now.ToString("yyyyMMddhhmm") + imageExtension;
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Images/{imageName}");
                using var stream = new FileStream(path, FileMode.Create, FileAccess.Write);
                await file.CopyToAsync(stream);
                userRepository.AddUpdateImage(imageName, currentUserId);
                HttpContext.Session.SetString("image", imageName);
            }
            return RedirectToAction("Settings", "User");
        }

        public IActionResult AddTopicForUser()
        {
            ViewBag.Topics = topicRepository.GetAllTopics();
            return View();
        }

        [HttpPost]
        public IActionResult AddTopicForUser(int[] ids)
        {
            int userId = (int)HttpContext.Session.GetInt32("loginId");
            topicRepository.AddTopicsToUser(userId, ids);
            return Json(new { redirectToUrl = Url.Action("Index", "User") });
        }

        public IActionResult UserDetails(int id)
        {
            User user = userRepository.GetUserById(id);
            return View(user);
        }
    }
}
