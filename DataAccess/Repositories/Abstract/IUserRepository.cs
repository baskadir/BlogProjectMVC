using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract
{
    public interface IUserRepository
    {
        bool Register(User user);
        User Login(string email);
        bool Update(User user);
        bool Delete(int id);
        User GetUserById(int id);
        void ConfirmUser(int id);
        bool IsUserRegistered(string email);
        void AddUpdateImage(string path, int userId);
        int GetAllUsersCount();
    }
}
