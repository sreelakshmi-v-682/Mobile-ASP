using DemoProject.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Data
{
    public class MvcDbContext : DbContext
    {
        public MvcDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Register>Registers { get; set; }
        public DbSet<Mobile> mobiles { get; set; }

        
    }
}
