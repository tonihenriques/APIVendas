using Payment.API.Vendas.Data.ValueObjects;
using Payment.API.Vendas.Service.IService;
using Payment.API.Vendas.Utils;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payment.API.Vendas.Service.ServiceConcrete
{
    public class EmpregadoService : IEmpregadoService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/empregado";

        public EmpregadoService(HttpClient client)
        {
            _client = client;
        }

        public async Task<FuncionarioVO> FindEmpregadoById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<FuncionarioVO>();
        }
    }
}
