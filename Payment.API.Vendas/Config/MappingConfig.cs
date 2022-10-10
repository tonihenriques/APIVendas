using AutoMapper;
using Payment.API.Vendas.Data.ValueObject;
using Payment.API.Vendas.Model;

namespace Payment.API.Vendas.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<OrderVendasVO, OrderVendas>();
                config.CreateMap<OrderVendas, OrderVendasVO>();
            });
            return mappingConfig;
        }
    }
}
