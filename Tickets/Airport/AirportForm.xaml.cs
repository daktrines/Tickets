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

namespace Tickets
{
    /// <summary>
    /// Логика взаимодействия для Passenger.xaml
    /// </summary>
    public partial class AirportForm : Window
    {
        public AirportForm()
        {
            InitializeComponent();
        }
        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Загружаем таблицу из БД
            db.Аэропорты.Load();
            //Загружаем таблицу в DataGrid с отслеживанием изменения контекста 
            DataGrid1.ItemsSource = db.Аэропорты.Local.ToBindingList();
            //DataGrid1.ItemsSource = db.ГлавноеОкно();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ////DataGrid1.ItemsSource = новыйПассажир 
            AddForm2 add = new AddForm2();
            add.ShowDialog();
            DataGrid1.Focus();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGrid1.SelectedIndex;
            if (indexRow != -1)
            {
                //Загружаем таблицу из БД
                db.Аэропорты.Load();
                //Получаем ключ текущей записи
                Аэропорты row = (Аэропорты)DataGrid1.Items[indexRow];
                ContextDB.ID = row.КодАэропорта;
                ////Получаем ключ текущей записи
                //Пассажиры d = db.Пассажиры.Local.ElementAt(indexRow);
                //Открываем форму Редактировать
                EditForm2 edit = new EditForm2();
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
                    #region Новое
                    if (DataGrid1.SelectedValue == null) throw new Exception();
                    //Получаем текущую запись
                    Аэропорты d = (Аэропорты)DataGrid1.SelectedValue;
                    #endregion
                    ////Получаем текущую запись
                    //Аэропорты d = db.Аэропорты.Local.ElementAt(indexRow);
                    //Удаляем запись
                    db.Аэропорты.Remove(d);
                    db.SaveChanges();
                    //Обновляем таблицу
                    //DataGrid1.ItemsSource = db.ГлавноеОкно();
                    DataGrid1.ItemsSource = db.Аэропорты.Local.ToBindingList();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            FindWin2 find = new FindWin2();
            if (find.ShowDialog() == true)
            {
                foreach (var item in DataGrid1.Items)
                {
                    if (((Аэропорты)item).КодАэропорта == find.q)
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
            db.Аэропорты.Load();
            //Загружаем таблицу в DataGrid с отслеживанием изменения контекста 
            DataGrid1.ItemsSource = db.Аэропорты.Local.ToBindingList();
            //DataGrid1.ItemsSource = db.ГлавноеОкно();
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

        private void Авиакомпании_Click(object sender, RoutedEventArgs e)
        {
            AirlineForm add = new AirlineForm();
            add.ShowDialog();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {

        }



        private void Information_Click(object sender, RoutedEventArgs e)
        {

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


        private void Рейсы_Click(object sender, RoutedEventArgs e)
        {
            FlightForm add = new FlightForm();
            add.ShowDialog();
        }
    }
}
