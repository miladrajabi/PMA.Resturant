namespace Resturants.Web.Services.IServices
{
    public interface IProductService
    {
        Task<T> GetAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> PostAsync<T>();
        Task<T> PutAsync<T>();
        Task<T> DeleteAsync<T>(int id);
    }
}
