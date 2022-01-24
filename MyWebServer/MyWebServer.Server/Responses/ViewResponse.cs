using MyWebServer.Server.HTTP;

namespace MyWebServer.Server.Responses
{
    public class ViewResponse : ContentResponse
    {
        private const char separator = '/';

        public ViewResponse(string viewName, string controllerName, object model = null) 
            : base("", ContentType.Html) 
        {
            if (!viewName.Contains(separator))
            {
                viewName = controllerName + separator + viewName;
            }

            var viewPath = Path.GetFullPath(
                $"./Views/" + viewName.TrimStart(separator) + ".cshtml");

            var viewContent = File.ReadAllText(viewPath);

            if (model != null)
            {
                viewContent = this.PopulateModel(viewContent, model);
            }

            this.Body = viewContent; 
        }

        private string PopulateModel(string viewContent, object model)
        {
            var data = model
                .GetType()
                .GetProperties()
                .Select(x => new
                {
                    x.Name,
                    Value = x.GetValue(model)
                });

            foreach (var item in data)
            {
                const string openingBrackets = "{{";
                const string closingBrackets = "}}";

                viewContent = viewContent.Replace($"{openingBrackets}{item.Name}{closingBrackets}",
                    item.Value.ToString());
            }

            return viewContent;
        }
    }
}
