using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;
using TimeSheet.Repositories;

namespace TimeSheet.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository = new CategoryRepository();
        public string AddCategory(Category category)
        {
            if (_categoryRepository.GetCategoryByName(category.Name).Name != null)
            {
                return "Category name taken";
            }
            _categoryRepository.AddCategory(category);
            return "Category successfully added";
        }
        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }
    }
}
