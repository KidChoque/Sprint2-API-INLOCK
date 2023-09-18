using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_inlock_dbFirst_manha.Interfaces;
using webapi_inlock_dbFirst_manha.Repositories;

namespace webapi_inlock_dbFirst_manha.Controllers
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

        public IActionResult ListarEstudios()
        {
            try
            {
                return Ok(_estudioRepository.Listar());
            }
            catch (Exception Erro)
            {

                return BadRequest(Erro.Message);
            }
        }

        [HttpGet("ListarComJogos")]
        public IActionResult GetWithGames()
        {
            try
            {
                return Ok(_estudioRepository.ListarComJogos());
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro.Message);
                
            }
        }

    }
}
