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
    public partial class EditForm2 : Window
    {
        public EditForm2()
        {
            InitializeComponent();
        }

        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        Аэропорты p1;//Элемент для работы с записью

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

            //Заполняем этот элемент
            p1.КодАэропорта = Convert.ToInt32(КодАэропорта.Text);
            p1.Наименование = Наименование.Text;
            p1.Город = Город.Text;
            p1.Телефон = Телефон.Text;
            
           
            try
            {
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
            //Получаем запись по коду
            p1 = db.Аэропорты.Find(ContextDB.ID);
            //Отображаем запись
            КодАэропорта.Text = Convert.ToString(p1.КодАэропорта);
            Наименование.Text = p1.Наименование;
            Город.Text = p1.Город;
            Телефон.Text = p1.Телефон;
        }
    }
}
