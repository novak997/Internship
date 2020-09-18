using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                if (_userRepository.GetUserByEmail(user.Email) != null)
                {
                    throw new BusinessLayerException("Email taken");
                }
                if (_userRepository.GetUserByUsername(user.Username) != null)
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
                User userCheckEmail = _userRepository.GetUserByEmail(user.Email);
                if (userCheckEmail.Name != null && userCheckEmail.ID != user.ID)
                {
                    throw new BusinessLayerException("Email taken");
                }
                User userCheckUsername = _userRepository.GetUserByUsername(user.Username);
                if (userCheckUsername.Name != null && userCheckUsername.ID != user.ID)
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
                User user = _userRepository.GetUserById(id);
                PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
                bool verified = false;
                var result = passwordHasher.VerifyHashedPassword(user, user.Password, oldPassword);
                if (result == PasswordVerificationResult.Success)
                {
                    verified = true;
                }    
                if (!verified)
                {
                    throw new BusinessLayerException("Invalid old password");
                }
                if (newPassword != newPasswordConfirm)
                {
                    throw new BusinessLayerException("Passwords do not match");
                }
                string hashedNewPassword = passwordHasher.HashPassword(user, newPassword);
                _userRepository.ChangePassword(hashedNewPassword, id);
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
                User user = _userRepository.GetUserById(id);
                PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
                string hashedPassword = passwordHasher.HashPassword(user, password);
                _userRepository.ChangePassword(hashedPassword, id);
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

        public User Login(string email, string password)
        {
            try
            {
                User user = _userRepository.GetUserByEmail(email);
                if (user.Username == null)
                {
                    throw new BusinessLayerException("No such user exists");
                }
                PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
                bool verified = false;
                var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);
                if (result == PasswordVerificationResult.Success)
                {
                    verified = true;
                }
                if (!verified)
                {
                    throw new BusinessLayerException("Incorrect password");
                }
                return user;
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
        }
    }
}
