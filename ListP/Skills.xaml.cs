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

namespace ListP
{
    /// <summary>
    /// Логика взаимодействия для Skills.xaml
    /// </summary>
    
    public partial class Skills : Window
    {
        private int _availablePoints = 7; // Доступные очки для распределения
        private int fight = 0;       // Значение силы
        private int atlet = 0;      // Значение ловкости
        private int strel = 0;   // Значение телосложения
        private int znanie = 0;  // Значение интеллекта
        private int talk = 0;
        private int vnimay = 0;
        private MainWindow MainWindow;
        private SchetSkill SchetSkill = new SchetSkill();
        public Skills(MainWindow MainWindow)
        {
            
            InitializeComponent();
            this.MainWindow = MainWindow;
            if ((MainWindow.GG.STREL != 0)|| (MainWindow.GG.FIGHT != 0)|| (MainWindow.GG.VNIM != 0)|| (MainWindow.GG.ZNAN != 0)|| (MainWindow.GG.TALK != 0)|| (MainWindow.GG.ATL != 0))
            {
                fight = MainWindow.GG.FIGHT;       // Значение силы
                vnimay = MainWindow.GG.VNIM;      // Значение ловкости
                znanie = MainWindow.GG.ZNAN;   // Значение телосложения
                strel = MainWindow.GG.STREL;  // Значение интеллекта
                talk = MainWindow.GG.TALK;
                atlet = MainWindow.GG.ATL;
                _availablePoints = 0;
            }
            FighttextBox.Text = fight.ToString();
            AtlTextBox.Text = atlet.ToString();
            ZnaTextBox.Text = znanie.ToString();
            VstrTextBox.Text = strel.ToString();
            TalkTextBox.Text = talk.ToString();
            VninTextBox.Text = vnimay.ToString();
            //AvailablePointsLabel.Content = 'Очки: {_availablePoints.ToString()}';
            UpdateAvailablePointsLabel();
            SchetSkill.MessageRaised += Schet_MessageRaised;
        }
        

        private void Schet_MessageRaised(object sender, string e)
        {
            MessageBox.Show(e); // Отображаем сообщение из Schet
        }

        private void UpdateAvailablePointsLabel()
        {
            AvailablePointsLabel.Content = $"Очки: {_availablePoints}";
        }

        private void ZnaPlus(object sender, RoutedEventArgs e)
        {
            var (newzna, newPoints, stata) = SchetSkill.Plus(znanie, _availablePoints, MainWindow.GG.INT);
            MainWindow.GG.INT = stata;
            znanie = newzna;
            _availablePoints = newPoints;
            ZnaTextBox.Text = znanie.ToString();
            UpdateAvailablePointsLabel();
        }

        private void ZnaMin (object sender, RoutedEventArgs e)
        {
            var (newzna, newPoints) = SchetSkill.Minus(znanie, _availablePoints);
            znanie = newzna;
            _availablePoints = newPoints;
            ZnaTextBox.Text = znanie.ToString();
            UpdateAvailablePointsLabel();
        }

        private void VstrPlus(object sender, RoutedEventArgs e)
        {
            var (newvstr, newPoints, stata) = SchetSkill.Plus(strel, _availablePoints, MainWindow.GG.DEX);
            strel = newvstr;
            MainWindow.GG.DEX = stata;
            _availablePoints = newPoints;
            VstrTextBox.Text = strel.ToString();
            UpdateAvailablePointsLabel();
        }

        private void VstrMin(object sender, RoutedEventArgs e)
        {
            var (newvstr, newPoints) = SchetSkill.Minus(strel, _availablePoints);
            strel = newvstr;
            _availablePoints = newPoints;
            VstrTextBox.Text = strel.ToString();
            UpdateAvailablePointsLabel();
        }

        private void VniPlus(object sender, RoutedEventArgs e)
        {
            var (newvni, newPoints, stata) = SchetSkill.Plus(vnimay, _availablePoints, MainWindow.GG.INT);
            vnimay = newvni;
            MainWindow.GG.INT = stata;
            _availablePoints = newPoints;
            VninTextBox.Text = vnimay.ToString();
            UpdateAvailablePointsLabel();
        }

        private void VniMin(object sender, RoutedEventArgs e)
        {
            var (newvni, newPoints) = SchetSkill.Minus(vnimay, _availablePoints);
            vnimay = newvni;
            _availablePoints = newPoints;
            VninTextBox.Text = vnimay.ToString();
            UpdateAvailablePointsLabel();
        }
        private void TalkPlus(object sender, RoutedEventArgs e)
        {
            var (newtalk, newPoints, stata) = SchetSkill.Plus(talk, _availablePoints, MainWindow.GG.CHA);
            talk = newtalk;
            MainWindow.GG.CHA = stata;
            _availablePoints = newPoints;
            TalkTextBox.Text = talk.ToString();
            UpdateAvailablePointsLabel();
        }

        private void TalkMin(object sender, RoutedEventArgs e)
        {
            var (newtalk, newPoints) = SchetSkill.Minus(talk, _availablePoints);
            talk = newtalk;
            _availablePoints = newPoints;
            TalkTextBox.Text = talk.ToString();
            UpdateAvailablePointsLabel();
        }
        private void FightPlus(object sender, RoutedEventArgs e)
        {
            var (newfight, newPoints, stata) = SchetSkill.Plus(fight, _availablePoints, MainWindow.GG.DEX);
            fight = newfight;
            MainWindow.GG.DEX = stata;
            _availablePoints = newPoints;
            FighttextBox.Text = fight.ToString();
            UpdateAvailablePointsLabel();
        }

        private void FightMin(object sender, RoutedEventArgs e)
        {
            var (newfight, newPoints) = SchetSkill.Minus(fight, _availablePoints);
            fight = newfight;
            _availablePoints = newPoints;
            FighttextBox.Text = fight.ToString();
            UpdateAvailablePointsLabel();
        }
        private void AtlPlus(object sender, RoutedEventArgs e)
        {
            var (newalt, newPoints, stata) = SchetSkill.Plus(atlet, _availablePoints, MainWindow.GG.STR);
            atlet = newalt;
            MainWindow.GG.STR = stata;
            _availablePoints = newPoints;
            AtlTextBox.Text = atlet.ToString();
            UpdateAvailablePointsLabel();
        }

        private void AtlMin(object sender, RoutedEventArgs e)
        {
            var (newalt, newPoints) = SchetSkill.Minus(atlet, _availablePoints);
            atlet = newalt;
            _availablePoints = newPoints;
            AtlTextBox.Text = atlet.ToString();
            UpdateAvailablePointsLabel();
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            if (_availablePoints > 0)
            {
                MessageBox.Show($"Вы не выбрали характеристики");
            }
            else
            {
                MainWindow.GG.FIGHT = fight;
                MainWindow.GG.VNIM = vnimay;
                MainWindow.GG.ZNAN = znanie;
                MainWindow.GG.STREL = strel;
                MainWindow.GG.ATL = atlet;
                MainWindow.GG.TALK = talk;
                MessageBox.Show("Характеристики распределены");
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((MainWindow.GG.STREL == 0) && (MainWindow.GG.FIGHT == 0) && (MainWindow.GG.VNIM == 0) && (MainWindow.GG.ZNAN == 0) && (MainWindow.GG.TALK == 0) && (MainWindow.GG.ATL == 0))
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
