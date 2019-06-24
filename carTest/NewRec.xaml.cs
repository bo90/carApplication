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

namespace carTest
{
    /// <summary>
    /// Логика взаимодействия для NewRec.xaml
    /// </summary>
    public partial class NewRec : Window
    {
        

        public Car newCar { get; set; }
        public Holder newHolder { get; set; }

        CarEntity CE = new CarEntity();
        CollectionViewSource carSource;
        CollectionViewSource holderSource;
        public NewRec()
        {
            InitializeComponent();
            carSource = ((CollectionViewSource)(FindResource("carViewSource")));
            DataContext = this;
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {           
            InsertData();                    
        }

        private void InsertData()
        {
            newCar = new Car();
            newCar.vin = VinTextBox.Text;
            newCar.gos_nomer = gosNomTxtBox.Text;
            newCar.mark = MarkTxtBoxs.Text;
            newCar.model = ModelTxtBox.Text;
            newCar.ptc_nom = ptcTxtBox.Text;
            newCar.color = ColorTxtBox.Text;
            newCar.trip = Int32.Parse(tripTxtBox.Text);
            CE.Cars.Add(newCar);
            CE.SaveChanges();

            newHolder = new Holder();
            newHolder.fName = fNameTxtBox.Text;
            newHolder.lName = lNameTxtBox.Text;
            newHolder.city = cityTxtbox.Text;
            newHolder.telephone = telTxtBox.Text;
            newHolder.vin = VinTextBox.Text;
            newHolder.mail = mailTxtbox.Text;
            CE.Holders.Add(newHolder);
            CE.SaveChanges();

            MessageBox.Show("Запись создана!");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource carViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("carViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            // carViewSource.Source = [универсальный источник данных]
            System.Windows.Data.CollectionViewSource holderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("holderViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            // holderViewSource.Source = [универсальный источник данных]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CE.Dispose();
            Close();
        }

        private void btn_NewOrder_Click(object sender, RoutedEventArgs e)
        {
            
            NewOrder order = new NewOrder();
            order.Owner = this;
            order.StateOpen = true;
            order.Show();
            
        }
    }
}
