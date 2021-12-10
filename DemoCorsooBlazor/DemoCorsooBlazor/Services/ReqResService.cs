using DemoCorsoBlazor.Library.Interfaces;
using DemoCorsoBlazor.Library.Models;
using System.Net.Http.Json;

namespace DemoCorsooBlazor.Services
{
    public class ReqResService : IReqResData
    {
        private readonly IHttpClientFactory httpClientFactory;
        private CancellationTokenSource? cancellationToken;

        public ReqResService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<ReqResData?> GetData()
        {
            var httpClient = httpClientFactory.CreateClient("reqres");
            cancellationToken = new CancellationTokenSource();

            using var response = await httpClient
                .GetAsync("api/users", HttpCompletionOption.ResponseHeadersRead, 
                cancellationToken.Token);

            if (response.IsSuccessStatusCode)
            {
                if(response.Content != null)
                {
                    return await response.Content.ReadFromJsonAsync<ReqResData>();
                }
            }
            return null;
        }

        public void Cancel()
        {
            cancellationToken?.Cancel();
        }

        public async Task<string> PostData(ReqResRequest newUser)
        {
            var httpClient = httpClientFactory.CreateClient("reqres");

            using var response = await httpClient
                .PostAsJsonAsync<ReqResRequest>("api/users", newUser);

            if(response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync< ReqResResponse>();
                if(data != null)
                {
                    return data.CreatedAt;
                }
            }
            return "KO";
        }
    }
}
