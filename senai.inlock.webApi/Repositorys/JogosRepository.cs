using System.Data.SqlClient;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;

namespace senai.inlock.webApi_.Repositorys
{
    public class JogosRepository : IJogosRepository
    {
        private string StringConexao = "Data Source = NOTE08-S14; Initial Catalog = inlock_games_manha; User ID = SA; Pwd=Senai@134";

        public JogosDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(JogosDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsertJogo = "INSERT INTO Jogo(IdEstudio,Nome,Descricao,DataLancamento,Valor)\r\nVALUES(@IdEstudio,@Nome,@Descricao,@Datalancamento,@Valor)";

                using (SqlCommand cmd = new SqlCommand(queryInsertJogo, con))
                {

                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }

        }

        public List<JogosDomain> ListarTodos()
        {
            List<JogosDomain> ListaJogos = new List<JogosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string querySelectAll = "SELECT IdJogo,Nome,Descricao,DataLancamento,Valor FROM Jogo";
             
                
                SqlDataReader rdr;

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        JogosDomain jogos = new JogosDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Valor = Convert.ToDouble(rdr[0])
                            

                        };
                        ListaJogos.Add(jogos);
                    }
                    


                }
            }return ListaJogos;
        }

        
    }
}
