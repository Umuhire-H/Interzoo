﻿using Interzoo.Web.Models;
using Interzoo.Web.Tools.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Areas.Admin.ModelsAdmin
{
    public class AdminModel
    {
        
        public AnimalModel Animal //<===================unused
        {
            get; set;
        }
        public ProfileModel Utilisateur
        {
            get; set;
        }
        public bool UserIsDeleted
        {
            get;set;
        }
        
        public AdminModel()
        {
            this.Utilisateur = SessionUtilisateur.ConnectedUser;
            //CategorieRepository ctr = new CategorieRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);

            this.Animal = new AnimalModel()
            {
                allCategories = new List<CategorieModel>()
                //{
                //     ctr.getAll().Select(item => mapToVIEWmodels.CategorieTOCategorieModel(item)).ToList()
                //}

            };
        }
    }
}