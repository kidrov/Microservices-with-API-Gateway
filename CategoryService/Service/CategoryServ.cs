using System;
using System.Collections.Generic;
using DAL; 
using Entities;
using Exceptions;

namespace Service
{
    public class CategoryServ : ICategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryServ(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category CreateCategory(Category category)
        {
            // Business logic and validation (if needed)
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category cannot be null.");
            }

            // Call the MongoDB repository to create the category
            return _categoryRepository.CreateCategory(category);
        }

        public bool DeleteCategory(string categoryId)
        {
            // Check if the category exists
            var existingCategory = _categoryRepository.GetCategoryById(categoryId);
            if (existingCategory == null)
            {
                throw new CategoryNotFoundException($"Category with ID {categoryId} not found.");
            }

            // Call the MongoDB repository to delete the category
            return _categoryRepository.DeleteCategory(categoryId);
        }

        //public List<Category> GetAllCategoriesByUserId(string userId)
        //{
        //    // Call the MongoDB repository to get categories by user ID
        //    return _categoryRepository.GetAllCategoriesByUserId(userId);
        //}

        public Category GetCategoryById(string categoryId)
        {
            // Call the MongoDB repository to get the category by ID
            return _categoryRepository.GetCategoryById(categoryId);
        }

        public bool UpdateCategory(string categoryId, Category category)
        {
            // Check if the category exists
            var existingCategory = _categoryRepository.GetCategoryById(categoryId);
            if (existingCategory == null)
            {
                throw new CategoryNotFoundException($"Category with ID {categoryId} not found.");
            }

            // Update category properties
            existingCategory.CategoryName = category.CategoryName;
            existingCategory.CategoryDescription = category.CategoryDescription;

            // Call the MongoDB repository to update the category
            return _categoryRepository.UpdateCategory(categoryId, existingCategory);
        }
    }
}
