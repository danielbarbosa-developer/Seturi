namespace Seturi.Entities
{
    public sealed class Uri
    {
        private readonly string AbsoluteUri;
        public Uri()
        {
            AbsoluteUri = null;
        }

        public Uri(string absoluteUri)
        {
            AbsoluteUri = absoluteUri;
        }
        
        internal Uri(string protocol, string path)
        {
            AbsoluteUri = null;
        }
        
        public string Protocol { get; private set; }
        
        public string Host { get; private set; }
        
        public string Path { get; private set; }
        
        public string Params { get; private set; }

        public override string ToString()
        {
            if (AbsoluteUri != null)
                return AbsoluteUri;
            
            return Protocol + Host + Path + Params;
        }
    }
}