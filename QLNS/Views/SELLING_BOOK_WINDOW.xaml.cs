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
    /// Interaction logic for SELLING_BOOK_WINDOW.xaml
    /// </summary>
    public partial class SELLING_BOOK_WINDOW : Window
    {
        public SELLING_BOOK_WINDOW()
        {
            InitializeComponent();
        }



        private void ListBook_OnSelected(object sender, RoutedEventArgs e)
        {
            
            var dialog = new DialogSell();
            ListView t = (ListView)sender;
            if (t.SelectedItem == null)
                return;
            if (dialog.ShowDialog() == true)
            {
                BookModel temp = (BookModel)t.SelectedItems[0];
                temp.SellQuantity = dialog.sellAmount;
            }
            t.SelectedItem = null;
        }

    }
}
