using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using Microsoft.VisualBasic;
using Npgsql;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic; //  Для работы со списками



namespace ListP
{
    /// <summary>
    /// Логика взаимодействия для Movement.xaml
    /// </summary>
   
    public partial class Movement : Window
    {
        private MainWindow MainWindow;
        public Movement(MainWindow MainWindow)
        {
            InitializeComponent();
           this.MainWindow = MainWindow;
            this.Loaded += LoadDataGrid;
        }

        private void LoadDataGrid(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                // Загружаем все данные из базы данных
                var allData = context.Ideals.ToList();
                //var allData = context.Ideals.Include(x => x.Id).ToList();

                //  Преобразуем List в ObservableCollection
                ObservableCollection<Ideal> observableCollection = new ObservableCollection<Ideal>(allData);

                // Привязываем ObservableCollection к DataGrid
                dataGridIdeal.ItemsSource = observableCollection;
                dataGridIdeal.Items.Refresh();
            }
        }


        private void Click_Mov(object sender, RoutedEventArgs e)
        {
            //MainWindow.Background = new SolidColorBrush(Colors.Red);
            
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)MovComboBox.SelectedItem;
            if (selectedItem != null)
            {
                string color = selectedItem.Content.ToString();
                MainWindow.ChangeBackgroundColor(color);
                FilterDataGrid(color);
            }
        }

        private void FilterDataGrid(string selectedColor)
        {
            using (var context = new ApplicationContext())
            {
                // LINQ запрос для фильтрации данных
                // var filteredData = context.Ideals
                //  .Where(item => item.Mov_1 == selectedColor || item.Mov_2 == selectedColor)
                //  .ToList();
                var filteredData = context.Ideals.ToList();

                //  Преобразуем List в ObservableCollection
                ObservableCollection<Ideal> observableCollection = new ObservableCollection<Ideal>(filteredData);

                // Обновление DataGrid
                Console.WriteLine($"Count: {observableCollection.Count}");
                dataGridIdeal.ItemsSource = observableCollection; //  dataGridIdeal - имя вашего DataGrid
                dataGridIdeal.Items.Refresh(); //  Обновляем DataGrid (если необходимо)
            }
        }
    }
}
