using Microsoft.EntityFrameworkCore;
using webapi_inlock_dbFirst_manha.Contexts;
using webapi_inlock_dbFirst_manha.Domains;
using webapi_inlock_dbFirst_manha.Interfaces;

namespace webapi_inlock_dbFirst_manha.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        //Instância do contexto para acessar o banco de dados 
        InLockContext ctx = new InLockContext();
        public void Atualizar(Guid id, Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public Estudio BuscarPorId(Guid id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id); 
        }

        public void Cadastrar(Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }



        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
