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
    public partial class AddForm4 : Window
    {
        public AddForm4()
        {
            InitializeComponent();
            КодБилета.Focus();
        }

        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();

        private void AddMain_Click(object sender, RoutedEventArgs e)
        {
            //Проверка каждого обязательного для заполнения поля
            StringBuilder errors = new StringBuilder();
            if (КодБилета.Text.Length == 0 || double.TryParse(КодБилета.Text, out double x1) == false || x1 < 1) errors.AppendLine("Введите код билета");
            if (Наименование.Text.Length == 0) errors.AppendLine("Введите наименование авиакомпании ");
            if (Фамилия.Text.Length == 0) errors.AppendLine("Введите наименование авиакомпании ");
            if (Имя.Text.Length == 0) errors.AppendLine("Введите имя");
            if (Отчество.Text.Length == 0) errors.AppendLine("Введите отчество");
            if (КодРейса.Text.Length == 0 || double.TryParse(КодРейса.Text, out double x2) == false || x2 < 1) errors.AppendLine("Введите количество мест");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            try
            {
                db.НовыйСамолет(Convert.ToInt32(КодСамолета.Text), ((Авиакомпании)Наименование.SelectedValue).КодАвиакомпании, МодельСамолета.Text, Convert.ToInt32(КоличествоМест.Text));
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
            db.Самолеты.Load();
            //Поличаем список из другой таблицы
            Наименование.ItemsSource = db.Авиакомпании.Local.ToBindingList();

        }

        private void Наименование_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //получаем список авиакомпаний из таблицы авиакомпаниии, и потом используем выборку по наименованию
                AddTable.ItemsSource = db.Авиакомпании.Local.ToBindingList().Where(p => p.Наименование == ((Авиакомпании)Наименование.SelectedValue).Наименование);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Город_назначение_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
