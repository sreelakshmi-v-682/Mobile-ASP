using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.Models.Domain
{
    public class Mobile 
    {
        [Required]
        [Key]
        /*[DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/

        public Guid MobileId { get; set; } 
        
        public string MobileName { get; set; }

        public string Catogery { get; set; }
        public int Price { get; set; }

        public string Photopath { get; set; }
       
    }
}
