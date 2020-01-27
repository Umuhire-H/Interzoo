using Interzoo.DAL.Repositories;
using Interzoo.Web.Models;
using Interzoo.Web.Tools.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            //  ============== I3 =====================
            // ========================================
            //UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);


            // ============== HOME ====================
            // ========================================
            // UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings["h_Cnstr"].ConnectionString);
            return RedirectToAction("Index", new { controller = "Home", area = "" });
        }
        [HttpPost]
        public ActionResult Register(RegisterModelPOST rmPost, HttpPostedFileBase photo)
        {
            if(rmPost != null)
            {

            return RedirectToAction("Index", new { controller = "Home", area = "Personnel" });
            }
            else
            {

                return RedirectToAction("Index", new { controller = "Home", area = "" });
            }

        }
    }
}