using Resturants.Web.Models;
using Resturants.Web.Services.IServices;

namespace Resturants.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private const string apiCurl = "/api/Product";

        public ProductService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClientFactory = httpClient;
        }

        public async Task<T> DeleteAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = String.Empty,
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + apiCurl,
                Data = id

            });
        }

        public async Task<T> GetAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = String.Empty,
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + apiCurl,
            });
        }

        public async Task<T> GetAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = String.Empty,
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + apiCurl,
                Data = id
            });
        }

        public async Task<T> PostAsync<T>(ProductApiData data)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = String.Empty,
                ApiType = SD.ApiType.POST,
                Url = SD.ProductAPIBase + apiCurl,
                Data = data
            });
        }

        public async Task<T> PutAsync<T>(ProductApiData data)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                AccessToken = String.Empty,
                ApiType = SD.ApiType.PUT,
                Url = SD.ProductAPIBase + apiCurl,
                Data = data
            });
        }
    }
}
