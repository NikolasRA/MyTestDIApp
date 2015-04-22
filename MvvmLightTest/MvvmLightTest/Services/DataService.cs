using System.Collections.Generic;
using AutoMapper;
using MvvmLightTest.Model;

namespace MvvmLightTest.Services
{
    public class DataService<TEntity> : IDataService where TEntity : RepoBook
    {
        private readonly IRepository _repository;

        public DataService(IRepository repository)
        {
            _repository = repository;
            Mapper.CreateMap<List<DataBooks>, List<TEntity>>();
            Mapper.CreateMap<TEntity, DataBooks>().ReverseMap();
        }

        public DataBooks Reverse<T>(T value)
        {
            return Mapper.DynamicMap<T, DataBooks>(value);
        }

        public T Set<T>(DataBooks source) where T : class, new()
        {
            return Mapper.Map<DataBooks, T>(source);
        }

        public List<DataBooks> GetBooks()
        {
            return Mapper.Map<List<DataBooks>>(_repository.GetBooks());
        }

        public void AddBook(DataBooks book)
        {
            var b = Mapper.Map<TEntity>(book);
            _repository.AddBook(b);
            book.Id = b.Id;
        }

        public DataBooks GetById(object Id)
        {
            return Mapper.Map<DataBooks>(_repository.GetById(Id));
        }

        public void RemoveBook(DataBooks book)
        {
            _repository.RemoveBook(Mapper.Map<TEntity>(book));
        }

        public void ModifyBook(DataBooks book)
        {
            var b = Mapper.Map<TEntity>(book);
            _repository.RemoveBook(b);
            _repository.AddBook(b);
            book.Id = b.Id;
        }
    }
}