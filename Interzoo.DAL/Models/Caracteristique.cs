using Interzoo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Models
{
    public class Caracteristique : IEntity<int>
    {
        private int _idCaracteristique;
        private string _typeCaracteristique;

        public int IdCaracteristique { get => _idCaracteristique; set => _idCaracteristique = value; }
        public string TypeCaracteristique { get => _typeCaracteristique; set => _typeCaracteristique = value; }
    }
}
