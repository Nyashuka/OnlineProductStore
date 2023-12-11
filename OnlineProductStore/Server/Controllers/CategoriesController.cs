using Microsoft.AspNetCore.Mvc;
using OnlineProductStore.Server.Services.Categories;
using OnlineProductStore.Server.Services.Products;
using OnlineProductStore.Shared.DTO;

namespace OnlineProductStore.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_categoriesService.GetAllCategories());
        }

        [HttpPost("add-new")]
        public IActionResult AddNewCategory(CategoryDTO category)
        {
            _categoriesService.TryAddCategory(category);

            return Ok();
        }
    }
}
