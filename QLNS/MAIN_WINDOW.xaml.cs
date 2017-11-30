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
using QLNS.WINDOWS;

namespace QLNS
{
    /// <summary>
    /// Interaction logic for MAIN_WINDOW.xaml
    /// </summary>
    public partial class MAIN_WINDOW : Window
    {
        public MAIN_WINDOW()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            BANSACH_WINDOW window = new BANSACH_WINDOW();
            window.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SACH_WINDOW window = new SACH_WINDOW();
            window.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            KHACHHANG_WINDOW window = new KHACHHANG_WINDOW();
            window.ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
