using Interzoo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Models
{
    public class FlashCadeau : IEntity<int>
    {
        private int _idFlashCadeau;
        private string _nom;
        private string _contenu;
        private DateTime _dateDebut;
        private DateTime _dateFin;

        public int IdFlashCadeau { get => _idFlashCadeau; set => _idFlashCadeau = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Contenu { get => _contenu; set => _contenu = value; }
        public DateTime DateDebut { get => _dateDebut; set => _dateDebut = value; }
        public DateTime DateFin { get => _dateFin; set => _dateFin = value; }
    }
}
