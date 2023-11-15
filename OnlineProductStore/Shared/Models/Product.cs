using System.ComponentModel.DataAnnotations;

namespace OnlineProductStore.Shared.Models
{
    public class Product
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.Currency)]
        public required decimal OriginalPrice { get; set; }

        public int Quantity { get; set; }

        public string? Image { get; set; } 

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public DateTime UploadedTime { get; set; } = DateTime.Now;
    }
}
