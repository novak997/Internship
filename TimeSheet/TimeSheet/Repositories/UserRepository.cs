using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Context;

namespace TimeSheet.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;
        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Database.ExecuteSqlRaw("exec uspAddUser {0}, {1}, {2}, {3}, {4}, {5}", user.Name,
                user.Weekly, user.Username, user.Email, user.IsActive, user.IsAdmin);
        }

        public void ChangePassword(string password, int id)
        {
            _context.Database.ExecuteSqlRaw("exec uspChangePassword {0}, {1}", password, id);
        }

        public void DeleteUserLogically(int id)
        {
            _context.Database.ExecuteSqlRaw("exec uspDeleteUserLogically {0}", id);
        }

        public void DeleteUserPhysically(int id)
        {
            _context.Database.ExecuteSqlRaw("exec uspDeleteUserPhysically {0}", id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.FromSqlRaw("exec uspGetAllUsers").ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FromSqlRaw("exec uspGetUserById {0}", id).FirstOrDefault();
        }

        public void UpdateUser(User user)
        {
            _context.Database.ExecuteSqlRaw("exec uspUpdateUser {0}, {1}, {2}, {3}, {4}, {5}, {6}", 
                user.Name, user.Weekly, user.Username, user.Email, user.IsActive, user.IsAdmin, user.ID);
        }
    }
}
