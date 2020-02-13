using Interzoo.DAL.Repositories;
using Interzoo.Web.Areas.Admin.ModelsAdmin;
using Interzoo.Web.Models;
using Interzoo.Web.Tools.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interzoo.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            AdminModel admiM = new AdminModel();
            UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            // stocker l'utilisateur dans AdminModel
            admiM.Utilisateur = mapToVIEWmodels.utilisateurTOprofileModel(ur.getOne(SessionUtilisateur.ConnectedUser.IdUtilisateur));

            // stocker fraichement animalModif
            if (SessionUtilisateur.ConnectedUserAnimals != null)
            {
                 admiM.Animal = SessionUtilisateur.ConnectedUserAnimals.Last();

            }
            //afficher les categories de l'animal
            CategorieRepository ctr = new CategorieRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            if (SessionUtilisateur.ConnectedUserPackage != null)
            {
                admiM.Animal = SessionUtilisateur.ConnectedUserAnimals.Last();
               
                // admiM.Animal.allCategories = ctr.getAll().Select(item => mapToVIEWmodels.CategorieTOCategorieModel(item)).ToList();

            }
            // stocker si animal = deleted or not
            admiM.UserIsDeleted = Convert.ToBoolean(TempData["userDeleted"]);
            return View(admiM);
        }
        [HttpPost]
        public ActionResult EditProfile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteUser(ProfileModel utilisM)
        {
            UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            bool userIsDeleted = ur.delete(utilisM.IdUtilisateur);
            TempData["userDeleted"] = userIsDeleted;
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditAnimal(AnimalModel animM, HttpPostedFileBase photoAnim)
        {
            AnimalRepository aniRepo = new AnimalRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
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
                // 1. Ajouter ANIMAL sans photo
                AnimalModel anMo = mapToVIEWmodels.animalToAnimalModel(aniRepo.insert(MapToDBModel.animalModelToAnimal(animM)));

                // 2. photo : 
                if (anMo != null)
                {
                    List<string> listeMIME = new List<string>() { "image/jpeg", "image/png", "image/gif" };
                    if (!listeMIME.Contains(photoAnim.ContentType) || photoAnim.ContentLength > 80000)
                    {
                        ViewBag.ErrorMessage = "unauthorized extention (choose : png, jpg or gif)";
                        return View("Index");
                    }

                    string[] splitPhotoname = photoAnim.FileName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    string ext = splitPhotoname[splitPhotoname.Length - 1];
                    string photoNew = anMo.IdAnimal + "profil" + "." + ext;
                    anMo.Photo = photoNew; // saved in DB via mapper
                    string chemin = Server.MapPath("~/photos/animal");
                    string photoToSave = chemin + "/" + photoNew;
                    photoAnim.SaveAs(photoToSave);
                    // try catch 
                    bool reussi = aniRepo.update(MapToDBModel.animalModelToAnimal(anMo));

                    //
                    if (reussi)
                    {
                        AnimalModel updatedAnModel = mapToVIEWmodels.animalToAnimalModel(aniRepo.getOne(animM.IdAnimal));
                        SessionUtilisateur.ConnectedUserAnimals.ToList().Add(updatedAnModel);
                        return RedirectToAction("Index", new
                        {
                            controller = "Home",
                            area = "Admin"
                        });

                    }

                }
                return View(ViewBag.Message = "Insersion failed");
            }
        }
    }
}