using Microsoft.AspNetCore.Mvc;
using Payment.API.Vendas.Repository;
using Payment.API.Vendas.Data.ValueObject;
using System.Threading.Tasks;
using Payment.API.Vendas.Service.IService;
using System.Collections.Generic;
using AutoMapper.Internal.Mappers;
using System;

namespace Payment.API.Vendas.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
       
        private IProductService _productService;
        private IEmpregadoService _empregadoService;
        private IOrderVendastRepository _orderVendastRepository;

        public VendasController(IProductService productService, IEmpregadoService empregadoService, 
                                IOrderVendastRepository orderVendastRepository)
        {
            _productService = productService;
            _empregadoService = empregadoService;
            _orderVendastRepository = orderVendastRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderVendasVO>>> FindAll()
        {
            try
            {
                var func = _orderVendastRepository.FindAll();
                return Ok(func);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        [HttpPost("regist-venda")]
        public async Task<ActionResult> RegistrarVenda(long vendedorID, long produtoID, long quantidade)
        {
            try
            {
                return await AdicionarVenda(vendedorID, produtoID, quantidade);

            }
            catch (Exception)
            {

                throw;
            }

            async Task<ActionResult> AdicionarVenda(long vendedorID, long produtoID, long quantidade)
            {
                var product = await _productService.FindProductById(produtoID);
                if (product == null) return NotFound();

                string prodIDs = Convert.ToString(product.Id);

                var empregado = await _empregadoService.FindEmpregadoById(vendedorID);
                if (empregado == null) return NotFound();


                OrderVendasVO orderVendasVO = new OrderVendasVO()
                {

                    VendedorID = empregado.Id.ToString(),
                    VendedorNome = empregado.Name,
                    VendedorCPF = empregado.cpf,
                    VendedorTel = empregado.telefone,
                    VendedorEmail = empregado.email,
                    ProductID = product.Id,
                    name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    CategoryName = product.CategoryName,
                    Quantidade = quantidade,
                    PurchaseAmount = quantidade * Convert.ToDecimal(product.Price)

                };

                var result = _orderVendastRepository.Create(orderVendasVO);

                return Ok(result);
            }
        }


        [HttpPut("update-vendas")]
        public async Task<ActionResult<OrderVendasVO>> Update([FromBody] OrderVendasVO vo, string status)
        {
            try
            {
                var func = _orderVendastRepository.Update(vo, status);
                return Ok(func);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
