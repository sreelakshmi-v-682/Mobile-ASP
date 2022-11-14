using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models.Domain
{
    public class Login
    {
        [Required]
        [Key]
        public string Email { get; set; }
       
        public string Password { get; set; }
    }
}
