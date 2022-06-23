using Resturants.Web.Models;

namespace Resturants.Web.Services.IServices
{
    public interface IProductService : IBaseService
    {
        Task<T> GetAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> PostAsync<T>(ProductApiData dto);
        Task<T> PutAsync<T>(ProductApiData dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
