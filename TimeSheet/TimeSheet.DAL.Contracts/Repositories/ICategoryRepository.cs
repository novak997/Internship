using System.Collections.Generic;
using TimeSheet.DAL.Entities;

namespace TimeSheet.DAL.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        public int AddCategory(Category category);
        public Category GetCategoryById(int id);
        public IEnumerable<Category> GetAllCategories();
        public Category GetCategoryByName(string name);
    }
}
