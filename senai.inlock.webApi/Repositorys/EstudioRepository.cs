using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositorys
{
    public class EstudioRepository : IEstudioRepository
    {
        private string StringConexao = "Data Source = NOTE08-S14; Initial Catalog = inlock_games_manha; User ID = sa; Pwd=Senai@134";
        public void Cadastrar(EstudiosDomain novoEstudio)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                string queryCadastrarEstudio = "INSERT INTO Estudio(Nome)\r\nVALUES (@Nome)";

                using(SqlCommand cmd = new SqlCommand(queryCadastrarEstudio, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.Nome);
                }
            }
        }

        public List<EstudiosDomain> ListarTodos()
        {
            List<EstudiosDomain> ListaEstudio = new List<EstudiosDomain>();

            using(SqlConnection con  = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT Estudio.IdEstudio,Estudio.Nome,Jogo.Nome FROM Estudio\r\nLEFT JOIN Jogo\r\nON Estudio.IdEstudio = Jogo.IdEstudio;";
                
                con.Open();

            SqlDataReader rdr;

            using(SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudiosDomain estudio = new EstudiosDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString()

                        };
                        
                        ListaEstudio.Add(estudio);
 
                    }
                }
            }
            return ListaEstudio;

        }
    }
}
