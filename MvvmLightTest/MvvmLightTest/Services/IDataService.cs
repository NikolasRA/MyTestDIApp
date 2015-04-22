using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using MvvmLightTest.Services;

namespace MvvmLightTest.Model
{
    public interface IDataService
    {
        List<DataBooks> GetBooks();
        void AddBook(DataBooks book);
        void RemoveBook(DataBooks book);
        void ModifyBook(DataBooks book);
        DataBooks GetById(object Id);
        T Set<T>(DataBooks source) where T : class, new();
        DataBooks Reverse<T>(T value);

    }
}
