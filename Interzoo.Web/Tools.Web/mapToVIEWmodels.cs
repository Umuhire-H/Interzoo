using Interzoo.DAL.Models;
using Interzoo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Tools.Web
{
    public static class mapToVIEWmodels
    {
        
        public static RoleModel RoleTORoleModel(Role r)
        {
            return new RoleModel()
            {
                IdRole = r.IdRole,
                TypeRole = r.TypeRole
            };

        }
        public static ProfileModel utilisateurTOprofileModel(Utilisateur u)
        {
            return new ProfileModel()
            {
                IdUtilisateur = u.IdUtilisateur,
                Nom = u.Nom,
                Prenom = u.Prenom,
                Courriel = u.Courriel,
                MotDePasse = u.MotDePasse,
                DateDeNaissance = u.DateDeNaissance,
                Photo = u.Photo,
                IsAdmin = u.IsAdmin,
                IdRole = u.IdRole
            };
        }
        public static FormuleModel formuleToFormuleModel(Formule f)
        {
            return new FormuleModel()
            {
                IdFormule = f.IdFormule,
                Nom = f.Nom,
                Description = f.Description,
                Prix = f.Prix,
                DateDebut = f.DateDebut,
                DateFin = f.DateFin
            };
        }
    }

    
}