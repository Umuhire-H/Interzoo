using Interzoo.Web.Models;
using Interzoo.Web.Tools.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Areas.Parrain.ModelsParrain
{
    public class ParrainModel
    {
        public ProfileModel InfoParrain { get; set; }
        public IEnumerable<AnimalModel> AnimauxAdoptes
        {
            get; set;
        }
        public IEnumerable<FormuleModel> FormulesOneUtilisateur
        {
            get;set;
        }
        
        public ParrainModel()
        {
            this.InfoParrain = SessionUtilisateur.ConnectedUser;
            this.AnimauxAdoptes = new List<AnimalModel>();
        }
    }
}