using Interzoo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Tools.Web
{
    public static class SessionUtilisateur
    {
        public static bool IsConnected
        {
            get
            {
                if (HttpContext.Current.Session["IsConnected"] != null)
                {
                    return (bool)HttpContext.Current.Session["IsConnected"];
                }
                return false;
            }
            set
            {
                HttpContext.Current.Session["IsConnected"] = value;
            }
        }
        //-----stock+retourne le membre connecté
        public static ProfileModel ConnectedUser
        {
            get
            {
                if (HttpContext.Current.Session["ConnectedUser"] != null)
                {
                    return (ProfileModel)HttpContext.Current.Session["ConnectedUser"];
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["ConnectedUser"] = value;
            }
        }


    }
}