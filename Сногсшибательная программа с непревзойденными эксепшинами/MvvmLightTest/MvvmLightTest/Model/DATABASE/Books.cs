using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GalaSoft.MvvmLight;
using MvvmLightTest.ViewModel.Repository;

namespace MvvmLightTest
{
    public class Books
    {
      
        public int ID {get; set;}

        public string Author {get; set;}

        public string Book { get; set; }
    }
}