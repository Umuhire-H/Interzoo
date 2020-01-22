using Interzoo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Models
{
    public class Utilisateur : IEntity <int>
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

        public int IdUtilisateur { get => _idUtilisateur; set => _idUtilisateur = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Courriel { get => _courriel; set => _courriel = value; }
        public string MotDePasse { get => _motDePasse; set => _motDePasse = value; }
        public DateTime DateDeNaissance { get => _dateDeNaissance; set => _dateDeNaissance = value; }
        public string Photo { get => photo; set => photo = value; }


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
        public string HashMDP
        {
            get
            {
                if (_motDePasse == null) throw new InvalidOperationException("Le mot de passe est vide");
                using (SHA512 sha512Hash = SHA512.Create())
                {
                    byte[] sourceBytes = Encoding.UTF8.GetBytes(_motDePasse);
                    byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
                    string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                    return hash;
                }
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
