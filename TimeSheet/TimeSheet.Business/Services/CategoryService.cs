using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Business.Contracts.Services;
using TimeSheet.DAL.Entities;
using TimeSheet.DAL.SQLClient.Repositories;

namespace TimeSheet.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _categoryRepository = new CategoryRepository();
        public string AddCategory(Category category)
        {
            if (category.Name == "" || category.Name == null)
            {
                return "Category name cannot be empty";
            }
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
