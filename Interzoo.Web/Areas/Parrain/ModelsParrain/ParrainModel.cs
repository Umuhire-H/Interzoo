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
        public FormuleModel FormuleOneUtilisateur
        {
            get;set;
        }
        public bool isConnected { get; set; }
        public ParrainModel()
        {
            this.InfoParrain = SessionUtilisateur.ConnectedUser;
            this.isConnected = SessionUtilisateur.IsConnected;
            this.AnimauxAdoptes = new List<AnimalModel>();
        }
    }
}