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
    public partial class AddForm2 : Window
    {
        public AddForm2()
        {
            InitializeComponent();
            КодАэропорта.Focus();
        }

        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();

        private void AddMain_Click(object sender, RoutedEventArgs e)
        {
            //Проверка каждого обязательного для заполнения поля
            StringBuilder errors = new StringBuilder();
            if (КодАэропорта.Text.Length == 0 || double.TryParse(КодАэропорта.Text, out double x1) == false || x1 < 1) errors.AppendLine("Введите код аэропорта");
            if (Наименование.Text.Length == 0) errors.AppendLine("Введите наименование ");
            if (Город.Text.Length == 0) errors.AppendLine("Введите  адрес");
            if (Телефон.Text.Length == 0) errors.AppendLine("Введите телефон ");
           
           
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
             //Создаем элемент таблицы
            Аэропорты p1 = new Аэропорты();
            //Заполняем этот элемент
            p1.КодАэропорта = Convert.ToInt32(КодАэропорта.Text);
            p1.Наименование = Наименование.Text;
            p1.Город = Город.Text;
            p1.Телефон = Телефон.Text;
            
           
            try
            {
                //Добавляем в БД
                db.Аэропорты.Add(p1);
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
            db.Аэропорты.Load();

        }


    }
}
