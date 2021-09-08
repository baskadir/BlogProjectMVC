using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ArticlesTopic
    {
        public int ArticleID { get; set; }
        public int TopicID { get; set; }

        public virtual Article Article { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
