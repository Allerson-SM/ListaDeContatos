using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaContatos.Domain.Interfaces;
using ListaContatos.Domain.Model;

namespace ListaContatos.Data.Repository
{
    public class ContatoRepository : IRepositorioContato<Contato>
    {
        protected readonly Contexto _contexto;

        public ContatoRepository()
        {
            _contexto = new Contexto();
        }

        public void Atualizar(Contato contato, Contato contatoAtualizado)
        {
            if (contato is not null)
            {
                _contexto.Entry(contato).CurrentValues.SetValues(contatoAtualizado);
                _contexto.SaveChanges();
            }

        }

        public void Cadastrar(Contato contato)
        {
            try
            {
                _contexto.Set<Contato>().Add(contato);
                _contexto.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Excluir(Contato contato)
        {
            try
            {
                _contexto.Contato.Remove(contato);
                _contexto.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Contato> Listar()
        {
            return _contexto.Set<Contato>().ToList();
        }

        public int ProximoId()
        {
            return Listar().Count();
        }

        public Contato RetornarPorId(int id)
        {
            return _contexto.Contato.SingleOrDefault(x => x.Id == id); 
        }
    }
}