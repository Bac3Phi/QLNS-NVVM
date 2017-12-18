using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QLNS.Annotations;
using QLNS.Commands;
using QLNS.Models;
using System.Collections.Specialized;
using QLNS.Views;

namespace QLNS.ViewModels
{
    class SellBookViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ClientModel> _listClientToSell;
        private int _billMoney = 0;
        public int BillMoney
        {
            get => _billMoney;
            set
            {
                _billMoney = value;
                OnPropertyChanged(nameof(BillMoney));

            }
        }
        public ObservableCollection<ClientModel> ListClientsToSell
        {
            get => _listClientToSell;
            set
            {
                _listClientToSell = value;


                OnPropertyChanged(nameof(ListClientsToSell));
            }
        }

        private BookModel _selectedBook;


        public BookModel SelectedBook
        {
            get { return _selectedBook; }
            set
            {

                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));

            }
        }

        private ClientModel _selectedClient;


        public ClientModel SelectedClient
        {
            get { return _selectedClient; }
            set
            {

                _selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));

            }
        }


        private BookModel _selectedSellBook;


        public BookModel SelectedSellBook
        {
            get { return _selectedSellBook; }
            set
            {

                _selectedSellBook = value;
                OnPropertyChanged(nameof(SelectedSellBook));

            }
        }

        public ObservableCollection<BookModel> ListBooksToSell
        {
            get => _listBooksToSell;
            set
            {
                _listBooksToSell = value;
                OnPropertyChanged(nameof(ListBooksToSell));
            }
        }

        private ObservableCollection<BookModel> _listBooksInSell;


        public ObservableCollection<BookModel> ListBooksInSell
        {
            get => _listBooksInSell;
            set
            {
                _listBooksInSell = value;
                OnPropertyChanged(nameof(ListBooksInSell));
            }
        }




        private ObservableCollection<BookModel> _listBooksToSell;


        public SellBookViewModel()
        {
            _listClientToSell = new ObservableCollection<ClientModel>();
            _listBooksToSell = new ObservableCollection<BookModel>();
            _listBooksInSell = new ObservableCollection<BookModel>();
            ReadBookData();
            ReadClientData();

            SelectedBook = new BookModel();
            _listBooksInSell.CollectionChanged += new NotifyCollectionChangedEventHandler(ListCollectionChanged);


        }
        public void ListCollectionChanged(Object sender, NotifyCollectionChangedEventArgs e)
        {
            BillMoney = SumBill();
        }

        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand<object>(
                    null, // CanExecute()
                    book =>
                    {

                        if (ListBooksInSell.Contains(book))
                        {
                            return;
                        }
                        if (SelectedBook.Name != "" && SelectedBook.Author != "" && SelectedBook.Category != "" && SelectedBook.Price != 0)
                        {
                            ListBooksInSell.Add(SelectedBook);
                            SelectedSellBook = SelectedBook;
                        }
                        SelectedBook = new BookModel();

                    }
                );
            }
        }

        public ICommand AddSellQuantityCommand
        {
            get
            {
                return new RelayCommand<object>(
                   null,
                   book =>
                   {
                       var dialog = new DialogSell();
                       if ((SelectedSellBook == null))
                           return;
                       if (dialog.ShowDialog() == true)
                       {
                           SelectedSellBook.SellQuantity = dialog.sellAmount;
                       }

                       BillMoney = SumBill();
                   });
            }
        }
        public ICommand RemoveComand
        {
            get
            {
                return new RelayCommand<object>(
                    null,
                    book =>
                    {
                        ListBooksInSell.Remove(SelectedSellBook);
                    });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ReadBookData()
        {
            String data = "";
            try
            {
                using (StreamReader sw = new StreamReader(Directory.GetCurrentDirectory() + "\\Database\\BookData.txt"))
                {
                    data = sw.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                // MessageBox.Show("Can't Read data!!!\nError: " + e);
            }


            String[] fullbook = data.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (String book in fullbook)
            {

                String[] bookdata = book.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
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

                        case "@! ":
                            {
                                _book.Category = property.Replace(check, "");
                            }
                            break;
                        case "@@ ":
                            {
                                _book.Author = property.Replace(check, "");

                            }
                            break;
                        case "@# ":
                            {
                                _book.Price = Int32.Parse(property.Replace(check, ""));
                            }
                            break;
                        case "@$ ":
                            {
                                _book.Quantity = Int32.Parse(property.Replace(check, ""));
                            }
                            break;
                    }

                }
                if (bookdata.Count() >= 5)
                    ListBooksToSell.Add(_book);
            }
        }
        public void ReadClientData()
        {
            String data = "";
            try
            {
                using (StreamReader sw = new StreamReader(Directory.GetCurrentDirectory() + "\\Database\\ClientData.txt"))
                {
                    data = sw.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("Can't read data!!!");
            }

            String[] fulllist = data.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (String client in fulllist)
            {
                String[] listdata = client.Split(new string[] { Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries);
                ClientModel _client = new ClientModel();
                foreach (String property in listdata)
                {
                    String check = property.Substring(0, 3);
                    switch (check)
                    {
                        case "@  ":
                            {
                                _client.Address = property.Replace(check, "");
                            }
                            break;
                        case "@! ":
                            {
                                _client.Name = property.Replace(check, "");
                            }
                            ;
                            break;
                        case "@@ ":
                            {
                                _client.Debt = Int32.Parse(property.Replace(check, ""));
                            }
                            ;
                            break;
                        case "@# ":
                            {
                                _client.Email = property.Replace(check, "");
                            }
                            ;
                            break;
                        case "@$ ":
                            {
                                _client.Phonenum = property.Replace(check, "");
                            }
                            ;
                            break;
                    }
                }
                if (listdata.Count() >= 5)
                    ListClientsToSell.Add(_client);
            }
        }

        public int SumBill()
        {
            int total = 0;
            try
            {
                foreach (BookModel book in ListBooksToSell)
                {
                    total += book.SellQuantity * book.Price;
                }
                return total;

            }
            catch (Exception ex)
            {

            }
            return 0;
        }
    }
}
