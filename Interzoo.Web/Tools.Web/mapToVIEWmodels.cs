using Interzoo.DAL.Models;
using Interzoo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Tools.Web
{
    public static class mapToVIEWmodels
    {
        
        public static RoleModel RoleTORoleModel(Role r)
        {
            return new RoleModel()
            {
                IdRole = r.IdRole,
                TypeRole = r.TypeRole
            };

        }
    }

    
}