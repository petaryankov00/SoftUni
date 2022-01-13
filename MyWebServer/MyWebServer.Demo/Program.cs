using MyWebServer.Server;
using System;

namespace MyWebServer.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var server = new HttpServer("127.0.0.1", 8080);
            server.Start();
        }
    }
}