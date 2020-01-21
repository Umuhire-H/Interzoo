using Interzoo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Models
{
    public class Parrain : IEntity<int>
    {
                
        private int _idParrain;
        private int _idFomule;
        private int _idUtilisateur;

        public int IdUtilisateur
        {
            get { return _idUtilisateur; }
            set { _idUtilisateur = value; }
        }

        public int IdFomule
        {
            get { return _idFomule; }
            set { _idFomule = value; }
        }

        public int IdParrain
        {
            get { return _idParrain; }
            set { _idParrain = value; }
        }

    }
}
