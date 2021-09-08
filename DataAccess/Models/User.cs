using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class User
    {
        public User()
        {
            Articles = new HashSet<Article>();
            UsersFavsArticles = new HashSet<UsersFavsArticle>();
            UsersTopics = new HashSet<UsersTopic>();
        }

        public int UserID { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string PhotoName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<UsersFavsArticle> UsersFavsArticles { get; set; }
        public virtual ICollection<UsersTopic> UsersTopics { get; set; }
    }
}
