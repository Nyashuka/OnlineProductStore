using OnlineProductStore.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineProductStore.Shared.DTO
{
    public class ProductDTO
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.Currency)]
        public required decimal OriginalPrice { get; set; }

        public int Quantity { get; set; }

        public string? Image { get; set; }

        public Category Category { get; set; }

        public DateTime UploadedTime { get; set; } = DateTime.Now;
    }
}
