using ClassLibrary;
using System;
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
using ClassLibrary;

namespace ListP
{
    /// <summary>
    /// Логика взаимодействия для Parametr.xaml
    /// </summary>
    
    public partial class Parametr : Window
    {
        private int _availablePoints = 5; // Доступные очки для распределения
        private int _strength = 1;       // Значение силы
        private int _dexterity = 1;      // Значение ловкости
        private int _constitution = 1;   // Значение телосложения
        private int _intelligence = 1;  // Значение интеллекта
        private int _charisma = 1;
        private MainWindow MainWindow;
        private Schet Schet = new Schet();
        public Parametr(MainWindow MainWindow)
        {
            InitializeComponent();
            this.MainWindow = MainWindow;
            if(MainWindow.GG.STR !=0)
            {
               _strength = MainWindow.GG.STR;       // Значение силы
               _dexterity = MainWindow.GG.DEX;      // Значение ловкости
               _constitution = MainWindow.GG.TEL;   // Значение телосложения
               _intelligence = MainWindow.GG.INT;  // Значение интеллекта
               _charisma = MainWindow.GG.CHA;
                _availablePoints = 0;
            }
            StrengthTextBox.Text = _strength.ToString();
            DexTextBox.Text = _dexterity.ToString();
            WoundTextBox.Text = _constitution.ToString();
            IntTextBox.Text = _intelligence.ToString();
            CharTextBox.Text = _charisma.ToString();
            //AvailablePointsLabel.Content = 'Очки: {_availablePoints.ToString()}';
            UpdateAvailablePointsLabel();
            Schet.MessageRaised += Schet_MessageRaised;
        }
        private void Schet_MessageRaised(object sender, string e)
        {
            MessageBox.Show(e); // Отображаем сообщение из Schet
        }
        private void UpdateAvailablePointsLabel()
        {
            AvailablePointsLabel.Content = $"Очки: {_availablePoints}";
        }

        private void StrengPlus(object sender, RoutedEventArgs e)
        {
            var (newStrength, newPoints) = Schet.Plus(_strength, _availablePoints);
            _strength = newStrength;
            _availablePoints = newPoints;
            StrengthTextBox.Text = _strength.ToString();
            UpdateAvailablePointsLabel();
        }
        private void StrengMin(object sender, RoutedEventArgs e)
        {
            var (newStrength, newPoints) = Schet.Minus(_strength, _availablePoints);
            _strength = newStrength;
            _availablePoints = newPoints;
            StrengthTextBox.Text = _strength.ToString();
            UpdateAvailablePointsLabel();
        }

        private void DexPlus(object sender, RoutedEventArgs e)
        {
            var (newDexterity, newPoints) = Schet.Plus(_dexterity, _availablePoints);
            _dexterity = newDexterity;
            _availablePoints = newPoints;
            DexTextBox.Text = _dexterity.ToString();
            UpdateAvailablePointsLabel();
        }
        private void DexMin(object sender, RoutedEventArgs e)
        {
            var (newDexterity, newPoints) = Schet.Minus(_dexterity, _availablePoints);
            _dexterity = newDexterity;
            _availablePoints = newPoints;
            DexTextBox.Text = _dexterity.ToString();
            UpdateAvailablePointsLabel();
        }

        private void ConPlus(object sender, RoutedEventArgs e)
        {
            var (newConstitution, newPoints) = Schet.Plus(_constitution, _availablePoints);
            _constitution = newConstitution;
            _availablePoints = newPoints;
            WoundTextBox.Text = _constitution.ToString();
            UpdateAvailablePointsLabel();
        }
        private void ConMin(object sender, RoutedEventArgs e)
        {
            var (newConstitution, newPoints) = Schet.Minus(_constitution, _availablePoints);
            _constitution = newConstitution;
            _availablePoints = newPoints;
            WoundTextBox.Text = _constitution.ToString();
            UpdateAvailablePointsLabel();
        }

        private void IntPlus(object sender, RoutedEventArgs e)
        {
            var (newIntelligence, newPoints) = Schet.Plus(_intelligence, _availablePoints);
            _intelligence = newIntelligence;
            _availablePoints = newPoints;
            IntTextBox.Text = _intelligence.ToString();
            UpdateAvailablePointsLabel();
        }
        private void IntMin(object sender, RoutedEventArgs e)
        {
            var (newIntelligence, newPoints) = Schet.Minus(_intelligence, _availablePoints);
            _intelligence = newIntelligence;
            _availablePoints = newPoints;
            IntTextBox.Text = _intelligence.ToString();
            UpdateAvailablePointsLabel();
        }

        private void ChaPlus(object sender, RoutedEventArgs e)
        {
            var (newCharisma, newPoints) = Schet.Plus(_charisma, _availablePoints);
            _charisma = newCharisma;
            _availablePoints = newPoints;
            CharTextBox.Text = _charisma.ToString();
            UpdateAvailablePointsLabel();
        }
        private void ChaMin(object sender, RoutedEventArgs e)
        {
            var (newCharisma, newPoints) = Schet.Minus(_charisma, _availablePoints);
            _charisma = newCharisma;
            _availablePoints = newPoints;
            CharTextBox.Text = _charisma.ToString();
            UpdateAvailablePointsLabel();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (_availablePoints > 0)
            {
                MessageBox.Show($"Вы не выбрали характеристики");
            }
            else {
                MainWindow.GG.CHA = _charisma;
                MainWindow.GG.STR = _strength;
                MainWindow.GG.INT = _intelligence;
                MainWindow.GG.DEX = _dexterity;
                MainWindow.GG.TEL = _constitution;
                MessageBox.Show("Характеристики распределены");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MainWindow.GG.STR==0)
            {
                MessageBox.Show($"Вы не выбрали характеристики");
                e.Cancel = true;
            }
            if (_availablePoints != 0)
            {
                MessageBox.Show($"Вы не выбрали все характеристики");
                e.Cancel = true;
            }
        }
    }
}
