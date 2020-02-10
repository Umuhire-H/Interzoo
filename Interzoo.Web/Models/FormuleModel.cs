using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class FormuleModel
    {
        private int _idFormule;
        private string _nom;
        private string _description;
        private double _prix;
        private DateTime _dateDebut;
        private DateTime _dateFin;

        public int IdFormule
        {
            get
            {
                return _idFormule;
            }

            set
            {
                _idFormule = value;
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

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public double Prix
        {
            get
            {
                return _prix;
            }

            set
            {
                _prix = value;
            }
        }

        public DateTime DateDebut
        {
            get
            {
                return _dateDebut;
            }

            set
            {
                _dateDebut = value;
            }
        }

        public DateTime DateFin
        {
            get
            {
                return _dateFin;
            }

            set
            {
                _dateFin = value;
            }
        }
        // extras
        public IEnumerable<FormuleModel> FormulesOneUtilisateur
        {
            get; set;
        }
    }
}