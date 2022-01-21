﻿using MyWebServer.Server.HTTP;
using MyWebServer.Server.Responses;
using System.Runtime.CompilerServices;

namespace MyWebServer.Demo.Controllers
{
    public abstract class Controller
    {
        protected Controller(Request request)
        {
            this.Request = request;
        }

        protected Request Request { get; set; }

        protected Response View([CallerMemberName] string viewName = "")
            => new ViewResponse(viewName, this.GetControllerName());

        protected Response View(object model,[CallerMemberName] string viewName = "")
           => new ViewResponse(viewName, this.GetControllerName(),model);

        private string GetControllerName()
               => this.GetType().Name.Replace(nameof(Controller),string.Empty);

        protected Response Text(string text) => new TextResponse(text);

        protected Response Html(string text, CookieCollection cookies = null)
        {
            var response = new HtmlResponse(text);

            if (cookies != null)
            {
                foreach (var cookie in cookies)
                {
                    response.Cookies.Add(cookie.Name, cookie.Value);
                }
            }

            return response;
        }
        protected Response BadRequest() => new BadRequsetResponse();
        protected Response Unauthorized() => new UnauthorizedResponse();
        protected Response NotFound() => new NotFoundResponse();
        protected Response Redirect(string location) => new RedirectResponse(location);
        protected Response File(string fileName) => new TextFileResponse(fileName);
    }
}