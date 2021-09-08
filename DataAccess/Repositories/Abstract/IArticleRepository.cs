using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract
{
    public interface IArticleRepository
    {
        List<Article> GetArticles();
        List<Article> GetArticlesByUser(int userId);
        void AddArticle(Article article, int[] ids);
        bool UpdateArticle(Article article);
        bool DeleteArticle(int articleId);
        Article GetArticle(int articleId);
        List<Article> GetRandomArticles();
        List<Article> GetTrendArticles();
        void CountClickedForArticle(int id);
        int GetAllArticlesCount();
        void AddArticleToFavourites(int articleId, int userId);
        List<Article> GetFavouriteArticlesForUser(int userId);
    }
}
