using MyWebServer.Server.Common;

namespace MyWebServer.Server.HTTP
{
    public class Header
    {
        public const string ContentType = "Content-Type";
        public const string ContentLength = "Content-Length";
        public const string Date = "Date";
        public const string Location = "Location";
        public const string Server = "Server";
        public const string ContentDisposition = "Content-Disposition";
        public const string Cookie = "Cookie";
        public const string SetCookie = "Set-Cookie";


        public Header(string _name, string _value)
        {
            Guard.AgaintsNull(_name, nameof(_name));
            Guard.AgaintsNull(_value, nameof(_value));

            Name = _name;
            Value = _value;
        }

        public string Name { get; init; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {this.Value}";
        }
    }
}
