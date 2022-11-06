using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class FindWin2 : Window
    {

        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        public IEnumerable<Аэропорты> q;
        public FindWin2()
        {
            InitializeComponent();
            Find.Focus();
        }
        private void FindForm_Click(object sender, RoutedEventArgs e)
        {
            //Получаем поиск записи
            q = db.Аэропорты.ToList().Where(p => p.Город == Find.Text);
            DialogResult = true;
            Close();
        }
    }
}
