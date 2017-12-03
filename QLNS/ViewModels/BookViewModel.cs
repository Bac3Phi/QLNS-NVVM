using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using QLNS.Annotations;
using QLNS.Commands;
using QLNS.Models;

namespace QLNS.ViewModels
{
    class BookViewModel: INotifyPropertyChanged
    {
     public ICommand AddCommand
        {
            get
            {
                return new RelayCommand<object>(
                    null, // CanExecute()
                    book =>
                    {
                        AddBook(NewBook);
                        NewBook =  new BookModel();
                    }
                );
            }
        }

        public ICommand RemoveComand
        {
            get
            {
                return new RelayCommand<object>(
                    null,
                    book => RemoveBook(SelectedBook)
                    );
            }
        }
        

        public ObservableCollection<BookModel> ListBook
        {
            get => _listBooks;
            set
            {
                _listBooks = value;
                OnPropertyChanged(nameof(ListBook));
            }
        }

        private BookModel _selectedBook;

        public BookModel SelectedBook
        {
            get { return _selectedBook; }
            set
            {

                _selectedBook = value;
                if (value == null)
                {
                    NewBook = new BookModel();
                }
                else
                {
                    NewBook = SelectedBook;
                }
                OnPropertyChanged(nameof(SelectedBook));

            }
        }

        private BookModel _newBook;

        public BookModel NewBook
        {
            get { return _newBook; }
            set
            {
                _newBook = value;
                OnPropertyChanged(nameof(NewBook));
            }
        }

        private ObservableCollection<BookModel> _listBooks;

        public BookViewModel()
        {
           _listBooks = new ObservableCollection<BookModel>();

            ListBook.Add(new BookModel
            {
                Category = "Test1",
                Name = "ABC",
                Price = 5,
                Quantity = 10,
                Author = "Phong"

            });

            ListBook.Add(new BookModel
            {
                Category = "Test5",
                Name = "DEF",
                Price = 5,
                Quantity = 10,
                Author = "Phong"
            });

            NewBook =  new BookModel();
        }

        public void AddBook(BookModel book)
        {
            if (ListBook.Contains(book))
            {
                return;
            }
            ListBook.Add(book);
        }

        public void RemoveBook(BookModel book)
        {
            if (book != null)
            {
                ListBook.Remove(book);
            }
        }

 

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
