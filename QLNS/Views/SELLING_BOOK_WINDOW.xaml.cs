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
            sheet.Cells[1, 2] = TxtMHD.Text;//text book hóa đơn
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
            // ghi count vao` path1

            //tinh lai so luong nhap
            foreach (BookModel sellbook in ListBook.ItemsSource)
            {
                sellbook.Quantity -= sellbook.SellQuantity;
                sellbook.SellQuantity = 0;
            }
            //ghi listbookInsell + listtosell
            //Listbooktosell

          
            this.Close();
            //Listbookinsell
            foreach (BookModel Book in cbBook.ItemsSource)
            {
                MessageBox.Show(Book.Name);
                MessageBox.Show(Book.Author);
                MessageBox.Show(Book.Category);
                MessageBox.Show(Book.SellQuantity.ToString());
                MessageBox.Show(Book.Price.ToString());
            }
            this.Close();

        }
        public string path1 = Directory.GetCurrentDirectory() + "\\Database\\MHD.txt";
        public string ReadMHD()
        {

            String a = "";
            try
            {
                using (StreamReader sw = new StreamReader(path1))
                {
                    a = sw.ReadToEnd();


                }
            }
            catch (Exception e)
            {
                // MessageBox.Show("Can't Read data!!!\nError: " + e);
            }
            return (int.Parse(a) + 1).ToString();


        }
        public string count = "";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string num = ReadMHD();
            count = num;
            if (num.Length == 1)
                TxtMHD.Text = "HD00" + num;
            else if (num.Length == 2)
                TxtMHD.Text = "HD0" + num;
            else
                TxtMHD.Text = "HD" + num;
        }
        //ghi count vao path 1
        public void WriteBookMHD()
        {
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\Database\\MHD.txt"))

                foreach (BookModel book in ListBook.ItemsSource)
                {
                    try
                    {
                        sw.WriteLine(count);
                        sw.WriteLine(Environment.NewLine); // 2 cai xuong dong
                       
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Can't write data!!!\nError: " + e);
                    }

                }
            
        }
        //ghi listbookInsell + listtosell
        //Listbooktosell
        public void WriteBookToSell()
        {
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\Database\\BookData.txt"))

                foreach (BookModel Book in cbBook.ItemsSource)
                {
                    try
                    {
                        sw.WriteLine("@  " + Book.Name);
                        sw.WriteLine("@! " + Book.Category);
                        sw.WriteLine("@@ " + Book.Author);
                        sw.WriteLine("@# " + Book.Price.ToString());
                        sw.WriteLine("@$ " + Book.Quantity.ToString());
                        sw.WriteLine(Environment.NewLine); // 2 cai xuong dong
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Can't write data!!!\nError: " + e);
                    }

                }

        }
        //Listbooktosell
        public void WriteBookInSell()
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
                        sw.WriteLine("@%" + book.SellQuantity);
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

    

