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
    public partial class TicketForm : Window
    {
        public TicketForm()
        {
            InitializeComponent();
        }
        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Загружаем таблицу из БД
            db.Рейсы.Load();
            db.Авиакомпании.Load();
            db.Билеты.Load();
            db.Аэропорты.Load();
            db.Пассажиры.Load();
            //Загружаем таблицу в DataGrid с отслеживанием изменения контекста 
            DataGrid1.ItemsSource = db.БилетыПроцедура();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ////DataGrid1.ItemsSource = новыйПассажир 
            AddForm4 add = new AddForm4();
            add.ShowDialog();
            DataGrid1.Focus();
            DataGrid1.ItemsSource = db.БилетыПроцедура();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedValue != null)
            {
                //Загружаем таблицу из БД
                db.Рейсы.Load();
                db.Авиакомпании.Load();
                db.Билеты.Load();
                db.Аэропорты.Load();
                db.Пассажиры.Load();
                //Получаем ключ текущей записи
                ContextDB.ID = ((БилетыПроцедура_Result)DataGrid1.SelectedValue).КодБилета;
                //Открываем форму Редактировать
                EditForm4 edit = new EditForm4();
                edit.ShowDialog();
                //Обновляем таблицу
                DataGrid1.ItemsSource = db.БилетыПроцедура();
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
                    Билеты d = db.Билеты.Find(((БилетыПроцедура_Result)DataGrid1.SelectedValue).КодБилета);
                    #endregion
                    //Удаляем запись
                    db.Билеты.Remove(d);
                    db.SaveChanges();
                    //Обновляем таблицу
                    DataGrid1.ItemsSource = db.БилетыПроцедура();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            FindWin4 find = new FindWin4();
            if (find.ShowDialog() == true) DataGrid1.ItemsSource = find.q;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            //Загружаем таблицу из БД
            db.Рейсы.Load();
            db.Авиакомпании.Load();
            db.Билеты.Load();
            db.Аэропорты.Load();
            db.Пассажиры.Load();
            //Загружаем таблицу в DataGrid с отслеживанием изменения контекста 
            DataGrid1.ItemsSource = db.БилетыПроцедура();
        }

        private void Самолеты_Click(object sender, RoutedEventArgs e)
        {
            AirplaneForm add = new AirplaneForm();
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
