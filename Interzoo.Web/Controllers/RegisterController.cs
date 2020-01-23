using Interzoo.DAL.Repositories;
using Interzoo.Web.Models;
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

            UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings["h_Cnstr"].ConnectionString);
            // List<Role>  = List<modelDAL>  ----->  vue connait pas modelDAL --> creation modelVUE
            RegisterModelGET rm = new RegisterModelGET();
            List<Role> = new li
                ur.getAllRolesForRegisterModel(ConfigurationManager.ConnectionStrings["h_Cnstr"].ConnectionString).ToList();
            rm.ListeRole
            return View(rm);
        }
    }
}