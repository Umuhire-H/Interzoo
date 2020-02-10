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
            ViewIndexModel vim = new ViewIndexModel();
            vim.RoleModels = LoadRoles();
            return View(vim);
        }

        public ActionResult About()
        {
            ViewAboutModel vam = new ViewAboutModel();
            vam.RoleModels = LoadRoles();
            return View(vam);
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
            ViewBlogModel vbm = new ViewBlogModel();
            vbm.RoleModels = LoadRoles();
            return View(vbm);
        }
        public ActionResult Formules()
        {
            ViewFormuleModel vfm = new ViewFormuleModel();
            vfm.RoleModels = LoadRoles();
            //--
            FormuleRepository fr = new FormuleRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            vfm.Formules = fr.getAll().Select(formule => mapToVIEWmodels.formuleToFormuleModel(formule)).ToList();
            return View(/*LoadRoles()*/vfm);
        }
        public ActionResult Portfolio()
        {
            ViewPortfolioModel vpm = new ViewPortfolioModel();
            vpm.RoleModels = LoadRoles();
            return View(vpm);
        }

        public ActionResult Team()
        {
            ViewTeamModel vtm = new ViewTeamModel();
            vtm.RoleModels = LoadRoles();
            return View(vtm);
        }

        private List<RoleModel> LoadRoles()
        {
            UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);            
            return ur.getAllRolesForRegisterModel().Select(item => mapToVIEWmodels.RoleTORoleModel(item)).ToList();
        }
    }
}