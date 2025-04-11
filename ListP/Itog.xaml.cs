using ClassLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Itog.xaml
    /// </summary>
    public partial class Itog : Window
    {

        private MainWindow MainWindow;
        private int zagr = 2;
        private Converter Converter = new Converter();
        public Itog(MainWindow MainWindow)
        {
            InitializeComponent();
            this.MainWindow = MainWindow;
            LoadCharacterData(MainWindow.GG);
        }

        private void LoadCharacterData(Character character)
        {

            Start.Content = $"Начало: {character.Start }";
            Ideal.Content = $"Идеал: {character.Ideal }";
            Name.Content= $"Имя: {character.Name}";
            if (character.STR != 0)
            {
                str.Text = $"Cила:{Converter.Cinvert(character.STR)}";
                dex.Text = $"Ловкость:{Converter.Cinvert(character.DEX)}";
                con.Text = $"Тело:{Converter.Cinvert(character.TEL)}";
                intel.Text = $"Смекалка:{Converter.Cinvert(character.INT)}";
                cha.Text = $"Характер:{Converter.Cinvert(character.CHA)}";

              
            }
            if ((character.STREL != 0) || (character.FIGHT != 0) || (character.VNIM != 0) || (character.ZNAN != 0) || (character.TALK != 0) || (character.ATL != 0))
            {
                fig.Text = $"Драка:{Converter.Cinvert(character.FIGHT)}";
                pew.Text = $"Стрельба:{Converter.Cinvert(character.STREL)}";
                zna.Text = $"Знания:{Converter.Cinvert(character.ZNAN)}";
                atl.Text = $"Атлетика:{Converter.Cinvert(character.ATL)}";
                vni.Text = $"Внимание:{Converter.Cinvert(character.VNIM)}";
                ube.Text = $"Убеждение:{Converter.Cinvert(character.TALK)}";
            }
            // Создаём список для DataGrid с учётом значений по умолчанию

        }

        private void Fight_Roll(object sender, RoutedEventArgs e)
        {
            Character character = MainWindow.GG;
            string It = " ";
            int Itog = 0;
            if ((MainWindow.GG.STREL == 0) && (MainWindow.GG.FIGHT == 0) && (MainWindow.GG.VNIM == 0) && (MainWindow.GG.ZNAN == 0) && (MainWindow.GG.TALK == 0) && (MainWindow.GG.ATL == 0))
            {
                MessageBox.Show("Вы еще не определили параметры");
            }
            else
            {
                It = Converter.Cinvert(character.FIGHT);
                Itog = Converter.RollDice(It);
                MessageBox.Show($"Результат:{Itog}");
            }
        }

        private void Strell_Roll(object sender, RoutedEventArgs e)
        {
            Character character = MainWindow.GG;
            string It = " ";
            int Itog = 0;
            if ((MainWindow.GG.STREL == 0) && (MainWindow.GG.FIGHT == 0) && (MainWindow.GG.VNIM == 0) && (MainWindow.GG.ZNAN == 0) && (MainWindow.GG.TALK == 0) && (MainWindow.GG.ATL == 0))
            {
                MessageBox.Show("Вы еще не определили параметры");
            }
            else
            {
                It = Converter.Cinvert(character.STREL);
                Itog = Converter.RollDice(It);
                MessageBox.Show($"Результат:{Itog}");
            }
        }

        private void Znan_Roll(object sender, RoutedEventArgs e)
        {
            Character character = MainWindow.GG;
            string It = " ";
            int Itog = 0;
            if ((MainWindow.GG.STREL == 0) && (MainWindow.GG.FIGHT == 0) && (MainWindow.GG.VNIM == 0) && (MainWindow.GG.ZNAN == 0) && (MainWindow.GG.TALK == 0) && (MainWindow.GG.ATL == 0))
            {
                MessageBox.Show("Вы еще не определили параметры");
            }
            else
            {
                It = Converter.Cinvert(character.ZNAN);
                Itog = Converter.RollDice(It);
                MessageBox.Show($"Результат:{Itog}");
            }
        }

        private void Atl_Roll(object sender, RoutedEventArgs e)
        {
            Character character = MainWindow.GG;
            string It = " ";
            int Itog = 0;
            if ((MainWindow.GG.STREL == 0) && (MainWindow.GG.FIGHT == 0) && (MainWindow.GG.VNIM == 0) && (MainWindow.GG.ZNAN == 0) && (MainWindow.GG.TALK == 0) && (MainWindow.GG.ATL == 0))
            {
                MessageBox.Show("Вы еще не определили параметры");
            }
            else
            {
                It = Converter.Cinvert(character.ATL);
                Itog = Converter.RollDice(It);
                MessageBox.Show($"Результат:{Itog}");
            }
        }

        private void Vnim_Roll(object sender, RoutedEventArgs e)
        {
            Character character = MainWindow.GG;
            string It = " ";
            int Itog = 0;
            if ((MainWindow.GG.STREL == 0) && (MainWindow.GG.FIGHT == 0) && (MainWindow.GG.VNIM == 0) && (MainWindow.GG.ZNAN == 0) && (MainWindow.GG.TALK == 0) && (MainWindow.GG.ATL == 0))
            {
                MessageBox.Show("Вы еще не определили параметры");
            }
            else
            {
                It = Converter.Cinvert(character.VNIM);
                Itog = Converter.RollDice(It);
                MessageBox.Show($"Результат:{Itog}");
            }
        }

        private void Talk_Roll(object sender, RoutedEventArgs e)
        {
            Character character = MainWindow.GG;
            string It = " ";
            int Itog = 0;
            if ((MainWindow.GG.STREL == 0) && (MainWindow.GG.FIGHT == 0) && (MainWindow.GG.VNIM == 0) && (MainWindow.GG.ZNAN == 0) && (MainWindow.GG.TALK == 0) && (MainWindow.GG.ATL == 0))
            {
                MessageBox.Show("Вы еще не определили параметры");
            }
            else
            {
                It = Converter.Cinvert(character.TALK);
                Itog = Converter.RollDice(It);
                MessageBox.Show($"Результат:{Itog}");
            }
        }



        private void ScreenshotButton_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image (*.png)|*.png|JPEG Image (*.jpeg;*.jpg)|*.jpeg;*.jpg";
            saveFileDialog.Title = "Сохранить лист";
            saveFileDialog.FileName = "Лист_Персонажа"; // Имя файла по умолчанию

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {

                    string filePath = saveFileDialog.FileName;
                    string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();

                    RenderTargetBitmap rtb = new RenderTargetBitmap(
                        (int)ActualWidth,
                        (int)ActualHeight,
                        96d, // DPI X
                        96d, // DPI Y
                        PixelFormats.Default); 

                    rtb.Render(this);


                    BitmapEncoder encoder = null;
                    switch (fileExtension)
                    {
                        case ".png":
                            encoder = new PngBitmapEncoder();
                            break;
                        case ".jpeg":
                        case ".jpg":
                            encoder = new JpegBitmapEncoder { QualityLevel = 95 }; // Уровень качества JPEG
                            break;
                        default:
                            MessageBox.Show("Неподдерживаемый формат файла.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                    }

                    BitmapFrame frame = BitmapFrame.Create(rtb);
                    encoder.Frames.Add(frame);


                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        encoder.Save(stream);
                    }

                    MessageBox.Show("Лист  успешно сохранен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении : {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Character character = MainWindow.GG;
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Сохранить персонажа"
            };

            if (saveFileDialog.ShowDialog() == true) // Если пользователь выбрал файл
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine(character.Name);
                    writer.WriteLine(character.Move);
                    writer.WriteLine(character.Ideal);
                    writer.WriteLine(character.Start);
                    writer.WriteLine(character.STR);
                    writer.WriteLine(character.DEX);
                    writer.WriteLine(character.TEL);
                    writer.WriteLine(character.INT);
                    writer.WriteLine(character.CHA);
                    writer.WriteLine(character.FIGHT);
                    writer.WriteLine(character.VNIM);
                    writer.WriteLine(character.ZNAN);
                    writer.WriteLine(character.STREL);
                    writer.WriteLine(character.ATL);
                    writer.WriteLine(character.TALK);
                }
            }
        }

        public Character LoadCharacterFromFile(string filePath)
        {
             zagr = 0;
            Character character = new Character();

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Загрузить персонажа"
            };

            if (openFileDialog.ShowDialog() == true) // Если пользователь выбрал файл
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    zagr = 1;
                     MainWindow.GG.Name = reader.ReadLine();
                     MainWindow.GG.Move = reader.ReadLine();
                     MainWindow.GG.Ideal = reader.ReadLine();
                     MainWindow.GG.Start = reader.ReadLine();
                     MainWindow.GG.STR = int.Parse(reader.ReadLine());
                     MainWindow.GG.DEX = int.Parse(reader.ReadLine());
                     MainWindow.GG.TEL = int.Parse(reader.ReadLine());
                     MainWindow.GG.INT = int.Parse(reader.ReadLine());
                     MainWindow.GG.CHA = int.Parse(reader.ReadLine());
                     MainWindow.GG.FIGHT = int.Parse(reader.ReadLine());
                     MainWindow.GG.VNIM = int.Parse(reader.ReadLine());
                     MainWindow.GG.ZNAN = int.Parse(reader.ReadLine());
                     MainWindow.GG.STREL = int.Parse(reader.ReadLine());
                     MainWindow.GG.ATL = int.Parse(reader.ReadLine());
                     MainWindow.GG.TALK = int.Parse(reader.ReadLine());
                    LoadCharacterData(MainWindow.GG);
                }
            }

            return character;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "character.txt";
            Character character = LoadCharacterFromFile(filePath);
            MessageBox.Show("Готово");

        }


    }



}
