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
        public static AnimalModel animalToAnimalModel(Animal a)
        {
            return new AnimalModel()
            {
                IdAnimal = a.IdAnimal,
                Nom = a.Nom,
                NomScientifique = a.NomScientifique,
                RegionOrigine = a.RegionOrigine,
                Photo = a.Photo
            };
        }
        public static AnimalCaracteristiqueModel animalCaracToAnimalCaractModel(AnimalCaracteristique ac)
        {
            return new AnimalCaracteristiqueModel()
            {
                IdAnimal = ac.IdAnimal,
                IdCaracteristique = ac.IdCaracteristique,
                NomCaracteristique = ac.NomCaracteristique
            };
        }
        public static CaracteristiqueModel caracToCaractModel(Caracteristique c)
        {
            return new CaracteristiqueModel()
            {
                IdCaracteristique = c.IdCaracteristique,
                TypeCaracteristique = c.TypeCaracteristique
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
        public static CategorieModel CategorieTOCategorieModel(Categorie r)
        {
            return new CategorieModel()
            {
                IdCategorie = r.IdCategorie,
                TypeCategorie = r.TypeCategorie
            };

        }
    }

    
}