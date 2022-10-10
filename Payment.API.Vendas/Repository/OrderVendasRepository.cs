using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Payment.API.Vendas.Data.ValueObject;
using Payment.API.Vendas.Model;
using Payment.API.Vendas.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Payment.API.Vendas.Repository
{
    public class OrderVendasRepository : IOrderVendastRepository
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";
        private IMapper _mapper;

        public OrderVendasRepository(HttpClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public IEnumerable<OrderVendasVO> FindAll()
        {

            try
            {
                List<OrderVendas> products = OrderVendas.listaOrderVendas;

                return _mapper.Map<List<OrderVendasVO>>(products);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public OrderVendasVO FindById(long id)
        {
            try
            {
                List<OrderVendas> products = OrderVendas.listaOrderVendas;


                var prod = products.Where(x => x.Id == Convert.ToString(id)).FirstOrDefault();

                return _mapper.Map<OrderVendasVO>(prod);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public OrderVendasVO Create(OrderVendasVO vo)
        {
            try
            {
                return CreateVendas(vo);

            }
            catch (Exception)
            {

                throw new Exception("Error em Create");
            }
            
        }

        private OrderVendasVO CreateVendas(OrderVendasVO vo)
        {
            OrderVendas product = _mapper.Map<OrderVendas>(vo);

            if (product.ProductID == 0)
            {
                throw new Exception("OrderVendas não pode ser null!");
            }

            var id = product.ProductID;

            List<OrderVendas> Listproducts = OrderVendas.Todos();

            var prod = Listproducts.Where(x => x.ProductID == Convert.ToInt32(id)
                                          && x.VendedorID == product.VendedorID).FirstOrDefault();

            if (prod != null)
            {
                if (prod.ProductID == product.ProductID && prod.VendedorID == product.VendedorID
                    && prod.Status == "Aguardando pagamento")
                {

                    Listproducts.Remove(prod);

                    product.Id = prod.Id;
                    product.Uniquekey = Guid.NewGuid().ToString();
                    product.PedidoID = Guid.NewGuid().ToString();
                    product.Quantidade += prod.Quantidade;
                    product.PurchaseAmount = product.Quantidade * Convert.ToDecimal(prod.Price);
                    product.Status = "Aguardando pagamento";
                    product.UsuarioInclusao = product.VendedorID;
                    product.DataInclusao = DateTime.Now.ToString();

                    product.Salvar();
                }
                else
                {
                    product.Uniquekey = Guid.NewGuid().ToString();
                    product.PedidoID = Guid.NewGuid().ToString();
                    product.Status = "Aguardando pagamento";
                    product.UsuarioInclusao = product.VendedorID;
                    product.DataInclusao = DateTime.Now.ToString();

                    product.Salvar();
                }


            }
            else
            {
                product.Id = Guid.NewGuid().ToString();
                product.Uniquekey = Guid.NewGuid().ToString();
                product.PedidoID = Guid.NewGuid().ToString();
                product.Status = "Aguardando pagamento";
                product.UsuarioInclusao = product.VendedorID;
                product.DataInclusao = DateTime.Now.ToString();

                product.Salvar();
            }

            var products = _mapper.Map<OrderVendasVO>(product);

            return products;
        }

        public bool Update([FromBody] OrderVendasVO vo, string status)
        {           

            try
            {
                return AtualizaStatusVendas(vo, status);

            }
            catch (Exception)
            {
                return false;
            }
          
        }

        private bool AtualizaStatusVendas(OrderVendasVO vo, string status)
        {
            OrderVendas ordervenda = _mapper.Map<OrderVendas>(vo);
            var id = ordervenda.Id;

            List<OrderVendas> ordervendas = OrderVendas.Todos();

            var ordUP = ordervendas.Where(x => string.IsNullOrEmpty(x.UsuarioExclusao) && x.Id == id).FirstOrDefault();

            var statusUP = atualiza(ordUP, status);

            if (statusUP != null)
            {

                OrderVendas order = new OrderVendas()
                {
                    Id = ordUP.Id,
                    Uniquekey = ordUP.Uniquekey,
                    PedidoID = ordUP.PedidoID,
                    ProductID = ordUP.ProductID,
                    VendedorID = ordUP.VendedorID,
                    VendedorNome = ordUP.VendedorNome,
                    VendedorCPF = ordUP.VendedorCPF,
                    VendedorTel = ordUP.VendedorTel,
                    VendedorEmail = ordUP.VendedorEmail,
                    name = ordUP.name,
                    Price = ordUP.Price,
                    Description = ordUP.Description,
                    CategoryName = ordUP.CategoryName,
                    Quantidade = ordUP.Quantidade,
                    PurchaseAmount = ordUP.PurchaseAmount,
                    Status = ordUP.Status,
                    UsuarioExclusao = "Usuario Admin",
                    DataExclusao = DateTime.Now.ToString()

                };

                ordervendas.Add(order);

                ordervendas.Remove(ordUP);

                OrderVendas orderUP = new OrderVendas()
                {
                    Id = ordUP.Id,
                    Uniquekey = Guid.NewGuid().ToString(),
                    PedidoID = ordUP.PedidoID,
                    ProductID = ordUP.ProductID,
                    VendedorID = ordUP.VendedorID,
                    VendedorNome = ordUP.VendedorNome,
                    VendedorCPF = ordUP.VendedorCPF,
                    VendedorTel = ordUP.VendedorTel,
                    VendedorEmail = ordUP.VendedorEmail,
                    name = ordUP.name,
                    Price = ordUP.Price,
                    Description = ordUP.Description,
                    CategoryName = ordUP.CategoryName,
                    Quantidade = ordUP.Quantidade,
                    PurchaseAmount = ordUP.PurchaseAmount,
                    Status = statusUP,
                    UsuarioInclusao = "Usuario Admin",
                    UsuarioExclusao = "",
                    DataInclusao = DateTime.Now.ToString(),

                };

                ordervendas.Add(orderUP);

                //return _mapper.Map<OrderVendasVO>(orderUP);

                ordervendas = null;

                return true;
            }
            else
            {
                return false;
            }
        }

        public string atualiza(OrderVendas ordUP, string status)
        {
            try
            {
                if (ordUP.Status != status)
                {
                    string statusOrd = "";

                    if (ordUP.Status == "Aguardando pagamento" && status == "Pagamento Aprovado")
                    {
                        statusOrd = "Pagamento Aprovado";

                        return statusOrd;

                    }
                    if (ordUP.Status == "Aguardando pagamento" && status == "Cancelada")
                    {
                        statusOrd = "Cancelada";

                        return statusOrd;

                    }
                    if (ordUP.Status == "Pagamento Aprovado" && status == "Enviado para Transportadora")
                    {
                        statusOrd = "Enviado para Transportadora";

                        return statusOrd;

                    }
                    if (ordUP.Status == "Pagamento Aprovado" && status == "Cancelada")
                    {
                        statusOrd = "Cancelada";

                        return statusOrd;

                    }
                    if (ordUP.Status == "Enviado para Transportadora" && status == "Entregue")
                    {
                        statusOrd = "Entregue";

                        return statusOrd;

                    }

                    return null;

                }
                

                return null;

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public bool Delete(long id)
        {
           
            try
            {
                return ExcluirlogicoOrderVendas(id);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool ExcluirlogicoOrderVendas(long id)
        {
            List<OrderVendas> orderVendas = OrderVendas.listaOrderVendas;

            var ordUP = orderVendas.Where(x => x.Id == Convert.ToString(id)).FirstOrDefault();

            OrderVendas ordev = new OrderVendas()
            {
                Id = ordUP.Id,
                VendedorID = ordUP.VendedorID,
                ProductID = ordUP.ProductID,
                PedidoID = ordUP.PedidoID,
                name = ordUP.name,
                Price = ordUP.Price,
                Description = ordUP.Description,
                CategoryName = ordUP.CategoryName,
                Status = "",
                UsuarioExclusao = "Usuario Admin",
                DataExclusao = DateTime.Now.ToString()

            };

            orderVendas.Add(ordev);

            orderVendas.Remove(ordUP);

            return true;
        }
    }
}
