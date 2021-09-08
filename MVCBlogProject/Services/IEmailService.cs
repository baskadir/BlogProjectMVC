using MVCBlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlogProject.Services
{
    public interface IEmailService
    {
        bool SendEmail(string email, int userId, UserTypeEnum userType);
    }
}
