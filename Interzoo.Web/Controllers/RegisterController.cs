using Interzoo.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interzoo.Web.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            UtilisateurRepository ur = new UtilisateurRepository ()
            return View();
        }
    }
}