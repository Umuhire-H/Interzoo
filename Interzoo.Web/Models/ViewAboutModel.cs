using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class ViewAboutModel
    {
        public List<RoleModel> RoleModels
        {
            get; set;
        }
        public ViewAboutModel()
        {
            this.RoleModels = new List<RoleModel>();
        }
    }
}