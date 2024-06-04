using Microsoft.AspNetCore.Mvc;
using WebAppAarohi28052024.Models;

namespace WebAppAarohi28052024.Controllers
{
    [SetSessionGlobally]
    public class CurdController : Controller
    {
        public readonly DatabaseContext _context;
        public CurdController(DatabaseContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Insert(CurdModel obj)
        {

            // ef logic to add data ito a db
            try
            {
                _context.curdmodel.Add(obj);
                int x = _context.SaveChanges();
                if (x > 0)
                {
                    return RedirectToAction("Display");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        public IActionResult Display()
        {
            var res = (from s in _context.curdmodel select s).ToList(); //LINQ Synatx
            return View(res);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var res = _context.curdmodel.Find(id);
            return View(res);
        }


        [HttpPost]
        public IActionResult Edit(CurdModel obj)
        {
            var res = _context.curdmodel.Update(obj);
            int x = _context.SaveChanges();
            if (x > 0)
            {
                return RedirectToAction("Display");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var res = _context.curdmodel.Find(id);
            if (res != null)
            {
                _context.curdmodel.Remove(res);
                int x = _context.SaveChanges();
                if (x > 0)
                {
                    return RedirectToAction("Display");
                }
            }
            return View();
        }
    }
}
