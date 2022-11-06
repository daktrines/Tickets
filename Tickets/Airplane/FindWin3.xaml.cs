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
    public partial class FindWin3 : Window
    {

        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        public IEnumerable<СамолетыПроцедура_Result> q;
        public FindWin3()
        {
            InitializeComponent();
            Find.Focus();
        }
        private void FindForm_Click(object sender, RoutedEventArgs e)
        {
            //Получаем поиск записи
            q = db.СамолетыПроцедура().ToList().Where(p => p.МодельСамолета == Find.Text);
            DialogResult = true;
            Close();
        }
    }
}
