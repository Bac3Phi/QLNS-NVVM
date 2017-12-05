using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
     public ICommand UpdateCommand   // Update Quantity
        {
            get
            {
                return new RelayCommand<object>(
                    null, // CanExecute()
                    book =>
                    {
                        SelectedBook.Quantity += AddionalQuantity;
                        AddionalQuantity = 0;
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

        public int AddionalQuantity {
            get => _addionalQuantity;
            set {
                _addionalQuantity = value;
                OnPropertyChanged(nameof(AddionalQuantity));
            } }

        private int _addionalQuantity ;

        private ObservableCollection<BookModel> _listBooks;

        public BookViewModel()
        {
           _listBooks = new ObservableCollection<BookModel>();

            ReadBookData();
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

        public void WriteBookData()
        {
            using (StreamWriter sw = new StreamWriter("BookData.txt"))

                foreach (BookModel book in ListBook)
                {
                    try
                    {
                        sw.WriteLine("@  " + book.Name);
                        sw.WriteLine("@! " + book.Category);
                        sw.WriteLine("@@ " + book.Author);
                        sw.WriteLine("@# " + book.Price.ToString());
                        sw.WriteLine("@$ " + book.Quantity.ToString());
                        sw.WriteLine(Environment.NewLine); // 2 cai xuong dong
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Can't write data!!!");
                    }

                }
        }

        public void ReadBookData()
        {
            String data = "";
            try
            {
                using (StreamReader sw = new StreamReader("BookData.txt"))
                {
                    data = sw.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Can't read data!!!");
            }
           

            String[] fullbook = data.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (String book in fullbook)
            {

                String[] bookdata = book.Split(new string[] { Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                BookModel _book = new BookModel();
                foreach (String property in bookdata)
                {
                    String check = property.Substring(0, 3);
                    switch (check)
                    {
                        case "@  ":
                        {
                            _book.Name = property.Replace(check, "");
                        }
                        break;

                        case"@! ":
                        {
                            _book.Category= property.Replace(check,"");
                        }break;
                        case"@@ ":
                        {
                            _book.Author= property.Replace(check,"");
                            
                        }break;
                        case"@# ":
                        {
                            _book.Price= Int32.Parse(property.Replace(check,""));
                        }break;
                        case"@$ ":
                        {
                            _book.Quantity= Int32.Parse(property.Replace(check,""));
                        }break;
                    }
                    
                }
                ListBook.Add(_book);
            }    
        }
    }
}
