using Microsoft.AspNetCore.Mvc;
using OnlineProductStore.Server.Services.Products;
using OnlineProductStore.Shared.DTO;
using OnlineProductStore.Shared.Models;

namespace OnlineProductStore.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_productsService.GetAllProducts());
        }

        [HttpPost("add-new")]
        public IActionResult AddNewProduct(ProductDTO product)
        {
            _productsService.TryAddProduct(product);

            return Ok();
        }
    }
}
