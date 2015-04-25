using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MvvmLightTest.Common.Data;

namespace MvvmLightTest.DataAccess
{
   public class Repository<T>:IDisposable, IRepository<T>where T:class,IEntity
   {
       private DbContext _context;
       private DbSet<T> _table;

       public Repository(DbContext dataBase)
       {
           _context = dataBase;
           _table = _context.Set<T>();
       } 


       public IQueryable<T> Items {
           get { return _table.AsQueryable(); }
       }
       public void Add(T item)
       {
           _table.Add(item);
           _context.SaveChanges();
       }

       public T GetById(int id)
       {
           return _table.Find(id);
       }

       public void Remove(T item)
       {
           _table.Remove(item);
           _context.SaveChanges();
       }

       public void Update(T item)
       {
           _table.AddOrUpdate(i=>i.ID,item);
           _context.SaveChanges();
       }

       public void Dispose()
       {
           _context.Dispose();
       }
   }
}
