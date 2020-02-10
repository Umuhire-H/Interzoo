using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class ProfileModel
    {
        private int _idUtilisateur;
        private string _nom;
        private string _prenom;
        private string _courriel;
        private string _motDePasse;
        private DateTime _dateDeNaissance;
        private string photo;
        private bool _isAdmin;
        private int _idRole;

        public int IdUtilisateur
        {
            get
            {
                return _idUtilisateur;
            }

            set
            {
                _idUtilisateur = value;
            }
        }

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                _prenom = value;
            }
        }

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

        public DateTime DateDeNaissance
        {
            get
            {
                return _dateDeNaissance;
            }

            set
            {
                _dateDeNaissance = value;
            }
        }

        public string Photo
        {
            get
            {
                return photo;
            }

            set
            {
                photo = value;
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

        public int IdRole
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
    }
}