using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#if (NETSTANDARD2_0_OR_GREATER || NET461_OR_GREATER)
using Microsoft.Extensions.Logging;
#endif

namespace _4chan.NET.Lib
{
    public partial class Client
    {
        #if (NETSTANDARD2_0_OR_GREATER || NET461_OR_GREATER)
        protected readonly ILogger _logger;
        #endif

        #pragma warning disable CS1998
        private async Task PrepareRequestAsync(HttpClient client, HttpRequestMessage request, string url, CancellationToken cancellationToken)
        {
            #if (NETSTANDARD2_0_OR_GREATER || NET461_OR_GREATER)
            _logger?.LogTrace("{Url}:\r\n\tHeader:\r\n{Header}\r\n\tContent:\r\n{Content}", request.RequestUri.ToString(), String.Join(",\r\n", request.Headers.SelectMany(Header => Header.Value.Select(Value => String.Format("{0}={1}", Header.Key, Value)))), request.Content != null ? await request.Content.ReadAsStringAsync() : "");
            #endif
        }
        #pragma warning restore CS1998
        #pragma warning disable CS1998
        private async Task PrepareRequestAsync(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder, CancellationToken cancellationToken)
        {

        }
        #pragma warning restore CS1998
        #pragma warning disable CS1998
        private async Task ProcessResponseAsync(HttpClient client, HttpResponseMessage response, CancellationToken cancellationToken)
        {
            #if (NETSTANDARD2_0_OR_GREATER || NET461_OR_GREATER)
            _logger?.LogTrace("{StatusCode}:\r\n\tHeader:\r\n{Header}\r\n\tContent:\r\n{Content}", response.StatusCode.ToString(), String.Join(",\r\n", response.Headers.SelectMany(Header => Header.Value.Select(Value => String.Format("{0}={1}", Header.Key, Value)))), response.Content != null ? await response.Content.ReadAsStringAsync() : "");
            #endif
        }
        #pragma warning restore CS1998        
    }
}