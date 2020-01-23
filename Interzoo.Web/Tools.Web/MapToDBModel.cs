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
        public static Utilisateur LoginToUtilisateur(LoginModel lm)
        {
            return new Utilisateur()
            {
                Courriel = lm.Courriel,
                MotDePasse = lm.MotDePasse
            };
        }
        //public static Utilisateur RegisterToUtilisateur(RegisterModel rm)
        //{
        //    r
        //}
    }
}