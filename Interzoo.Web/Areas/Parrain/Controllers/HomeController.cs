using Interzoo.DAL.Repositories;
using Interzoo.Web.Areas.Parrain.ModelsParrain;
using Interzoo.Web.Tools.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interzoo.Web.Areas.Parrain.Controllers
{
    [CustomAuthorize]
    public class HomeController : Controller
    {
        // GET: Parrain/Home
        public ActionResult Index()
        {
            ViewBag.title = "Area Parrain - Marraine";
            ParrainModel pm = new ParrainModel(); // donc contient : infosOfConnectedUser + IsConnected 
            
            // ici stocker le formule choisi : pm.FormuleOneUtilisateur : voir 
            return View(pm);
        }

        public ActionResult ChosenFormule(int id)
        {
            FormuleRepository fr = new FormuleRepository(ConfigurationManager.ConnectionStrings[/*"h_Cnstr"*/"My_Asptest_Cnstr"].ConnectionString);
            ParrainModel pm = new ParrainModel();
            pm.FormuleOneUtilisateur = mapToVIEWmodels.formuleToFormuleModel(fr.getOne(id));
            return RedirectToAction("Index");
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