using OnlineProductStore.Server.Data;
using OnlineProductStore.Shared.DTO;
using OnlineProductStore.Shared.Models;

namespace OnlineProductStore.Server.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly DataContext _dbContext;

        public CategoriesService(DataContext worldDbContext)
        {
            _dbContext = worldDbContext;
        }

        public Category ConvertCategoryDTOToCategoryModel(CategoryDTO categoryDTO)
        {
            return new Category()
            {
               Name = categoryDTO.Name,
               Url = categoryDTO.Url,
               Icon = categoryDTO.Icon
            };

        }

        public List<Category> GetAllCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public async Task<bool> TryAddCategory(CategoryDTO productDTO)
        {
            var newCategory = ConvertCategoryDTOToCategoryModel(productDTO);

            _dbContext.Categories.Add(newCategory);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
