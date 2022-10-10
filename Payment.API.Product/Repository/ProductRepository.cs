using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Product.Data.ValueObject;
using Payment.API.Product.Mock;
using Payment.API.Product.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Product.Repository
{
    public class ProductRepository : IProductRepository
    {
       
        private IMapper _mapper;

        public ProductRepository( IMapper mapper)
        {          
            _mapper = mapper;
        }
        public IEnumerable<ProductVO> FindAll()
        {
            try
            {
                List<Produto> products = Produto.listaProdutos;

                return _mapper.Map<List<ProductVO>>(products);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public ProductVO FindById(long id)
        {
            try
            {
                List<Produto> products = Produto.listaProdutos;

                var prod = products.Where(x => x.Id == id).FirstOrDefault();

                return _mapper.Map<ProductVO>(prod);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public ProductVO Create(ProductVO vo)
        {
            try
            {
                Produto product = _mapper.Map<Produto>(vo);

                product.UsuarioInclusao = "Usuario Admin";
                product.DataInclusao = DateTime.Now.ToString();

                product.Salvar();

                var products = _mapper.Map<ProductVO>(product);

                return products;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public ProductVO Update(ProductVO vo)
        {

            try
            {
                return AtualizacaoProduct(vo);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private ProductVO AtualizacaoProduct(ProductVO vo)
        {
            Produto product = _mapper.Map<Produto>(vo);
            var id = product.Id;

            List<Produto> products = Produto.listaProdutos;

            var prodUP = products.Where(x => x.Id == id).FirstOrDefault();

            Produto produto = new Produto()
            {
                Id = prodUP.Id,
                Uniquekey = prodUP.Uniquekey,
                Name = prodUP.Name,
                Price = prodUP.Price,
                Description = prodUP.Description,
                CategoryName = prodUP.CategoryName,
                ImageURL = prodUP.ImageURL,
                UsuarioExclusao = "Usuario Admin",
                DataExclusao = DateTime.Now.ToString()

            };

            products.Add(produto);

            products.Remove(prodUP);

            Produto productUP = new Produto()
            {
                Id = prodUP.Id,
                Uniquekey = Guid.NewGuid().ToString(),
                Name = prodUP.Name,
                Price = prodUP.Price,
                Description = prodUP.Description,
                CategoryName = prodUP.CategoryName,
                ImageURL = prodUP.ImageURL,
                UsuarioInclusao = "Usuario Admin",
                UsuarioExclusao = "",
                DataInclusao = DateTime.Now.ToString(),

            };

            products.Add(productUP);

            return _mapper.Map<ProductVO>(product);
        }

        public bool Delete(long id)
        {
           
            try
            {
                return ExcluirLogicoProduct(id);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool ExcluirLogicoProduct(long id)
        {
            List<Produto> products = Produto.listaProdutos;

            var prodUP = products.Where(x => x.Id == id).FirstOrDefault();

            Produto produto = new Produto()
            {
                Id = prodUP.Id,
                Uniquekey = prodUP.Uniquekey,
                Name = prodUP.Name,
                Price = prodUP.Price,
                Description = prodUP.Description,
                CategoryName = prodUP.CategoryName,
                ImageURL = prodUP.ImageURL,
                UsuarioExclusao = "Usuario Admin",
                DataExclusao = DateTime.Now.ToString()

            };

            products.Add(produto);

            products.Remove(prodUP);

            return true;
        }

        public async Task<ProductVO> FindProdId(long id)
        {
            List<Produto> products = Produto.listaProdutos;

            var prod = products.Where(x => x.Id == id).FirstOrDefault();

            return _mapper.Map<ProductVO>(prod);
        }

        public string GetProductName()
        {
            return "ok";
        }

    }
}
