using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using MvvmLightTest.ViewModel.Repository;

namespace MvvmLightTest.Model
{
    public interface IDataService
    {
        ObservableCollection<VMBooks> GetBooks();
        void AddBook(VMBooks book);
        void RemoveBook(VMBooks book);
        void ModifyBook(VMBooks book);
        VMBooks GetById(object Id);
    }
}
