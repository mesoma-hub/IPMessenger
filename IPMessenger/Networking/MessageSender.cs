using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace IPMessenger.Networking
{
    internal class MessageSender
    {
        public static void SendMessage(TcpClient client, string message)
        {
            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }
    }
}
