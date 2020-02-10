using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interzoo.Web.Models
{
    public class CaracteristiqueModel
    {
        private int _idCaracteristique;
        private string _typeCaracteristique;

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

        public string TypeCaracteristique
        {
            get
            {
                return _typeCaracteristique;
            }

            set
            {
                _typeCaracteristique = value;
            }
        }
        public IEnumerable<CaracteristiqueModel> caracteristiquesOneAnimal // getAllCaractTYPEOfOneAnimal
        {
            get; set;
        }
    }
}