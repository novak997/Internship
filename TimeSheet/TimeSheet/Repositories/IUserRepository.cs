using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.Repositories
{
    interface IUserRepository
    {
        public void AddUser(User user);
        public IEnumerable<User> GetAllUsers();
        public User GetUserById(int id);
        public void UpdateUser(User user);
        public void ChangePassword(string password, int id);
        public void DeleteUserPhysically(int id);
        public void DeleteUserLogically(int id);
    }
}
