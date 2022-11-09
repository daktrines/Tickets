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
    public partial class Airplane : Window
    {
        public Airplane()
        {
            InitializeComponent();
        }
        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Загружаем таблицу из БД
            db.Самолеты.Load();
            db.Авиакомпании.Load();
            //Загружаем таблицу в DataGrid с отслеживанием изменения контекста 
             DataGrid1.ItemsSource = db.СамолетыПроцедура();
         
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ////DataGrid1.ItemsSource = новыйПассажир 
            AddForm3 add = new AddForm3();
            add.ShowDialog();
            DataGrid1.Focus();
            DataGrid1.ItemsSource = db.СамолетыПроцедура();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGrid1.SelectedIndex;
            if (indexRow != -1)
            {
                //Загружаем таблицу из БД
                db.Самолеты.Load();
                db.Авиакомпании.Load();
                //Получаем ключ текущей записи
                Самолеты d = db.Самолеты.Local.ElementAt(indexRow);
                //Открываем форму Редактировать
                EditForm3 edit = new EditForm3(d);
                edit.ShowDialog();
                //Обновляем таблицу
                DataGrid1.ItemsSource = db.СамолетыПроцедура();
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
                    Самолеты d = db.Самолеты.Find(((СамолетыПроцедура_Result)DataGrid1.SelectedValue).КодСамолета);
                    #endregion
                    ////Получаем текущую запись
                    //Самолеты d = db.Самолеты.Local.ElementAt(indexRow);
                    //Удаляем запись
                    db.Самолеты.Remove(d);
                    db.SaveChanges();
                    //Обновляем таблицу
                    DataGrid1.ItemsSource = db.СамолетыПроцедура();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            FindWin3 find = new FindWin3();
            if (find.ShowDialog() == true) DataGrid1.ItemsSource = find.q;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            //Загружаем таблицу из БД
            db.Самолеты.Load();
            db.Авиакомпании.Load();
            //Загружаем таблицу в DataGrid с отслеживанием изменения контекста 
            DataGrid1.ItemsSource = db.СамолетыПроцедура();
        }


        private void Билеты_Click(object sender, RoutedEventArgs e)
        {
            Ticket add = new Ticket();
            add.ShowDialog();
        }

        private void Авиакомпании_Click(object sender, RoutedEventArgs e)
        {
            Airline add = new Airline();
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
            Passenger add = new Passenger();
            add.ShowDialog();
        }

        private void Аэропорты_Click(object sender, RoutedEventArgs e)
        {
            Airport add = new Airport();
            add.ShowDialog();
        }
        private void Рейсы_Click(object sender, RoutedEventArgs e)
        {
            Flight add = new Flight();
            add.ShowDialog();
        }
    }
}
