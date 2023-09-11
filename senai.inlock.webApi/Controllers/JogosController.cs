using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositorys;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogosRepository { get; set; }

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }

        [HttpGet]
        public IActionResult ListarJogos() 
        {

            try
            {
                List<JogosDomain> ListaJogos = _jogosRepository.ListarTodos();
                return Ok(ListaJogos);
            }
            catch ( Exception Erro)
            {

                return BadRequest(Erro.Message);
            }
        }

        [HttpPost]

        public IActionResult CadastrarJogos(JogosDomain novoJogo)
        {   
            try
            {
                _jogosRepository.Cadastrar(novoJogo);
                return Ok(novoJogo);

            }
            catch (Exception Erro)
            {

                return BadRequest(Erro.Message);
            }
        }


       



    }
}
