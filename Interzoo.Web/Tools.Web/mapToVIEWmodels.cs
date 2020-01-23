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
        //public static IEnumerable<RoleModel> listRoleTOlistRoleModel(IEnumerable<Role> lr)
        //{
        //    //return new List<RoleModel>  ()
        //    //{
        //    //    Add
        //    //};
        //    List<RoleModel> lrm = new List<RoleModel>();
        //    {
        //        lrm.Add(lr.)
        //    }

        //}
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