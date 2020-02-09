using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class RoleModel
    {
        private int? _idRole = null; 
        private string _typeRole;

        public int? IdRole
        {
            get
            {
                return _idRole;
            }

            set
            {
                _idRole = value;
            }
        }

        public string TypeRole
        {
            get
            {
                return _typeRole;
            }

            set
            {
                _typeRole = value;
            }
        }


    }
}
