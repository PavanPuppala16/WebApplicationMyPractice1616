using Microsoft.AspNetCore.Mvc;
using WebApplicationMyPractice1616.Business_logic;
using WebApplicationMyPractice1616.Models;

namespace WebApplicationMyPractice1616.Controllers
{
    public class MyPractceController : Controller
    {
        [HttpGet]
        
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(First obj)
        {
           
            if (ModelState.IsValid)
            {
                bool res = Logic.InsertData(obj);
                if(res=true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(obj);
                }

              
            }
            else
            {
                return View();
            }
        }
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
