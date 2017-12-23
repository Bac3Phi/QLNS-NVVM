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
using System.IO;
using System.Windows.Forms;
using cExcel = Microsoft.Office.Interop.Excel;
using MessageBox = System.Windows.Forms.MessageBox;


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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {


        }


        private void HoanTatButton_Click(object sender, EventArgs e)
        {

            //Khai báo Excel 
            cExcel.Application app = new cExcel.Application();
            cExcel.Workbook book = app.Workbooks.Add(Type.Missing);
            cExcel.Worksheet sheet = (cExcel.Worksheet)book.Worksheets[1];
            sheet.Columns.ColumnWidth = 15;
            sheet.Activate();
            sheet.Name = "Export Data Sheet";


            //Tiêu đề file Excel
            sheet.Cells[1, 1] = "Mã hóa đơn";
            sheet.Cells[1, 2] = txtHD.Text;//text book hóa đơn
            sheet.Cells[2, 1] = "Ngày ";
            sheet.Cells[2, 2] = txtDate.DisplayDate.ToString();  //lấy ngày hệ thống
            sheet.Cells[3, 1] = "Họ và tên";
            sheet.Cells[3,2] =txtName.Text;
            sheet.Cells[4, 1] = "Địa chỉ";
            sheet.Cells[4,2] =txtAddress.Text;
            sheet.Cells[5, 1] = "Điện thoại";
            sheet.Cells[5,2] = txtPhone.Text;
            //Tên các cột trong file
            sheet.Cells[6, 1] = "Tên sách";
            sheet.Cells[6, 2] = "Thể loại";
            sheet.Cells[6, 3] = "Tác giả";
            sheet.Cells[6, 4] = "Số lượng tồn";
            sheet.Cells[6, 5] = "Đơn giá";
            sheet.Cells[6, 6] = "Số Lượng bán";



            // Nhập dữ liệu từ bảng
            int i = 7;
            foreach (BookModel bookModel in ListBook.ItemsSource)
            {
                sheet.Cells[i, 1] = bookModel.Name;
                sheet.Cells[i, 2] = bookModel.Category;
                sheet.Cells[i, 3] = bookModel.Author;
                sheet.Cells[i, 4] = bookModel.Quantity;
                sheet.Cells[i, 5] = bookModel.Price;
                sheet.Cells[i, 6] = bookModel.SellQuantity;

                i++;
            }

            sheet.Cells[i, 6] = "Tổng tiền :";
            sheet.Cells[i, 7] = TextBill.Text;

            //Tạo save dialog
            SaveFileDialog browser = new SaveFileDialog();
            browser.Filter = Properties.Resources.SELLING_BOOK_WINDOW_HoanTatButton_Click_Excel_files____xlsx____xlsx;
            browser.FileName = "Test";

            if (browser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                browser.AddExtension = true;
                browser.RestoreDirectory = true;
                MessageBox.Show(browser.FileName);
                book.SaveAs(browser.FileName);
                book.Saved = true;
                app.Quit();
                

            }
            

            // Khởi động chtr Excell
            //System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //cExcel.Application exApp = new cExcel.Application();
            //// Lấy sheet 1.
            //string workbookPath = "c:\\text.xls";

            //cExcel.Workbook exBook = exApp.Workbooks.Open(workbookPath,
            //        0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
            //        true, false, 0, true, false, false);
            //cExcel.Worksheet exSheet = (cExcel.Worksheet)exBook.Worksheets[1];
            //exSheet.Activate();
            //exSheet.Name = "Export Data Sheet";
            //cExcel.Range rng = exSheet.get_Range("A1", "K25");
            //rng.Value2 = "giá trị muốn đưa vào";
            //rng.Columns.AutoFit();
            //exBook.SaveCopyAs("C:\\text.xls");
            //exApp.Quit();
            //exBook.Close(false, false, false);
            //exApp.Quit();
            //System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;


        }
    }

    
}
