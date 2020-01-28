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
            return View(LoadRoles());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(LoadRoles());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(LoadRoles());
        }

       

        public ActionResult Blog()
        {
            return View(LoadRoles());
        }
        public ActionResult Formules()
        {
            return View(LoadRoles());
        }
        public ActionResult Portfolio()
        {
            return View(LoadRoles());
        }
        public ActionResult Pricing()
        {
            return View(LoadRoles());
        }
        public ActionResult Team()
        {
            return View(LoadRoles());
        }

        private List<RoleModel> LoadRoles()
        {
            UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            //List<Role> ListeRole = ur.getAllRolesForRegisterModel().ToList();
            //List<RoleModel> lr = new List<RoleModel>();
            //foreach (var item in ListeRole)
            //{
            //    lr.Add(mapToVIEWmodels.RoleTORoleModel(item));
            //}
            return ur.getAllRolesForRegisterModel().Select(item => mapToVIEWmodels.RoleTORoleModel(item)).ToList();
        }
    }
}