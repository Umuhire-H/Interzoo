using Interzoo.DAL.Infra;
using Interzoo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Models
{
    public class AnimalCategorie : IEntity<CompositeKey<int, int>>
    {
        private int _idCategorie;
        private int idAnimal;
        private string _nomCategorie;

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

        public int IdAnimal
        {
            get
            {
                return idAnimal;
            }

            set
            {
                idAnimal = value;
            }
        }

        public string NomCategorie
        {
            get
            {
                return _nomCategorie;
            }

            set
            {
                _nomCategorie = value;
            }
        }
    }
}
