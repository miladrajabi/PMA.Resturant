using Newtonsoft.Json;
using Resturants.Web.Models;
using Resturants.Web.Services.IServices;
using System.Text;
using static Resturants.Web.SD;

namespace Resturants.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseApiDto responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
            responseModel = new ResponseApiDto();
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            var mediaType = "application/json";
            try
            {
                var client = httpClient.CreateClient("PmaAPI");
                var message = new HttpRequestMessage();
                message.Headers.Add("Accept", mediaType);
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, mediaType);
                HttpResponseMessage apiResponse = null;

                message.Method =
                apiRequest.ApiType switch
                {
                    ApiType.POST => HttpMethod.Post,
                    ApiType.PUT => HttpMethod.Put,
                    ApiType.DELETE => HttpMethod.Delete,
                    ApiType.PATCH => HttpMethod.Patch,
                    _ => HttpMethod.Get,
                };
                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;
            }
            catch (Exception e)
            {
                var dto = new ResponseApiDto
                {
                    DisplayMessage = "Error",
                    ErrorMessage = new List<string> { e.Message },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var responseDto = JsonConvert.DeserializeObject<T>(res);
                return responseDto;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
