using System.ComponentModel.DataAnnotations;

namespace StoreHub.Model
{
    public class Product
    {
        public int id { get; set; }
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public int Quantity { get; set; }

        // Foriegen Key For Category
        public int? CategoryId { get; set; }
    }
}
