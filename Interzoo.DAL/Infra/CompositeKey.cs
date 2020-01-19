using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Infra
{
    public struct CompositeKey<T, U>
    {
        public T PK1;
        public U PK2;
    }
   
}
