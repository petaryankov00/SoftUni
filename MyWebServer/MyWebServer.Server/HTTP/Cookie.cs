namespace MyWebServer.Server.HTTP
{
    public class Cookie
    {
        public Cookie(string _name, string _value)
        {
            this.Name = _name;
            this.Value = _value;
        }

        public string Name { get; init; }

        public string Value { get; init; }

        public override string ToString()
         => $"{this.Name}={this.Value}";
    }
}
