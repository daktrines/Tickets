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

namespace Tickets.Flight
{
    /// <summary>
    /// Логика взаимодействия для ViewForm.xaml
    /// </summary>
    public partial class ViewForm5 : Window
    {
        public ViewForm5()
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
                if (sql2.IsChecked == true)
                {
                    Viewtable.ItemsSource = db.ОпределеннаяДатаРейса();
                }
                if (sql3.IsChecked == true)
                {
                    Viewtable.ItemsSource = db.ОпределеннаяПочтаИНомерАвиакомпании(Convert.ToInt32(ID.Text));
                }
                if (sql4.IsChecked == true)
                {
                    Viewtable.ItemsSource = db.СтоимостьОпределенногоРейса(Convert.ToInt32(ID.Text));
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
                int iHeader0 = Viewtable.Columns.Where(p => p.Header.ToString() == "СтоимостьБилета").First().DisplayIndex;
                Viewtable.Columns[iHeader0].Header = "Стоимость билета";
                int iHeader = Viewtable.Columns.Where(p => p.Header.ToString() == "Наименование").First().DisplayIndex;
                Viewtable.Columns[iHeader].Header = "Наименование авиакомпании";
                int iHeader1 = Viewtable.Columns.Where(p => p.Header.ToString() == "МодельСамолета").First().DisplayIndex;
                Viewtable.Columns[iHeader1].Header = "Модель самолета";
                int iHeader2 = Viewtable.Columns.Where(p => p.Header.ToString() == "КодРейса").First().DisplayIndex;
                Viewtable.Columns[iHeader2].Header = "Код рейса";
                int iHeader3 = Viewtable.Columns.Where(p => p.Header.ToString() == "МодельСамолета").First().DisplayIndex;
                Viewtable.Columns[iHeader3].Header = "Модель самолета";
                int iHeader4 = Viewtable.Columns.Where(p => p.Header.ToString() == "КодАвиакомпании").First().DisplayIndex;
                Viewtable.Columns[iHeader4].Header = "Код авиакомпании";
                int iHeader5 = Viewtable.Columns.Where(p => p.Header.ToString() == "КодСамолёта").First().DisplayIndex;
                Viewtable.Columns[iHeader5].Header = "Код самолёта";
                int iHeader6 = Viewtable.Columns.Where(p => p.Header.ToString() == "ДатаОтправления").First().DisplayIndex;
                Viewtable.Columns[iHeader6].Header = "Дата отправления";
                int iHeader7 = Viewtable.Columns.Where(p => p.Header.ToString() == "ДатаПрибытия").First().DisplayIndex;
                Viewtable.Columns[iHeader7].Header = "Дата прибытия";
                int iHeader8 = Viewtable.Columns.Where(p => p.Header.ToString() == "ВремяОтправления").First().DisplayIndex;
                Viewtable.Columns[iHeader8].Header = "Время отправления";
                int iHeader9 = Viewtable.Columns.Where(p => p.Header.ToString() == "ВремяПрибытия").First().DisplayIndex;
                Viewtable.Columns[iHeader9].Header = "Время прибытия";
                int iHeader10 = Viewtable.Columns.Where(p => p.Header.ToString() == "ДлительностьПерелета").First().DisplayIndex;
                Viewtable.Columns[iHeader10].Header = "Длительность перелета";
                int iHeader11 = Viewtable.Columns.Where(p => p.Header.ToString() == "НомерАвиакомпании").First().DisplayIndex;
                Viewtable.Columns[iHeader11].Header = "Номер авиакомпании";
                int iHeader12 = Viewtable.Columns.Where(p => p.Header.ToString() == "ЭлектронныйАдрес").First().DisplayIndex;
                Viewtable.Columns[iHeader12].Header = "Электронный адрес";
                int iHeader13 = Viewtable.Columns.Where(p => p.Header.ToString() == "НомерРейса").First().DisplayIndex;
                Viewtable.Columns[iHeader13].Header = "Номер рейса";
            }
            catch { }
        }
    }
}