using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace K_Akica.Blazor.Data.Helpers
{
    public class HttpServiceResponse<TResponse>
    {
        public TResponse Result { get; private set; }
        public bool Success { get; private set; }
        public string ErrorMessage { get; private set; }

        public HttpServiceResponse(TResponse result, bool success, string errorMessage)
        {
            Result = result;
            Success = success;
            ErrorMessage = errorMessage;
        }
    }

    public class HttpServiceResponse
    {
        public async static Task<HttpServiceResponse<TResponse>> FromMessage<TResponse>(HttpResponseMessage response)
        {
            TResponse result = default;
            bool success = false;
            string errorMsg = string.Empty;

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<TResponse>();
                success = true;
            }
            else
            {
                errorMsg = await response.Content.ReadAsStringAsync();
            }

            return new HttpServiceResponse<TResponse>(result, success, errorMsg);
        }
    }
}
