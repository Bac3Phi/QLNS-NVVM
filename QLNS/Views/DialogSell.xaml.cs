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
    /// Interaction logic for DialogSell.xaml
    /// </summary>
    public partial class DialogSell : Window
    {
        public DialogSell()
        {
            InitializeComponent();
        }
        public int sellAmount = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            sellAmount = Int32.Parse(Box.Text);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
            
        }
    }
}
