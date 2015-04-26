using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using AutoMapper;
using MvvmLightTest.Common.Data;
using MvvmLightTest.Common.Model;
using MvvmLightTest.Data;

namespace MvvmLightTest.Model
{
    public class DataService : IDataService
    {
        private IRepository<BookEntity> _repo;

        public DataService(IRepository<BookEntity> repo)
        {
            _repo = repo;

        }

        public List<DataItem> GetItems
        {
            get
            {

                List<DataItem> list = new List<DataItem>();
                foreach (var item in _repo.Items)
                {
                    list.Add(ConvertItem(item));

                }

                return list;
            }
        }

        public void AddItem(DataItem item)
        {

            var item_ = ConvertItem<BookEntity>(item);
            _repo.Add(item_);
            item.Id = item_.ID;
        }

        public void RemoveItem(DataItem item)
        {
            _repo.Remove(_repo.GetById(item.Id));
        }

        public void ModifyItem(DataItem item)
        {
            _repo.Update(ConvertItem<BookEntity>(item));
        }

        public T1 ConvertItem<T1>(DataItem item) where T1 : class
        {
            return Mapper.DynamicMap<DataItem, T1>(item);
        }

        public DataItem ConvertItem<T1>(T1 item) where T1 : class
        {
            return Mapper.DynamicMap<T1, DataItem>(item);
        }

        public List<T1> ConvertItem<T1>(List<DataItem> items) where T1 : class
        {
            return items.Select(item => Mapper.DynamicMap<T1>(item)).ToList();
        }
    }
}