using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController
    {
        private CategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }
        [HttpGet]
        public List<Category> GetCategorys()
        {
            return _categoryService.GetCategorys();
        }

        [HttpPost("Insert")]
        public int InsertCategory(Category category)
        {
            return _categoryService.InsertCategory(category);
        }

        [HttpPut]
        public int UpdateCategory(Category category)
        {
            return _categoryService.UpdateCategory(category);
        }

        [HttpDelete]
        public int DeleteCategory(int id)
        {
            return _categoryService.DeleteCategory(id);
        }
    }
}