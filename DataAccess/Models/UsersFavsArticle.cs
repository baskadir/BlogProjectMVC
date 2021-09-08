using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UsersFavsArticle
    {
        public int UserID { get; set; }
        public int ArticleID { get; set; }

        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
    }
}
