using Interzoo.DAL.Infra;
using Interzoo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Models
{
    public class FlashCadeauFormule : IEntity<CompositeKey<int, int>>
    {
        private int _idFlashCadeau;
        private int _idFormule;

        public int IdFlashCadeau { get => _idFlashCadeau; set => _idFlashCadeau = value; }
        public int IdFormule { get => _idFormule; set => _idFormule = value; }
    }
  
}
