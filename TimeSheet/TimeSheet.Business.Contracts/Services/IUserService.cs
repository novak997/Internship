using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.DAL.Entities;

namespace TimeSheet.Business.Contracts.Services
{
    public interface IUserService
    {
        public string AddUser(User user);
        public IEnumerable<User> GetAllUsers();
        public User GetUserById(int id);
        public string UpdateUser(User user);
        public string DeleteUserLogically(int id);
        public string ResetPassword(string oldPassword, string newPassword, string newPasswordConfirm, int id);
        public string SetPassword(string password, int id);
        public User Login(string email, string password);
    }
}
