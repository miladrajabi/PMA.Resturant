using AutoMapper;
using PMA.Services.Product.API.Moldes.Dto;

namespace PMA.Services.Product.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(
                config =>
                {
                    config.CreateMap<ProductDto, PMA.Services.Product.API.Moldes.Product>();
                    config.CreateMap<PMA.Services.Product.API.Moldes.Product, ProductDto>();
                });
            return mappingConfig;
        }
    }
}
