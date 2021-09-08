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
    public class TopicRepository : ITopicRepository
    {
        DbBlogContext context;
        public TopicRepository(DbBlogContext context)
        {
            this.context = context;
        }
        public List<Topic> GetAllTopics()
        {
            return context.Topics.ToList();
        }

        // Giriş yapan kullanıcının takip ettiği konular
        public List<Topic> GetTopicsByUser(int id)
        {
            return context.UsersTopics.Include(x => x.Topic).Include(x => x.User).Where(x => x.UserID == id).Select(x => x.Topic).ToList();
        }

        public void AddTopicsToUser(int id,int[] ids)
        {
            foreach (var item in ids)
            {
                UsersTopic usersTopic = new UsersTopic()
                {
                    UserID = id,
                    TopicID = item
                };
                context.UsersTopics.Add(usersTopic);
            }
            context.SaveChanges();
        }

        //Kullanıcının ilgilendiği konulardan oluşan makaleleri getirme
        public List<Article> GetArticlesForUserByTopics(int id)
        {
            List<Article> articles = new List<Article>();
            List<Topic> topics = GetTopicsByUser(id);

            foreach (var item in topics)
            {
                var articlesFound = context.ArticlesTopics.Include(x => x.Article).Where(x => x.Article.UserID != id && x.TopicID == item.TopicID).Select(x => x.Article).ToList();
                if (articlesFound != null)
                {
                    articles.AddRange(articlesFound);
                }
            }
            return articles.Distinct<Article>().ToList();
        }

        // Kullanıcının ilgilendiği konularla ilgili makaleleri konu ismine göre getirme
        public List<Article> GetArticlesByTopic(int topicId, int userId)
        {
            return context.ArticlesTopics.Include(x => x.Article).Where(x => x.Article.UserID != userId && x.TopicID == topicId).Select(x => x.Article).ToList();
        }

        // Makalenin alakalı olduğu konuları getirme
        public List<string> GetTopicNameForArticle(int articleId)
        {
            return context.ArticlesTopics.Include(x => x.Topic).Where(x => x.ArticleID == articleId).Select(x => x.Topic.TopicName).ToList();
        }

        public List<string> GetRandomTopics()
        {
            return context.Topics.OrderBy(x => Guid.NewGuid()).Take(5).Select(x => x.TopicName).ToList();
        }

        public int GetAllTopicsCount()
        {
            return context.Topics.Count();
        }
    }
}
