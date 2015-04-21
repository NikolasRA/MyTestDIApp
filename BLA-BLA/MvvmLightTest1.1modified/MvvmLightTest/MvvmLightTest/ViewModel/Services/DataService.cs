using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoMapper;
using MvvmLightTest.ViewModel.Repository;

namespace MvvmLightTest.Model
{
    public class DataService<TEntity, TDB>:IDataService where TEntity : class, IBook, new()
        where TDB : DbContext, new()
    {
       
        private DbContext _dataBase;


        public DataService()
        {
            _dataBase = new TDB();
            Mapper.CreateMap<ObservableCollection<VMBooks>, IQueryable<TEntity>>();
            Mapper.CreateMap<TEntity, VMBooks>().ReverseMap();
          
        }


        private IDbSet<TEntity> Entities
        {
            get { return _dataBase.Set<TEntity>(); }
        }

        
        public ObservableCollection<VMBooks> GetBooks()
        {
            return   Mapper.Map<ObservableCollection<VMBooks>>(Entities.AsQueryable());
        }

        
        public void AddBook(VMBooks book)
        {
            var b = Mapper.Map<TEntity>(book);
            Entities.Add(b);
           _dataBase.SaveChanges();
            book.ID = b.ID;
        }

        public VMBooks GetById(object Id)
        {
            return Mapper.Map<VMBooks>(Entities.Find(Id));
        }

        public void RemoveBook(VMBooks book)
        {
            Entities.Remove(Entities.Find(book.ID));
            _dataBase.SaveChanges();
        }

        public void ModifyBook(VMBooks book)
        {
            var b = Entities.Find(book.ID);
            b.Author = book.Author;
            b.Book = book.Book;
            _dataBase.SaveChanges();
            book.ID = b.ID;
        }

    }
}