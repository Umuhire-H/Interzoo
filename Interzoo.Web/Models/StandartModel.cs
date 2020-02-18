using Interzoo.DAL.Repositories;
using Interzoo.Web.Tools.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class StandartModel
    {
        public List<RoleModel> RoleModels
        {
            get; set;
        }
        public IEnumerable<AnimalModel> ListeAnimaux
        {
            get;set;
        }
        public StandartModel()
        {
            this.RoleModels = new List<RoleModel>();
            UtilisateurRepository ur = new UtilisateurRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            RoleModels = ur.getAllRolesForRegisterModel().Select(item => mapToVIEWmodels.RoleTORoleModel(item)).ToList();
            //-------------------------------------------------------------------------
            this.ListeAnimaux = new List<AnimalModel>();
            AnimalRepository animRepo = new AnimalRepository(ConfigurationManager.ConnectionStrings["My_Asptest_Cnstr"].ConnectionString);
            ListeAnimaux = animRepo.getAll().Select(item => mapToVIEWmodels.animalToAnimalModel(item)).ToList();
        }
    }
}