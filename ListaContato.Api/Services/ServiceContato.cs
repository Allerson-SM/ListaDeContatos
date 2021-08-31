using System.Collections.Generic;
using ListaContatos.Data.Repository;
using ListaContatos.Domain.Model;

namespace ListaContatos.Api.Services
{
    public class ServiceContato
    {
        private readonly ContatoRepository _repositorio;

        public ServiceContato(ContatoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Contato> Listar()
        {
            return _repositorio.Listar();
            
        }

        public void Cadastrar(string nome, int idade, string email, string celular)
        {
            var id = _repositorio.ProximoId();

            Contato novoContato = new Contato(id,
                                              nome,
                                              idade,
                                              email,
                                              celular);

            _repositorio.Cadastrar(novoContato);
        }

        public void Excluir(int id)
        {
            var contatoASerExcluido = Consultar(id);
            _repositorio.Excluir(contatoASerExcluido);
        }

        public void Atualizar(int id, string nome, int idade, string email, string celular)
        {
            var contatoAntigo = Consultar(id);

            Contato contatoAtualizado = new Contato(id,
                                                    nome,
                                                    idade,
                                                    email,
                                                    celular);

            _repositorio.Atualizar(contatoAntigo, contatoAtualizado);
        }

        public Contato Consultar(int id)
        {
            return _repositorio.RetornarPorId(id);
        }

        
    }
}