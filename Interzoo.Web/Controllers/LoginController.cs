﻿using Interzoo.DAL.Repositories;
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
            if (!SessionUtilisateur.IsConnected)
            {
                return RedirectToAction("Index", new
                {
                    Controller = "Home",
                    Area = ""
                });
            }
            else
            {                
                switch (SessionUtilisateur.ConnectedUser.IdRole)
                {
                    case 0:
                        switch (SessionUtilisateur.ConnectedUser.IsAdmin)
                        {
                            case true:
                                return RedirectToAction("Index", new
                                {
                                    Controller = "Home",
                                    Area = "Admin"
                                });
                               ;
                            case false:
                                return RedirectToAction("Index", new
                                {
                                    Controller = "Home",
                                    Area = "Parrain"
                                });
                            default:
                                return RedirectToAction("Index", new { Controller = "Home", Area = ""  });

                        }
                    case 1:
                    case 2:
                    case 3:
                        return RedirectToAction("Index", new { Controller = "Home", Area = "Personnel"  });
                    default:
                        return RedirectToAction("Index", new
                        {
                            Controller = "Home",
                            Area = ""
                        });
                }                
            }
           
            
        }
        [HttpPost]
        public ActionResult Login(LoginModel lm)
        {
            UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
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