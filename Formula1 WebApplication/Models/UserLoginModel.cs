using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Formula1_WebApplication.Models
{
    public class UserLoginModel
    {
        [Required]
        [StringLength(50), MinLength(2)]
        [DisplayName("Username")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

    }
}
