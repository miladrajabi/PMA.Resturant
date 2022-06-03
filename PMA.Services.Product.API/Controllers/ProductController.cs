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

        [HttpGet]
        public async Task<object> Get()
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
        [Route("{id}")]
        public async Task<object> Get(int id)
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

        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                var result = await _productRepository.Create(productDto);
                _responseDto.Result = result;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessage = new List<string> { ex.Message };
            }
            return _responseDto;
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<object> Put(int id, [FromBody] ProductDto productDto)
        {
            try
            {
                var result = await _productRepository.Update(id, productDto);
                _responseDto.Result = result;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessage = new List<string> { ex.Message };
            }
            return _responseDto;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                var result = await _productRepository.DeleteProduct(id);
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
