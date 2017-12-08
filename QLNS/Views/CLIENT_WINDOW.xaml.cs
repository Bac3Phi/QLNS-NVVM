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

namespace QLNS.Views
{
    /// <summary>
    /// Interaction logic for CLIENT_WINDOW.xaml
    /// </summary>
    public partial class CLIENT_WINDOW : Window
    {
        public CLIENT_WINDOW()
        {
            InitializeComponent();
        }



        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            BtnThem.IsEnabled = false;
            TxtHoten.IsReadOnly = false;

            TxtDiaChi.IsReadOnly = false;
            TxtSotienno.IsReadOnly = false;
            TxtEmail.IsReadOnly = false;
            TxtDienthoai.IsReadOnly = false;
            TxtThu.IsReadOnly = true;

            BtnNhap.Visibility = Visibility.Collapsed;
            BtnThem.Visibility = Visibility.Visible;
            BtnXoa.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {


            TxtHoten.IsReadOnly = true;
            TxtDiaChi.IsReadOnly = true;

           TxtDienthoai.IsReadOnly = true;
            TxtEmail.IsReadOnly = true;
            TxtThu.IsReadOnly = false;
            BtnNhap.Visibility = Visibility.Visible;
            BtnThem.Visibility = Visibility.Collapsed;
            BtnXoa.Visibility = Visibility.Collapsed;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ListBook.SelectedItem = null;
        }
    }
}
