using _19;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tickets
{
    /// <summary>
    /// Логика взаимодействия для AddForm.xaml
    /// </summary>
    public partial class EditForm : Window
    {
        public EditForm()
        {
            InitializeComponent();
            
        }

        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        Пассажиры p1;//Элемент для работы с записью

        private void AddMain_Click(object sender, RoutedEventArgs e)
        {
            //Проверка каждого обязательного для заполнения поля
            StringBuilder errors = new StringBuilder();
            if (КодПассажира.Text.Length == 0 || double.TryParse(КодПассажира.Text, out double x1) == false || x1 < 1) errors.AppendLine("Введите табельный номер");
            if (Фамилия.Text.Length == 0) errors.AppendLine("Введите фамилию");
            if (Имя.Text.Length == 0) errors.AppendLine("Введите имя");
            if (Отчество.Text.Length == 0) errors.AppendLine("Введите отчество");
            if (СерияПаспорта.Text.Length == 0 || double.TryParse(СерияПаспорта.Text, out double x2) == false) errors.AppendLine("Введите серию паспорта");
            if (НомерПаспорта.Text.Length == 0 || double.TryParse(НомерПаспорта.Text, out double x3) == false) errors.AppendLine("Введите номер паспорта");
            if (МобильныйТелефон.Text.Length == 0) errors.AppendLine("Введите мобильный телефон");
            if (ДатаРождения.Text.Length == 0) errors.AppendLine("Введите дату");
            //if (НазваниеКласса.Text != "Бизнес-класс" && НазваниеКласса.Text != "Эконом-класс")
            //    errors.AppendLine("Введите пол Бизнес-класс/Эконом-класс");
            //if (Багаж.Text != "False" && Багаж.Text != "True")
            //    errors.AppendLine("Введите пол False/True");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            // ((Билеты)НазваниеКласса.SelectedValue).НазваниеКласса, ((Билеты)Багаж.SelectedValue).Багаж
            
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
                
                //Сохраняем изменения
                db.SaveChanges();
                MessageBox.Show("Информация сохранена!");
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
            //db.Пассажиры.Load();
            //db.Билеты.Load();
            //Получаем запись по коду
            p1 = db.Пассажиры.Find(Data.КодПассажира);
            //Отображаем запись
            КодПассажира.Text = Convert.ToString(p1.КодПассажира);
            Фамилия.Text = p1.Фамилия;
            Имя.Text = p1.Имя;
            Отчество.Text = p1.Отчество;
            СерияПаспорта.Text = Convert.ToString(p1.СерияПаспорта);
            НомерПаспорта.Text = Convert.ToString(p1.НомерПаспорта);
            МобильныйТелефон.Text = p1.МобильныйТелефон;
            ДатаРождения.Text = Convert.ToString(p1.ДатаРождения);

        }


    }
}
