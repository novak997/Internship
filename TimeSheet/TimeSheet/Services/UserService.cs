using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Controllers.DTO;
using TimeSheet.Models;
using TimeSheet.Repositories;

namespace TimeSheet.Services
{
    public class UserService
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
        public string ResetPassword(ChangePasswordDTO changePasswordDTO)
        {
            if (_userRepository.GetUserById(changePasswordDTO.ID).Password != changePasswordDTO.OldPassword)
            {
                return "Invalid old password";
            }
            if (changePasswordDTO.NewPassword != changePasswordDTO.NewPasswordConfirm)
            {
                return "Passwords do not match";
            }
            _userRepository.ChangePassword(changePasswordDTO.NewPassword, changePasswordDTO.ID);
            return "Password successfully changed";
        }
        public string SetPassword(SetPasswordDTO setPasswordDTO)
        {
            _userRepository.ChangePassword(setPasswordDTO.Password, setPasswordDTO.ID);
            return "Password successfully changed";
        }
        public string DeleteUserLogically(int id)
        {
            _userRepository.DeleteUserLogically(id);
            return "User successfully deleted";
        }
    }
}
