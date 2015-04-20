using System;
using System.Data.Entity;
using TEST1_.Data;
using TEST1_.DataService;

namespace TEST1_.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
        RepositoryService<Dog> GetDogs(DbContext dataContext);
        DbContext GetDb();

        IElement GetDog();
    }
}
