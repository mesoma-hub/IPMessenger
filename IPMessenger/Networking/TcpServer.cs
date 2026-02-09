using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace IPMessenger.Networking
{
    internal class TcpServer
    {
        private readonly TcpListener _listener;
        private readonly ConcurrentBag<TcpClient> _clients = new();
        private readonly int _port;

        public TcpServer(int port)
        {
            _port = port;
            _listener = new TcpListener(IPAddress.Any, port);
        }

        public void Start()
        {
            _listener.Start();

            Console.WriteLine("Server started on port " + _port + "...");

            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();
                _clients.Add(client);

                Console.WriteLine("Client connected!");
                Task.Run(() => HandleClient(client));
            }
        }

        private void HandleClient(TcpClient client)
        {
            MessageReceiver receiver = new(client);

            while (true)
            {
                string message = receiver.ReceiveMessage();
                Console.WriteLine($"Received: {message}");
            }
        }

        private void BroadCast(string message)
        {
            foreach (TcpClient client in _clients)
            {
                MessageSender.SendMessage(client, message);
            }
        }
    }
}
