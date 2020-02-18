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
            //if (SessionUtilisateur.ConnectedUserAnimals != null)
            //{
            //     admiM.Animal = SessionUtilisateur.ConnectedUserAnimals.Last();

            //}
            //afficher les categories de l'animal
            CategorieRepository ctr = new CategorieRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            admiM.Animal.allCategories = ctr.getAll().Select(item => mapToVIEWmodels.CategorieTOCategorieModel(item)).ToList();
            //if (SessionUtilisateur.ConnectedUserPackage != null)
            //{
            //    admiM.Animal = SessionUtilisateur.ConnectedUserAnimals.Last();              
            //}
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
        // ===================================================================================================================
        // ============================================= EDITION =============================================================
        // ===================================================================================================================
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditAnimal(AnimalModel animM, HttpPostedFileBase Photo)
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
                    if (!listeMIME.Contains(Photo.ContentType) /*|| photoAnim.ContentLength > 800000*/)
                    {
                        ViewBag.ErrorMessage = "unauthorized extention (choose : png, jpg or gif)";
                        return View("Index");
                    }
                    string[] splitPhotoname = Photo.FileName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    string ext = splitPhotoname[splitPhotoname.Length - 1];
                    string photoNew = anMo.IdAnimal + "animal" + "." + ext;
                    anMo.Photo = photoNew; // saved in DB via mapper
                    string chemin = Server.MapPath("~/photos/animal");
                    string photoToSave = chemin + "/" + photoNew;
                    Photo.SaveAs(photoToSave);
                    // try catch 
                    bool reussi = aniRepo.update(MapToDBModel.animalModelToAnimal(anMo));
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

        // ==================================================================================================================
        // ============================================= UPDATE =============================================================
        // ==================================================================================================================
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdateAnimal(AnimalModel toUpdate, HttpPostedFileBase Photo)
        {
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
                AnimalRepository aniRepo = new AnimalRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);

                // 1. update reussi ?
                bool updatePart1OK = aniRepo.update(MapToDBModel.animalModelToAnimal(toUpdate));
                // 2. photo : 
                if (updatePart1OK)
                {
                    if (Photo == null)
                    {
                        return View(ViewBag.Message = "Picture null, insersion failed");
                    }
                    else
                    {
                        List<string> listeMIME = new List<string>() { "image/jpeg", "image/png", "image/gif" };
                        if (!listeMIME.Contains(Photo.ContentType) /*|| photoAnim.ContentLength > 800000*/)
                        {
                            ViewBag.ErrorMessage = "unauthorized extention (choose : png, jpg or gif)";
                            return View("Index");
                        }
                        string[] splitPhotoname = Photo.FileName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                        string ext = splitPhotoname[splitPhotoname.Length - 1];
                        string photoNew = toUpdate.IdAnimal + "animal" + "." + ext;
                        toUpdate.Photo = photoNew; // saved in DB via mapper
                        string chemin = Server.MapPath("~/photos/animal");
                        string photoToSave = chemin + "/" + photoNew;
                        Photo.SaveAs(photoToSave);
                        // try catch 
                        bool updatePart2OK = aniRepo.update(MapToDBModel.animalModelToAnimal(toUpdate));
                        //
                        //if (updatePart2OK)
                        //{
                            return RedirectToAction("Index", new
                            {
                                controller = "Home",
                                area = "Admin"
                            });

                        //}
                    }


                }
                else
                {
                    return View(ViewBag.Message = "Insersion failed");
                }
            }
        }
    }
}