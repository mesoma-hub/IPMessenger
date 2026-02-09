using System.Net.Sockets;

namespace IPMessenger.Networking
{
    internal class TcpClientHandler
    {
        private readonly string _ip;
        private readonly int _port;
        private TcpClient _client;

        public TcpClientHandler(string ip, int port)
        {
            _ip = ip;
            _port = port;
        }

        public void Start()
        {
            _client = new TcpClient();
            _client.Connect(_ip, _port);
            Console.WriteLine("Connected to server!");

            Task.Run(() => ReceiveLoop());

            while (true)
            {
                string? message = Console.ReadLine();
                MessageSender.SendMessage(_client, message!);
            }
        }

        private void ReceiveLoop()
        {
            MessageReceiver receiver = new (_client);
            while (true)
            {
                string message = receiver.ReceiveMessage(); 
                Console.WriteLine($"<< {message}");
            }
        }
    }
}
