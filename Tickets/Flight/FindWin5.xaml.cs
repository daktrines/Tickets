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
    public partial class FindWin5 : Window
    {

        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        public object q;
        public FindWin5(DataGrid curTable)
        {
            InitializeComponent();
            CurTable = curTable;
            Find.Focus();
        }
        DataGrid CurTable;
        private void FindForm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < CurTable.Items.Count; i++)
                {
                    var row = (РейсыПроцедура_Result)CurTable.Items[i];
                    string findContent = row.МодельСамолета;
                    try
                    {
                        if (findContent != null && findContent.Contains(Find.Text))
                        {
                            q = CurTable.Items[i];
                            break;
                        }
                    }
                    catch
                    {

                    }
                }
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
