using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows.Documents;
using AutoMapper;
using MvvmLightTest.ViewModel.Repository;
using MvvmLightTest.ViewModel.Services;

namespace MvvmLightTest.Model
{
    public class RepositoryService<TEntity>:IRepository  where TEntity : class
    {
       
        private DbContext _dataBase;


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
           List<RepoBook> list = new List<RepoBook>();

            foreach (var item in Entities.AsQueryable())
            {
                list.Add(Mapper.Map<RepoBook>(item));                
            }
            return list;
        }


        public void AddBook(RepoBook book)
        {
            var b = Mapper.Map<TEntity>(book);
            Entities.Add(b);
           _dataBase.SaveChanges();
            book.ID = Mapper.Map<RepoBook>(b).ID;
        }

       
        public RepoBook GetById(object Id)
        {
            return Mapper.Map<RepoBook>(Entities.Find(Id));
        }

        public void RemoveBook(RepoBook book)
        {
            Entities.Remove(Entities.Find(book.ID));
            _dataBase.SaveChanges();
        }

       
    }
}