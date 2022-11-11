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
    /// Логика взаимодействия для AddForm.xaml
    /// </summary>
    public partial class EditForm5 : Window
    {
        public EditForm5(РейсыПроцедура_Result d1)
        {
            InitializeComponent();
            P1 = d1;
        }
        public РейсыПроцедура_Result P1;
        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        Рейсы p1;
        private void AddMain_Click(object sender, RoutedEventArgs e)
        {
            ////Проверка каждого обязательного для заполнения поля
            StringBuilder errors = new StringBuilder();
            if (КодРейса.Text.Length == 0 || double.TryParse(КодРейса.Text, out double x2) == false || x2 < 1) errors.AppendLine("Введите код рейса");
            if (Наименование.Text.Length == 0) errors.AppendLine("Введите наименование авиакомпании");
            if (МодельСамолета.Text.Length == 0) errors.AppendLine("Введите модель самолета");
            if (ДатаОтправления.Text.Length == 0) errors.AppendLine("Введите дату отправления");
            if (ДатаПрибытия.Text.Length == 0) errors.AppendLine("Введите дату прибытия");
            if (Часы.Text.Length == 0) errors.AppendLine("Введите время в часах");
            if (Минуты.Text.Length == 0) errors.AppendLine("Введите время в минутах");
            if (Часы1.Text.Length == 0) errors.AppendLine("Введите время в часах");
            if (Минуты1.Text.Length == 0) errors.AppendLine("Введите время в минутах");
            if (ДлительностьПерелета.Text.Length == 0) errors.AppendLine("Введите длительность перелета");
            if (СтоимостьБилета.Text.Length == 0) errors.AppendLine("Введите стоимость билета");
            if (Город_отправление.Text.Length == 0) errors.AppendLine("Введите город отправления");
            if (Город_назначение.Text.Length == 0) errors.AppendLine("Введите город назначения");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            try
            {//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Изменение
             //db.НовыйСамолет(Convert.ToInt32(КодСамолета.Text), ((Авиакомпании)Наименование.SelectedValue).КодАвиакомпании, МодельСамолета.Text, Convert.ToInt32(КоличествоМест.Text));
                #region Проверка наличия такого рейса и его присваивание
                int RaceId = Convert.ToInt32(КодРейса.Text);
                var codes = from table in db.Рейсы
                            where table.КодРейса == RaceId
                            select table;
                if (codes.Count() == 0) throw new Exception("Не существует указанный рейс");
                else p1.КодРейса = RaceId;
                #endregion
                p1.КодАвиакомпании = db.Авиакомпании.Local.ToBindingList().Where(p => p.Наименование == Наименование.Text).First().КодАвиакомпании;
                p1.КодСамолёта = db.Самолеты.Local.ToBindingList().Where(p => p.МодельСамолета == ((Самолеты)МодельСамолета.SelectedValue).МодельСамолета).First().КодСамолета;
                p1.ДатаОтправления = (DateTime)ДатаОтправления.SelectedDate;
                p1.ДатаПрибытия = (DateTime)ДатаПрибытия.SelectedDate;
                p1.ВремяОтправления = new TimeSpan(Convert.ToInt32(Часы.Text), Convert.ToInt32(Минуты.Text), 0);
                p1.ВремяПрибытия = new TimeSpan(Convert.ToInt32(Часы1.Text), Convert.ToInt32(Минуты1.Text), 0);
                p1.ДлительностьПерелета = ДлительностьПерелета.Text; 
                p1.СтоимостьБилета = Convert.ToDecimal(СтоимостьБилета.Text);
                p1.Отправление = db.Аэропорты.Local.ToBindingList().Where(p => p.Город == ((Аэропорты)Город_отправление.SelectedValue).Город).First().КодАэропорта;
                p1.Прибытие = db.Аэропорты.Local.ToBindingList().Where(p => p.Город == ((Аэропорты)Город_назначение.SelectedValue).Город).First().КодАэропорта;
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
            //Загружаем таблицу из БД
            db.Рейсы.Load();
            db.Авиакомпании.Load();
            db.Аэропорты.Load();
            db.Самолеты.Load();
            //Поличаем список из другой таблицы
            МодельСамолета.ItemsSource = db.Самолеты.Local.ToBindingList();            
            Город_отправление.ItemsSource = db.Аэропорты.Local.ToBindingList();
            Город_назначение.ItemsSource = db.Аэропорты.Local.ToBindingList();


            //Отображаем запись
            p1 = db.Рейсы.Find(ContextDB.ID);
            КодРейса.Text = p1.КодРейса.ToString();
            Наименование.Text = P1.Наименование;
            МодельСамолета.Text = P1.МодельСамолета;
            ДатаОтправления.Text = p1.ДатаОтправления.ToString();
            ДатаПрибытия.Text = p1.ДатаПрибытия.ToString();
            Часы.Text = p1.ВремяОтправления.Hours.ToString(); ;
            Минуты.Text = p1.ВремяОтправления.Minutes.ToString();
            Часы1.Text = p1.ВремяПрибытия.Hours.ToString();
            Минуты1.Text = p1.ВремяПрибытия.Minutes.ToString();
            ДлительностьПерелета.Text = p1.ДлительностьПерелета;
            СтоимостьБилета.Text = Convert.ToString(p1.СтоимостьБилета);
            Город_отправление.Text = P1.Город_отправление;
            Город_назначение.Text = P1.Город_назначение;
            
        }

        private void МодельСамолета_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var airplanes = db.Самолеты.Local.ToBindingList().Where(p => p.КодСамолета == ((Самолеты)МодельСамолета.SelectedValue).КодСамолета);
                AddTable.ItemsSource = airplanes;
                Наименование.Text = db.Авиакомпании.Local.ToBindingList().Where(p => p.КодАвиакомпании == airplanes.First().КодАвиакомпании).First().Наименование;
            }
            catch (Exception ex)//Если что пойдет не так - при точке останова глянуть значение ex
            {

            }
        }
    }
}
