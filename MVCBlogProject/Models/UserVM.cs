using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlogProject.Models
{
    public class UserVM
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string FullName 
        {
            get
            {
                int index = Email.IndexOf('@');
                return Email.Substring(0, index);
            }
        }

        public string UserName
        {
            get
            {
                int index = Email.IndexOf('@');
                return Email.Substring(0, index);
            }
        }
        public bool IsRemember { get; set; }
        public string PhotoPath
        {
            get
            {
                return "default.png";
            }
        }
    }
}
