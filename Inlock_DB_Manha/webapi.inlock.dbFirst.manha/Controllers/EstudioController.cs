using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.dbFirst.manha.Domains;
using webapi.inlock.dbFirst.manha.Interfaces;
using webapi.inlock.dbFirst.manha.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.inlock.dbFirst.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_estudioRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarComJogos")]
        public IActionResult GetWithGames()
        {
            try
            {
                return Ok(_estudioRepository.ListarComJogos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_estudioRepository.BuscarPorId(id));
            }
            catch (Exception Erro)
            {

                return BadRequest(Erro.Message);
            }

        }

        [HttpPost]
        public IActionResult Insert(Estudio estudio)
        {
            try
            {
                _estudioRepository.Cadastrar(estudio);
                return Ok(201);
            }
            catch (Exception Erro)
            {

                return BadRequest(Erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _estudioRepository.Deletar(id);
                return Ok(204);
            }
            catch (Exception Erro)
            {

                return BadRequest(Erro.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id ,Estudio estudio)
        {
            try
            {
                _estudioRepository.Atualizar(id, estudio);
                return NoContent();
            }
            catch (Exception Erro)
            {

                return BadRequest(Erro.Message);
            }
        }
    
    }

}