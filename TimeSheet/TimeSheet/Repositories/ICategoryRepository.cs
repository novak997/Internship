using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.Repositories
{
    interface ICategoryRepository
    {
        public void AddCategory(Category category);
        public Category GetCategoryById(int id);
        public IEnumerable<Category> GetAllCategories();
        public Category GetCategoryByName(string name);
    }
}
