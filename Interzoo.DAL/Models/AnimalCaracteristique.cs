using Interzoo.DAL.Infra;
using Interzoo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Models
{
    class AnimalCaracteristique : IEntity<CompositeKey<int, int>>
    {
        private int _idAnimal;
        private int _idCaracteristique;
        private string _nomCaracteristique;

        public int IdAnimal { get => _idAnimal; set => _idAnimal = value; }
        public int IdCaracteristique { get => _idCaracteristique; set => _idCaracteristique = value; }
        public string NomCaracteristique { get => _nomCaracteristique; set => _nomCaracteristique = value; }
    }
}
