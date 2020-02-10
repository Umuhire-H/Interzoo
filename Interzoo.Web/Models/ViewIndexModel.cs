using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class ViewIndexModel
    {
        public List<RoleModel> RoleModels
        {
            get; set;
        }
        public ViewIndexModel()
        {
            this.RoleModels = new List<RoleModel>();
        }
    }
}