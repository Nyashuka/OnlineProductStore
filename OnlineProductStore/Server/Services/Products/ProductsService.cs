using OnlineProductStore.Server.Data;
using OnlineProductStore.Shared.DTO;
using OnlineProductStore.Shared.Models;
using System.Drawing;

namespace OnlineProductStore.Server.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly DataContext _dbContext;

        public ProductsService(DataContext worldDbContext) 
        { 
            _dbContext = worldDbContext;
        }

        public Product ConvertProductDTOToProductModel(ProductDTO productDTO)
        {
            return new Product()
            { 
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                OriginalPrice = productDTO.OriginalPrice,
                Quantity = productDTO.Quantity,
                Image = productDTO.Image,
                Category = productDTO.Category,
                CategoryId = productDTO.Category.Id,
                UploadedTime = productDTO.UploadedTime,
            };

        }


        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public async Task<bool> TryAddProduct(ProductDTO productDTO)
        {
            var newProduct = ConvertProductDTOToProductModel(productDTO);

            _dbContext.Products.Add(newProduct);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
