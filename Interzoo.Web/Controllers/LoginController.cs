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
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            if (SessionUtilisateur.IsConnected)
            {
                switch (SessionUtilisateur.ConnectedUser.IdRole)
                {
                    case 0:
                        return RedirectToAction("Index", new
                        {
                            Controller = "Home",
                            Area = "Parrain"
                        });                        
                    case 1:
                    case 2:
                    case 3:
                        return RedirectToAction("Index", new
                        {
                            Controller = "Home",
                            Area = "Personnel"
                        });
                    //default:
                    //    return View();
                }                
            }
            //return View();
            return RedirectToAction("Index", new
            {
                Controller = "Home",
                Area = ""
            });
        }
        [HttpPost]
        public ActionResult Login(LoginModel lm)
        {
            UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings[/*"h_Cnstr"*/"My_Asptest_Cnstr"].ConnectionString);
            if (!ModelState.IsValid)
            {
                foreach (ModelState each_modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError each_error in each_modelState.Errors)
                    {
                        ViewBag.ErrorMessage += each_error.ErrorMessage + "<br>";
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {

                ProfileModel pm = mapToVIEWmodels.utilisateurTOprofileModel(ur.verifLogin(MapToDBModel.loginToUtilisateur(lm)));
                if (pm != null)
                {
                    SessionUtilisateur.ConnectedUser = pm;
                    SessionUtilisateur.IsConnected = true;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorInLoginProcess = "Error with tne email or password";
                return RedirectToAction("Index", new { Controller = "Home", Area = "" });
                }
                
                //if ou else : faut passer par index de ce controller : pour suite des verif (parrain...)  
            }
        }
        
    }
}