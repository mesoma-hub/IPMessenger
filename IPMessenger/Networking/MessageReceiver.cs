using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace IPMessenger.Networking
{
    internal class MessageReceiver
    {
        private readonly TcpClient _client;
        private readonly byte[] _buffer = new byte[1024];

        public MessageReceiver(TcpClient client)
        {
            _client = client;
        }

        public string ReceiveMessage()
        {
            NetworkStream stream = _client.GetStream();
            int bytesRead = stream.Read(_buffer, 0, _buffer.Length);
            return Encoding.UTF8.GetString(_buffer, 0, bytesRead);
        }
    }
}
