using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Entities;
using MongoDB.Driver;

public class CategoryRepository : ICategoryRepository
{
    private readonly IMongoCollection<Category> _categories;

    public CategoryRepository(IMongoClient mongoClient, string databaseName)
    {
        var database = mongoClient.GetDatabase(databaseName);
        _categories = database.GetCollection<Category>("categories");
    }

    public Category CreateCategory(Category category)
    {
        _categories.InsertOne(category);
        return category;
    }

    public bool DeleteCategory(string categoryId)
    {
        var result = _categories.DeleteOne(c => c.CategoryId == categoryId);
        return result.DeletedCount > 0;
    }

    //public List<Category> GetAllCategoriesByUserId(string userId)
    //{
    //    return _categories.Find(c => c.UserId == userId).ToList();
    //}

    public Category GetCategoryById(string categoryId)
    {
        return _categories.Find(c => c.CategoryId == categoryId).FirstOrDefault();
    }

    public bool UpdateCategory(string categoryId, Category category)
    {
        var filter = Builders<Category>.Filter.Eq(c => c.CategoryId, categoryId);
        var update = Builders<Category>.Update
            .Set(c => c.CategoryName, category.CategoryName)
            .Set(c => c.CategoryDescription, category.CategoryDescription);

        var result = _categories.UpdateOne(filter, update);
        return result.ModifiedCount > 0;
    }
}
