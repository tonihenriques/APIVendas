using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Product.Data.ValueObject;
using Payment.API.Product.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.API.Product.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            try
            {
                var products = _repository.FindAll();
                return Ok(products);
            }
            catch (System.Exception)
            {

                throw;
            }
           
        }

        [HttpGet("{id}")]        
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            try
            {
                var product = _repository.FindById(id);
                if (product == null) return NotFound();
                return Ok(product);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

        [HttpGet("regist-venda/{prodID}")]
        public async Task<ActionResult<ProductVO>> FindProdId(long prodID)
        {
            try
            {
                var product = await _repository.FindProdId(prodID);
                if (product == null) return NotFound();
                return Ok(product);
            }
            catch (System.Exception)
            {

                throw;
            }
           
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO vo)
        {
            try
            {
                if (vo == null) return BadRequest();

                var product = _repository.Create(vo);

                return Ok(product);
            }
            catch (System.Exception)
            {

                throw;
            }
           
        }

        [HttpPut]
        public ActionResult<ProductVO> Update([FromBody] ProductVO vo)
        {
            try
            {
                if (vo == null) return BadRequest();
                var prod = _repository.Update(vo);
                return Ok(prod);
            }
            catch (System.Exception)
            {

                throw;
            }
           
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            try
            {
                var status = _repository.Delete(id);
                if (!status) return BadRequest();
                return Ok(status);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

    }
}
