using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class RegisterModel
    {
        private int _idUtilisateur;
        private string _nom;
        private string _prenom;
        private string _courriel;
        private string _motDePasse;
        private string _confirmeMotDePasse;
        private DateTime _dateDeNaissance;
        private string photo;
        private bool _isAdmin;
        private int _idRole;
    }
}