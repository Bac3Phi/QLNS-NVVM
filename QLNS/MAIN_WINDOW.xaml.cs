using System;
using System.Windows;
using QLNS.Views;

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
           
            SELLING_BOOK_WINDOW window = new SELLING_BOOK_WINDOW();
            window.ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
