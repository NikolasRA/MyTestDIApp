using GalaSoft.MvvmLight;

namespace MvvmLightTest.ViewModel
{
    public class ViewBooks : ObservableObject
    {
        private int _id;
        private string _author, _book;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged(() => Id);
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
