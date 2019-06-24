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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace carTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Car cars {get; set;}
        CarEntity CE = new CarEntity();
        CollectionViewSource carSource;

        public MainWindow()
        {
            InitializeComponent();
            carSource = ((CollectionViewSource)(FindResource("carsViewSource")));
            DataContext = this;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource carsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("carsViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            // carsViewSource.Source = [универсальный источник данных]
            CE.Cars.Load();            
            carSource.Source = CE.Cars.Local;
        }

        private void But_del_Click(object sender, RoutedEventArgs e)
        {
            var cr = carSource.View.CurrentItem as Car;

            var crs = (from c in CE.Cars
                       where c.vin == cr.vin
                       select c).FirstOrDefault();            
            CE.Cars.Remove(cr);
            CE.SaveChanges();
            carSource.View.Refresh();
            MessageBox.Show("Запись удалена!");
        }

        private void DeleteCar(Car caR)
        {
            var cr = (from c in CE.Cars.Local
                      where c.vin == caR.vin
                      select c).FirstOrDefault();

            foreach (var detail in cr.vin.ToList())
            {
               // CE.Cars.Remove(detail);
            }
            CE.Cars.Remove(cr);
            CE.SaveChanges();     
            
        }

        private void Create_new_rec_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NewRec nr = new NewRec();
            nr.Show();
        }

        private void NewOrder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NewOrder Order = new NewOrder();
            Order.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CE.Dispose();
        }

        public void TakeData()
        {
            NewOrder order = new NewOrder();
            order.Owner = this;
            order.Show();
        }



        private void dGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
