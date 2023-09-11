using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;

namespace senai.inlock.webApi_.Repositorys
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE08-S14; Initial Catalog = inlock_games_manha; User ID = sa; Pwd=Senai@134";
        public UsuarioDomain Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
