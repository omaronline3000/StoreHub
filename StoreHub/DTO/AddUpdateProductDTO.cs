using System.ComponentModel.DataAnnotations;

namespace StoreHub.DTO
{
    public class AddUpdateProductDTO
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "*")]
        [Range(0,12500)]
        public decimal Price { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage = "*")]
        [Range(0,500)]
        public int Quantity { get; set; }
    }
}
