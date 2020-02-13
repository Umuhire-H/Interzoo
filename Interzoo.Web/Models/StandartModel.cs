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
        
        public StandartModel()
        {
            this.RoleModels = new List<RoleModel>();         
        }
    }
}