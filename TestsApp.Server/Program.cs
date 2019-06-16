using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsApp.Lib.Messaging;
using TestsApp.Lib.Networking;
using TestsApp.Lib.Threading;

namespace TestsApp.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var listener = new UdpMessageListener<ServiceMessage>(8080))
            {
                listener.IncomingMessage += OnServiceMessage;
                listener.Start();
                Console.WriteLine("Сервер жив!");
                Console.WriteLine("Список команд: ");
                Console.WriteLine("questions - вывести список вопросов из базы;");
                Console.WriteLine("delete    - удалить вопрос из базы по id;");
                Console.WriteLine("exit      - закончить работу сервера.");
                Console.WriteLine();

                while (true)
                {
                    string command = Console.ReadLine().ToLower();
                    switch (command) {
                        case "questions":
                            {
                                string connectionString = GetConnectionString();
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();

                                    string query = @"SELECT Id, Text FROM [QUESTIONS]";
                                    //string query = @"SELECT * FROM [QUESTIONS]";
                                    using (SqlCommand sqlcommand = new SqlCommand(query, connection))
                                    {
                                        using (SqlDataReader reader = sqlcommand.ExecuteReader())
                                        {
                                            while (reader.Read())
                                            { 
                                                for (int i = 0; i < reader.FieldCount; i++)
                                                {
                                                    var dtS = reader.GetDataTypeName(i);
                                                    string s;
                                                    switch(dtS)
                                                    {
                                                        case "int":
                                                            {
                                                                s = String.Format("{0}", reader.GetInt32(i));
                                                                break;
                                                            }
                                                        case "nvarchar":
                                                            {
                                                                s = reader.GetString(i);
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                s = "@" + dtS + "@";
                                                                break;
                                                            }
                                                    }
                                                    
                                                    Console.Write("\"{0}\" ", s == null ? "null" : s);
                                                }
                                                Console.WriteLine();
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case "delete":
                            {
                                string connectionString = GetConnectionString();

                                int countQuestions;
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    string query = @"SELECT COUNT(*) cnt FROM [QUESTIONS]";
                                    using (SqlCommand commandS = new SqlCommand(query, connection))
                                    {
                                        countQuestions = Convert.ToInt32(commandS.ExecuteScalar()) + 1;
                                    }
                                    connection.Close();
                                }

                                Console.Write("Введите номер вопроса (Введите \"-1\" для отмены операции): ");
                                int id;
                                if (!Int32.TryParse(Console.ReadLine(), out id))
                                {
                                    Console.WriteLine("Значение введено некорректно.");
                                }
                                else if (id == -1)
                                {
                                    Console.WriteLine("Операция отменена");
                                    break;
                                }
                                else if (id > countQuestions || id < -1)
                                {
                                    Console.WriteLine("Вопроса с таким id нет в базе.");
                                    break;
                                }
                                
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    
                                    string query = @"DELETE FROM Questions WHERE Id = " + id;
                                    SqlCommand commandDel = new SqlCommand(query, connection);

                                    commandDel.ExecuteNonQuery();

                                    if (id != countQuestions)
                                    {
                                        for (int i = id + 1; i <= countQuestions; i++)
                                        {
                                            query = @"UPDATE Questions SET Id = " + (i-1) + " WHERE Id = " + i;
                                            commandDel = new SqlCommand(query, connection);

                                            commandDel.ExecuteNonQuery();
                                        }
                                    }
                                    Console.WriteLine("Вопрос успешно удален.");
                                    connection.Close();
                                }
                                break;
                            }
                        case "exit":
                            {
                                goto exit; 
                            }
                        default:
                            {
                                Console.WriteLine("Команда не распознана.");
                                break;
                            }
                    }
                    Console.WriteLine();
                }
            exit: Console.WriteLine("Выключение..."); 
            }
        }

        //Обработка сообщения пришедшего на сервер
        private static void OnServiceMessage(object sender, IncommingMessageEventArgs<ServiceMessage> e)
        {
            if (e != null && e.Message.Command == Command.CountQuestions)
            {
                //Обработка запроса об общем количестве вопросов, хранящихся в базе 
                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    int maxQuestionNumber;
                    string query = @"SELECT COUNT(*) cnt FROM [QUESTIONS]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        maxQuestionNumber = Convert.ToInt32(command.ExecuteScalar());

                        using (var writer = NetworkingFactory.UdpWriter<Question>(e.Sender.Address, 9091))
                        {
                            var info = new Question(Convert.ToString(maxQuestionNumber), null, null, null, null, null);
                            writer.Write(info);
                        }
                    }
                }
            }
            else if (e != null && e.Message.Command == Command.NextQuestion)
            {
                //обработка запроса следующего вопроса
                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT text, answer, var1, var2, var3, var4 FROM [QUESTIONS] WHERE id = @Id";//+ e.Message.Num;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", SqlDbType.Int);
                        command.Parameters["@Id"].Value = e.Message.Num;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            int columnId = reader.GetOrdinal("text");
                            string text = reader.GetString(columnId);
                            
                            columnId = reader.GetOrdinal("answer");
                            string answer = reader.GetString(columnId);
                            //
                            columnId = reader.GetOrdinal("var1");
                            string var1 = reader.GetString(columnId);

                            columnId = reader.GetOrdinal("var2");
                            string var2 = reader.GetString(columnId);

                            columnId = reader.GetOrdinal("var3");
                            string var3 = reader.GetString(columnId);

                            columnId = reader.GetOrdinal("var4");
                            string var4 = reader.GetString(columnId);
                            //
                            using (var writer = NetworkingFactory.UdpWriter<Question>(e.Sender.Address, 9090))
                            {
                                var info = new Question(text, answer, var1, var2, var3, var4);
                                writer.Write(info);
                            }
                        }
                    }
                }
            }
            else if (e != null && e.Message.Command == Command.AddQuestion)
            {
                //обработка запроса добавления нового вопроса в базу
                string connectionString = GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Questions VALUES (@Id, @Text, @Answer, @Var1, @Var2, @Var3, @Var4)";

                    command.Parameters.AddWithValue("@Id", SqlDbType.Int);
                    command.Parameters.AddWithValue("@Text", SqlDbType.NVarChar);
                    command.Parameters.AddWithValue("@Answer", SqlDbType.NVarChar);
                    command.Parameters.AddWithValue("@Var1", SqlDbType.NVarChar);
                    command.Parameters.AddWithValue("@Var2", SqlDbType.NVarChar);
                    command.Parameters.AddWithValue("@Var3", SqlDbType.NVarChar);
                    command.Parameters.AddWithValue("@Var4", SqlDbType.NVarChar);

                    string query = @"SELECT COUNT(*) cnt FROM [QUESTIONS]";
                    using (SqlCommand commandS = new SqlCommand(query, connection))
                    {
                        command.Parameters["@Id"].Value = Convert.ToInt32(commandS.ExecuteScalar()) + 1;
                    }
                    
                    command.Parameters["@Text"].Value = e.Message.Question.Text;
                    command.Parameters["@Answer"].Value = e.Message.Question.Answer;
                    command.Parameters["@Var1"].Value = e.Message.Question.Var1;
                    command.Parameters["@Var2"].Value = e.Message.Question.Var2;

                    if (e.Message.Question.Var3 != "")
                    {
                        command.Parameters["@Var3"].Value = e.Message.Question.Var3;
                    }
                    else
                    {
                        command.Parameters["@Var3"].Value = "";
                    }
                    if (e.Message.Question.Var4 != "")
                    {
                        command.Parameters["@Var4"].Value = e.Message.Question.Var4; ;
                    }
                    else
                    {
                        command.Parameters["@Var4"].Value = "";
                    }
                    
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Генерирует строку для подключения к базе данных
        /// </summary>
        /// <returns> Строка для подключения к базе данных </returns>
        private static string GetConnectionString()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = @"(LocalDB)\MSSQLLocalDB",
                AttachDBFilename = Path.GetFullPath("Database.mdf"),
                IntegratedSecurity = true
            };
            return builder.ConnectionString;
        }
    }
}
