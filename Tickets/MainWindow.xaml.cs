
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tickets
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Самолеты_Click(object sender, RoutedEventArgs e)
        {
            Airplane add = new Airplane();
            add.ShowDialog();
        }

        private void Авиакомпании_Click(object sender, RoutedEventArgs e)
        {
            Airline add = new Airline();
            add.ShowDialog();
        }

        private void Рейсы_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Билеты_Click(object sender, RoutedEventArgs e)
        {
            Ticket add = new Ticket();
            add.ShowDialog();
        }

        private void Аэропорты_Click(object sender, RoutedEventArgs e)
        {
            Airport add = new Airport();
            add.ShowDialog();
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

     

        private void Pessenger_Click(object sender, RoutedEventArgs e)
        {
            Passenger add = new Passenger();
            add.ShowDialog();
        }

       
    }
}
