﻿using Interzoo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Models
{
    public class Animal : IEntity<int>
    {
        private int _idAnimal;
        private string _nom;
        private string _nomScientifique;
        private string _regionOrigine;
        private int _idCategorie;

        public int IdAnimal
        {
            get
            {
                return _idAnimal;
            }

            set
            {
                _idAnimal = value;
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

        public string NomScientifique
        {
            get
            {
                return _nomScientifique;
            }

            set
            {
                _nomScientifique = value;
            }
        }

        public string RegionOrigine
        {
            get
            {
                return _regionOrigine;
            }

            set
            {
                _regionOrigine = value;
            }
        }

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
    }
}
