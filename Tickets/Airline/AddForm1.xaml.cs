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
    public partial class AddForm1 : Window
    {
        public AddForm1()
        {
            InitializeComponent();
            КодАвиакомпании.Focus();
        }

        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();

        private void AddMain_Click(object sender, RoutedEventArgs e)
        {
            //Проверка каждого обязательного для заполнения поля
            StringBuilder errors = new StringBuilder();
            if (КодАвиакомпании.Text.Length == 0 || double.TryParse(КодАвиакомпании.Text, out double x1) == false || x1 < 1) errors.AppendLine("Введите код авиакомпании");
            if (Наименование.Text.Length == 0) errors.AppendLine("Введите наименование авиакомпании");
            if (Телефон.Text.Length == 0) errors.AppendLine("Введите телефон авиакомпании");
            if (ЭлектронныйАдрес.Text.Length == 0) errors.AppendLine("Введите электронный адрес");
           
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
             //Создаем элемент таблицы
            Авиакомпании p1 = new Авиакомпании();
            //Заполняем этот элемент
            p1.КодАвиакомпании = Convert.ToInt32(КодАвиакомпании.Text);
            p1.Наименование = Наименование.Text;
            p1.Телефон = Телефон.Text;
            p1.ЭлектронныйАдрес = ЭлектронныйАдрес.Text;
           
            try
            {
                //Добавляем в БД
                db.Авиакомпании.Add(p1);
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
            db.Авиакомпании.Load();

        }


    }
}
