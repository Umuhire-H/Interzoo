using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class RegisterModelPOST //
    {
        private string _idUtilisateur;//
        private string _nom;//
        private string _prenom;//
        private string _courriel;//
        private string _motDePasse;//
        private string _confirmeMotDePasse;//
        private DateTime _dateDeNaissance;//
        private string photo; //
        private string _isAdmin;//
        //private int? _idRole = null;
        private int? _idRole;



        public string IdUtilisateur
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
        [Required(ErrorMessage ="Veuillez compléter le champ 'Nom'")]
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
        [Required(ErrorMessage = "Veuillez compléter le champ 'Prenom'")]
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
        [Required(ErrorMessage = "Veuillez compléter le champ 'Email'")]
        [DataType(DataType.EmailAddress)]
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
        
        [Required(ErrorMessage = "Veuillez compléter le champ 'Mot de passe'")]
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
        [Compare("MotDePasse", ErrorMessage ="Les deux mots de passe diffèrent")]
        public string ConfirmeMotDePasse
        {
            get
            {
                return _confirmeMotDePasse;
            }

            set
            {
                _confirmeMotDePasse = value;
            }
        }
        [Required(ErrorMessage = "Veuillez compléter le champ 'date de naissance'")]
        [DataType(DataType.DateTime)]
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
        public string IsAdmin
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

      
    }
}