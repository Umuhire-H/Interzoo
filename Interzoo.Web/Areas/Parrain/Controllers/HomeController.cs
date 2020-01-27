using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interzoo.Web.Areas.Parrain.Controllers
{
    public class HomeController : Controller
    {
        // GET: Parrain/Home
        public ActionResult Index()
        {
            ViewBag.title = "Area Parrain - Marraine";
            return View();
        }
    }
}