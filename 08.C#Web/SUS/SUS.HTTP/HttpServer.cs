namespace SUS.HTTP
{
    using System;
    using System.Net;
    using System.Linq;
    using System.Text;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class HttpServer : IHttpServer
    {
        private List<Route> routeTable;

        public HttpServer(List<Route> routes)
        {
            this.routeTable = routes;
        }

        public async Task StartAsync(int port)
        {
            var tcpLitener = new TcpListener(IPAddress.Loopback, port);
            tcpLitener.Start();

            while (true)
            {
                var client = await tcpLitener.AcceptTcpClientAsync();

                ProcessClient(client);
            }
        }

        private async Task ProcessClient(TcpClient client)
        {
            try
            {
                using var networkStream = client.GetStream();

                var byteData = await ReadByteDataAsync(networkStream);

                var requestAsString = Encoding.UTF8.GetString(byteData.ToArray(), 0, byteData.Count);

                if (string.IsNullOrWhiteSpace(requestAsString)) return;

                var request = new HttpRequest(requestAsString);

                Console.WriteLine($"{request.Method} {request.Path} => {request.Headers.Count - request.Cookies.Count} headers, {request.Cookies.Count} cookies");
                Console.WriteLine(new string('=', 100));

                var response = this.GetResponseByPath(request);

                AddHeadersToResponse(request, response);

                var responseHeaderBytes = Encoding.UTF8.GetBytes(response.ToString());

                await networkStream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);

                if (response.Body != null)
                {
                    await networkStream.WriteAsync(response.Body, 0, response.Body.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void AddHeadersToResponse(HttpRequest request, HttpResponse response)
        {
            response.Headers.Add(new Header("Server", "SUS Server 1.0"));

            var sessionCookie = request.Cookies
                                .FirstOrDefault(x => x.Name == HttpConstant.SessionCookieName);

            if (sessionCookie != null)
            {
                var responseSessionCookie = new ResponseCookie(sessionCookie.Name, sessionCookie.Value);
                responseSessionCookie.Path = "/";
                response.Cookies.Add(responseSessionCookie);
            }
        }

        private HttpResponse GetResponseByPath(HttpRequest request)
        {
            HttpResponse response;

            var route = this.routeTable
                    .FirstOrDefault(x => string.Compare(x.Path, request.Path, true) == 0
                                && x.Method == request.Method);
            if (route != null)
            {
                response = route.Action(request);
            }
            else
            {
                response = new HttpResponse("text/html", new byte[0], HttpStatusCode.NotFound);
            }

            return response;
        }

        private static async Task<List<byte>> ReadByteDataAsync(NetworkStream networkStream)
        {
            var buffer = new byte[HttpConstant.BufferBytes];

            var data = new List<byte>(buffer.Length);
            var currPosition = 0;
            while (true)
            {
                var dataRead = await networkStream.ReadAsync(buffer, currPosition, buffer.Length);

                if (dataRead < buffer.Length)
                {
                    var compressData = new byte[dataRead];
                    Array.Copy(buffer, compressData, compressData.Length);
                    data.AddRange(compressData);

                    break;
                }
                else
                {
                    currPosition += buffer.Length;
                    data.AddRange(buffer);
                }
            }

            return data;
        }
    }
}
