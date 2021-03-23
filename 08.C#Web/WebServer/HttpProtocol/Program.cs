namespace HttpProtocol
{
    using HttpProtocol.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Sockets;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;

    public class Program
    {
        private const string HTTP_NEW_LINE = "\r\n";

        private static Dictionary<string, int> SessionStorage = new Dictionary<string, int>();

        static async Task Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var context = new VaskoTwitterContext();

            var tcpListener = new TcpListener(IPAddress.Loopback, 12345);
            tcpListener.Start();

            // service daemon 
            while (true)
            {
                var client = tcpListener.AcceptTcpClient();

                ProcessClinetAsync(client, context);
            }

        }

        public static async Task ProcessClinetAsync(TcpClient client, VaskoTwitterContext context)
        {
            using var stream = client.GetStream();

            var readData = await ReadDataFromClient(stream);

            var requestString = GetRequestStringFromReadData(readData);

            if (requestString == "") return;

            var sid = Guid.NewGuid().ToString();

            var match = Regex.Match(requestString, @$"sid=[^\n]*{HTTP_NEW_LINE}");

            if (match.Success)
            {
                sid = match.Value.Substring(4);
            }

            var requestArgs = requestString.Split(HTTP_NEW_LINE).ToArray();

            var requestMethodArgs = requestArgs[0].Split().ToArray();

            var method = requestMethodArgs[0];
            var resource = requestMethodArgs[1];

            if (method == "GET")
            {
                DoGetMethod(stream, context, resource, sid);
            }
            else if (method == "POST")
            {
                Task.Run(() => DoPostMethod(stream, context, requestArgs, sid));
            }

            Console.WriteLine(requestString);

            Console.WriteLine(new string('=', 100));
        }

        private static async Task DoPostMethod(NetworkStream stream, VaskoTwitterContext context, string[] requestArgs, string sId)
        {
            var postArgs = requestArgs
                .Last()
                .Split(new char[] { '=', '&' })
                .ToArray();

            var user = HttpUtility.UrlDecode(postArgs[1]);
            var vaskoTweet = HttpUtility.UrlDecode(postArgs[3]);

            var unescapeUser = Uri.UnescapeDataString(user);
            var unescapeTweet = Uri.UnescapeDataString(vaskoTweet);

            await context.Tweets.AddAsync(new Tweet
            {
                User = unescapeUser,
                VaskoTweet = unescapeTweet
            });

            await context.SaveChangesAsync();

            ShowHomePage(stream, context, sId);
        }

        private static string GetAllListItems(VaskoTwitterContext context)
        {
            var allTweets = context.Tweets
                                .Select(x => $@" <li>
                                   {x.User}: {x.VaskoTweet} 
                               </li>")
                                .ToArray();

            var allListItems = string.Join(Environment.NewLine, allTweets);

            return allListItems;
        }

        private static void DoGetMethod(NetworkStream stream, VaskoTwitterContext context, string resource, string sId)
        {
            if (resource == "/"
                || resource == "/home")
            {
                ShowHomePage(stream, context, sId);
            }
            else
            {
                ShowHomePage(stream, context, sId);
            }
        }

        private static async Task ShowHomePage(NetworkStream stream, VaskoTwitterContext context, string sId)
        {
            var allListItems = GetAllListItems(context);

            if (!SessionStorage.ContainsKey(sId))
                SessionStorage[sId] = 0;

            SessionStorage[sId]++;

            var html = @$"<h1>Hello to VaskoTwitter, from VaskoServer 2021, Time: {DateTime.Now}. You have logged in {SessionStorage[sId]}</h1>
                          <form method=post>
                              User:  <input name=username />
                              Tweet: <input name=tweet />
                              <input type=submit value=Submit />
                          </form>
                          <ul method=post>
                               {allListItems}
                          </ul>";

            var serverResponse = "HTTP/1.1 200 OK" + HTTP_NEW_LINE +
                "Server: VaskoServer 2021" + HTTP_NEW_LINE +
                //"Location: /vasko-tweets" + HTTP_NEW_LINE +
                "Content-Type: text/html; charset=utf-8" + HTTP_NEW_LINE +
                "Content-Length: " + html.Length + HTTP_NEW_LINE +
                $"Set-Cookie: sid={sId}; HttpOnly" + HTTP_NEW_LINE +
                "Set-Cookie: lang=en; Path=/register; Secure" + HTTP_NEW_LINE +
                "Set-Cookie: lang=bg; Path=/; Max-Age=-1" + HTTP_NEW_LINE +
                //"Content-Disposition: attachment; filename=vasko.txt" + html.Length + HTTP_NEW_LINE +
                HTTP_NEW_LINE +
                html + HTTP_NEW_LINE;

            var responseToBytes = Encoding.UTF8.GetBytes(serverResponse);

            await stream.WriteAsync(responseToBytes);
        }

        private static string GetRequestStringFromReadData(List<KeyValuePair<int, byte[]>> readData)
        {
            var offset = 0;
            var sb = new StringBuilder();
            foreach (var kvp in readData)
            {
                var text = Encoding.UTF8.GetString(kvp.Value, offset, kvp.Key);

                sb.Append(text);

                offset += kvp.Key;
            }

            return sb.ToString();
        }

        private static async Task<List<KeyValuePair<int, byte[]>>> ReadDataFromClient(NetworkStream stream)
        {
            var offset = 0;
            var buffer = new byte[4096];
            var readData = new List<KeyValuePair<int, byte[]>>();
            while (true)
            {
                var length = await stream.ReadAsync(buffer, offset, buffer.Length);

                if (length < 4096)
                {
                    if (length != 0)
                        readData.Add(new KeyValuePair<int, byte[]>(length, buffer));
                    break;
                }

                offset += length;

                readData.Add(new KeyValuePair<int, byte[]>(length, buffer));
            }

            return readData;
        }

        private static async Task GetHtml()
        {
            var url = "https://softuni.bg/trainings/3164/csharp-web-basics-september-2020#lesson-18198";

            var netClient = new HttpClient();

            var response = await netClient.GetAsync(url);

            Console.WriteLine(string.Join(Environment.NewLine, response.Headers
                .Select(x => x.Key + ": " + string.Join(" ", x.Value))));

            var html = await netClient.GetStringAsync(url);

            Console.WriteLine(html);
        }
    }
}
