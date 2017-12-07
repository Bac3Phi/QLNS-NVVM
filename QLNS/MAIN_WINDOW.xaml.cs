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
using QLNS.Views;
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
            
            BOOK_WINDOW window = new BOOK_WINDOW();
            window.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            CLIENT_WINDOW window = new CLIENT_WINDOW(); ;
            window.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
           
            BANSACH_WINDOW window = new BANSACH_WINDOW();
            window.ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
