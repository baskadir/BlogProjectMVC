using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract
{
    public interface ITopicRepository
    {
        List<Topic> GetAllTopics();
        List<Topic> GetTopicsByUser(int id);
        void AddTopicsToUser(int id, int[] ids);
        List<Article> GetArticlesForUserByTopics(int id);
        List<Article> GetArticlesByTopic(int topicId, int userId);
        List<string> GetTopicNameForArticle(int articleId);
        List<string> GetRandomTopics();
        int GetAllTopicsCount();
    }
}
