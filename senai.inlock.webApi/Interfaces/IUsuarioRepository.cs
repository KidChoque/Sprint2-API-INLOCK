using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login(string email, string senha);
    }
}
