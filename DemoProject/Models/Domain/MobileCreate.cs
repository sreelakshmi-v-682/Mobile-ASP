using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models.Domain
{
    public class MobileCreate 
    {
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters ")]
        public string MobileName { get; set; }

        public string Catogery { get; set; }
        public int Price { get; set; }

        public IFormFile Photo { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
