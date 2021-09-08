using DataAccess.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using MVCBlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlogProject.Controllers
{
    public class HomeController : Controller
    {
        IArticleRepository articleRepository;
        IUserRepository userRepository;
        ITopicRepository topicRepository;
        public HomeController(IArticleRepository articleRepository, IUserRepository userRepository, ITopicRepository topicRepository)
        {
            this.topicRepository = topicRepository;
            this.articleRepository = articleRepository;
            this.userRepository = userRepository;
        }
        public IActionResult Index()
        {
            List<ArticleVM> articles = new List<ArticleVM>();
            foreach (var item in articleRepository.GetRandomArticles())
            {
                ArticleVM article = new ArticleVM()
                {
                    ArticleId = item.ArticleID,
                    Title = item.Title,
                    Content = item.Content,
                    CreatedDate = (DateTime)item.CreatedTime,
                    UserId = item.UserID,
                    UserName = userRepository.GetUserById(item.UserID).UserName,
                    ImageName = userRepository.GetUserById(item.UserID).PhotoName
                };
                articles.Add(article);
            }
            ViewBag.TopicNames = topicRepository.GetRandomTopics();
            return View(articles);
        }

        public IActionResult GetTrendArticlesPartial()
        {
            List<ArticleVM> articles = new List<ArticleVM>();
            foreach (var item in articleRepository.GetTrendArticles())
            {
                ArticleVM article = new ArticleVM()
                {
                    ArticleId = item.ArticleID,
                    Title = item.Title,
                    Content = item.Content,
                    CreatedDate = (DateTime)item.CreatedTime,
                    UserId = item.UserID,
                    UserName = userRepository.GetUserById(item.UserID).UserName,
                    ImageName = userRepository.GetUserById(item.UserID).PhotoName
                };
                articles.Add(article);
            }
            return PartialView("_mostReadArticlesPartial", articles);
        }

        public IActionResult About()
        {
            ViewBag.ArticlesCount = articleRepository.GetAllArticlesCount();
            ViewBag.UsersCount = userRepository.GetAllUsersCount();
            ViewBag.TopicsCount = topicRepository.GetAllTopicsCount();
            return View();
        }
    }
}
