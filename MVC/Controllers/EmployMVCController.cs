using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVC.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class EmployMVCController : Controller
    {
        HttpClient req;
        string url = "https://localhost:44375/api/";
        public EmployMVCController()
        { 
            req = new HttpClient();
            req.BaseAddress = new Uri(url);
            req.DefaultRequestHeaders.Accept.Clear();
            req.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: EmployMVC
        public ViewResult GetAllEmployee()
        { 
            IEnumerable<EmployeeInfo> employList;
            HttpResponseMessage response = req.GetAsync("getAllEmployee").Result;
            employList = response.Content.ReadAsAsync<IEnumerable<EmployeeInfo>>().Result;
            return View(employList);
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(EmployeeInfo employ)
        {
            
                HttpResponseMessage response = req.PostAsJsonAsync("createEmploy", employ).Result;
                return RedirectToAction("getAllEmployee");
               
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int id1 = Convert.ToInt32(id);
            HttpResponseMessage response = req.GetAsync("edit/"+ id1).Result;

            EmployeeInfo info = response.Content.ReadAsAsync<EmployeeInfo>().Result;
            if(info == null)
            {
                return HttpNotFound();
            }
            return View(info);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeInfo employ)
        {
            HttpResponseMessage response = req.PutAsJsonAsync("update", employ).Result;
            
            return RedirectToAction("getAllEmployee");
        }

        public ActionResult Delete(int id)
        {
            if (id.ToString() == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            HttpResponseMessage response = req.DeleteAsync("delete/" + id).Result;
          
            return RedirectToAction("getAllEmployee");
        }

    }
}