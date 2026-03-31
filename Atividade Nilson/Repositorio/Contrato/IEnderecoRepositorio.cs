using Atividade_Nilson.Models;

namespace Atividade_Nilson.Repositorio.Contrato
{
    public interface IEnderecoRepositorio
    {
        void Cadastrar(Endereco endereco);
        void Atualizar(Endereco endereco);
        void Excluir(int id);
        Endereco? ObterEndereco(int id);
        IEnumerable<Endereco> ObterTodosEnderecos();
    }
}