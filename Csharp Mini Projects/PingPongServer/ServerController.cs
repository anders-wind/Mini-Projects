﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using PingPongClient;
using PingPongCommon;

namespace PingPongServer
{
    class ServerConnection : UdpBase
    {
        private IPEndPoint _listenOn;

        public ServerConnection() : this(new IPEndPoint(IPAddress.Any,32123))
        {
        }

        public ServerConnection(IPEndPoint endpoint)
        {
            _listenOn = endpoint;
            Client = new UdpClient(_listenOn);
        }

        public void Reply(string message,IPEndPoint endpoint)
        {
            var datagram = Encoding.ASCII.GetBytes(message);
            Client.Send(datagram, datagram.Length,endpoint);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Server");
            //create a new server
            var server = new ServerConnection();

            //start listening for messages and copy the messages back to the client
            var factory = Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    var received = await server.Receive();
                    Console.WriteLine(@"Message received: " + received.Message);
                    server.Reply("copy " + received.Message, received.Sender);
                    if (received.Message == "quit")
                        break;
                }
            });
            Console.WriteLine("Listening...");
            string read;
            do
            {
                read = Console.ReadLine();
            } while (read != "quit");
            factory.Dispose();
        }
    }
}
