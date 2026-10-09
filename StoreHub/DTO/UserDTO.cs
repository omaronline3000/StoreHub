using System.ComponentModel.DataAnnotations;

namespace StoreHub.DTO
{
    public class UserDTO
    {
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
         
    }
}
