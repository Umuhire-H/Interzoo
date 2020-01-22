using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class LoginModel
    {
        private string _courriel;
        private string _motDePasse;

        public string Courriel
        {
            get
            {
                return _courriel;
            }

            set
            {
                _courriel = value;
            }
        }

        public string MotDePasse
        {
            get
            {
                return _motDePasse;
            }

            set
            {
                _motDePasse = value;
            }
        }


    }
}