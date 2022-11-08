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
    public partial class FindWin : Window
    {

        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        public IEnumerable<ГлавноеОкно_Result> q;
        public FindWin()
        {
            InitializeComponent();
        }
        private void FindForm_Click(object sender, RoutedEventArgs e)
        {
            //Получаем поиск записи
            q = db.ГлавноеОкно().ToList().Where(p => p.Фамилия == Find.Text);
            DialogResult = true;
            Close();
        }
    }
}
