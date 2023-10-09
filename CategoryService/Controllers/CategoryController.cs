using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace KeepNote.Controllers
{
    [ApiController]
    [Route("api/category")] // Base route for CategoryController
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            // Call the CategoryService to create a category
            var createdCategory = _categoryService.CreateCategory(category);
            return Created("", createdCategory); // 201 Created
        }

        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory(string categoryId)
        {
            // Call the CategoryService to delete a category
            var result = _categoryService.DeleteCategory(categoryId);
            if (result)
            {
                return Ok(); // 200 OK
            }
            return NotFound(); // 404 Not Found
        }

        [HttpPut("{categoryId}")]
        public IActionResult UpdateCategory(string categoryId, Category category)
        {
            // Call the CategoryService to update a category
            var result = _categoryService.UpdateCategory(categoryId, category);
            if (result)
            {
                return Ok(); // 200 OK
            }
            return NotFound(); // 404 Not Found
        }

        //[HttpGet("{userId}")]
        ////public IActionResult GetCategoriesByUserId(string userId)
        ////{
        ////    // Call the CategoryService to get categories by user ID
        ////    var categories = _categoryService.GetAllCategoriesByUserId(userId);
        ////    return Ok(categories); // 200 OK
        ////}
    }
}

