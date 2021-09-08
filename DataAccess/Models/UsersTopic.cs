using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UsersTopic
    {
        public int UserID { get; set; }
        public int TopicID { get; set; }

        public virtual Topic Topic { get; set; }
        public virtual User User { get; set; }
    }
}
