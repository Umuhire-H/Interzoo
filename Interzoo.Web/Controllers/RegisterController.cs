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
            UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            // IEnum<Role> --> List<Role>
            RegisterModelGET rm = new RegisterModelGET();
            rm.ListeRole = ur.getAllRolesForRegisterModel (ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString).ToList();
            
            return View(rm);
        }
    }
}