using System.Collections.Generic;
using AutoMapper;
using MvvmLightTest.Common.Data;
using MvvmLightTest.Data;
using MvvmLightTest.Model;

namespace MvvmLightTest.Services
{
    public class DataService<TEntity> : IDataService where TEntity : RepoBook
    {
        private readonly IRepository<Book> _repository;

        public DataService(IRepository<Book> repository)
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
            return Mapper.Map<List<DataBooks>>(_repository.Items);
        }

        public void AddBook(DataBooks book)
        {
            var b = Mapper.Map<TEntity>(book);
            _repository.Add(new Book());
            book.Id = b.Id;
        }

        public DataBooks GetById(object Id)
        {
            return Mapper.Map<DataBooks>(null);
        }

        public void RemoveBook(DataBooks book)
        {
            _repository.Remove(new Book
            {

            });
        }

        public void ModifyBook(DataBooks book)
        {
            var b = Mapper.Map<TEntity>(book);
            _repository.Remove(null);
            _repository.Add(null);
            book.Id = b.Id;
        }
    }
}