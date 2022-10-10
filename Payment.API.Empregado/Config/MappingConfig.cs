


using AutoMapper;
using Payment.API.Empregado.Data.ValueObjects;
using Payment.API.Empregado.Model;

namespace Payment.API.Empregado.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<FuncionarioVO, Funcionario>();
                config.CreateMap<Funcionario, FuncionarioVO>();
            });
            return mappingConfig;
        }
    }
}
