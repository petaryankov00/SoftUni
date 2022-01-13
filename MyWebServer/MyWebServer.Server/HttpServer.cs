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

        public HttpServer(string _ipAdress, int _port)
        {
            this.ipAddress = IPAddress.Parse(_ipAdress);
            this.port = _port;

            serverListener = new TcpListener(ipAddress, port);
        }


        public void Start()
        {
            serverListener.Start();

            Console.WriteLine($"Server started on port: {port}");
            Console.WriteLine("Listening for requests...");

            while (true)
            {
                var connection = serverListener.AcceptTcpClient();
                var networkStream = connection.GetStream();

                var requestText = this.ReadRequest(networkStream);
                Console.WriteLine(requestText);

                var content = "Hello Guys!";
                WriteResponse(networkStream, content);

                connection.Close();
            }
        }

        private void WriteResponse(NetworkStream networkStream, string content)
        {
            var contentLength = Encoding.UTF8.GetByteCount(content);
            var response = $@"HTTP/1.1 200 OK 
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);
            networkStream.Write(responseBytes);            
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];
            var totalBytes = 0;

            var requestBuilder = new StringBuilder(); 
            do
            {
                var bytesReaded = networkStream.Read(buffer, 0, buffer.Length);
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
