using Common.DTOs;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JurisDict.Wpf.Handlers
{
    public class JurisDictClientHandler : HttpClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode && response.Content is not null)
            {
                throw JsonSerializer.Deserialize<HttpException>(await response.Content.ReadAsStringAsync());
            }
            return response;
        }
    }
}
