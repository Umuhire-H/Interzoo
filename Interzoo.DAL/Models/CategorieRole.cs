using Interzoo.DAL.Infra;
using Interzoo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Models
{
    public class CategorieRole : IEntity <CompositeKey<int, int>>
    {
        private int _idCategorie;
        private int _idRole;

        public int IdCategorie { get => _idCategorie; set => _idCategorie = value; }
        public int IdRole { get => _idRole; set => _idRole = value; }
    }
}
