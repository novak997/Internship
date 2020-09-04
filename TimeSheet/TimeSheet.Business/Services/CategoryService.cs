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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public string AddCategory(Category category)
        {
            try
            {
                if (category.Name == "" || category.Name == null)
                {
                    throw new BusinessLayerException("Category name cannot be empty");
                }
                if (_categoryRepository.GetCategoryByName(category.Name).Name != null)
                {
                    throw new BusinessLayerException("Category name taken");
                }
                //return _categoryRepository.AddCategory(category).ToString();
                return "Category successfully added";
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
        }
        public Category GetCategoryById(int id)
        {
            try
            {
                return _categoryRepository.GetCategoryById(id);
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
                return _categoryRepository.GetAllCategories();
            }
            catch (DatabaseException ex)
            {
                throw ex;
            }
        }
    }
}
