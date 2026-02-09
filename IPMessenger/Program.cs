using IPMessenger.Networking;

namespace IPMessenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int port = 5000;
            Console.WriteLine("Select Mode:");
            Console.WriteLine("1 - Server");
            Console.WriteLine("2 - Client");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                TcpServer server = new TcpServer(port);
                server.Start();
            }
            else
            {
                Console.WriteLine("Enter server IP: ");
                string? ip = Console.ReadLine();
                TcpClientHandler client = new TcpClientHandler(ip!, port);
                client.Start();
            }
        }
    }
}
