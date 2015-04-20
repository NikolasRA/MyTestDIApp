using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Runtime.InteropServices;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Ninject;
using Ninject.Parameters;
using TEST1_.Data;
using TEST1_.DataService;
using TEST1_.Model;

namespace TEST1_.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        //public MyTable ttt;
     //   private readonly IDataService _dataService; //проміжна база для звернення 
     //   private IRepository<IElement> _dogs; //таблиця 
        private ObservableCollection<IElement> _dogs_col; //таблиця відображення
        public RelayCommand<IElement> AddCommand { get; set; } //команда додавання
        public RelayCommand<int> DelCommand { get; set; } //команда видалення
        int _id;
        IElement _dog; //контейнер для збору даних з форми
   /*     public ObservableCollection<IElement> Dogs
        {
            get { return _dogs_col; }
            set
            {
                _dogs_col = value;
                RaisePropertyChanged("Dogs");
            }
        }*/
        /*public IElement Dog
        {
            get
            {
                return _dog;
            }
            set
            {
                _dog = value;
                RaisePropertyChanged("Dog");
            }
        }*/
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChanged("ID");
            }
        }
      /* void Add_dog(IElement puppy)
        {
            try
            {
                if (!puppy.Equals(null))
                {
                    
                    dogs.Add(puppy);
                    Dogs.Add(puppy);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Something happens with the base:((");
            }

        }*/
        void Del_dog(int ID)
        {
            try
            {
                if (!ID.Equals(null))
                {
                    _dogs.Remove(Dogs[ID]);
                    Dogs.RemoveAt(ID);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Chose element");

            }

        }
        public MainViewModel(IDataService dataService, IElement dog)
        {
            
          //  _dogs = new RepositoryService<IElement>(new Entities());//загружаэмо у вьюмодель
            //_dogs_col =new ObservableCollection<IElement>(_dogs.GetAll());//загружаємо у view
            
            var dogs = dataService.GetDogs(dataService.GetDb());
            AddCommand = new RelayCommand(() =>
            {
                dogs.Add(dog);
                //Dogs.Add(puppy);
            });//ініціалізуємо додавання
            //DelCommand = new RelayCommand<int>(Del_dog);//ініціалізуємо видалення
            _dataService = dataService; //копіюємо дані у проміжний DataService і перевіряємо
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        return;
                    }
                });
        }
        

    }
 /*   public class MyDependencyResolver: IDbDependencyResolver
    {
        private IKernel _kernel;

        public MyDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }
        public object GetService(Type serviceType, object key)
        {
            return _kernel.TryGet(serviceType, new IParameter[0]);
        }

        public IEnumerable<object> GetServices(Type serviceType, object key)
        {
            return _kernel.GetAll(serviceType, new IParameter[0]);
        }
    }*/
}