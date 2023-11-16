using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class AEmployeeController : Controller
    {
        // GET: AEmployee
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            IEnumerable<Employee> employees = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:6848/api/");

                var responseTask = client.GetAsync("employees");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                    readTask.Wait();

                    employees = readTask.Result;
                }
                else
                {
                    employees = Enumerable.Empty<Employee>();
                    ModelState.AddModelError(string.Empty, "Server error");
                }
            }
            return Json(employees, JsonRequestBehavior.AllowGet);
        }
    }
}