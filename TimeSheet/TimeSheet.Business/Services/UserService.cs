using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.Business.Exceptions;
using TimeSheet.DAL.Contracts.Repositories;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Exceptions;
using TimeSheet.DAL.SQLClient.Repositories;

namespace TimeSheet.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public string AddUser(User user)
        {
            try
            {
                if (user.Name == "" || user.Name == null || user.Email == "" || user.Email == null || user.Username == "" || user.Username == null)
                {
                    throw new BusinessLayerException("Name, username and email cannot be empty");
                }
                if (_userRepository.GetUserByEmail(user.Email).Name != null)
                {
                    throw new BusinessLayerException("Email taken");
                }
                if (_userRepository.GetUserByUsername(user.Username).Name != null)
                {
                    throw new BusinessLayerException("Username taken");
                }
                _userRepository.AddUser(user);
                return "User successfully added";
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return _userRepository.GetAllUsers();
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public User GetUserById(int id)
        {
            try
            {
                return _userRepository.GetUserById(id);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public string UpdateUser(User user)
        {
            try
            {
                if (_userRepository.GetUserByEmail(user.Email).Name != null)
                {
                    throw new BusinessLayerException("Email taken");
                }
                if (_userRepository.GetUserByUsername(user.Username).Name != null)
                {
                    throw new BusinessLayerException("Username taken");
                }
                _userRepository.UpdateUser(user);
                return "User successfully updated";
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public string ResetPassword(string oldPassword, string newPassword, string newPasswordConfirm, int id)
        {
            try
            {
                if (_userRepository.GetUserById(id).Password != oldPassword)
                {
                    throw new BusinessLayerException("Invalid old password");
                }
                if (newPassword != newPasswordConfirm)
                {
                    throw new BusinessLayerException("Passwords do not match");
                }
                _userRepository.ChangePassword(newPassword, id);
                return "Password successfully changed";
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public string SetPassword(string password, int id)
        {
            try
            {
                _userRepository.ChangePassword(password, id);
                return "Password successfully changed";
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
        public string DeleteUserLogically(int id)
        {
            try
            {
                _userRepository.DeleteUserLogically(id);
                return "User successfully deleted";
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
            
        }
    }
}
