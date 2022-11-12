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
    public partial class FlightForm : Window
    {
        public FlightForm()
        {
            InitializeComponent();
        }
        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Загружаем таблицу из БД
            db.Рейсы.Load();
            db.Авиакомпании.Load();
            db.Аэропорты.Load();
            db.Самолеты.Load();
            //Загружаем таблицу в DataGrid с отслеживанием изменения контекста 
            DataGrid1.ItemsSource = db.РейсыПроцедура();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ////DataGrid1.ItemsSource = новыйПассажир 
            AddForm5 add = new AddForm5();
            add.ShowDialog();
            DataGrid1.Focus();
            DataGrid1.ItemsSource = db.РейсыПроцедура();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedValue != null)
            {
                //Загружаем таблицу из БД
                db.Рейсы.Load();
                db.Авиакомпании.Load();
                db.Аэропорты.Load();
                db.Самолеты.Load();
                //Получаем ключ текущей записи
                ContextDB.ID = ((РейсыПроцедура_Result)DataGrid1.SelectedValue).КодРейса;
                //Открываем форму Редактировать
                EditForm5 edit = new EditForm5((РейсыПроцедура_Result)DataGrid1.SelectedValue);
                edit.ShowDialog();
                //Обновляем таблицу
                DataGrid1.ItemsSource = db.РейсыПроцедура();
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
                    Рейсы d = db.Рейсы.Find(((РейсыПроцедура_Result)DataGrid1.SelectedValue).КодРейса);
                    #endregion
                    //Удаляем запись
                    db.Рейсы.Remove(d);
                    db.SaveChanges();
                    //Обновляем таблицу
                    DataGrid1.ItemsSource = db.РейсыПроцедура();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            FindWin5 find = new FindWin5();
            if (find.ShowDialog() == true) DataGrid1.ItemsSource = find.q;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            //Загружаем таблицу из БД
            db.Рейсы.Load();
            db.Авиакомпании.Load();
            db.Аэропорты.Load();
            db.Самолеты.Load();
            //Загружаем таблицу в DataGrid с отслеживанием изменения контекста 
            DataGrid1.ItemsSource = db.РейсыПроцедура();
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

        private void Аэропорты_Click(object sender, RoutedEventArgs e)
        {
            AirportForm add = new AirportForm();
            add.ShowDialog();
        }
    }
}
