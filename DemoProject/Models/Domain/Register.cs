using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models.Domain
{
    public class Register
    {
        [Display(Prompt = "Enter name")]
        [Required(ErrorMessage = "The name is required"), MinLength(4, ErrorMessage = "name contain atleast 4 characters")]
        public string Name { get; set; } = null!;
        [Required]
        [Key]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string? Mobile { get; set; }
        [Required(ErrorMessage = "Please enter password"), MinLength(6, ErrorMessage = "Password contain atleast 6 characters")]
        public string? Password { get; set; }
    }
}
