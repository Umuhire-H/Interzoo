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
        //// GET: Register
        //public ActionResult Index()
        //{

        //    return RedirectToAction("Index", new
        //    {
        //        controller = "Home",
        //        area = ""
        //    });
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModelPOST rmPost, HttpPostedFileBase photo)
        {            
            UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            if (!ModelState.IsValid)
            {
                foreach (ModelState each_modelState in ViewData.ModelState.Values)
                {
                    foreach(ModelError each_error in each_modelState.Errors)
                    {
                        ViewBag.ErrorMessage += each_error.ErrorMessage + "<br>";
                    }
                }
                return RedirectToAction("Index", new { controller = "Home", area = "" });
            }
            else
            {
                //is admin or not ?  
                VerifAdminModel verifAdmin = new VerifAdminModel();
                if (rmPost.IsAdmin == verifAdmin.Code) // long string
                {
                    verifAdmin.IsAdmin = true;              
                }
                else if (rmPost.IsAdmin == null || rmPost.IsAdmin != verifAdmin.Code)
                {
                    ViewBag.Message = "Not a administrator";                   
                }
                rmPost.IsAdmin = verifAdmin.IsAdmin.ToString();

                // 1. Ajouter MMembre sans photo
                ProfileModel pm = mapToVIEWmodels.utilisateurTOprofileModel(ur.insert(MapToDBModel.registerToUtilisateur(rmPost)));

                // 2. photo : 
                if(pm == null)
                {
                    ViewBag.Message = "The profileModel is Null";
                    return RedirectToAction("Index", new { controller = "Home", area = "" });
                }
                else //if (pm != null)
                {
                    List<string> listeMIME = new List<string>() { "image/jpeg", "image/png", "image/gif" };
                    if (!listeMIME.Contains(photo.ContentType) || photo.ContentLength > 80000)
                    {
                        ViewBag.ErrorMessage = "Votre photo ne possède pas une extension autorisée (choisissez parmis : png, jpg, gif)";
                        return View("Index");
                    }
                    
                    string[] splitPhotoname = photo.FileName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    string ext = splitPhotoname[splitPhotoname.Length - 1];
                    string photoNew = pm.IdUtilisateur + "." + ext; // <== save in DB
                    string chemin = Server.MapPath("~/photos/utilisateur");
                    string photoToSave = chemin + "/" + photoNew;
                    photo.SaveAs(photoToSave);
                    pm.Photo = photoNew; // saved in DB via mapper
                    // try catch 
                    bool reussi = ur.update(MapToDBModel.profileTOUtilisateur(pm));
                    //
                    
                    if (!reussi)
                    {
                        ViewBag.Message = "The profileModel updating failed (no picture)";
                        return RedirectToAction("Index", new { controller = "Home", area = "" });
                    }
                    else // reussi
                    {
                        if (!pm.IsAdmin)
                        {                        
                            if(pm.IdRole == 0)
                            {
                                return RedirectToAction("Index", new { controller = "Home", area = "Parrain" });
                            }
                            else
                            {
                                return RedirectToAction("Index", new { controller = "Home", area = "Personnel" });

                            }
                        }
                        else // is admin
                        {
                            return RedirectToAction("Index", new { controller = "Home", area = "Admin" });
                        }                        
                    }

                }
                
            }               
        }
    }
}