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
    public partial class EditForm1 : Window
    {
        public EditForm1()
        {
            InitializeComponent();
        }

        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        Авиакомпании p1;//Элемент для работы с записью

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
           
            //Заполняем этот элемент
            p1.КодАвиакомпании = Convert.ToInt32(КодАвиакомпании.Text);
            p1.Наименование = Наименование.Text;
            p1.Телефон = Телефон.Text;
            p1.ЭлектронныйАдрес = ЭлектронныйАдрес.Text;
           
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
            //Получаем запись по коду
            p1 = db.Авиакомпании.Find(ContextDB.ID);
            //Отображаем запись
            КодАвиакомпании.Text = Convert.ToString(p1.КодАвиакомпании);
            Наименование.Text = p1.Наименование;
            Телефон.Text = p1.Телефон;
            ЭлектронныйАдрес.Text = p1.ЭлектронныйАдрес;
        }


    }
}
