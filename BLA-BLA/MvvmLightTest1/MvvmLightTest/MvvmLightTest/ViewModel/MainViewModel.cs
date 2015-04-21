using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Windows.Input;
using AutoMapper;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using MvvmLightTest.Model;
using MvvmLightTest.ViewModel.Repository;

namespace MvvmLightTest.ViewModel
{
    /// <summary>
    ///     This class contains properties that the main View can data bind to.
    ///     <para>
    ///         See http://www.galasoft.ch/mvvm
    ///     </para>
    /// </summary>
    public class MainViewModel<TEntity> : ViewModelBase where TEntity : class,IBook, new()
    {

        #region DataFields

        

       private IDataService<TEntity> _dataService;
       


        /// <summary>
        /// Type to make some actions with books
        /// </summary>
        private TEntity _book;

        /// <summary>
        /// Index of data from ListView
        /// </summary>
        private int _index;

  
        #endregion


        /// <summary>
        ///     Initializes a new instance of the MainViewModel class. Initializes DataFields
        /// </summary>
        public MainViewModel(IDataService<TEntity> dataService)
        {

            _book = new TEntity();
            Books = dataService.GetBooks();
            _index = 0;
            _dataService = dataService;

            Add = new RelayCommand(() =>
            {

                var add = GetClone(_book);
                Books.Add(add);
                _dataService.AddBook(add);

            });
            Remove = new RelayCommand(() =>
            {
                if (_index < Books.Count && _index >= 0)
                {
                    
                    _dataService.RemoveBook(Books[Index]);
                    Books.RemoveAt(Index);
                }

            });

            Modify = new RelayCommand(() =>
            {
                GetClone(Book, Books[Index]);
                _dataService.ModifyBook(Books[Index]);

            });


        }


        #region Commands

        /// <summary>
        /// Commands to run
        /// </summary>
        public ICommand Add { get; private set; }


        public ICommand Remove { get; private set; }


        public ICommand Modify { get; private set; }


        #endregion


        private TEntity GetClone(TEntity book)
        {
            return new TEntity(){Author = book.Author, Book = book.Book};
        }

        private void GetClone(TEntity from, TEntity to)
        {
            to.Book = from.Book;
            to.Author = from.Author;
        }

        #region BindindData

        /// <summary>
        /// Collection to display content
        /// </summary>
        public ObservableCollection<TEntity> Books { get; set; }

        /// <summary>
        /// To make some actions with books
        /// </summary>
        public TEntity Book
        {
            get { return _book; }
            set
            {
                _book = value;
                RaisePropertyChanged(() => Book);
            }
        }


        /// <summary>
        /// Selected index from the ListView
        /// </summary>
        public int Index
        {
            get { return _index; }

            set
            {
                _index = value;
                if (_index < Books.Count && _index >= 0)
                {
            //        Book = new Books(Books[_index]);
                    Book = GetClone(Books[Index]);
                }
                RaisePropertyChanged(() => Index);

            }
        }

        #endregion
    }
}