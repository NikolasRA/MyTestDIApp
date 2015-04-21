using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using MvvmLightTest.ViewModel.Repository;

namespace MvvmLightTest.Model
{
    public interface IDataService<TEntity> where TEntity:class,IBook
    {
        ObservableCollection<TEntity> GetBooks();
        void AddBook(TEntity book);
        void RemoveBook(TEntity book);
        void ModifyBook(TEntity book);
        TEntity GetById(object Id);
    }
}
