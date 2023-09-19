using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositorys
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE08-S14; Initial Catalog = inlock_games_manha; User ID = sa; Pwd=Senai@134";
        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT IdUsuario,IdTipoUsuario,Email,Senha FROM Usuario WHERE Email = @Email AND Senha = @Senha;";

                using (SqlCommand cmd = new SqlCommand(queryLogin,con)) 
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if(rdr.Read()) 
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                         IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),             
                         IdTipoDeUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                         Email = rdr["Email"].ToString(),
                         Senha = rdr["Senha"].ToString()
                        };

                        return usuario;

                    }
                    return null;
                        

                }
            }
        }
    }
}
