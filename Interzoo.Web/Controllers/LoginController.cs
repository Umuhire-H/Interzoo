using Interzoo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interzoo.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel lm)
        {
            

            return RedirectToAction("Index", new { Controller = "Home", Area = "" }); // dès que area sera  fait : alors regirigé vers l'AREA
        }
    }
}