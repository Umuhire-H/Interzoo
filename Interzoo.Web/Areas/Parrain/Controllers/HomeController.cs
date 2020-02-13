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
            ParrainModel parainM = new ParrainModel(); // donc contient :  IsConnected + package
            UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            // 1.
            parainM.Utilisateur = mapToVIEWmodels.utilisateurTOprofileModel(ur.getOne(SessionUtilisateur.ConnectedUser.IdUtilisateur));
            // 2.
            if (SessionUtilisateur.ConnectedUserPackage != null)
            {
                FormuleRepository fr = new FormuleRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
                parainM.ThePackage = mapToVIEWmodels.formuleToFormuleModel(fr.getOne(SessionUtilisateur.ConnectedUserPackage.IdFormule));
            
            }
            // 3.
            if (SessionUtilisateur.ConnectedUserAnimals != null)
            {

                AnimalRepository ar = new AnimalRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
                foreach (AnimalModel item in SessionUtilisateur.ConnectedUserAnimals)
                {
                    AnimalModel AnimalfromDB = mapToVIEWmodels.animalToAnimalModel(ar.getOne(item.IdAnimal));
                    parainM.AnimauxAdoptes.ToList().Add(AnimalfromDB);
                }
            }

            return View(parainM);
        }
        // when the user choose a package
        public ActionResult ChosenPackage(int id=1)
        {
            FormuleRepository fr = new FormuleRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            
             FormuleModel selectedPackage = mapToVIEWmodels.formuleToFormuleModel(fr.getOne(id));
            if (selectedPackage != null)
            {                
                return RedirectToAction("Index");   
            }
            ViewBag.Message = "Package selection Failed";
            return RedirectToAction("Formules", new
            {
                controller = "Home",
                area = ""
            });

        }
        // when the user choose a ANIMAL
        public ActionResult ChosenAnimal(int id = 1)
        {
            AnimalRepository ar = new AnimalRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);

            AnimalModel selectedAnim = mapToVIEWmodels.animalToAnimalModel(ar.getOne(id));
            if (selectedAnim != null)
            {
                SessionUtilisateur.ConnectedUserAnimals.ToList().Add(selectedAnim);
                return RedirectToAction("Index");                
            }
            ViewBag.Message = "Animal selection Failed";
            return RedirectToAction("Portfolio", new
            {
                controller = "Home",
                area = ""
            });
        }
        public ActionResult confirmPackage(int id)
        {
            FormuleRepository fr = new FormuleRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            FormuleModel insertedInFormulTable = mapToVIEWmodels.formuleToFormuleModel(fr.insert(fr.getOne(id)));
            int idFormuleInsertedInParrain = fr.insertInParrainTable(insertedInFormulTable.IdFormule);
            if (idFormuleInsertedInParrain == insertedInFormulTable.IdFormule)
            {
                SessionUtilisateur.ConnectedUserPackage = insertedInFormulTable;
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