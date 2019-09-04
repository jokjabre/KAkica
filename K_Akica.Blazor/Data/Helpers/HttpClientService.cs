using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace K_Akica.Blazor.Data.Helpers
{
    public class HttpClientService
    {
        private readonly IHttpClientFactory m_clientFactory;

        public HttpClientService(IHttpClientFactory factory)
        {
            m_clientFactory = factory;
        }


        public async Task<HttpServiceResponse<TResponse>> Get<TResponse>(string url)
        {
            var client = m_clientFactory.CreateClient("kakica");
            var response = await client.GetAsync(url);

            return await HttpServiceResponse.FromMessage<TResponse>(response);
        }

        public async Task<HttpServiceResponse<TResponse>> Post<TRequest, TResponse>(string url, TRequest request)
        {
            var client = m_clientFactory.CreateClient("kakica");
            var content = new ObjectContent<TRequest>(request, new JsonMediaTypeFormatter());
            var response = await client.PostAsync(url, content);

            return await HttpServiceResponse.FromMessage<TResponse>(response);
        }

        public async Task<HttpServiceResponse<TResponse>> Delete<TRequest, TResponse>(string url, TRequest request)
        {
            var client = m_clientFactory.CreateClient("kakica");
            var response = await client.DeleteAsync($"{url}/{request.ToString()}");

            return await HttpServiceResponse.FromMessage<TResponse>(response);
        }
    }
}
