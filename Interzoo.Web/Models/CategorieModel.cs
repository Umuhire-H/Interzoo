﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class CategorieModel
    {
        private int _idCategorie;
        private string _typeCategorie;

        public int IdCategorie
        {
            get
            {
                return _idCategorie;
            }

            set
            {
                _idCategorie = value;
            }
        }

        public string TypeCategorie
        {
            get
            {
                return _typeCategorie;
            }

            set
            {
                _typeCategorie = value;
            }
        }
    }
}