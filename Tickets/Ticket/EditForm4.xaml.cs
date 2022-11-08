﻿using System;
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
    /// Логика взаимодействия для AddForm.xaml
    /// </summary>
    public partial class EditForm4 : Window
    {
        public EditForm4()
        {
            InitializeComponent();
        }

        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        Билеты p1;
        private void AddMain_Click(object sender, RoutedEventArgs e)
        {
            //Проверка каждого обязательного для заполнения поля
            StringBuilder errors = new StringBuilder();
            if (КодБилета.Text.Length == 0 || double.TryParse(КодБилета.Text, out double x1) == false || x1 < 1) errors.AppendLine("Введите код билета");
            if (КодРейса.Text.Length == 0 || double.TryParse(КодРейса.Text, out double x2) == false || x2 < 1) errors.AppendLine("Введите код рейса");
            if (Наименование.Text.Length == 0) errors.AppendLine("Введите наименование авиакомпании");
            if (Фамилия.Text.Length == 0) errors.AppendLine("Введите фамилию");
            if (НазваниеКласса.Text.Length == 0) errors.AppendLine("Введите название класса");
            if (Багаж.Text.Length == 0) errors.AppendLine("Введите багаж");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            try
            {//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Изменение
             //db.НовыйСамолет(Convert.ToInt32(КодСамолета.Text), ((Авиакомпании)Наименование.SelectedValue).КодАвиакомпании, МодельСамолета.Text, Convert.ToInt32(КоличествоМест.Text));

                p1.КодБилета = Convert.ToInt64(КодБилета.Text);
                #region Проверка наличия такого рейса и его присваивание
                int RaceId = Convert.ToInt32(КодРейса.Text);
                var codes = from table in db.Рейсы
                            where table.КодРейса == RaceId
                            select table;
                if (codes.Count() == 0) throw new Exception("Не существует указанного рейса");
                else p1.КодРейса = RaceId;
                #endregion
                p1.КодАвиакомпании = db.Авиакомпании.Local.ToBindingList().Where(p => p.Наименование == ((Авиакомпании)Наименование.SelectedValue).Наименование).First().КодАвиакомпании;
                p1.НазваниеКласса = НазваниеКласса.Text;
                #region Багаж
                if (Багаж.Text == "Есть") p1.Багаж = true;
                else p1.Багаж = false;
                #endregion
                #region Получение кода пассажира
                var passengers = db.Пассажиры.Local.ToBindingList().
                    Where(p => p.Фамилия == Фамилия.Text).
                    Where(p => p.Имя == Имя.Text).
                    Where(p => p.Отчество == Отчество.Text);
                if (passengers.Count() == 0) throw new Exception("Не существует человека с таким ФИО!");
                else
                {
                    int passengerId = passengers.First().КодПассажира;
                    var tickets = from table in db.Билеты
                                where table.КодПассажира == passengerId
                                select table;
                    if (tickets.Count() != 0) throw new Exception("Данный пассажир уже имеет билет!");
                    else p1.КодПассажира = passengerId;
                }
                #endregion
                p1.ДатаПокупкиБилета = DateTime.Now.Date;
                p1.ВремяПокупкиБилета = DateTime.Now.TimeOfDay;
                db.Билеты.Add(p1);
                //Сохраняем изменения
                db.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void CloseMain_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Авиакомпании.Load();
            db.Рейсы.Load();
            db.Билеты.Load();
            //Поличаем список из другой таблицы
            Наименование.ItemsSource = db.Авиакомпании.Local.ToBindingList();
            КодРейса.ItemsSource = db.Рейсы.Local.ToBindingList();
            Фамилия.ItemsSource = db.Пассажиры.Local.ToBindingList();

            //Отображаем запись
            КодБилета.Text = Convert.ToString(p1.КодБилета);
            КодРейса.Text = Convert.ToString(p1.КодРейса);
            Наименование.SelectedValue = db.Авиакомпании.Local.ToBindingList().Where(p => p.КодАвиакомпании == p1.КодАвиакомпании).First();


            //здесь хз че добавлять

            ////Фамилия.Text = p1.Фамилия;
            ////НазваниеКласса.Text = p1.НазваниеКласса;
            ////Багаж.Text = p1.Багаж;

        }  

        private void КодРейса_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                AddTable.ItemsSource = db.Рейсы.Local.ToBindingList().Where(p => p.КодРейса == ((Рейсы)КодРейса.SelectedValue).КодРейса);
            }
            catch (Exception ex)//Если что пойдет не так - при точке останова глянуть значение ex
            {

            }
        }
        private void Фамилия_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var query = from table in db.Пассажиры
                            where ((Пассажиры)Фамилия.SelectedValue).Фамилия == table.Фамилия
                            select table;
                var passenger = query.First();
                Имя.Text = passenger.Имя;
                Отчество.Text = passenger.Отчество;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
