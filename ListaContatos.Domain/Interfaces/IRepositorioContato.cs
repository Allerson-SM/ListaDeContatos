using System.Collections.Generic;

namespace ListaContatos.Domain.Interfaces
{
    public interface IRepositorioContato<T>
    {
        List<T> Listar();

        void Cadastrar(T entidade);

        void Excluir(int Id);

        T RetornarPorId(int Id);

        void Atualizar(int Id, T entidade);

        int ProximoId();
    }
}