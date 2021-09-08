using DataAccess.Context;
using DataAccess.Models;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class ArticleRepository : IArticleRepository
    {
        DbBlogContext context;
        public ArticleRepository(DbBlogContext context)
        {
            this.context = context;
        }

        public Article GetArticle(int articleId)
        {
            return context.Articles.Find(articleId);
        }

        public List<Article> GetArticles()
        {
            return context.Articles.ToList();
        }

        public List<Article> GetArticlesByUser(int userId)
        {
            return context.Articles.Where(x => x.UserID == userId).ToList();
        }

        public void AddArticle(Article article, int[] ids)
        {
            context.Articles.Add(article);
            context.SaveChanges();
            AddTopicsForArticle(article.ArticleID, ids);
        }

        private void AddTopicsForArticle(int id, int[] ids)
        {
            foreach (var item in ids)
            {
                ArticlesTopic articlesTopic = new ArticlesTopic()
                {
                    ArticleID = id,
                    TopicID = item
                };
                context.ArticlesTopics.Add(articlesTopic);
            }
            context.SaveChanges();
        }

        public bool DeleteArticle(int articleId)
        {
            context.Articles.Remove(GetArticle(articleId));
            return context.SaveChanges() > 0;
        }

        public bool UpdateArticle(Article article)
        {
            Article oldArticle = GetArticle(article.ArticleID);
            if (oldArticle != null)
            {
                oldArticle.Content = article.Content;
                oldArticle.CreatedTime = DateTime.Now;
                oldArticle.Title = article.Title;
                return context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
        }
        public List<Article> GetRandomArticles()
        {
            return context.Articles.OrderBy(a => Guid.NewGuid()).Take(8).ToList();
        }

        public List<Article> GetTrendArticles() 
        {
            return context.Articles.OrderByDescending(x => x.CountClicked).Take(6).ToList();
        }

        public void CountClickedForArticle(int id)
        {
            Article article = GetArticle(id);
            article.CountClicked += 1;
            context.SaveChanges();
        }

        public int GetAllArticlesCount()
        {
            return context.Articles.Count();
        }

        public void AddArticleToFavourites(int articleId, int userId)
        {
            if (!context.UsersFavsArticles.Any(x=>x.ArticleID == articleId))
            {
                UsersFavsArticle usersLikedArticle = new UsersFavsArticle()
                {
                    UserID = userId,
                    ArticleID = articleId
                };
                context.UsersFavsArticles.Add(usersLikedArticle);
                context.SaveChanges();
            }
        }

        //Kullanıcının beğendiği makalelerin listesi
        public List<Article> GetFavouriteArticlesForUser(int userId)
        {
            return context.UsersFavsArticles.Include(x => x.Article).Where(x => x.UserID == userId).Select(x => x.Article).ToList();
        }
    }
}
