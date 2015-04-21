using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoMapper;
using MvvmLightTest.ViewModel.Repository;

namespace MvvmLightTest.Model
{
    public class DataService<TEntity, TDB>:IDataService<TEntity> where TEntity : class, IBook, new()
        where TDB : DbContext, new()
    {
       
        private DbContext _dataBase;


        public DataService()
        {
            _dataBase = new TDB();
          
        }


        private IDbSet<TEntity> Entities
        {
            get { return _dataBase.Set<TEntity>(); }
        }

        
        public ObservableCollection<TEntity> GetBooks()
        {
            return  new ObservableCollection<TEntity>(Entities.AsQueryable());
        }

        
        public void AddBook(TEntity book)
        {
            Entities.Add(book);
           _dataBase.SaveChanges();
        }

        public TEntity GetById(object Id)
        {
            return Entities.Find(Id);
        }

        public void RemoveBook(TEntity book)
        {
            Entities.Remove(GetById(book.ID));
            _dataBase.SaveChanges();
        }

        public void ModifyBook(TEntity book)
        {
            var b = GetById(book.ID);
            b.Author = book.Author;
            b.Book = book.Book;
            _dataBase.SaveChanges();
            book.ID = b.ID;
        }

    }
}