using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class AnimalCaracteristiqueModel
    {
        private int _idAnimal;
        private int _idCaracteristique;
        private string _nomCaracteristique;
        
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

        public int IdCaracteristique
        {
            get
            {
                return _idCaracteristique;
            }

            set
            {
                _idCaracteristique = value;
            }
        }

        public string NomCaracteristique
        {
            get
            {
                return _nomCaracteristique;
            }

            set
            {
                _nomCaracteristique = value;
            }
        }
        // extras
        public IEnumerable<AnimalCaracteristiqueModel> caracteristiquesValuesOneAnimal
        {
            get; set;
        }
    }
}