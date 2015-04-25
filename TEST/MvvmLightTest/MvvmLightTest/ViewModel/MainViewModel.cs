using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AutoMapper;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmLightTest.Common.Data;
using MvvmLightTest.Common.Model;
using MvvmLightTest.Model;


namespace MvvmLightTest.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        #region DataFields



        private IDataService _dataService;


        /// <summary>
        /// Type to make some actions with books
        /// </summary>
        private ViewBooks _book;

        /// <summary>
        /// Index of data from ListView
        /// </summary>
        private int _index;


        #endregion

        public MainViewModel(IDataService dataService)
        {
            _book = new ViewBooks();

            Books = new ObservableCollection<ViewBooks>(dataService.ConvertItem<ViewBooks>(dataService.GetItems));

          

            _index = 0;
            _dataService = dataService;

            Add = new RelayCommand(() =>
            {

                var add = GetClone(_book);
                Books.Add(add);
                var InsertItem = _dataService.ConvertItem<ViewBooks>(add);
                _dataService.AddItem(InsertItem);
                add.Id = InsertItem.Id;


            });
            Remove = new RelayCommand(() =>
            {
                if (_index < Books.Count && _index >= 0)
                {

                    _dataService.RemoveItem(_dataService.ConvertItem<ViewBooks>(Books[Index]));
                    Books.RemoveAt(Index);
                }

            });

            Modify = new RelayCommand(() =>
            {
                GetClone(Book, Books[Index]);
                _dataService.ModifyItem(_dataService.ConvertItem(Books[Index]));

            });
        }

        #region Commands

        public ICommand Add { get; private set; }

        public ICommand Remove { get; private set; }

        public ICommand Modify { get; private set; }

        #endregion

        private ViewBooks GetClone(ViewBooks book)
        {
            return new ViewBooks() { Author = book.Author, Book = book.Book };
        }

        private void GetClone(ViewBooks from, ViewBooks to)
        {
            to.Book = from.Book;
            to.Author = from.Author;
        }

        #region BindindData

        public ObservableCollection<ViewBooks> Books { get; set; }

        public ViewBooks Book
        {
            get { return _book; }
            set
            {
                _book = value;
                RaisePropertyChanged(() => Book);
            }
        }

        public int Index
        {
            get { return _index; }

            set
            {
                _index = value;
                if (_index < Books.Count && _index >= 0)
                {
                    Book = GetClone(Books[Index]);
                }
                RaisePropertyChanged(() => Index);
            }
        }

        #endregion
    }
}