using System.Data.Entity;
using System.Linq;
using Ninject;
using TEST1_.Data;

namespace TEST1_.DataService
{
    //імплементація методів
    public class RepositoryService<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _dataBase;
      //  public IKerne
        public RepositoryService(DbContext dataBase)
        {
            _dataBase = dataBase;
          /*  IKernel kernel = new StandardKernel();
            kernel.Bind<IElement>().To<Dog>();
            kernel.Bind<IRepository<IElement>>().To<RepositoryService<IElement>>();*/

           
        }
        private DbSet<TEntity> Entities
        {
            get { return _dataBase.Set<TEntity>(); }
        }
        public IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }
        public void Add(TEntity entity)
        {
            Entities.Add(entity);
            _dataBase.SaveChanges();
        }
        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
            _dataBase.SaveChanges();
        }
        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }
    }
}
