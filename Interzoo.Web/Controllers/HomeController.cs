
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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            StandartModel stm = new StandartModel();
            stm.RoleModels = LoadRoles();
           // stm.Administrator = new VerifAdminModel();
            
            return View(stm);

        }

        public ActionResult About()
        {

            StandartModel stm = new StandartModel();
            stm.RoleModels = LoadRoles();
            return View(stm);

        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            StandartModel stm = new StandartModel();
            stm.RoleModels = LoadRoles();
            return View(stm);
        } 

        public ActionResult Blog()
        {
            StandartModel stm = new StandartModel();
            stm.RoleModels = LoadRoles();
            return View(stm);
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
            StandartModel stm = new StandartModel();

            //stm.RoleModels = LoadRoles();
            // ===========doit envoyer à  la vue ListAnimalAdded
            //AnimalRepository animRepo = new AnimalRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            //stm.ListeAnimaux = animRepo.getAll().Select(item => mapToVIEWmodels.animalToAnimalModel(item)).ToList();

            return View(stm);
        }

        public ActionResult Team()
        {
            StandartModel stm = new StandartModel();
            stm.RoleModels = LoadRoles();
            // stm.Administrator.IsAdmin = Convert.ToBoolean(TempData["isAdmin"]); // <===============
            return View(stm);
        }


        private List<RoleModel> LoadRoles()
        {
            UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);            
            return ur.getAllRolesForRegisterModel().Select(item => mapToVIEWmodels.RoleTORoleModel(item)).ToList();
        }
    }
}