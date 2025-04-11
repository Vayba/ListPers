using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace ListP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Character GG { get; set; } = new Character();
        public MainWindow()
        {   
            InitializeComponent();
            
            //Color Back = new SolidColorBrush(Colors.Blue);;
            Brush Back = new SolidColorBrush(Colors.Blue);
            GG.CHA = 0;
            GG.STR = 0;
            GG.INT = 0;
            GG.DEX = 0;
            GG.TEL = 0;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Здесь ты выбираешь принципы персонажа");

            Movement Movement = new Movement(this);
            Movement.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Здесь ты выбираешь характеристики ");

            Parametr Parametr = new Parametr(this);
            Parametr.Show();
        }

        private void Button_Click_end(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Твой персонаж");

            Itog Itog = new Itog (this);
            Itog.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Здесь ты выбираешь навыки");

            if (GG.STR == 0)
            {
                MessageBox.Show($"Для начала распредели характеристики");
            }
            else
            {
                Skills Skills = new Skills(this);
                Skills.Show();
            }
        }

        public void ChangeBackgroundColor(string color)
        {
            switch (color)
            {
                case "Белое":
                    this.Background = System.Windows.Media.Brushes.White;
                    break;
                case "Красное":
                    this.Background = System.Windows.Media.Brushes.Red;
                    break;
                case "Черное":
                    this.Background = System.Windows.Media.Brushes.Black;
                    break;
                case "Зеленое":
                    this.Background = System.Windows.Media.Brushes.Green;
                    break;
            }
        }
        private void Name_Button_Click(object sender, RoutedEventArgs e)
        {
           

            GG.Name = Name_TextBox.Text;
            MessageBox.Show($"Теперь ты {GG.Name}");
        }

    }

       

    

}