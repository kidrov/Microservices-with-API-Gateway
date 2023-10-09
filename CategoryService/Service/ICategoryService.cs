using System;
using System.Collections.Generic;
using Entities;

namespace Service
{
    public interface ICategoryService
    {
        Category CreateCategory(Category category);
        bool UpdateCategory(string categoryId, Category category);
        bool DeleteCategory(string categoryId);
        Category GetCategoryById(string categoryId);

        //List<Category> GetAllCategoriesByUserId(string userId);
    }
}
