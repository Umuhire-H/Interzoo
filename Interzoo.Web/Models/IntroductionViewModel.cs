using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class IntroductionViewModel
    {
        public List<RoleModel> RoleModels
        {
            get;set;
        }
        public IEnumerable<FormuleModel> Formules
        {
            get; set;
        }
        public IntroductionViewModel()
        {
            this.RoleModels = new List<RoleModel>();
            this.Formules = new List<FormuleModel>();
        }

    }
}