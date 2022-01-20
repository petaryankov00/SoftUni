using MyWebServer.Server.HTTP;
using MyWebServer.Server.Routing;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MyWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;
        private readonly RoutingTable routingTable;

        public HttpServer(string _ipAdress, int _port,Action<IRoutingTable> routingTableConfig)
        {
            this.ipAddress = IPAddress.Parse(_ipAdress);
            this.port = _port;
            serverListener = new TcpListener(ipAddress, port);

            routingTableConfig(this.routingTable = new RoutingTable());
        }



        public HttpServer(int port, Action<IRoutingTable> routingTable) 
            : this("127.0.0.1",port, routingTable)
        {
        }

        public HttpServer(Action<IRoutingTable> routingTable)
            : this(8080, routingTable)
        {
        }


        public async Task Start()
        {
            serverListener.Start();

            Console.WriteLine($"Server started on port: {port}");
            Console.WriteLine("Listening for requests...");

            while (true)
            {
                var connection = await serverListener.AcceptTcpClientAsync();

                _ = Task.Run(async () =>
                {
                    var networkStream = connection.GetStream();

                    var requestText = await this.ReadRequest(networkStream);
                    Console.WriteLine(requestText);
                  
                    var request = Request.Parse(requestText);
                    var response = this.routingTable.MatchRequest(request);

                    AddSession(request, response);

                    await WriteResponse(networkStream, response);

                    connection.Close();
                });

            }

        }

        private static void AddSession(Request request, Response response)
        {
            var sessionExist = request.Session.ContainsKey(Session.SessionCurrentDayKey);

            if (!sessionExist)
            {
                request.Session[Session.SessionCurrentDayKey] = DateTime.Now.ToString();
                response.Cookies.Add(Session.SessionCookieName, request.Session.Id);
            }
        }

        private async Task WriteResponse(NetworkStream networkStream, Response response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());
            await networkStream.WriteAsync(responseBytes);            
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];
            var totalBytes = 0;

            var requestBuilder = new StringBuilder(); 
            do
            {
                var bytesReaded = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                totalBytes += bytesReaded;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("The Request is too large.");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer,0,bufferLength));
            }
            while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }
    }
}
