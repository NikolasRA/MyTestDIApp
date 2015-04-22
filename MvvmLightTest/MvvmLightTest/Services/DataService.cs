using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoMapper;
using MvvmLightTest.ViewModel.Repository;
using MvvmLightTest.ViewModel.Services;

namespace MvvmLightTest.Model
{
    public class DataService<TEntity>:IDataService where TEntity : RepoBook
    {
        private IRepository _repository;

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

        public T Set<T>(DataBooks source) where T:class, new()
        {
          T item = new T();
            item =  Mapper.Map<DataBooks,T>(source);
            return item;
        }


        public List<DataBooks> GetBooks()
        {
            return Mapper.Map<List<DataBooks>>(_repository.GetBooks()); //Mapper.Map<ObservableCollection<ViewBooks>>(_repository.GetBooks());
        }


        public void AddBook(DataBooks book)
        {
            var b = Mapper.Map<TEntity>(book);
           _repository.AddBook(b);
            book.ID = b.ID;
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
            book.ID = b.ID;
        }

    }
}