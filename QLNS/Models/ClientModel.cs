using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.Models
{
    class ClientModel : INotifyPropertyChanged
    {
        private string _name;
        private string _address;
        private string _phonenum;
        private string _email;
        private int _debt;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public string Phonenum
        {
            get => _phonenum;
            set
            {
                _phonenum = value;
                OnPropertyChanged(nameof(Phonenum));
            }
        }


        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public int Debt
        {
            get => _debt;
            set
            {
                _debt = value;
                OnPropertyChanged(nameof(Debt));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

