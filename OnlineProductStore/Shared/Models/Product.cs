using System.ComponentModel.DataAnnotations;

namespace OnlineProductStore.Shared.Models
{
    public class Product
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [DataType(DataType.Currency)]
        public required string PriceWithDiscount { get; set; }

        public int Quantity { get; set; }

        public string? Image { get; set; } 

        public DateTime UploadedTime { get; set; } = DateTime.Now;
    }
}
