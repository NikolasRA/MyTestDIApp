using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;

namespace MvvmLightTest.Services
{
    public class RepositoryService<TEntity> : IRepository where TEntity : class
    {
        private readonly DbContext _dataBase;

        public RepositoryService(DbContext dataBase)
        {
            _dataBase = dataBase;
            Mapper.CreateMap<TEntity, RepoBook>().ReverseMap();
        }

        private IDbSet<TEntity> Entities
        {
            get { return _dataBase.Set<TEntity>(); }
        }

        public List<RepoBook> GetBooks()
        {
            return Entities.AsQueryable().Select(item => Mapper.Map<RepoBook>(item)).ToList();
        }

        public void AddBook(RepoBook book)
        {
            var b = Mapper.Map<TEntity>(book);
            Entities.Add(b);
            _dataBase.SaveChanges();
            book.Id = Mapper.Map<RepoBook>(b).Id;
        }

        public RepoBook GetById(object id)
        {
            return Mapper.Map<RepoBook>(Entities.Find(id));
        }

        public void RemoveBook(RepoBook book)
        {
            Entities.Remove(Entities.Find(book.Id));
            _dataBase.SaveChanges();
        }
    }
}