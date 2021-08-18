using System.Collections.Generic;

namespace ListaContatos.Domain.Interfaces
{
    public interface IRepositorioContato<T>
    {
        List<T> Listar();

        void Cadastrar(T entidade);

        void Excluir(T entidade);

        T RetornarPorId(int Id);

        void Atualizar(T entidade, T entidadeAtualizada);

        int ProximoId();
    }
}