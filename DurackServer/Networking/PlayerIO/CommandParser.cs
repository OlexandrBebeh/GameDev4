﻿using System.Text.Json;

namespace DurackServer.networking.PlayerIO
{
    public class CommandParser
    {
        public static Command FromString(string text)
        {
            return JsonSerializer.Deserialize<Command>(text);
        }
        
        public static Command FromBytes(byte[] text)
        {
            return JsonSerializer.Deserialize<Command>(text);
        }
    }
}