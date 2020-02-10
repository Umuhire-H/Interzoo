using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class ViewTeamModel
    {
        public List<RoleModel> RoleModels
        {
            get; set;
        }
        public ViewTeamModel()
        {
            this.RoleModels = new List<RoleModel>();
        }
    }
}