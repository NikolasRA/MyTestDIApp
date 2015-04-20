using System;
using System.Data.Entity;
using TEST1_.Data;
using TEST1_.DataService;
using TEST1_.Model;

namespace TEST1_.Design
{
    public class DesignDataService : IDataService
    {
        //public void GetData(Action<DataItem, Exception> callback)
        //{
        //    // Use this to create design time data

        //    var item = new DataItem("Welcome to MVVM Light [design]");
        //    callback(item, null);
        //}
        public void GetData(Action<DataItem, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public RepositoryService<Dog> GetDogs(DbContext dataContext)
        {
            throw new NotImplementedException();
        }

        public DbContext GetDb()
        {
            throw new NotImplementedException();
        }

        public IElement GetDog()
        {
            throw new NotImplementedException();
        }
    }
}