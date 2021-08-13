using System.Collections.Generic;
using System.Linq;
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

        public void Excluir(int id)
        {
            ListaContato.RemoveAt(id);
        }

        public List<Contato> Listar()
        {
            return ListaContato;
        }

        public Contato RetornarPorId(int id)
        {
            return ListaContato[id];
        }

        public int ProximoId()
        {
            return ListaContato.Count();
        }
    }
}