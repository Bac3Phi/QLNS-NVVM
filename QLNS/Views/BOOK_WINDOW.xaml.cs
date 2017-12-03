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
    /// Interaction logic for BOOK_WINDOW.xaml
    /// </summary>
    public partial class BOOK_WINDOW : Window
    {
        public BOOK_WINDOW()
        {
            InitializeComponent();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

            ListBook.SelectedItem = null;
        }
    }
}
