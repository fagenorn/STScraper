namespace STScraper.Api
{
    internal class Parameter
    {
        private readonly string _value;

        public Parameter(string value, bool sign)
        {
            _value = value;
            Sign   = sign;
        }

        public bool Sign { get; }

        public override string ToString() { return _value; }
    }
}