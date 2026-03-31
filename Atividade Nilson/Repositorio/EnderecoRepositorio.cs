using Atividade_Nilson.Models;
using Atividade_Nilson.Repositorio.Contrato;
using MySql.Data.MySqlClient;

namespace Atividade_Nilson.Repositorio
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly string _conexaoMySQL;

        public EnderecoRepositorio(IConfiguration configuracao)
        {
            _conexaoMySQL = configuracao.GetConnectionString("ConexaoMySql")!;

            if (string.IsNullOrWhiteSpace(_conexaoMySQL))
            {
                throw new Exception("A connection string 'ConexaoMySql' não foi encontrada no appsettings.json.");
            }
        }

        public void Cadastrar(Endereco endereco)
        {
            using var conexao = new MySqlConnection(_conexaoMySQL);
            conexao.Open();

            string sql = @"INSERT INTO Endereco
                           (CEP, Estado, Cidade, Bairro, Logradouro, Complemento, Numero)
                           VALUES
                           (@CEP, @Estado, @Cidade, @Bairro, @Logradouro, @Complemento, @Numero)";

            using var cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@CEP", endereco.CEP);
            cmd.Parameters.AddWithValue("@Estado", endereco.Estado);
            cmd.Parameters.AddWithValue("@Cidade", endereco.Cidade);
            cmd.Parameters.AddWithValue("@Bairro", endereco.Bairro);
            cmd.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
            cmd.Parameters.AddWithValue("@Complemento", endereco.Complemento);
            cmd.Parameters.AddWithValue("@Numero", endereco.Numero);

            cmd.ExecuteNonQuery();
        }

        public void Atualizar(Endereco endereco)
        {
            using var conexao = new MySqlConnection(_conexaoMySQL);
            conexao.Open();

            string sql = @"UPDATE Endereco
                           SET CEP = @CEP,
                               Estado = @Estado,
                               Cidade = @Cidade,
                               Bairro = @Bairro,
                               Logradouro = @Logradouro,
                               Complemento = @Complemento,
                               Numero = @Numero
                           WHERE Id = @Id";

            using var cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Id", endereco.Id);
            cmd.Parameters.AddWithValue("@CEP", endereco.CEP);
            cmd.Parameters.AddWithValue("@Estado", endereco.Estado);
            cmd.Parameters.AddWithValue("@Cidade", endereco.Cidade);
            cmd.Parameters.AddWithValue("@Bairro", endereco.Bairro);
            cmd.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
            cmd.Parameters.AddWithValue("@Complemento", endereco.Complemento);
            cmd.Parameters.AddWithValue("@Numero", endereco.Numero);

            cmd.ExecuteNonQuery();
        }

        public void Excluir(int id)
        {
            using var conexao = new MySqlConnection(_conexaoMySQL);
            conexao.Open();

            string sql = "DELETE FROM Endereco WHERE Id = @Id";

            using var cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
        }

        public Endereco? ObterEndereco(int id)
        {
            using var conexao = new MySqlConnection(_conexaoMySQL);
            conexao.Open();

            string sql = "SELECT * FROM Endereco WHERE Id = @Id";

            using var cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Endereco
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    CEP = reader["CEP"].ToString()!,
                    Estado = reader["Estado"].ToString()!,
                    Cidade = reader["Cidade"].ToString()!,
                    Bairro = reader["Bairro"].ToString()!,
                    Logradouro = reader["Logradouro"].ToString()!,
                    Complemento = reader["Complemento"]?.ToString(),
                    Numero = reader["Numero"]?.ToString()
                };
            }

            return null;
        }

        public IEnumerable<Endereco> ObterTodosEnderecos()
        {
            var lista = new List<Endereco>();

            using var conexao = new MySqlConnection(_conexaoMySQL);
            conexao.Open();

            string sql = "SELECT * FROM Endereco ORDER BY Id DESC";

            using var cmd = new MySqlCommand(sql, conexao);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Endereco
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    CEP = reader["CEP"].ToString()!,
                    Estado = reader["Estado"].ToString()!,
                    Cidade = reader["Cidade"].ToString()!,
                    Bairro = reader["Bairro"].ToString()!,
                    Logradouro = reader["Logradouro"].ToString()!,
                    Complemento = reader["Complemento"]?.ToString(),
                    Numero = reader["Numero"]?.ToString()
                });
            }

            return lista;
        }
    }
}