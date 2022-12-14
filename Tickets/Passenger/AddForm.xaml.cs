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
    public partial class AddForm : Window
    {
        public AddForm()
        {
            InitializeComponent();
            КодПассажира.Focus();
        }

        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();

        private void AddMain_Click(object sender, RoutedEventArgs e)
        {
            //Проверка каждого обязательного для заполнения поля
            StringBuilder errors = new StringBuilder();
            if (КодПассажира.Text.Length == 0 || double.TryParse(КодПассажира.Text, out double x1) == false || x1 < 1) errors.AppendLine("Введите код пассажира");
            if (Фамилия.Text.Length == 0) errors.AppendLine("Введите фамилию");
            if (Имя.Text.Length == 0) errors.AppendLine("Введите имя");
            if (Отчество.Text.Length == 0) errors.AppendLine("Введите отчество");
            if (СерияПаспорта.Text.Length == 0 || double.TryParse(СерияПаспорта.Text, out double x2) == false) errors.AppendLine("Введите серию паспорта");
            if (НомерПаспорта.Text.Length == 0 || double.TryParse(НомерПаспорта.Text, out double x3) == false) errors.AppendLine("Введите номер паспорта");
            if (МобильныйТелефон.Text.Length == 0) errors.AppendLine("Введите мобильный телефон");
            if (ДатаРождения.Text.Length == 0) errors.AppendLine("Введите дату");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            //Создаем элемент таблицы
            Пассажиры p1 = new Пассажиры();
            //Заполняем этот элемент
            p1.КодПассажира = Convert.ToInt32(КодПассажира.Text);
            p1.Фамилия = Фамилия.Text;
            p1.Имя = Имя.Text;
            p1.Отчество = Отчество.Text;
            p1.СерияПаспорта = Convert.ToInt32(СерияПаспорта.Text);
            p1.НомерПаспорта = Convert.ToInt32(НомерПаспорта.Text);
            p1.МобильныйТелефон =МобильныйТелефон.Text;
            p1.ДатаРождения = Convert.ToDateTime(ДатаРождения.Text);

            try
            {
                //Добавляем в БД
                db.Пассажиры.Add(p1);
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
            db.Пассажиры.Load();
            db.Билеты.Load();
        }
    }
}
