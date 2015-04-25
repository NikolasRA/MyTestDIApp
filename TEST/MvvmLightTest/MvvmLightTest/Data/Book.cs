using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmLightTest.Common.Data;

namespace MvvmLightTest.Data
{
  public  class BookEntity:IEntity
    {
      public int ID { get; private set; }
      public string Author { get; set; }
      public string Book { get; set; }
    }
}
