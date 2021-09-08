using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Article
    {
        public Article()
        {
            ArticlesTopics = new HashSet<ArticlesTopic>();
            UsersFavsArticles = new HashSet<UsersFavsArticle>();
        }
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string ReadingTime { get; set; }
        public int UserID { get; set; }
        public int? CountClicked { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ArticlesTopic> ArticlesTopics { get; set; }
        public virtual ICollection<UsersFavsArticle> UsersFavsArticles { get; set; }
    }
}
