using DemoProject.Data;

using DemoProject.Models;
using DemoProject.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace DemoProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;



        private readonly MvcDbContext context;



        /* MvcDbContext dbContext = new MvcDbContext();*/
        public HomeController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, MvcDbContext context)
        {
            this.context = context;
            this.hostingEnvironment = hostingEnvironment;


        }


      

        [Route("")]
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult Index2()
        {
            IEnumerable<Mobile> mobileDetails = context.mobiles.ToList();
            ViewBag.sessionv = HttpContext.Session.GetString("hii");
            ViewData["message"] = "error page";
            return View(mobileDetails);
        }



        public IActionResult Lists()
        {
            var list = context.mobiles.ToList();
            return View(list);
        }



        
        [HttpGet]
        public IActionResult AddMobile()
        {
            MobileCreate mobile = new MobileCreate();
            return View(mobile);
        }

        [HttpPost]
        
        public IActionResult AddMobile(MobileCreate mobile)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                if (mobile.Photo != null)
                {
                    string folderName = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    fileName = Guid.NewGuid().ToString() + "_" + mobile.Photo.FileName;
                    string filePath = Path.Combine(folderName, fileName);
                    mobile.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Mobile mob = new Mobile()
                {
                    MobileName = mobile.MobileName,
                    Catogery = mobile.Catogery,
                    Price = mobile.Price,
                    Photopath = fileName
                };
                context.mobiles.Add(mob);
                context.SaveChanges();
                return RedirectToAction("Index", Lists);
            }
            return View();
        }






        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            if(id == null || context.mobiles == null)
            {
                return NotFound();
            }
            Mobile mob = context.mobiles.Find(id);
            if(mob == null)
            {
                return NotFound();
            }
            return View(mob);
        }
        [HttpPost]
        public ActionResult Edit(Guid? id,Mobile Model)
        {
           if(id != Model.MobileId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(Model);
                    context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobileExists(Model.MobileId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));

            }
            return View(Model);     
        }

        private bool MobileExists(Guid mobileId)
        {
            throw new NotImplementedException();
        }






        public ActionResult Details(Guid id)
        {
            var data = context.mobiles.Where(x => x.MobileId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(Guid id)
        {
            var data = context.mobiles.Where(x => x.MobileId == id).FirstOrDefault();
            context.mobiles.Remove(data);
            context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }



        public JsonResult Search(string mobileName)
        {
           
            if (mobileName == null)
            {
                mobileName = "";
            }
            try
            {
                    IEnumerable<Mobile> mobiles = context.mobiles.Where(a => a.MobileName.StartsWith(mobileName)).ToList();
                    return Json(mobiles);
                
            }
            catch
            {
                return Json(null);
            }
        }



























































        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}


        
        /* [HttpPost]
         public string SaveFile(FileUpload fileobj)
         {
             Mobile oMobile = JsonConvert.DeserializeObject<Mobile>(fileobj.Mobile);
             if (fileobj.file.Length > 0)
             {
                 using (var ms = new MemoryStream())
                 {
                     fileobj.file.CopyTo(ms);
                     var fileBytes=ms.ToArray();
                     oMobile.Photopath = fileBytes;
                     oMobile = _mobileservice.Save(oMobile);
                     if (oMobile.MobileId > 0)
                     {
                         return "saved";
                     }
                 }
             }
             return "failed";
         }
         [HttpGet]
         public JsonResult GetSavedMobile()
         {
             var mobile = _mobileservice.GetSavedMobile();
             mobile.Photo = this.GetImage(Convert.ToBase64String(mobile.Photo));
             return Json(mobile);
         }
         public byte[] GetImage(string sBase64String)
         {
             byte[] bytes = null;
             if (!string.IsNullOrEmpty(sBase64String))
             {
                 bytes=Convert.FromBase64String(sBase64String);
             }
             return bytes;
         }
     } */
    
