using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Repositories;

namespace TimeSheet.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository = new UserRepository();
        public string AddUser(User user)
        {
            if (_userRepository.GetUserByEmail(user.Email).Name != null)
            {
                return "Email taken";
            }
            if (_userRepository.GetUserByUsername(user.Username).Name != null)
            {
                return "Username taken";
            }
            _userRepository.AddUser(user);
            return "User successfully added";
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
        public string UpdateUser(User user)
        {
            if (_userRepository.GetUserByEmail(user.Email).Name != null)
            {
                return "Email taken";
            }
            if (_userRepository.GetUserByUsername(user.Username).Name != null)
            {
                return "Username taken";
            }
            _userRepository.UpdateUser(user);
            return "User successfully updated";
        }
        public string ResetPassword(string oldPassword, string newPassword, string newPasswordConfirm, int id)
        {
            if (_userRepository.GetUserById(id).Password != oldPassword)
            {
                return "Invalid old password";
            }
            if (newPassword != newPasswordConfirm)
            {
                return "Passwords do not match";
            }
            _userRepository.ChangePassword(newPassword, id);
            return "Password successfully changed";
        }
        public string SetPassword(string password, int id)
        {
            _userRepository.ChangePassword(password, id);
            return "Password successfully changed";
        }
        public string DeleteUserLogically(int id)
        {
            _userRepository.DeleteUserLogically(id);
            return "User successfully deleted";
        }
    }
}
