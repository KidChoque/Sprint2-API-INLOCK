using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IJogosRepository
    {
        void Cadastrar(JogosDomain novoJogo);

        List<JogosDomain> ListarTodos();

        JogosDomain BuscarPorId(int id);
    }
}
