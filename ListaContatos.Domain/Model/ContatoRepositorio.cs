using System.Collections.Generic;
using ListaContatos.Domain.Interfaces;

namespace ListaContatos.Domain.Model
{
    public class ContatoRepositorio : IRepositorioContato<Contato>
    {
        private List<Contato> ListaContato = new List<Contato>();

        public void Atualizar(int Id, Contato entidade)
        {
            ListaContato[Id] = entidade;
        }

        public void Cadastrar(Contato entidade)
        {
            ListaContato.Add(entidade);
        }

        public void Excluir(int Id)
        {
            Id = Id - 1;
            ListaContato.RemoveAt(Id);
        }

        public List<Contato> Listar()
        {
            return ListaContato;
        }

        public Contato RetornarPorId(int Id)
        {
            return ListaContato[Id];
        }
    }
}