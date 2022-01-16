﻿using MyWebServer.Server;
using MyWebServer.Server.HTTP;
using MyWebServer.Server.Responses;

namespace MyWebServer.Demo
{
    public class StartUp
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
                                            Name: <input type='text' name='Name'/>
                                            Age: <input type='number' name ='Age'/>
                                            <input type='submit' value ='Save'/>
                                           </form>";

        private const string DownloadForm = @"<form action='/Content' method='POST'>
                                                <input type='submit' value = 'Download Sites Content' />
                                              </form>";

        private const string FileName = "content.txt";

        

        public static async Task Main()

        {
            await DownloadSitesAsText(StartUp.FileName, new string[]
            {
                "https://judge.softuni.org/",
                "https://wikipedia.bg/"
            });

            var server = new HttpServer(routes => routes
            .MapGet("/", new TextResponse("Hello from the server!"))
            .MapGet("/Redirect", new RedirectResponse("https://softuni.org/"))
            .MapGet("/HTML", new HtmlResponse(StartUp.HtmlForm))
            .MapPost("/HTML", new TextResponse("", StartUp.AddFormDataAction))
            .MapGet("/Content", new HtmlResponse(StartUp.DownloadForm))
            .MapPost("/Content", new TextFileResponse(StartUp.FileName)));

            await server.Start();
           
        }
            

        private static void AddFormDataAction(Request request, Response response)
        {
            response.Body = "";

            foreach (var (key, value) in request.Form)
            {
                response.Body += $"{key} - {value}";
                response.Body += Environment.NewLine;
            }
        }

        private static async Task<string> DownloadWebSiteContent(string url)
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                var response = await httpClient.GetAsync(url);

                var html = await response.Content.ReadAsStringAsync();

                return html.Substring(0, 500);
            }
        }

        private static async Task DownloadSitesAsText(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var responses = await Task.WhenAll(downloads);

            var responseString = string.Join(Environment.NewLine + new string('-', 100), responses);
            
            await File.WriteAllTextAsync(fileName, responseString);
        }
    }
}