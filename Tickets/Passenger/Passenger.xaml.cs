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
    public partial class Passenger : Window
    {
        public Passenger()
        {
            InitializeComponent();
        }
        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Загружаем таблицу из БД
            db.Пассажиры.Load();
            db.Билеты.Load();
            //Загружаем таблицу в DataGrid с отслеживанием изменения контекста 
            DataGrid1.ItemsSource = db.Пассажиры.Local.ToBindingList();
            //DataGrid1.ItemsSource = db.ГлавноеОкно();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ////DataGrid1.ItemsSource = новыйПассажир 
            AddForm add = new AddForm();
            add.ShowDialog();
            DataGrid1.Focus();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DataGrid1.SelectedIndex;
            if (indexRow != -1)
            {
                //Загружаем таблицу из БД
                db.Пассажиры.Load();
                db.Билеты.Load();
                //Получаем ключ текущей записи
                Пассажиры row = (Пассажиры)DataGrid1.Items[indexRow];
                ContextDB.ID = row.КодПассажира;
                ////Получаем ключ текущей записи
                //Пассажиры d = db.Пассажиры.Local.ElementAt(indexRow);
                //Открываем форму Редактировать
                EditForm edit = new EditForm();
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
                    Пассажиры d = (Пассажиры)DataGrid1.SelectedValue;
                    #endregion
                    ////Получаем текущую запись
                    //Пассажиры d = db.Пассажиры.Local.ElementAt(indexRow);
                    //Удаляем запись
                    db.Пассажиры.Remove(d);
                    db.SaveChanges();
                    //Обновляем таблицу
                    //DataGrid1.ItemsSource = db.ГлавноеОкно();
                    DataGrid1.ItemsSource = db.Пассажиры.Local.ToBindingList();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            FindWin find = new FindWin();
            if (find.ShowDialog() == true)
            {
                foreach (var item in DataGrid1.Items)
                {
                    if (((Пассажиры)item).КодПассажира == find.q)
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
            db.Пассажиры.Load();
            //db.Билеты.Load();
            //Загружаем таблицу в DataGrid с отслеживанием изменения контекста 
            DataGrid1.ItemsSource = db.Пассажиры.Local.ToBindingList();
            //DataGrid1.ItemsSource = db.ГлавноеОкно();
        }

        private void Самолеты_Click(object sender, RoutedEventArgs e)
        {
            Airplane add = new Airplane();
            add.ShowDialog();
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
