using Interzoo.Web.Areas.Parrain.ModelsParrain;
using Interzoo.Web.Tools.Web;
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
            ParrainModel pm = new ParrainModel(); // donc contient : infosOfConnectedUser + IsConnected 
            
            // ici stocker le formule choisi : pm.FormuleOneUtilisateur
            return View(pm);
        }
        public RedirectToRouteResult Logout()
        {

            Session.Abandon();
            return RedirectToAction("Index", new
            {
                Controller = "Home",
                Area = ""
            });

        }
    }
}