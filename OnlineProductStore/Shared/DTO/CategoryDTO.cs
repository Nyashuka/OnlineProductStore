
namespace OnlineProductStore.Shared.DTO
{
    public class CategoryDTO
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string? Icon { get; set; }

        public CategoryDTO()
        {
            Name = string.Empty;
            Url = string.Empty;
        }
    }
}
