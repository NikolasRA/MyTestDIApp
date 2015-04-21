using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using MvvmLightTest.Model;
using MvvmLightTest.ViewModel.Repository;

namespace MvvmLightTest.Design
{
    public class DesignDataService<TEntity>:IDataService<TEntity> where TEntity : class,IBook
    {
       

        public ObservableCollection<TEntity> GetBooks()
        {
            throw new NotImplementedException();
        }

        public void AddBook(TEntity book)
        {
            throw new NotImplementedException();
        }

        public void RemoveBook(TEntity book)
        {
            throw new NotImplementedException();
        }

        public void ModifyBook(TEntity book)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(object Id)
        {
            throw new NotImplementedException();
        }
    }
}