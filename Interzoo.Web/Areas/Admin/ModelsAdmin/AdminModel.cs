using Interzoo.Web.Models;
using Interzoo.Web.Tools.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Areas.Admin.ModelsAdmin
{
    public class AdminModel
    {
        public ProfileModel InfoAdmin
        {
            get; set;
        }
        public AnimalModel Animal
        {
            get; set;
        }
       public ProfileModel Utilisateur
        {
            get; set;
        }

    public AdminModel()
        {
            this.InfoAdmin = SessionUtilisateur.ConnectedUser;
        }
    }
}