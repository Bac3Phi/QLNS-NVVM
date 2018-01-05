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

namespace QLNS.ViewModels
{
    class ClientViewModel : INotifyPropertyChanged
    {
        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand<object>(
                    null, // CanExecute()
                    client =>
                    {
                        AddClient(NewClient);
                        NewClient = new ClientModel();
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
                    client => RemoveClient(SelectedClient)
                    );
            }
        }


        public ObservableCollection<ClientModel> ListClient
        {
            get => _listClients;
            set
            {
                _listClients = value;
                OnPropertyChanged(nameof(ListClient));
            }
        }

        private ClientModel _selectedClient;

        public ClientModel SelectedClient
        {
            get { return _selectedClient; }
            set
            {

                _selectedClient = value;
                if (value == null)
                {
                    NewClient = new ClientModel();
                }
                else
                {
                    NewClient = SelectedClient;
                }
                OnPropertyChanged(nameof(SelectedClient));

            }
        }

        private ClientModel _newClient;

        public ClientModel NewClient
        {
            get { return _newClient; }
            set
            {
                _newClient = value;
                OnPropertyChanged(nameof(NewClient));
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
                        if (SelectedClient != null)
                        {
                            SelectedClient.Debt -= PaidMoney;
                            PaidMoney = 0;
                        }
                        else return;
                        
                    }
                );
            }
        }

        public int PaidMoney
        {
            get => _paidMoney;
            set
            {
                _paidMoney = value;
                OnPropertyChanged(nameof(PaidMoney));
            }
        }

        private int _paidMoney;

        private ObservableCollection<ClientModel> _listClients;

        public ClientViewModel()
        {
            _listClients = new ObservableCollection<ClientModel>();

 
            ReadClientData();

            NewClient = new ClientModel();
        }

        public void AddClient(ClientModel client)
        {
            if (ListClient.Contains(client))
            {
                return;
            }
            ListClient.Add(client);
        }

        public void RemoveClient(ClientModel client)
        {
            if (client != null)
            {
                ListClient.Remove(client);
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
        ListClient.Add(_client);
    }
    }
    }
    
}
