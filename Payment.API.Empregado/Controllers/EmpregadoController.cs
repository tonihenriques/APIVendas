using Microsoft.AspNetCore.Mvc;
using Payment.API.Empregado.Data.ValueObjects;
using Payment.API.Empregado.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.API.Empregado.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpregadoController : ControllerBase
    {

        private IFuncionarioRepository _repository;

        public EmpregadoController(IFuncionarioRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioVO>>> FindAll()
        {

            try
            {
                var func = _repository.FindAll();
                return Ok(func);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioVO>>FindById(long id)
        {
            try
            {
                var func = _repository.FindById(id);
                if (func == null) return NotFound();
                return Ok(func);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioVO>> Create([FromBody] FuncionarioVO vo)
        {
            try
            {
                if (vo == null) return BadRequest();
                var func = _repository.Create(vo);
                return Ok(func);

            }
            catch (System.Exception)
            {

                throw;
            }
           
        }

        [HttpPut]       
        public  ActionResult<FuncionarioVO> Update([FromBody] FuncionarioVO vo)
        {
            try
            {
                if (vo == null) return BadRequest();
                var func = _repository.Update(vo);
                return Ok(func);
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
