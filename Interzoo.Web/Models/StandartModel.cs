using System;
using System.Collections.Generic;
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
        public VerifAdminModel Administrator;
        public StandartModel()
        {
            this.RoleModels = new List<RoleModel>();
            this.Administrator = new VerifAdminModel();
                this.Administrator.IsAdmin = false;
        }
    }
}