using Interzoo.DAL.Repositories;
using Interzoo.Web.Areas.Parrain.ModelsParrain;
using Interzoo.Web.Models;
using Interzoo.Web.Tools.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interzoo.Web.Areas.Parrain.Controllers
{
    [CustomAuthorize]
    public class HomeController : Controller
    {
        // GET: Parrain/Home
        public ActionResult Index()
        {
            ViewBag.title = "Area Parrain - Marraine";
            ParrainModel pm = new ParrainModel(); // donc contient : infosOfConnectedUser + IsConnected + package
            return View(pm);
        }
        // when the user choose a package
        public ActionResult ChosenPackage(int id=1)
        {
            FormuleRepository fr = new FormuleRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            
            SessionUtilisateur.ConnectedUserPackage = mapToVIEWmodels.formuleToFormuleModel(fr.getOne(id));

            return RedirectToAction("Index");
        }
        // when the user choose a ANIMAL
        public ActionResult ChosenAnimal(int id = 1)
        {
            AnimalRepository ar = new AnimalRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);

            SessionUtilisateur.ConnectedUserAnimals.ToList().Add(mapToVIEWmodels.animalToAnimalModel(ar.getOne(id)));

            return RedirectToAction("Index");
        }
        public ActionResult confirmPackage(int id)
        {
            FormuleRepository fr = new FormuleRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            FormuleModel insertedInFormulTable = mapToVIEWmodels.formuleToFormuleModel(fr.insert(fr.getOne(id)));
            int insertedIdInParrain = fr.insertInParrainTable(insertedInFormulTable.IdFormule);
            if (insertedIdInParrain == insertedInFormulTable.IdFormule)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", ViewBag.Message("Please Confirm again"));
            }
        }
        public RedirectToRouteResult Logout()
        {

            Session.Abandon();
            return RedirectToAction("Index", new
            {
                Controller = "Home",
                Area = ""
            });

        }
    }
}