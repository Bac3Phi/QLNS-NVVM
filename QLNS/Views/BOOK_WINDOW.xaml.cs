using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QLNS.Models;

namespace QLNS.Views
{
    /// <summary>
    /// Interaction logic for BOOK_WINDOW.xaml
    /// </summary>
    public partial class BOOK_WINDOW : Window
    {
        private int _noOfErrorsOnScreen = 0;
        private Models.BookModel _book= new BookModel();
        public BOOK_WINDOW()
        {
            InitializeComponent();
          //  grid.DataContext = _book;
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
           
            ListBook.SelectedItem = null;
            txtSLNhap.Text = "Vui lòng chọn vào bảng bên dưới";
            txtSLNhap.IsEnabled = false;
        }

        private void ListBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtSLNhap.Clear();
            txtSLNhap.IsEnabled = true;
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
        }

        private void AddCustomer_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _noOfErrorsOnScreen == 0;
            e.Handled = true;
        }

        private void AddCustomer_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            BookModel cust = grid.DataContext as BookModel;
            // write code here to add Customer

            // reset UI
            _book = new BookModel();
            grid.DataContext = _book;
            e.Handled = true;

        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (_noOfErrorsOnScreen !=0)
            {
                MessageBox.Show("Bug còn kìa");
                return;
            }
            else
            {
                MessageBox.Show("Thanh cong");
            }
        }
    }
}
