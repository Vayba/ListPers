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
using System.Collections.Generic;
using SQLitePCL;
using Microsoft.Data.Sqlite;
using System.Reflection.Emit;
using System.Runtime;




namespace ListP
{
    /// <summary>
    /// Логика взаимодействия для Movement.xaml
    /// </summary>

    public partial class Movement : Window
    {
        private MainWindow MainWindow;

        public ObservableCollection<Ideal> Data { get; set; } = new ObservableCollection<Ideal>();

        public Movement(MainWindow MainWindow)
        {
            InitializeComponent();
            this.MainWindow = MainWindow;
            DataContext = this;

            // Ensure the database exists and has initial data
            ClassLibrary.DatabaseHelper.CreateDatabase();

            // Load data from the database and display it in the DataGrid
            LoadData();
        }

        private void LoadData(string colorFilter = null)
        {
            // Call the GetData method from the DatabaseHelper class
            ObservableCollection<Ideal> loadedData = ClassLibrary.DatabaseHelper.GetData(colorFilter);

            // Populate the ObservableCollection with the loaded data
            Data.Clear();
            foreach (var item in loadedData)
            {
                Data.Add(item);
            }

            // Set the DataGrid's ItemsSource to the ObservableCollection
            dataGrid.ItemsSource = Data;
        }

        private void Click_Mov(object sender, RoutedEventArgs e)
        {
            if (MovComboBox.SelectedItem != null)
            {
                string selectedColor = ((ComboBoxItem)MovComboBox.SelectedItem).Content.ToString();
                MainWindow.GG.Start = selectedColor;

                // Optional: Display a message to confirm the save
                MessageBox.Show($"Start color saved: {MainWindow.GG.Start}");
            }
            else
            {
                MessageBox.Show("Please select a color from the ComboBox.");
            }
        }



        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)MovComboBox.SelectedItem;

            if (selectedItem != null)
            {
                string color = selectedItem.Content.ToString();
                MainWindow.ChangeBackgroundColor(color); // Keep the main window color change
                LoadData(color); // Load data based on the selected color
                UpdateLabels(color);
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is Ideal selectedIdeal)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)MovComboBox.SelectedItem;
                if (selectedItem != null)
                {
                    MainWindow.GG.Ideal = selectedIdeal.Idea; // Assign the selected Idea to Character.Ideal

                    // Optional: Display a message to confirm

                    MessageBox.Show($"Ideal saved: {MainWindow.GG.Ideal}");
                }
                else
                {
                    MessageBox.Show($"Прошу вас выбрать движение, для начала");
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Здесь ваш код после закрытия окна
            // Пример: Освобождение ресурсов
            // CleanupResources();
            // Application.Current.Shutdown(); // Закрыть приложение (если это главное окно)
            //ComboBoxItem selectedItem = (ComboBoxItem)MovComboBox.SelectedItem;
            if (MainWindow.GG.Start == null)
            {

                MessageBox.Show($"Вы не выбрали движение");
                e.Cancel = true;

            }
            else if (MainWindow.GG.Ideal == null)
            {
                MessageBox.Show($"Вы не выбрали идеал");
                e.Cancel = true;
            }
            else if (MainWindow.GG.Start == "Белое")
            {
                if (MainWindow.GG.Ideal == "Воля")
                {
                    MessageBox.Show($"Выбран неверный идеал ");
                    e.Cancel = true;
                }
            }
            else if (MainWindow.GG.Start == "Красное")
            {
                if (MainWindow.GG.Ideal == "Воля")
                {
                    MessageBox.Show($"Выбран неверный идеал ");
                    e.Cancel = true;
                }
            }
            else if (MainWindow.GG.Start == "Черное")
            {
                if (MainWindow.GG.Ideal == "Порядок")
                {
                    MessageBox.Show($"Выбран неверный идеал ");
                    e.Cancel = true;
                }
            }
            else if (MainWindow.GG.Start == "Зеленое")
            {
                if (MainWindow.GG.Ideal == "Порядок")
                {
                    MessageBox.Show($"Выбран неверный идеал ");
                    e.Cancel = true;
                }
            }
        }

        private void UpdateLabels(string color)
        {
            switch (color)
            {
                case "Белое":
                    label1.Content = "Ангел-хранитель";
                    label2.Content = "Вы можете потратить фишку, чтобы заставить цель перебросить удачный бросок на атаку";
                    break;
                case "Красное":
                    label1.Content = "Сила Масс";
                    label2.Content = "Вы можете потратить фишку, чтобы добавить +2 к проверку с участием 2 и более лиц ";
                    break;
                case "Черное":
                    label1.Content = "Масть не та ";
                    label2.Content = "Вы можете потратить фишку, чтобы увеличить на грань куб";
                    break;
                case "Зеленое":
                    label1.Content = "Мать-земля";
                    label2.Content = "Вы можете потратить фишку, чтобы излечить 1 еденицу урона ";
                    break;
                default:
                    label1.Content = "Черта:";
                    label2.Content = "Описание черты";
                    break;
            }
        }

    }
}
