using Interzoo.DAL.Models;
using Interzoo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Tools.Web
{
    public static class MapToDBModel
    {
        // départ_VUE : ---- Models_DB <---- ModelsVUE 
        public static Utilisateur loginToUtilisateur(LoginModel lm)
        {
            return new Utilisateur()
            {
                Courriel = lm.Courriel,
                MotDePasse = lm.MotDePasse
            };
        }
       public static Utilisateur registerToUtilisateur (RegisterModelPOST rmPost)
        {
            return new Utilisateur()
            {
                Nom = rmPost.Nom,
                Prenom = rmPost.Prenom,
                Courriel = rmPost.Courriel,
                MotDePasse = rmPost.MotDePasse,
                DateDeNaissance = rmPost.DateDeNaissance,
                Photo = rmPost.Photo,
                IsAdmin = rmPost.IsAdmin,
                IdRole = rmPost.IdRole
            };
        }
        //public static Role RoleTORoleModel(RoleModel rm)
        //{
        //    return new Role()
        //    {
        //        IdRole = rm.IdRole,
        //        TypeRole = rm.TypeRole
        //    };

        //}

    }
}