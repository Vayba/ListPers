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
       
        public MainWindow()
        {   
            InitializeComponent();
            //Color Back = new SolidColorBrush(Colors.Blue);;
            Brush Back = new SolidColorBrush(Colors.Blue);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Привет");

            //string Content = Interaction.InputBox("Vvedi","Imya","Pin", 200, 200);
            //NavigationWindow win = new NavigationWindow();
            //win.Content = new Movement();
            //win.Show();
            //this.Background = C;
            //if (Content != null)
            // {
            //    MessageBox.Show(Content);
            // }

            //var myForm = new Movement(this);
            //myForm.Show();

            Movement Movement = new Movement(this);
            Movement.Show();
        }
         

            public void ChangeBackgroundColor(string color)
        {
            switch (color)
            {
                case "Белый":
                    this.Background = System.Windows.Media.Brushes.White;
                    break;
                case "Красный":
                    this.Background = System.Windows.Media.Brushes.Red;
                    break;
                case "Черный":
                    this.Background = System.Windows.Media.Brushes.Black;
                    break;
                case "Зеленый":
                    this.Background = System.Windows.Media.Brushes.Green;
                    break;
            }
        }

    }

       

    

}