using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLightTest.Common.Data
{
  public  interface IRepository<T> where T:IEntity
    {
        IQueryable<T> Items { get; }

        void Add(T item);

        T GetById(int id);

        void Remove(T item);

        void Update(T item);
    }
}
