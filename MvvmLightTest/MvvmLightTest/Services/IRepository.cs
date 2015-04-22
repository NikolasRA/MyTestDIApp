using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using MvvmLightTest.ViewModel.Repository;
using MvvmLightTest.ViewModel.Services;

namespace MvvmLightTest.Model
{
    public interface IRepository
    {
        List<RepoBook> GetBooks();
        void AddBook(RepoBook book);
        void RemoveBook(RepoBook book);
        RepoBook GetById(object Id);
    }
}
