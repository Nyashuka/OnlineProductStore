using OnlineProductStore.Shared.DTO;
using OnlineProductStore.Shared.Models;

namespace OnlineProductStore.Server.Services.Products
{
    public interface IProductsService
    {
        public List<Product> GetAllProducts();

        public Task<bool> TryAddProduct(ProductDTO productDTO);
    }
}
