using System.ComponentModel;

namespace MvvmLightTest.ViewModel.Repository
{
   public interface IBook:INotifyPropertyChanged
   {
       int ID { get; set; }
       string Author { get; set; }
       string Book { get; set; }
       
   }


}
