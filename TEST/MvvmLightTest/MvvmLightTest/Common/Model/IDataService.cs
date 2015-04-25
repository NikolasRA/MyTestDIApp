using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmLightTest.Common.Data;
using MvvmLightTest.Model;

namespace MvvmLightTest.Common.Model
{
    public interface IDataService
    {
        List<DataItem> GetItems { get; }
        void AddItem(DataItem item);
        void RemoveItem(DataItem item);
        void ModifyItem(DataItem item);
        T ConvertItem<T>(DataItem item) where T : class;
        DataItem ConvertItem<T>(T item) where T : class;
        List<T> ConvertItem<T>(List<DataItem> items) where T : class;
        
    }
}
