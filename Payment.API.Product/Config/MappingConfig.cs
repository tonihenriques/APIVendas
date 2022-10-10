using AutoMapper;
using Payment.API.Product.Data.ValueObject;
using Payment.API.Product.Model;

namespace Payment.API.Product.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductVO, Produto>();
                config.CreateMap<Produto, ProductVO>();
            });
            return mappingConfig;
        }
    }
}
