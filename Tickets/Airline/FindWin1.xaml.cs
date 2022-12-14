using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для FindWin.xaml
    /// </summary>
    public partial class FindWin1 : Window
    {

        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        public int q = -1;//Код записи авиакомпании
        public FindWin1()
        {
            InitializeComponent();
            Find.Focus();
        }
        private void FindForm_Click(object sender, RoutedEventArgs e)
        {
            //Получаем поиск записи
            try
            {
                q = db.Авиакомпании.ToList().Where(p => p.Наименование.Contains(Find.Text)).First().КодАвиакомпании;
                DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Нет таких авиакомпаний!", "Поиск авиакомпании", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
