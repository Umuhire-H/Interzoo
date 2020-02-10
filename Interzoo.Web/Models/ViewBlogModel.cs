using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class ViewBlogModel
    {
        public List<RoleModel> RoleModels
        {
            get; set;
        }
        public ViewBlogModel()
        {
            this.RoleModels = new List<RoleModel>();
        }
    }
}