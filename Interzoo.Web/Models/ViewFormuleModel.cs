using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class ViewFormuleModel
    {
        public List<RoleModel> RoleModels
        {
            get;set;
        }
        public IEnumerable<FormuleModel> Formules
        {
            get; set;
        }
        public ViewFormuleModel()
        {
            this.RoleModels = new List<RoleModel>();
            this.Formules = new List<FormuleModel>();

        }

    }
}