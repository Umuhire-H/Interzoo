using Interzoo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Models
{
    public class Role : IEntity<int>
    {
        private int _idRole;
        private string _typeRole;

        public int IdRole { get => _idRole; set => _idRole = value; }
        public string TypeRole { get => _typeRole; set => _typeRole = value; }
    }
}
