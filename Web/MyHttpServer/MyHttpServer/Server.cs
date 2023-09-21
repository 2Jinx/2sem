using System;
using System.Net;
using System.Text;

namespace MyHttpServer
{
    public class Server
    {
        HttpListener server;
        ServerConfiguration configuration;

        const string staticFilesPath = "static";
        const string htmlPath = $"{staticFilesPath}/index.html";

        public Server()
        {
            server = new HttpListener();
            configuration = new ServerConfiguration();
            configuration.Set(server);
            server.Start();
            Console.WriteLine("The server started working!");
        }

        public void Start()
        {
            try
            {
                
                HttpListenerContext context = server.GetContext();
                HttpListenerRequest request = context.Request;

                if (!Directory.Exists(staticFilesPath))
                {
                    Directory.CreateDirectory(staticFilesPath);
                }

                string responseText = "";
                if (!File.Exists(htmlPath))
                {
                    responseText = $"Error 404. File {htmlPath} not found!";
                }
                else
                {
                    using (StreamReader reader = new StreamReader(htmlPath))
                    {
                        string html = reader.ReadToEnd();
                        responseText = html;
                    }
                }

                HttpListenerResponse response = context.Response;
                byte[] buffer = Encoding.UTF8.GetBytes(responseText);

                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.Close();
                Console.WriteLine("Request processed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Stop()
        {
            server.Stop();
            server.Close();
            Console.WriteLine("The server has finished working!");
        }
    }
}

