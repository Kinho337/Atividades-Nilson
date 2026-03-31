using Atividade_Nilson.Models;

namespace Atividade_Nilson.Repositorio.Contrato
{
    public interface IUsuarioRepositorio
    {
        IEnumerable<Usuario> ObterTodosUsuarios();
        void Cadastrar(Usuario usuario);
        void Atualizar(Usuario usuario);
        Usuario ObterUsuario(int id);
        void Excluir(int id);
    }
}