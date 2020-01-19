using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interzoo.DAL.Interfaces
{
    public interface IRepository<T, TKey> where T:IEntity<TKey>, new() where TKey : struct
    {
        IEnumerable<T> getAll();
        T getOne(TKey id);
        T insert(T toInsert);
        bool update(T toUpdate);
        bool delete(TKey id);
    }
}
