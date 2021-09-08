using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using MVCBlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlogProject.Services
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(string email, int userId, UserTypeEnum userType)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Blog", "denemeblog55@gmail.com"));
            message.To.Add(MailboxAddress.Parse(email));

            switch (userType)
            {
                case UserTypeEnum.Register:
                    message.Subject = "Hesap Aktivasyonu";
                    message.Body = new TextPart(TextFormat.Html)
                    {
                        Text = "<p>Hesabınızı aktifleştirmek için <a href=" + "https://localhost:44354/User/RegisterConfirm/" + userId + ">buraya</a> tıklayın.</p>"
                    };
                    break;
                case UserTypeEnum.Login:
                    message.Subject = "Giriş Doğrulama";
                    message.Body = new TextPart(TextFormat.Html)
                    {
                        Text = "<p>Giriş yapmak için <a href=" + "https://localhost:44354/User/LoginConfirm/" + userId + ">buraya</a> tıklayın.</p>"
                    };
                    break;
            }

            string fromEmail = "denemeblog55@gmail.com";
            string fromPassword = "deneme123";

            SmtpClient smtpClient = new SmtpClient();
            try
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                smtpClient.Authenticate(fromEmail, fromPassword);
                smtpClient.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }
        }
    }
}
