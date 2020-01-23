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