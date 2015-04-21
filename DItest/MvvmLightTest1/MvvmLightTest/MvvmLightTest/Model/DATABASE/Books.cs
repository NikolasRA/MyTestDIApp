using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GalaSoft.MvvmLight;
using MvvmLightTest.ViewModel.Repository;

namespace MvvmLightTest
{
    public class Books:ObservableObject, IBook
    {


        //public int ID { get; set; }

        //[Column(TypeName = "text")]
        //public string Author { get; set; }

        //[Column(TypeName = "text")]
        //[Required]
        //public string Book { get; set; }

        private int _id;
        private string _author, _book;

        public Books(string author, string book)
        {

            this._book = book;
            this._author = author;
            this._id = 0;
        }
        public Books(Books book) : this(book.Author, book.Book) { }
        public Books() : this("none", "none") { }

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChanged(() => ID);
            }
        }

        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                RaisePropertyChanged(() => Author);
            }
        }

       public string Book
        {
            get { return _book; }
            set
            {
                _book = value;
                RaisePropertyChanged(() => Book);
            }
        }
    }
}