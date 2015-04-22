using System.Collections.ObjectModel;
using System.Windows.Input;
using AutoMapper;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmLightTest.Model;
using MvvmLightTest.Services;

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
            Mapper.CreateMap<DataBooks, ViewBooks>().ReverseMap();

            _book = new ViewBooks();

            Books = new ObservableCollection<ViewBooks>();

            foreach (var book in dataService.GetBooks())
            {
                //Null reference Exception!
                Books.Add(_dataService.Set<ViewBooks>(book));
            }

            _index = 0;
            _dataService = dataService;

            Add = new RelayCommand(() =>
            {

                var add = GetClone(_book);
                Books.Add(add);
                var toService = _dataService.Reverse(add);
                _dataService.AddBook(toService);
                add.Id = toService.Id;

            });
            Remove = new RelayCommand(() =>
            {
                if (_index < Books.Count && _index >= 0)
                {

                    _dataService.RemoveBook(_dataService.Reverse(Books[Index]));
                    Books.RemoveAt(Index);
                }

            });

            Modify = new RelayCommand(() =>
            {
                GetClone(Book, Books[Index]);
                _dataService.ModifyBook(Mapper.Map<DataBooks>(Books[Index]));

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