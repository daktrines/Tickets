﻿using System;
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

namespace Tickets.Airplane
{
    /// <summary>
    /// Логика взаимодействия для ViewForm.xaml
    /// </summary>
    public partial class ViewForm3 : Window
    {
        public ViewForm3()
        {
            InitializeComponent();
        }

        Продажа_билетов_на_самолетEntities db = ContextDB.GetContext();
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sql1.IsChecked == true)
                {
                    Viewtable.ItemsSource = db.МодельСамолета();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        private void Viewtable_AutoGeneratedColumns(object sender, EventArgs e)
        {
            try
            {
                int iHeader = Viewtable.Columns.Where(p => p.Header.ToString() == "Наименование").First().DisplayIndex;
                Viewtable.Columns[iHeader].Header = "Наименование авиакомпании";
                int iHeader1 = Viewtable.Columns.Where(p => p.Header.ToString() == "МодельСамолета").First().DisplayIndex;
                Viewtable.Columns[iHeader1].Header = "Модель самолета";              
            }
            catch { }
        }
    }
}
