using StoreHub.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public bool IsDeleted { get; set; }

        // Foriegen Key For Category
        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        public Category? category { get; set; }
    }
}
