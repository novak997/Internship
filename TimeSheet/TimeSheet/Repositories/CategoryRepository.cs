using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Context;
using TimeSheet.Models;

namespace TimeSheet.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;
        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void AddCategory(Category category)
        {
            _context.Database.ExecuteSqlRaw("exec uspAddCategory {0}", category.Name);
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.FromSqlRaw("exec uspGetCategoryById {0}", id).FirstOrDefault();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.FromSqlRaw("exec uspGetAllCategories").ToList();
        }
    }
}
