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
            ViewFormuleModel ivm = new ViewFormuleModel();
            ivm.RoleModels = LoadRoles();
            return View(ivm);
        }

        public ActionResult About()
        {
            ViewFormuleModel ivm = new ViewFormuleModel();
            ivm.RoleModels = LoadRoles();
            return View(ivm);
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            ViewFormuleModel ivm = new ViewFormuleModel();
            ivm.RoleModels = LoadRoles();
            return View(ivm);
        } 

        public ActionResult Blog()
        {
            ViewFormuleModel ivm = new ViewFormuleModel();
            ivm.RoleModels = LoadRoles();
            return View(ivm);
        }
        public ActionResult Formules()
        {
            ViewFormuleModel ivm = new ViewFormuleModel();
            ivm.RoleModels = LoadRoles();
            //--
            FormuleRepository fr = new FormuleRepository(ConfigurationManager.ConnectionStrings[/*"h_Cnstr"*/"My_Asptest_Cnstr"].ConnectionString);
            ivm.Formules = fr.getAll().Select(formule => mapToVIEWmodels.formuleToFormuleModel(formule)).ToList();
            return View(/*LoadRoles()*/ivm);
        }
        public ActionResult Portfolio()
        {
            ViewFormuleModel ivm = new ViewFormuleModel();
            ivm.RoleModels = LoadRoles();
            return View(ivm);
        }
        public ActionResult Pricing()
        {
            ViewFormuleModel ivm = new ViewFormuleModel();
            ivm.RoleModels = LoadRoles();
            return View(ivm);
        }
        public ActionResult Team()
        {
            ViewFormuleModel ivm = new ViewFormuleModel();
            ivm.RoleModels = LoadRoles();
            return View(ivm);
        }

        private List<RoleModel> LoadRoles()
        {
            UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings[/*"h_Cnstr"*/"My_Asptest_Cnstr"].ConnectionString);            
            return ur.getAllRolesForRegisterModel().Select(item => mapToVIEWmodels.RoleTORoleModel(item)).ToList();
        }
    }
}