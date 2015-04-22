using System.Collections.Generic;

namespace MvvmLightTest.Services
{
    public interface IRepository
    {
        List<RepoBook> GetBooks();

        void AddBook(RepoBook book);

        void RemoveBook(RepoBook book);

        RepoBook GetById(object id);
    }
}
