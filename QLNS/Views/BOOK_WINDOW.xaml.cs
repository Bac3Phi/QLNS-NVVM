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
            
          //  txtSLNhap.IsEnabled = false;
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

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton t = (RadioButton)sender;
            if(t.IsChecked == false)
            {
                txtGia.IsReadOnly = false;
                txtSLTon.IsReadOnly = false;
                txtTen.IsReadOnly = false;
                txtTheloai.IsReadOnly = false;
                txtTacgia.IsReadOnly = false;
                txtSLNhap.IsReadOnly = true;
                t.IsChecked = true;
            }
            else
            {
                txtGia.IsReadOnly = true;
                txtSLTon.IsReadOnly = true;
                txtTen.IsReadOnly = true;
                txtTheloai.IsReadOnly = true;
                txtTacgia.IsReadOnly = true;
                txtSLNhap.IsReadOnly = false;
                t.IsChecked = false;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            btnThem.IsEnabled = false;
            txtGia.IsReadOnly = false;
            
            txtSLTon.IsReadOnly = false;
            txtTen.IsReadOnly = false;
            txtTheloai.IsReadOnly = false;
            txtTacgia.IsReadOnly = false;
            txtSLNhap.IsReadOnly = true;

            btnNhap.Visibility = Visibility.Collapsed;
            btnThem.Visibility = Visibility.Visible;
            btnXoa.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

 
            txtGia.IsReadOnly = true;
            txtSLTon.IsReadOnly = true;
          
            txtTheloai.IsReadOnly = true;
            txtTacgia.IsReadOnly = true;
            txtSLNhap.IsReadOnly = false;
            btnNhap.Visibility = Visibility.Visible;
            btnThem.Visibility = Visibility.Collapsed;
            btnXoa.Visibility = Visibility.Collapsed;
        }

        private void txtTen_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_noOfErrorsOnScreen == 0)
                btnThem.IsEnabled = true;
            else btnThem.IsEnabled = false;
        }

        private void txtTheloai_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_noOfErrorsOnScreen == 0)
                btnThem.IsEnabled = true;
            else btnThem.IsEnabled = false;
        }

        private void txtTacgia_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_noOfErrorsOnScreen == 0)
                btnThem.IsEnabled = true;
            else btnThem.IsEnabled = false;
        }

        private void txtSLTon_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_noOfErrorsOnScreen == 0)
                btnThem.IsEnabled = true;
            else btnThem.IsEnabled = false;
        }

        private void txtGia_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_noOfErrorsOnScreen == 0)
                btnThem.IsEnabled = true;
            else btnThem.IsEnabled = false;
        }
    }
}
