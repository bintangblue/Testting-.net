using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Test1Controller : Controller
    {
        // GET: Test1
        public ActionResult Index( string name )
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "default";
            }
            
            MTest mts = new MTest
            {
                Id = 111,
                Name = name,
                Email = "hubla@ucok.com"
            };
            ViewBag.Message = mts;
            return View();
        }
    }
}