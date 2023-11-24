using System;
using System.Net.Sockets;

namespace Server
{
    public class Client
    {
        protected internal string Id { get; } = Guid.NewGuid().ToString();
        protected internal StreamWriter Writer { get; }
        protected internal StreamReader Reader { get; }

        protected internal TcpClient client;
        protected internal ServerObject server; // объект сервера

        public Client(TcpClient tcpClient, ServerObject server)
        {
            client = tcpClient;
            this.server = server;

            var stream = client.GetStream(); // получаем NetworkStream для взаимодействия с сервером

            Reader = new StreamReader(stream); // создаем StreamReader для чтения данных

            Writer = new StreamWriter(stream); // создаем StreamWriter для отправки данных
        }

        public async Task ProcessAsync()
        {
            try
            {
                string? userName = await Reader.ReadLineAsync(); // получаем имя пользователя
                string? message = $"{userName} вошел в чат";

                await server.BroadcastMessageAsync(message, Id); // посылаем сообщение о входе в чат всем подключенным пользователям
                Console.WriteLine(message);

                while (true) // в бесконечном цикле получаем сообщения от клиента
                {
                    try
                    {
                        message = await Reader.ReadLineAsync();
                        if (message == null) continue;
                        message = $"{userName}: {message}";
                        Console.WriteLine(message);
                        await server.BroadcastMessageAsync(message, Id);
                    }
                    catch
                    {
                        message = $"{userName} покинул чат";
                        Console.WriteLine(message);
                        await server.BroadcastMessageAsync(message, Id);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                server.RemoveConnection(Id); // в случае выхода из цикла закрываем ресурсы
            }
        }

        /// <summary>
        /// закрытие подключения
        /// </summary>
        protected internal void Close()
        {
            Writer.Close();
            Reader.Close();
            client.Close();
        }
    }
}
