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
            //UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            //// IEnum<Role> --> List<Role>
            //RegisterModelGET rm = new RegisterModelGET();
            //rm.ListeRole = ur.getAllRolesForRegisterModel (ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString).ToList();

           // UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings["h_Cnstr"].ConnectionString);
            // List<Role>  = List<modelDAL>  ----->  vue connait pas modelDAL --> creation modelVUE
            //RegisterModelGET regisM = new RegisterModelGET();
            // this is a list<ROLE>
            //regisM.ListeRole = ur.getAllRolesForRegisterModel(ConfigurationManager.ConnectionStrings["h_Cnstr"].ConnectionString).ToList();
            // list<RoleMODEL>
            // essai 1
            //foreach (var item in regisM.ListeRole)
            //{
            //    (regisM.ListeRoleModel.ToList()).Add(mapToVIEWmodels.RoleTORoleModel(item));
            //}
            //return View(regisM);

            // essai 1
            List<RoleModel> lr = new List<RoleModel>();
            //foreach (var item in regisM.ListeRole)
            //{
            //    lr.Add(mapToVIEWmodels.RoleTORoleModel(item));
            //}

            return View(lr);
        }
    }
}