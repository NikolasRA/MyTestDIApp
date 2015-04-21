using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using MvvmLightTest.Model;
using MvvmLightTest.ViewModel.Repository;

namespace MvvmLightTest.Design
{
    public class DesignDataService:  IDataService
    {
        

        public ObservableCollection<VMBooks> GetBooks()
        {
            throw new NotImplementedException();
        }

        public void AddBook(VMBooks book)
        {
            throw new NotImplementedException();
        }

        public void RemoveBook(VMBooks book)
        {
            throw new NotImplementedException();
        }

        public void ModifyBook(VMBooks book)
        {
            throw new NotImplementedException();
        }

        public VMBooks GetById(object Id)
        {
            throw new NotImplementedException();
        }
    }
}