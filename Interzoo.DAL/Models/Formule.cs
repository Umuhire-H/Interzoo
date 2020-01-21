﻿using Interzoo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Models
{
    public class Formule : IEntity<int>
    {
        private int _idFormule;
        private string _nom;
        private string _description;
        private double _prix;
        private DateTime _dateDebut;
        private DateTime _dateFin;

        public int IdFormule { get => _idFormule; set => _idFormule = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Description { get => _description; set => _description = value; }
        public double Prix { get => _prix; set => _prix = value; }
        public DateTime DateDebut { get => _dateDebut; set => _dateDebut = value; }
        public DateTime DateFin { get => _dateFin; set => _dateFin = value; }
    }
}
