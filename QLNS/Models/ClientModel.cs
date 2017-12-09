using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.Models
{
    class ClientModel : INotifyPropertyChanged, IDataErrorInfo
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

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "Name")
                {
                    if (string.IsNullOrEmpty(Name))
                        result = "Vui lòng nhập tên Khách Hàng";
                }
                if (columnName == "Address")
                {
                    if (string.IsNullOrEmpty(Address))
                        result = "Vui lòng nhập Địa Chỉ";
                }

                if (columnName == "Phonenum")
                {
                    if (string.IsNullOrEmpty(Phonenum))
                        result = "Vui lòng nhập Số Điện Thoại";
                }

                if (columnName == "Email")
                {
                    if (string.IsNullOrEmpty(Email))
                        result = "Vui lòng nhập Email";
                }
                if (columnName == "Debt")
                {
                    if (string.IsNullOrEmpty(Debt.ToString()))
                        result = "Vui lòng nhập Số tiền nợ";
                }
                return result;
            }
        }

        public string Error { get; }
    }
}

