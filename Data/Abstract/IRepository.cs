using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cennet_Emlak.Data.Abstract
{
    public interface IRepository<T>
    {
        IQueryable<T> Values {get;}
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}