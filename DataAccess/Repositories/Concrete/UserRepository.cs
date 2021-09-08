using DataAccess.Context;
using DataAccess.Models;
using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        DbBlogContext context;
        public UserRepository(DbBlogContext context)
        {
            this.context = context;
        }
        public User GetUserById(int id)
        {
            return context.Users.Find(id);
        }

        private bool IsUserActive(string email)
        {
            return context.Users.Where(x => x.Email == email && x.IsActive).FirstOrDefault() != null;
        }

        public User Login(string email)
        {
            if (!IsUserRegistered(email))
            {
                throw new Exception("Kayıtlı değilsiniz. Kayıt ol sekmesinden kayıt olabilirsiniz.");
            }
            else if (!IsUserActive(email)) 
            {
                throw new Exception("Mail adresiniz aktif değil. Mail adresinize gelen doğrulama linkine tıklayarak aktif edebilirsiniz.");
            }
            return context.Users.SingleOrDefault(a => a.Email == email);
        }
        public bool IsUserRegistered(string email)
        {
            if (context.Users.Any(x=>x.Email == email))
            {
                return true;
            }
            return false;
        }
        public bool Register(User user)
        {
            if (!IsUserRegistered(user.Email))
            {
                user.IsActive = false;
                context.Users.Add(user);
                return context.SaveChanges() > 0;
            }
            return false;
        }

        public bool Update(User user)
        {
            User updatedUser = GetUserById(user.UserID);
            if (updatedUser != null)
            {
                updatedUser.FullName = user.FullName;
                updatedUser.UserName = user.UserName;
                updatedUser.Email = user.Email;
                updatedUser.Description = user.Description;
                if (updatedUser.FullName != null && updatedUser.UserName != null && updatedUser.Email.Contains("@") && updatedUser.Email.EndsWith(".com"))
                {
                    return context.SaveChanges() > 0;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            context.Users.Remove(GetUserById(id));
            return context.SaveChanges() > 0;
        }

        public void AddUpdateImage(string imageName,int userId)
        {
            User user = GetUserById(userId);
            user.PhotoName = imageName;
            context.SaveChanges();
        }

        public void ConfirmUser(int id)
        {
            User confirmedUser = GetUserById(id);
            confirmedUser.IsActive = true;
            context.SaveChanges();
        }

        public int GetAllUsersCount()
        {
            return context.Users.Count(x=>x.IsActive);
        }
    }
}
