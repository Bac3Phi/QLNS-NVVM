using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.Models
{
 
    class BookModel : INotifyPropertyChanged,IDataErrorInfo
    {
        private string _name;
        private string _category;
        private int _price;
        private string _author;
        private int _quantity;

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

      

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Category
        {
            get => _category;
            set
            {
                _category = value; 
                OnPropertyChanged("Category");
            }
        }

        public int Price
        {
            get => _price;
            set
            {
                _price = value; 
                OnPropertyChanged("Price");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region ErrorException

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "Name")
                {
                    if (string.IsNullOrEmpty(Name))
                        result = "Vui lòng nhập tên sách";
                }
                if (columnName == "Category")
                {
                    if (string.IsNullOrEmpty(Category))
                        result = "Vui lòng nhập thể loại sách";
                }
                if (columnName == "Author")
                {
                    if (string.IsNullOrEmpty(Author))
                        result = "Vui lòng nhập tác giả";
                }
                if (columnName == "Quantity")
                {
                    if (Quantity == 0 || string.IsNullOrEmpty(Quantity.ToString()))
                        result = "Vui lòng nhập cập nhật số lượng tồn";
                }
                if (columnName == "Price")
                {
                    if (Price == 0 || string.IsNullOrEmpty(Quantity.ToString()))
                        result = "Vui lòng nhập cập nhật đơn giá";
                }
                return result;
            }
        }

        public string Error { get; }

        #endregion

    }
}
