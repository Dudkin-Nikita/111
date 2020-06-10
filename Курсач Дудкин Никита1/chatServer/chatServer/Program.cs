using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;


namespace chatServer
{

    public class ServerObject
    {
        static TcpListener tcpListener; 
        List<ClientObject> clients = new List<ClientObject>(); 

        protected internal void AddConnection(ClientObject clientObject)
        {
            clients.Add(clientObject);
        }
        protected internal void RemoveConnection(string id)
        {
            
            ClientObject client = clients.FirstOrDefault(c => c.Id == id);
            
            if (client != null)
                clients.Remove(client);
        }
        
        protected internal void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8888);
                tcpListener.Start();
                Console.WriteLine("Прослушивание подключений.");

                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();

                    ClientObject clientObject = new ClientObject(tcpClient, this);
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                    if (clients.Count == 2) break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }

        
        protected internal void BroadcastMessage(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id != id) 
                {
                    clients[i].Stream.Write(data, 0, data.Length); 
                }
            }
        }
        
        protected internal void Disconnect()
        {
            tcpListener.Stop(); 

            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close(); 
            }
            Environment.Exit(0); 
        }
    }


    public class ClientObject
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream { get; private set; }
        string userName;
        TcpClient client;
        ServerObject server; 

        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                
                string message = GetMessage();
                userName = message;

                message ="пользователь '" + userName + "' подключился";
                
                server.BroadcastMessage(message, this.Id);
                Console.WriteLine(message);
                
                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        message = String.Format("{0}- {1}", userName, message);
                        Console.WriteLine(message);
                        server.BroadcastMessage(message, this.Id);
                    }
                    catch
                    {
                        //message = String.Format("{0}: отключился", userName);
                        message="пользователь '"+userName+"' отключился";
                        Console.WriteLine(message);
                        server.BroadcastMessage(message, this.Id);
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
                
                server.RemoveConnection(this.Id);
                Close();
            }
        }

        
        private string GetMessage()
        {
            byte[] data = new byte[64]; 
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);

            return builder.ToString();
        }

        
        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }
    }

    class RunServer
    {
        static ServerObject server; 
        static Thread listenThread; 
        public static void Start()
        {
            try
            {
                server = new ServerObject();
                listenThread = new Thread(new ThreadStart(server.Listen));
                listenThread.Start(); 
            }
            catch (Exception ex)
            {
                server.Disconnect();
                Console.WriteLine(ex.Message);
            }
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            RunServer.Start();
        }
    }
}
