using System;
using Microsoft.Data.Sqlite;
 
namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*using (var connection = new SqliteConnection("Data Source=usersdata.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "CREATE TABLE UsersDB(_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Login TEXT NOT NULL, Password TEXT NOT NULL)";
                command.ExecuteNonQuery();
                
                Console.WriteLine("Таблица Users создана");
            }*/

            Console.WriteLine("Введите логин:");
            string login = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            string pass = Console.ReadLine();

            string sqlExpression = $"INSERT INTO UsersDB (Login, Password) VALUES ('{login}', '{pass}')";
            using (var connection = new SqliteConnection("Data Source=usersdata.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                command.ExecuteReader();
            }
            string sqlExpression1 = "SELECT * FROM UsersDB";
            using (var connection = new SqliteConnection("Data Source=usersdata.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression1, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var writeid = reader.GetValue(0);
                            var writelogin = reader.GetValue(1);
                            var writepass = reader.GetValue(2);

                            Console.WriteLine($"{writeid} \t {writelogin} \t {writepass}");
                        }
                    }
                }
            }

            Console.Read();
        }
    }
}