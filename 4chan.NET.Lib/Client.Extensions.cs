namespace _4chan.NET.Lib
{
    public partial class Client
    {
        #if (NETSTANDARD2_0_OR_GREATER || NET461_OR_GREATER)
        public Client(System.Net.Http.HttpClient httpClient, Microsoft.Extensions.Logging.ILogger<Client> logger):this(httpClient)
        {
            _logger = logger;
        }
        #endif     
    }
}