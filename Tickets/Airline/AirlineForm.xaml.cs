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
using System.Windows.Shapes;
using Tickets.Airline;

namespace Tickets
{
    /// <summary>
    /// Логика взаимодействия для Passenger.xaml
    /// </summary>
    public partial class AirlineForm : Window
    {
        public AirlineForm()
        {
            InitializeComponent();
        }
        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Загружаем таблицу из БД
            db.Авиакомпании.Load();
            //Загружаем таблицу в DataGrid с отслеживанием изменения контекста 
            DataGrid1.ItemsSource = db.Авиакомпании.Local.ToBindingList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddForm1 add = new AddForm1();
            add.ShowDialog();
            DataGrid1.Focus();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGrid1.SelectedIndex;
            if (indexRow != -1)
            {
                //Загружаем таблицу из БД
                db.Авиакомпании.Load();
                //Получаем ключ текущей записи
                Авиакомпании row = (Авиакомпании)DataGrid1.Items[indexRow];
                ContextDB.ID = row.КодАвиакомпании;
                //Открываем форму Редактировать
                EditForm1 edit = new EditForm1();
                edit.ShowDialog();
                //Обновляем таблицу
                DataGrid1.Items.Refresh();
                DataGrid1.Focus();
            }
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGrid1.SelectedIndex;
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    if (DataGrid1.SelectedValue == null) throw new Exception();
                    //Получаем текущую запись
                    Авиакомпании d = (Авиакомпании)DataGrid1.SelectedValue;
                    //Удаляем запись
                    db.Авиакомпании.Remove(d);
                    db.SaveChanges();
                    //Обновляем таблицу
                    DataGrid1.ItemsSource = db.Авиакомпании.Local.ToBindingList();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            FindWin1 find = new FindWin1();
            if (find.ShowDialog() == true)
            {
                foreach (var item in DataGrid1.Items)
                {
                    if (((Авиакомпании)item).КодАвиакомпании == find.q)
                    {
                        DataGrid1.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            //Загружаем таблицу из БД
            db.Авиакомпании.Load();
            //Загружаем таблицу в DataGrid с отслеживанием изменения контекста 
            DataGrid1.ItemsSource = db.Авиакомпании.Local.ToBindingList();
        }


        private void Самолеты_Click(object sender, RoutedEventArgs e)
        {
            AirplaneForm add = new AirplaneForm();
            add.ShowDialog();
        }


        private void Билеты_Click(object sender, RoutedEventArgs e)
        {
            TicketForm add = new TicketForm();
            add.ShowDialog();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            ViewForm1 view = new ViewForm1();
            view.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Пассажиры_Click(object sender, RoutedEventArgs e)
        {
            PassengerForm add = new PassengerForm();
            add.ShowDialog();
        }

        private void Аэропорты_Click(object sender, RoutedEventArgs e)
        {
            AirportForm add = new AirportForm();
            add.ShowDialog();
        }
        private void Рейсы_Click(object sender, RoutedEventArgs e)
        {
            FlightForm add = new FlightForm();
            add.ShowDialog();
        }
    }
}
