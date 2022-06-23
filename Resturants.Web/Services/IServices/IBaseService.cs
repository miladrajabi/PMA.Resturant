using Resturants.Web.Models;

namespace Resturants.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
         ResponseApiData responseModel { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);

    }
}
