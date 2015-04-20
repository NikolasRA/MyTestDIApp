using System.Linq;

namespace TEST1_.DataService
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll(); //Прописування методів CRUD в даному разі без Update
        TEntity GetById(object id);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
