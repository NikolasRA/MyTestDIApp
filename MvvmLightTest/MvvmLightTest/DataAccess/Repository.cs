using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using MvvmLightTest.Common.Data;

namespace MvvmLightTest.DataAccess
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _table;

        public Repository(DbContext dbContext)
        {
            _context = dbContext;
            _table = _context.Set<T>();
        }

        public IQueryable<T> Items
        {
            get { return _table; }
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
            _table.AddOrUpdate(i => i.Id, item);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}