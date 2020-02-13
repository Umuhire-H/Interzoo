﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class VerifAdminModel
    {
        
        private string _code;
        private bool _isAdmin;

     

        public string Code
        {
            get
            {
                return _code;
            }

            set
            {
                _code = value;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return _isAdmin;
            }

            set
            {
                _isAdmin = value;
            }
        }

        public VerifAdminModel()
        {
            this.Code = "1234";
            this.IsAdmin = false;
            //this.Code = "monday@code";
        }
    }
}