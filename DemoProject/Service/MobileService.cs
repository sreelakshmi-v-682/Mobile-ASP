using DemoProject.Data;
using DemoProject.Iservice;
using DemoProject.Models.Domain;

namespace DemoProject.Service
{
    public class MobileService 
        {
        private readonly MvcDbContext _context;
        public MobileService(MvcDbContext context)
        {
            _context = context;
        }

      

    }
}
