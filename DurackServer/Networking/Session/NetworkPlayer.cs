﻿using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using DurackServer.networking.PlayerIO;

namespace DurackServer.networking.Session
{
    public class NetworkPlayer
    {
        public GameSession GameSession { get; set; }
        private TcpClient Client { get; }
        public NetworkPlayer(TcpClient client)
        {
            Client = client;
        }

        public string GetMessage()
        {
            var stream = Client.GetStream();
            var data = new byte[64];
            var builder = new StringBuilder();
            int bytes;
            do
            {
                bytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);
            return builder.ToString();
        }

        public void SendMessageToClient(Command cmd)
        {
            var msg = JsonSerializer.Serialize(cmd);
            Client.GetStream().Write(Encoding.Unicode.GetBytes(msg));
        }

        public void Close()
        {
            Client.Close();
        }

    }
}