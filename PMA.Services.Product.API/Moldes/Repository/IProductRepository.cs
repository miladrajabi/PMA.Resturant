using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PMA.Services.Product.API.DbContexts;
using PMA.Services.Product.API.Moldes.Dto;

namespace PMA.Services.Product.API.Moldes.Repository
{
    public interface IProductRepository
    {
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAsync();
        Task<bool> DeleteProduct(int id);
        Task<ProductDto> Create(ProductDto dto);
        Task<ProductDto> Update(int id, ProductDto dto);

    }

    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductDto> Create(ProductDto dto)
        {
            var product = _mapper.Map<ProductDto, Product>(dto);
            product.CreationDate = DateTime.Now;
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }


        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

                if (product == null) return false;

                _dbContext.Products.Remove(product);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAsync()
        {
            var products = await _dbContext.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> Update(int id, ProductDto dto)
        {
            var product = _mapper.Map<ProductDto, Product>(dto);
            product.Id = id;
            product.MidifyDate = DateTime.Now;
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);
        }
    }
}
