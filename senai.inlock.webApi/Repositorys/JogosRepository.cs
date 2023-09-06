using System.Data.SqlClient;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;

namespace senai.inlock.webApi_.Repositorys
{
    public class JogosRepository : IJogosRepository
    {
        private string StringConexao = "Data Source = NOTE08-S14; Initial Catalog = Filmes; User ID = sa; Pwd=Senai@134";
        public void Cadastrar(JogosDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsertJogo = "INSERT INTO Jogo(IdEstudio,Nome,Descricao,DataLancamento,Valor)\r\nVALUES(@IdEstudio,@Nome,@Descricao,@Datalancamento,@Valor)";

                using (SqlCommand cmd = new SqlCommand(queryInsertJogo, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    cmd.ExecuteNonQuery();

                }
            }

        }

        public List<JogosDomain> ListarTodos()
        {
            List<JogosDomain> ListaJogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string querySelectAll = "SELECT IdEstudio As Estudio, Nome as Jogo, Descricao,DataLancamento,Valor FROM Jogo;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand())
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        JogosDomain jogos = new JogosDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(),
                            Valor

                        };
                    }


                }
            }
        }
    }
}
