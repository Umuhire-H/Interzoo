using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class ViewPortfolioModel
    {
        public List<RoleModel> RoleModels
        {
            get; set;
        }
        public ViewPortfolioModel()
        {
            this.RoleModels = new List<RoleModel>();
        }
    }
}