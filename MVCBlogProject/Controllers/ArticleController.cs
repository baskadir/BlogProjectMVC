using DataAccess.Models;
using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MVCBlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlogProject.Controllers
{
    public class ArticleController : Controller
    {
        IArticleRepository articleRepository;
        ITopicRepository topicRepository;
        IUserRepository userRepository;
        public ArticleController(IArticleRepository articleRepository, ITopicRepository topicRepository, IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.topicRepository = topicRepository;
            this.articleRepository = articleRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddArticle()
        {
            ViewBag.Topics = topicRepository.GetAllTopics();
            return View();
        }

        [HttpPost]
        public IActionResult AddArticle(Article newArticle, int[] ids)
        {
            int userId = (int)HttpContext.Session.GetInt32("loginId");
            Article article = new Article()
            {
                Title = newArticle.Title,
                Content = newArticle.Content,
                CreatedTime = DateTime.Now,
                UserID = userId,
                //ReadingTime = newArticle.ReadingTime,
            };
            articleRepository.AddArticle(article, ids);
            return Json(new { redirectToUrl = Url.Action("Index", "User") });
        }

        public IActionResult UserArticles()
        {
            int userId = (int)HttpContext.Session.GetInt32("loginId");
            List<Article> articles = articleRepository.GetArticlesByUser(userId);
            return View(articles);
        }

        public IActionResult UserArticlesPartial(int id)
        {
            List<ArticleVM> articles = new List<ArticleVM>();
            ArticleVM article;
            foreach (var item in articleRepository.GetArticlesByUser(id))
            {
                article = new ArticleVM()
                {
                    ArticleId = item.ArticleID,
                    Title = item.Title,
                    Content = item.Content,
                    UserId = item.UserID,
                    CreatedDate = (DateTime)item.CreatedTime
                };
                articles.Add(article);
            }
            return PartialView("_userArticleListPartial", articles.OrderByDescending(x => x.CreatedDate).ToList());
        }

        public IActionResult GetArticle(int id)
        {
            Article article = articleRepository.GetArticle(id);
            return View(article);
        }

        public IActionResult UpdateArticle(Article article)
        {
            bool check = articleRepository.UpdateArticle(article);
            if (check)
            {
                return Json("ok");
            }
            else
            {
                return Json("fail");
            }
        }

        public IActionResult DeleteArticle(int id)
        {
            bool check = articleRepository.DeleteArticle(id);
            if (check)
            {
                return Json(new { result = "Redirect", url = Url.Action("UserArticles", "Article") });
            }
            else
            {
                return Json("fail");
            }
        }

        public IActionResult ArticleDetails(int id)
        {
            Article selectedArticle = articleRepository.GetArticle(id);
            ArticleVM articleVM = new ArticleVM()
            {
                ArticleId = selectedArticle.ArticleID,
                Title = selectedArticle.Title,
                Content = selectedArticle.Content,
                ReadingTime = selectedArticle.ReadingTime,
                CreatedDate = (DateTime)selectedArticle.CreatedTime,
                UserId = selectedArticle.UserID
            };

            articleRepository.CountClickedForArticle(id);

            User user = userRepository.GetUserById(articleVM.UserId);
            ViewBag.UserName = user.UserName;
            ViewBag.UserImage = user.PhotoName;
            ViewBag.TopicList = topicRepository.GetTopicNameForArticle(id);

            return View(articleVM);
        }

        public IActionResult LikeArticle(int id)
        {
            int userId = (int)HttpContext.Session.GetInt32("loginId");
            articleRepository.AddArticleToFavourites(id, userId);
            return Json("ok");
        }

        public IActionResult LikedArticlesForUser(int id)
        {
            List<Article> likedArticles = articleRepository.GetFavouriteArticlesForUser(id);
            List<ArticleVM> articles = new List<ArticleVM>();
            foreach (var item in likedArticles)
            {
                ArticleVM articleVM = new ArticleVM()
                {
                    ArticleId = item.ArticleID,
                    Title = item.Title,
                    CreatedDate = (DateTime)item.CreatedTime,
                    UserName = userRepository.GetUserById(item.UserID).UserName,
                };
                articles.Add(articleVM);
            }
            return View(articles);
        }
    }
}
