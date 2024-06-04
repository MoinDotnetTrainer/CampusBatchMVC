using Microsoft.AspNetCore.Mvc;
using WebAppAarohi28052024.Models;

namespace WebAppAarohi28052024.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Add()  // geneates the view , Business logic
        {
            int x = 65, y = 46, z;
            z = x + y;
            ViewData["res"] = z;
            return View();
        }



        [HttpGet]  // works on load
        public IActionResult Sub()  // geneates the view , Business logic
        {
            ViewData["res"] = "No result on load";

            return View();
        }
        [HttpPost] //on click
        public IActionResult Sub(string s)  // geneates the view , Business logic
        {
            int x = Convert.ToInt32(Request.Form["txt1"].ToString());
            int y = Convert.ToInt32(Request.Form["txt2"].ToString());
            int z = x - y;
            ViewData["res"] = z;
            return View();
        }


        [HttpGet]
        public IActionResult Mul()  // geneates the view , Business logic
        {
            return View();
        }
        [HttpPost]
        public IActionResult Mul(MyData obj)  // geneates the view , Business logic
        {
            int z = obj.x * obj.y;
            ViewData["res"] = z;
            return View();
        }


    }
}
