using Interzoo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Models
{
    public class Categorie:IEntity<int>
    {
		private int _idCategorie;
		private string _typeCategorie;

		


		public int IdCategorie
		{
			get { return _idCategorie; }
			set { _idCategorie = value; }
		}
		public string TypeCategorie
		{
			get { return _typeCategorie; }
			set { _typeCategorie = value; }
		}
	}
}
