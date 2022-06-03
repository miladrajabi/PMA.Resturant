using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMA.Services.Product.API.Moldes.Dto;
using PMA.Services.Product.API.Moldes.Repository;

namespace PMA.Services.Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected ResponseDto _responseDto;
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _responseDto = new ResponseDto();
            _productRepository = productRepository;
        }

        [HttpGet("get")]
        public async Task<object> GetAsync()
        {
            try
            {
                var result = await _productRepository.GetAsync();
                _responseDto.Result = result;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessage = new List<string> { ex.Message };
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<object> GetAsync(int id)
        {
            try
            {
                var result = await _productRepository.GetByIdAsync(id);
                _responseDto.Result = result;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessage = new List<string> { ex.Message };
            }
            return _responseDto;
        }
    }
}
