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
        public FormuleModel TheFormule
        {
            get;set;
        }
        public bool isConnected { get; set; }
        public ParrainModel()
        {
            this.InfoParrain = SessionUtilisateur.ConnectedUser;
            this.isConnected = SessionUtilisateur.IsConnected;
            if (SessionUtilisateur.ConnectedUserPackage != null)
            {
                this.TheFormule = SessionUtilisateur.ConnectedUserPackage;
            }
            if (SessionUtilisateur.ConnectedUserAnimals != null)
            {
                this.AnimauxAdoptes = SessionUtilisateur.ConnectedUserAnimals;
            }
            else 
            {
                this.AnimauxAdoptes = new List<AnimalModel>();
            }
        }
    }
}