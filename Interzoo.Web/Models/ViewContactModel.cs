using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class ViewContactModel
    {
        public List<RoleModel> RoleModels
        {
            get; set;
        }
        public ViewContactModel()
        {
            this.RoleModels = new List<RoleModel>();
        }
    }
}