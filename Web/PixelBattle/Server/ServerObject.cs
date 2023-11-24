
using System.Net;
using System.Net.Sockets;
using System.Xml.Linq;

namespace Server
{
    public class ServerObject
    {
        private TcpListener? tcpListener = new TcpListener(IPAddress.Any, 8888); // сервер для прослушивания
        private List<Client>? clients = new List<Client>(); // все подключения

        protected internal void RemoveConnection(string id)
        {
            Client? client = clients.FirstOrDefault(c => c.Id == id); // получаем по id закрытое подключение

            if (client != null) clients.Remove(client); // и удаляем его из списка подключений
            client?.Close();
        }

        /// <summary>
        /// Прослушивание входящих подключений
        /// </summary>
        /// <returns></returns>
        protected internal async Task ListenAsync()
        {
            try
            {
                tcpListener?.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();

                    Client client = new Client(tcpClient, this);
                    clients.Add(client);
                    Task.Run(client.ProcessAsync);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        /// <summary>
        /// Трансляция сообщения подключенным клиентам
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="id">Id клиента</param>
        /// <returns></returns>
        protected internal async Task BroadcastMessageAsync(string message, string id)
        {
            foreach (var client in clients)
            {
                if (client.Id != id) // если id клиента не равно id отправителя
                {
                    await client.Writer.WriteLineAsync(message); //передача данных
                    await client.Writer.FlushAsync();
                }
            }
        }

        /// <summary>
        /// отключение всех клиентов
        /// </summary>
        protected internal void Disconnect()
        {
            foreach (var client in clients)
            {
                client.Close(); //отключение клиента
            }
            tcpListener?.Stop(); //остановка сервера
        }
    }
}
