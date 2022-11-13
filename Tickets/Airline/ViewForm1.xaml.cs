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

namespace Tickets.Airline
{
    /// <summary>
    /// Логика взаимодействия для ViewForm.xaml
    /// </summary>
    public partial class ViewForm1 : Window
    {
        public ViewForm1()
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
                    Viewtable.ItemsSource = db.ОпределеннаяПочтаИНомерАвиакомпании(Convert.ToInt32(ID.Text));
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
                int iHeader = Viewtable.Columns.Where(p => p.Header.ToString() == "НомерАвиакомпании").First().DisplayIndex;
                Viewtable.Columns[iHeader].Header = "Номер авиакомпании";                
                int iHeader12 = Viewtable.Columns.Where(p => p.Header.ToString() == "ЭлектронныйАдрес").First().DisplayIndex;
                Viewtable.Columns[iHeader12].Header = "Электронный адрес";
            }
            catch { }
        }

        private void Сброс_Click(object sender, RoutedEventArgs e)
        {
            ID.Clear();
            Viewtable.ItemsSource = null;
        }
    }
}
