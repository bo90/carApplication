using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;
using Exel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace carTest
{
    /// <summary>
    /// Логика взаимодействия для NewOrder.xaml
    /// </summary>
    public partial class NewOrder : Window
    {
        

        public bool StateOpen { get; set; }

        public Car cars { get; set; }
        public Holder holders { get; set; }
        public t_Order order { get; set; }

        CarEntity context = new CarEntity();
        CollectionViewSource carSource;
        CollectionViewSource holderSource;
        CollectionViewSource orderSource;

        public NewOrder()
        {
            InitializeComponent();
            StateOpen = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource t_OrderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("t_OrderViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            // t_OrderViewSource.Source = [универсальный источник данных]
            System.Windows.Data.CollectionViewSource carViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("carViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            // carViewSource.Source = [универсальный источник данных]
            if (StateOpen == true)
            {
                GetData();
            }
        }

        public void CreateNewOrder()
        {
            order = new t_Order();
            order.vin = vinTxtBox.Text;
            order.date_start = DateTime.Parse(DateStart.Text);
            order.date_end = DateTime.Parse(dateEnd.Text);
            order.discrtip_job = descriptTxtBox.Text;
            order.time_start = DateTime.Parse(TimeStart.Text);
            order.time_end = DateTime.Parse(TimeEnd.Text);
            order.view_job = ViewJobTxtBox.Text;
            context.t_Order.Add(order);
            context.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateNewOrder();
        }

        public void GetData()
        {
            NewRec Rec = this.Owner as NewRec;
            vinTxtBox.Text = Rec.VinTextBox.Text;
            GosNomTxtBox.Text = Rec.gosNomTxtBox.Text;
            markTxtBox.Text = Rec.MarkTxtBoxs.Text;
            modelTxt.Text = Rec.ModelTxtBox.Text;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            context.Dispose();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // печать документа
        }

        public void PrintDoc()
        {
          //  var exelapp = this.Application;
        }
    }
}
