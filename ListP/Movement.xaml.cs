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
                
            }
        }

       
    }
}
