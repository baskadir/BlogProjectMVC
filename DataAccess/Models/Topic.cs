using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Topic
    {
        public Topic()
        {
            ArticlesTopics = new HashSet<ArticlesTopic>();
            UsersTopics = new HashSet<UsersTopic>();
        }

        public int TopicID { get; set; }
        public string TopicName { get; set; }

        public virtual ICollection<ArticlesTopic> ArticlesTopics { get; set; }
        public virtual ICollection<UsersTopic> UsersTopics { get; set; }
    }
}
