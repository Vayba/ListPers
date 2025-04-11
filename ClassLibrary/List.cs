using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.VisualBasic;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.Data.Sqlite;
using System.Xml.Linq;



namespace ClassLibrary
{
    public class Ideal
    {
        public int Id { get; set; }
        public string Idea { get; set; }
        public string Mov_1 { get; set; }
        public string Mov_2 { get; set; }
        public string Desc { get; set; }
    }

    public class Character
    {
        public string Name;
        public string Move;
        public string Ideal;
        public string Start;
        public int STR;
        public int DEX;
        public int TEL;
        public int INT;
        public int CHA;
        public int FIGHT;
        public int VNIM;
        public int ZNAN;
        public int STREL;
        public int ATL;
        public int TALK;
    }

    public class SchetSkill
    {
        public event EventHandler<string> MessageRaised;

        protected virtual void OnMessageRaised(string message)
        {
            MessageRaised?.Invoke(this, message);
        }
        public (int updatedValue, int updatedPoints, int staticStata) Plus(int value, int availablePoints, int stata)
        {
            int oldvalue = value;

            if (availablePoints <= 0)
            {
                OnMessageRaised("Недостаточно очков для распределения!");
                return (value, availablePoints, stata); // No change
            }
            if (value >= stata)
            {
                OnMessageRaised($"Больше {stata} нельзя, не позволяет характеристика");
                return (value, availablePoints, stata); // No change
            }
            if (value >= 5)
            {
                OnMessageRaised("Больше нельзя");
                return (value, availablePoints, stata);
            }


            value++;
            availablePoints--;
            return (value, availablePoints, stata);
        }
        public (int updatedValue, int updatedPoints) Minus(int value, int availablePoints)
        {
            if (value > 0)
            {
                value--;
                availablePoints++;
                return (value, availablePoints);
            }
            else if (value == 0)
            {
                OnMessageRaised("Меньше нельзя!");
                return (value, availablePoints); // No change
            }
            else
            {
                OnMessageRaised("Недостаточно очков для распределения!");
                return (value, availablePoints); // No change
            }
        }
    }

    public class Schet
    {
        public event EventHandler<string> MessageRaised;

        protected virtual void OnMessageRaised(string message)
        {
            MessageRaised?.Invoke(this, message);
        }
        public (int updatedValue, int updatedPoints) Plus(int value, int availablePoints)
        {
            int oldvalue = value;
            if (value==5)
            {
                OnMessageRaised("Больше нельзя");
                return (value, availablePoints);
            }
            if (availablePoints > 0)
            {
                value++;
                availablePoints--;
                return (value, availablePoints);
            }
             else
            {
                OnMessageRaised("Недостаточно очков для распределения!");
                return (value, availablePoints); // No change
            }
        }
        public (int updatedValue, int updatedPoints) Minus(int value, int availablePoints)
        {
            if (value > 1)
            {
                value--;
                availablePoints++;
                return (value, availablePoints);
            }
            else if (value ==1)
            {
                OnMessageRaised("Меньше нельзя!");
                return (value, availablePoints); // No change
            }
            else
            {
                OnMessageRaised("Недостаточно очков для распределения!");
                return (value, availablePoints); // No change
            }
        }
    }

    public class Converter
    {
        private Random _random = new Random();
        public string Cinvert(int value)
        {
            string cube = string.Empty;
            switch (value)
            {
                case 0:
                    cube = "д4-2";
                    break;
                case 1:
                    cube = "д4";
                        break;
                case 2:
                    cube = "д6";
                    break;
                case 3:
                    cube = "д8";
                    break;
                case 4:
                    cube = "д10";
                    break;
                case 5:
                    cube = "д12";
                    break;
            }
            return (cube);
        }
        public int RollDice(string cubeType)
        {
            int result = 0;

            switch (cubeType)
            {
                case "д4-2": // Особый случай
                    result = _random.Next(1, 5) - 2; //  [1, 4] - 2,  минимальное значение -1, максимальное 2
                    break;
                case "д4":
                    result = _random.Next(1, 5); // От 1 до 4 включительно
                    break;
                case "д6":
                    result = _random.Next(1, 7); // От 1 до 6 включительно
                    break;
                case "д8":
                    result = _random.Next(1, 9); // От 1 до 8 включительно
                    break;
                case "д10":
                    result = _random.Next(1, 11); // От 1 до 10 включительно
                    break;
                case "д12":
                    result = _random.Next(1, 13); // От 1 до 12 включительно
                    break;
                default:
                    // Обработка некорректного типа кубика.
                    Console.WriteLine($"Ошибка: Неизвестный тип кубика: {cubeType}");
                    return -1; // Или другое значение по умолчанию, указывающее на ошибку
            }

            return result;
        }
    }

        public class DatabaseHelper
    {
        private const string DbName = "ideal.sqbpro";
        private const string TableName = "Ideal";

        public static void CreateDatabase()
        {
            using (var connection = new SqliteConnection($"Data Source={DbName}"))
            {
                connection.Open();

                // Check if the table already exists
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{TableName}';";
                var result = command.ExecuteScalar();

                if (result == null) // Table doesn't exist, create it
                {
                    command.CommandText = $@"
                        CREATE TABLE {TableName} (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Idea TEXT,
                            Mov_1 TEXT,
                            Mov_2 TEXT,
                            Desc TEXT
                        );
                    ";
                    command.ExecuteNonQuery();

                    InsertInitialData(connection); // Insert initial data after creating table
                }
                else
                {
                    if (GetRowCount(connection) == 0)
                    {
                        InsertInitialData(connection); // Insert if table exists, but is empty
                    }
                }
            }
        }

        private static int GetRowCount(SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT COUNT(*) FROM {TableName}";
            return Convert.ToInt32(command.ExecuteScalar());
        }

        private static void InsertInitialData(SqliteConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = $@"
                INSERT INTO {TableName} (Idea, Mov_1, Mov_2, Desc)
                VALUES ('Воля', 'Черное', 'Зеленое', 'Воля або Смерть');
            ";
            command.ExecuteNonQuery();


            command.CommandText = $@"
                INSERT INTO {TableName} (Idea, Mov_1, Mov_2, Desc)
                VALUES ('Порядок', 'Красное', 'Белое', 'В порядке едины ');
            ";
            command.ExecuteNonQuery();
        }

        public static ObservableCollection<Ideal> GetData(string colorFilter = null)
        {
            ObservableCollection<Ideal> data = new ObservableCollection<Ideal>();

            using (var connection = new SqliteConnection($"Data Source={DbName}"))
            {
                connection.Open();

                var command = connection.CreateCommand();

                if (string.IsNullOrEmpty(colorFilter))
                {
                    command.CommandText = $"SELECT Id, Idea, Mov_1, Mov_2, Desc FROM {TableName}";
                }
                else
                {
                    command.CommandText = $"SELECT Id, Idea, Mov_1, Mov_2, Desc FROM {TableName} WHERE Mov_1 = '{colorFilter}' OR Mov_2 = '{colorFilter}'";
                }


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(new Ideal
                        {
                            Id = reader.GetInt32(0),
                            Idea = reader.GetString(1),
                            Mov_1 = reader.GetString(2),
                            Mov_2 = reader.GetString(3),
                            Desc = reader.GetString(4)
                        });
                    }
                }
            }

            return data;
        }

        public static void InsertData(string idea, string mov1, string mov2, string desc)
        {
            using (var connection = new SqliteConnection($"Data Source={DbName}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $@"INSERT INTO {TableName} (Idea, Mov_1, Mov_2, Desc) VALUES ('{idea}', '{mov1}', '{mov2}', '{desc}')";
                command.ExecuteNonQuery();
            }
        }

        public static void UpdateData(int id, string idea, string mov1, string mov2, string desc)
        {
            using (var connection = new SqliteConnection($"Data Source={DbName}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $@"UPDATE {TableName} SET Idea = '{idea}', Mov_1 = '{mov1}', Mov_2 = '{mov2}', Desc = '{desc}' WHERE Id = {id}";
                command.ExecuteNonQuery();
            }
        }
    }
}