using DemoProject.Data;
using DemoProject.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    public class RegisterController : Controller
    {
        private readonly MvcDbContext mvcCon;
        public RegisterController(MvcDbContext mvcCon)
        {
            this.mvcCon = mvcCon;
        }
       
        [HttpGet]
        public IActionResult Add()
        {
            
            Register register = new Register(); 
            return View(register);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Register reg)
        {
          
            if (ModelState.IsValid)
            {
                Register register = new Register()

                {
                    Name = reg.Name,
                    Email = reg.Email,
                    Mobile = reg.Mobile,
                    Password = reg.Password,
                };

                await mvcCon.Registers.AddRangeAsync(register);
                await mvcCon.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View("Add");
            
        }
        [HttpGet]
        public IActionResult Login()

        {
           
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            
            Register register = new Register()
            {
                Email=login.Email,
                Password=login.Password,

            };
            HttpContext.Session.SetString("hii", register.Email);
            Register register1 = mvcCon.Registers.Where(obj=>obj.Email == register.Email && obj.Password ==register.Password  ).FirstOrDefault();
            if (register1 != null)
            {
                return RedirectToAction("Index2","Home", "~/ Views / Shared / _Layout2.cshtml");
            }
            else

            {
                if(login.Email=="admin@gmail.com" && login.Password == "1234")
                {
                    return RedirectToAction("Lists", "Home");
                }
                else
                {
                    return Content("error");
                }
             
            }
        }
    }
}
