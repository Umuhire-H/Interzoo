using Interzoo.DAL.Infra;
using Interzoo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Models
{
    public class AnimalParrain : IEntity <CompositeKey <int, int>>
    {
		private int _idAnimal;
		private int _idParrain;


		public int IdAnimal
		{
			get { return _idAnimal; }
			set { _idAnimal = value; }
		}
		public int IdParrain
		{
			get { return _idParrain; }
			set { _idParrain = value; }
		}

	}
}
