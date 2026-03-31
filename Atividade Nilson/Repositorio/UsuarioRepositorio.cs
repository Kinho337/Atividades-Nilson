using Atividade_Nilson.Models;
using Atividade_Nilson.Repositorio.Contrato;
using MySql.Data.MySqlClient;
using System.Data;

namespace Atividade_Nilson.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly string _conexaoMySQL;

        public UsuarioRepositorio(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySql")!;
        }

        public void Cadastrar(Usuario usuario)
        {
            using var conexao = new MySqlConnection(_conexaoMySQL);
            conexao.Open();

            var cmd = new MySqlCommand(
                "CALL spCriarUsuario(@nomeUsu, @Cargo, @DataNasc, @CEP, @Estado, @Cidade, @Bairro, @Logradouro, @Complemento, @Numero)",
                conexao);

            cmd.Parameters.AddWithValue("@nomeUsu", usuario.nomeUsu);
            cmd.Parameters.AddWithValue("@Cargo", usuario.Cargo);
            cmd.Parameters.AddWithValue("@DataNasc", usuario.DataNasc.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@CEP", usuario.CEP);
            cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
            cmd.Parameters.AddWithValue("@Cidade", usuario.Cidade);
            cmd.Parameters.AddWithValue("@Bairro", usuario.Bairro);
            cmd.Parameters.AddWithValue("@Logradouro", usuario.Logradouro);
            cmd.Parameters.AddWithValue("@Complemento", usuario.Complemento);
            cmd.Parameters.AddWithValue("@Numero", usuario.Numero);

            cmd.ExecuteNonQuery();
        }

        public void Atualizar(Usuario usuario)
        {
            using var conexao = new MySqlConnection(_conexaoMySQL);
            conexao.Open();

            var cmd = new MySqlCommand(
                "CALL spAtualizarUsuario(@nomeUsu, @Cargo, @DataNasc, @CEP, @Estado, @Cidade, @Bairro, @Logradouro, @Complemento, @Numero, @IdUsu)",
                conexao);

            cmd.Parameters.AddWithValue("@nomeUsu", usuario.nomeUsu);
            cmd.Parameters.AddWithValue("@Cargo", usuario.Cargo);
            cmd.Parameters.AddWithValue("@DataNasc", usuario.DataNasc.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@CEP", usuario.CEP);
            cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
            cmd.Parameters.AddWithValue("@Cidade", usuario.Cidade);
            cmd.Parameters.AddWithValue("@Bairro", usuario.Bairro);
            cmd.Parameters.AddWithValue("@Logradouro", usuario.Logradouro);
            cmd.Parameters.AddWithValue("@Complemento", usuario.Complemento);
            cmd.Parameters.AddWithValue("@Numero", usuario.Numero);
            cmd.Parameters.AddWithValue("@IdUsu", usuario.IdUsu);

            cmd.ExecuteNonQuery();
        }

        public void Excluir(int id)
        {
            using var conexao = new MySqlConnection(_conexaoMySQL);
            conexao.Open();

            var cmd = new MySqlCommand("CALL spDeletarUsuario(@IdUsu)", conexao);
            cmd.Parameters.AddWithValue("@IdUsu", id);

            cmd.ExecuteNonQuery();
        }

        public IEnumerable<Usuario> ObterTodosUsuarios()
        {
            var lista = new List<Usuario>();

            using var conexao = new MySqlConnection(_conexaoMySQL);
            conexao.Open();

            var cmd = new MySqlCommand("SELECT * FROM ViewUsu", conexao);
            var da = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new Usuario
                {
                    IdUsu = Convert.ToInt32(dr["Id"]),
                    nomeUsu = dr["Nome"].ToString(),
                    Cargo = dr["Cargo"].ToString(),
                    DataNasc = Convert.ToDateTime(dr["Data de Nascimento"]),
                    CEP = dr["CEP"].ToString(),
                    Estado = dr["Estado"].ToString(),
                    Cidade = dr["Cidade"].ToString(),
                    Bairro = dr["Bairro"].ToString(),
                    Logradouro = dr["Logradouro"].ToString(),
                    Complemento = dr["Complemento"]?.ToString(),
                    Numero = Convert.ToInt32(dr["Numero"])
                });
            }

            return lista;
        }

        public Usuario ObterUsuario(int id)
        {
            using var conexao = new MySqlConnection(_conexaoMySQL);
            conexao.Open();

            var cmd = new MySqlCommand("SELECT * FROM ViewUsu WHERE Id = @IdUsu", conexao);
            cmd.Parameters.AddWithValue("@IdUsu", id);

            using var dr = cmd.ExecuteReader();

            var usuario = new Usuario();

            while (dr.Read())
            {
                usuario.IdUsu = Convert.ToInt32(dr["Id"]);
                usuario.nomeUsu = dr["Nome"].ToString();
                usuario.Cargo = dr["Cargo"].ToString();
                usuario.DataNasc = Convert.ToDateTime(dr["Data de Nascimento"]);
                usuario.CEP = dr["CEP"].ToString();
                usuario.Estado = dr["Estado"].ToString();
                usuario.Cidade = dr["Cidade"].ToString();
                usuario.Bairro = dr["Bairro"].ToString();
                usuario.Logradouro = dr["Logradouro"].ToString();
                usuario.Complemento = dr["Complemento"] == DBNull.Value ? null : dr["Complemento"].ToString();
                usuario.Numero = Convert.ToInt32(dr["Numero"]);
            }

            return usuario;
        }
    }
}