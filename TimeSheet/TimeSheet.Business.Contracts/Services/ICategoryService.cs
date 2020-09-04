using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.DAL.Entities;

namespace TimeSheet.Business.Contracts.Services
{
    public interface ICategoryService
    {
        public string AddCategory(Category category);
        public Category GetCategoryById(int id);
        public IEnumerable<Category> GetAllCategories();
    }
}
