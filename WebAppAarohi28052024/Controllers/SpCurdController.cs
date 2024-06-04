using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAppAarohi28052024.Models;

namespace WebAppAarohi28052024.Controllers
{
    public class SpCurdController : Controller
    {
        public readonly DatabaseContext _context;
        public SpCurdController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel obj)
        {
            if (obj.EmailID == "xyz@yahoo.com" && obj.Password == "123")
            {
                HttpContext.Session.SetString("UserName", "Xyz");
                HttpContext.Session.SetString("LoginTime", System.DateTime.Now.ToShortDateString());
                return RedirectToAction("index");
            }
            return View();
        }


        [SetSessionGlobally]
        public IActionResult Index()
        {

            List<CurdModel> obj;
            string sql = "exec sp_getalldemodata";
            obj = _context.curdmodel.FromSqlRaw<CurdModel>(sql).ToList();
            return View(obj);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


        [HttpGet]
        [SetSessionGlobally]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(CurdModel obj)
        {

            //insert logi  using sp

            string sql = "exec sp_insert @name,@emailid,@dob,@gender,@status";
            List<SqlParameter> list = new List<SqlParameter> {
            new SqlParameter { ParameterName="@name",Value=obj.name},
            new SqlParameter { ParameterName="@EmailID",Value=obj.EmailID},
            new SqlParameter { ParameterName="@Dob",Value=obj.Dob},
            new SqlParameter { ParameterName="@Gender",Value=obj.Gender},
            new SqlParameter { ParameterName="@Status",Value=obj.Status}
            };

            var res = _context.Database.ExecuteSqlRaw(sql, list);
            if (res > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            string sql = "exec sp_getdataByID_ @id";
            List<SqlParameter> list = new List<SqlParameter> {
            new SqlParameter{ ParameterName="@id",Value=id}
            };

            var res = _context.curdmodel.FromSqlRaw(sql, list.ToArray()).AsEnumerable().FirstOrDefault();
            return View(res);
        }

        [HttpPost]
        public IActionResult Edit(CurdModel obj)
        {

            string sql = "exec sp_update @name,@emailid,@dob,@gender,@status,@id";
            List<SqlParameter> list = new List<SqlParameter> {
            new SqlParameter { ParameterName="@name",Value=obj.name},
            new SqlParameter { ParameterName="@EmailID",Value=obj.EmailID},
            new SqlParameter { ParameterName="@Dob",Value=obj.Dob},
            new SqlParameter { ParameterName="@Gender",Value=obj.Gender},
            new SqlParameter { ParameterName="@Status",Value=obj.Status},
            new SqlParameter { ParameterName="@id",Value=obj.Id}

            };

            var res = _context.Database.ExecuteSqlRaw(sql, list);
            if (res > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            string sql = "exec sp_deleteByID_ @id";
            List<SqlParameter> list = new List<SqlParameter> {
            new SqlParameter{ ParameterName="@id",Value=id}
            };
            var res = _context.Database.ExecuteSqlRaw(sql, list);
            if (res > 0)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult StoreData()
        {

            // holds and trabsfer the data
            ViewBag.res = "Some data thrw viewbag";
            ViewData["key1"] = "some data from view data";
            TempData["key2"] = "some data from tempdata";
            return RedirectToAction("anotherData");

        }
        public IActionResult anotherData()
        {

            return RedirectToAction("anotherData1");
        }


        public IActionResult anotherData1()
        {

            return View();
        }



    }
}
