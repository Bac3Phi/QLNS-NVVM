using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace QLNS.Views
{
    /// <summary>
    /// Interaction logic for CLIENT_WINDOW.xaml
    /// </summary>
    public partial class CLIENT_WINDOW : Window
    {
        private int _noOfErrorsOnScreen = 0;
        public CLIENT_WINDOW()
        {
            InitializeComponent();
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _noOfErrorsOnScreen++;
            else
                _noOfErrorsOnScreen--;
        }

        private void txt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_noOfErrorsOnScreen == 0)
                BtnThem.IsEnabled = true;
            else BtnThem.IsEnabled = false;
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
            ListClient.SelectedItem = null;
        }

        public void WriteClientData()
        {
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\Database\\ClientData.txt"))
                foreach (ClientModel client in ListClient.ItemsSource)
                {
                    try
                    {
                        sw.WriteLine("@  " + client.Address);
                        sw.WriteLine("@! " + client.Name);
                        sw.WriteLine("@@ " + client.Debt.ToString());
                        sw.WriteLine("@# " + client.Email.ToString());
                        sw.WriteLine("@$ " + client.Phonenum.ToString());
                        sw.WriteLine(Environment.NewLine);
                    }

                    catch (Exception c)
                    {
                        MessageBox.Show("Can't writing data!!!");

                    }
                }

        }

        private void CLIENT_WINDOW_OnClosing(object sender, CancelEventArgs e)
        {
            WriteClientData();
        }
    }
}
