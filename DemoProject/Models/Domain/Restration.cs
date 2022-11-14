using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models.Domain
{
    public class Restration
    {
        public string Name { get; set; }
        [Required]
        [Key]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
    }
}
