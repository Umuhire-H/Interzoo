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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StandartModel stm = new StandartModel();
            stm.RoleModels = LoadRoles();
           // stm.Administrator = new VerifAdminModel();
            if (TempData.ContainsKey("isAdmin"))
            {
            stm.Administrator.IsAdmin = bool.Parse(TempData["isAdmin"].ToString());
            
            }
            return View(stm);
        }

        public ActionResult About()
        {
            StandartModel stm = new StandartModel();
            stm.RoleModels = LoadRoles();
            stm.Administrator.IsAdmin = (bool)TempData["isAdmin"]; // <===============
            return View(stm);
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            StandartModel stm = new StandartModel();
            stm.RoleModels = LoadRoles();
            stm.Administrator.IsAdmin = (bool)TempData["isAdmin"]; // <===============
            return View(stm);
        } 

        public ActionResult Blog()
        {
            StandartModel stm = new StandartModel();
            stm.RoleModels = LoadRoles();
            stm.Administrator.IsAdmin = (bool)TempData["isAdmin"]; // <===============
            return View(stm);
        }
        public ActionResult Formules()
        {
            ViewFormuleModel vfm = new ViewFormuleModel();
            vfm.RoleModels = LoadRoles();
            vfm.Administrator.IsAdmin = (bool)TempData["isAdmin"]; // <===============
            //--
            FormuleRepository fr = new FormuleRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            vfm.Formules = fr.getAll().Select(formule => mapToVIEWmodels.formuleToFormuleModel(formule)).ToList();
            return View(/*LoadRoles()*/vfm);
        }
        public ActionResult Portfolio()
        {
            StandartModel stm = new StandartModel();
            stm.RoleModels = LoadRoles();
            stm.Administrator.IsAdmin = (bool)TempData["isAdmin"]; // <===============
            return View(stm);
        }

        public ActionResult Team()
        {
            StandartModel stm = new StandartModel();
            stm.RoleModels = LoadRoles();
            stm.Administrator.IsAdmin = (bool)TempData["isAdmin"]; // <===============
            return View(stm);
        }

        private List<RoleModel> LoadRoles()
        {
            UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);            
            return ur.getAllRolesForRegisterModel().Select(item => mapToVIEWmodels.RoleTORoleModel(item)).ToList();
        }
    }
}