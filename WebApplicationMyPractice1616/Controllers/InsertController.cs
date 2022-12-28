using Microsoft.AspNetCore.Mvc;
using WebApplicationMyPractice1616.Business_logic;
using WebApplicationMyPractice1616.Models;

namespace WebApplicationMyPractice1616.Controllers
{
    public class InsertController : Controller
    {
        [HttpGet]
        public IActionResult Inserting()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Inserting(InsetModel obj)
        {
            if(ModelState.IsValid)
            {
                bool res = InsertLogic.InsertData(obj);
                if(res=true)
                {
                    return RedirectToAction("Index", "MyPractce");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

        }
    }
}
