using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webAplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Title = "Home Page";
            return View();
            //return new JsonResult
            //{
            //  Data = "hubla",
            //JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //};

        }

        class A
        {
            public string Id { get; set; }
            public string Nama { get; set; }

        }
    }
}