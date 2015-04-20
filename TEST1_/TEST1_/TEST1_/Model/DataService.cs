using System;
using System.Data.Entity;
using TEST1_.Data;
using TEST1_.DataService;

namespace TEST1_.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }

       public RepositoryService<Dog> GetDogs(DbContext dataContext)
        {
            return new RepositoryService<Dog>(dataContext);
        }

       public DbContext GetDb()
        {
            return new Entities();
        }

        public IElement GetDog()
        {
            return new Dog();
        }
    }
}