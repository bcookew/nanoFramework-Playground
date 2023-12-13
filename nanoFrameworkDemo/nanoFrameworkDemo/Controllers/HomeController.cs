using nanoFramework.WebServer;
using System;

namespace nanoFrameworkDemo.Controllers
{
    public class HomeController
    {
        public HomeController()
        {
            Console.WriteLine("HomeController Initialized");
        }

        [Route("/")]
        [Method("GET")]
        public void Index(WebServerEventArgs e)
        {
            Console.WriteLine("GET /index " + e.Context.Request.RawUrl);
            string content = "<!DOCTYPE html>" +
                            "<html>" +
                                "<head>" +
                                    "<title>ESP32</title>" +
                                    "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">" +
                                    "<style>" +
                                        "font-family: sans-serif;" +
                                    "</style>" +
                                "</head>" +
                                "<body>" +
                                    "<h1>ESP32 - nanoFramework - Web Interface</h1>" +
                                "</body>" +
                            "</html>";
            e.Context.Response.ContentType = "text/html";
            WebServer.OutPutStream(e.Context.Response, content);
        }
    }
}
