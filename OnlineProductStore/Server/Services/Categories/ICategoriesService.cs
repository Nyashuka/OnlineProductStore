using OnlineProductStore.Shared.DTO;
using OnlineProductStore.Shared.Models;

namespace OnlineProductStore.Server.Services.Categories
{
    public interface ICategoriesService
    {
        List<Category> GetAllCategories();
        Task<bool> TryAddCategory(CategoryDTO category);
    }
}
