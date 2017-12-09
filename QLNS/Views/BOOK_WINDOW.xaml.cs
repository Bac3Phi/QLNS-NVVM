using System;
using System.Collections.Generic;
using System.IO;
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
using QLNS.ViewModels;

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
            TxtSlNhap.Clear();
            TxtSlNhap.IsEnabled = true;
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
                MessageBox.Show("Dien it nhat 5 thuoc tinh cua Sach");
                return;
            }
            else
            {
                MessageBox.Show("Thanh cong");
            }
        }

       

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            BtnThem.IsEnabled = false;
            TxtGia.IsReadOnly = false;
            
            TxtSlTon.IsReadOnly = false;
            TxtTen.IsReadOnly = false;
            TxtTheloai.IsReadOnly = false;
            TxtTacgia.IsReadOnly = false;
            TxtSlNhap.IsReadOnly = true;

            BtnNhap.Visibility = Visibility.Collapsed;
            BtnThem.Visibility = Visibility.Visible;
            BtnXoa.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

 
            TxtGia.IsReadOnly = true;
            TxtSlTon.IsReadOnly = true;
          
            TxtTheloai.IsReadOnly = true;
            TxtTacgia.IsReadOnly = true;
            TxtSlNhap.IsReadOnly = false;
            BtnNhap.Visibility = Visibility.Visible;
            BtnThem.Visibility = Visibility.Collapsed;
            BtnXoa.Visibility = Visibility.Collapsed;
        }

        private void txt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_noOfErrorsOnScreen == 0)
                BtnThem.IsEnabled = true;
            else BtnThem.IsEnabled = false;
        }

       

        private void BOOK_WINDOW_OnClosed(object sender, EventArgs e)
        {
            WriteBookData();
        }

        public void WriteBookData()
        {
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\Database\\BookData.txt"))

                foreach (BookModel book in ListBook.ItemsSource)
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
                        MessageBox.Show("Can't write data!!!\nError: " + e);
                    }

                }
        }
    }
}
