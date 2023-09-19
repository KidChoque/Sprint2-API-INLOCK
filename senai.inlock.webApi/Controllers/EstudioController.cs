using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositorys;
using System.Data;

namespace senai.inlock.webApi_.Controllers
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

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        [Authorize(Roles = "2")]
        [HttpPost("Cadastrar")]
        public IActionResult Post(EstudiosDomain estudio)
        {
            try
            {
                _estudioRepository.Cadastrar(estudio);

                return Ok("Estudio Cadastrado !");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

        }

        /// <summary>
        /// Lista todos os estúdios cadastrados
        /// </summary>
        [Authorize(Roles = "1,2")]
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            try
            {
                List<EstudiosDomain> listaEstudios = _estudioRepository.ListarTodos();

                return Ok(listaEstudios);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }




}
