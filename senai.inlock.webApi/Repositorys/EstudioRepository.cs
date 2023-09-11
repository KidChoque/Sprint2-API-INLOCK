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

                string queryCadastrarEstudio = "INSERT INTO Estudio(Nome)\r\nVALUES (@Nome);";
            }
        }

        public List<EstudiosDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
