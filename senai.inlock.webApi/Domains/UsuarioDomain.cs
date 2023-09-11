using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        public int IdTipoDeUsuario { get; set; }

        [Required]
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
