using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaContatos.Domain.Model;

namespace ListaContatos.Data.Repository
{
    public class ContatoRepository
    {
        protected readonly Contexto _contexto;

        public ContatoRepository()
        {
            _contexto = new Contexto();
        }

        public virtual bool Atualizar<Contato>(int id, Contato contato, Contato contatoAtualizado)
        {
            if(contato is not null)
            {
              _contexto.Entry(contato).CurrentValues.SetValues(contatoAtualizado);
              return true;
              
            }
            return false;
        }

        public virtual bool Incluir(Contato contato)
        {
            try
            {
                _contexto.Set<Contato>().Add(contato);
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Contato SelecionarPorId(int id)
        {
            return _contexto.Set<Contato>().FirstOrDefault(x => x.Id == id);

        }

        public virtual List<Contato> SelecionarTudo()
        {
            return _contexto.Set<Contato>().ToList();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public async Task<int> SalvarAlteracoesAsync() =>
            await _contexto.SaveChangesAsync();
    }
}