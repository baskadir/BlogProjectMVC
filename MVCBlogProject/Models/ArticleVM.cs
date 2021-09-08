using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlogProject.Models
{
    public class ArticleVM
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string SubTitle
        {
            get
            {
                int index = Content.IndexOf("."); 
                return Content.Substring(0, index);
            }
        }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }

        private string _readingTime;
        public string ReadingTime
        {
            get
            {
                // 400 karakter = 1 dakika olacak şekilde 
                if (Content.Length>400)
                {
                    return ReadingTime = $"{(Content.Length / 400)} dakika";
                }
                return ReadingTime = $"1 dakika";
            }
            set
            {
                this._readingTime = value;
            }
        }
        public string UserName { get; set; } //makaleyi yazan kişinin kullanıcı adı 
        public string ImageName { get; set; } // makaleyi yazan kişinin fotoğrafı
    }
}
