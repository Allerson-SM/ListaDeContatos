using System.Collections.Generic;
using ListaContatos.Domain.Model;

namespace ListaContatos.ConsoleUI.Services
{
    public class ServiceContato
    {
        private readonly ContatoRepositorio _repositorio;

        public ServiceContato(ContatoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Contato> Listar()
        {
            return _repositorio.Listar();
            
        }

        public void Cadastrar(string nome, int idade, string email)
        {
            var id = _repositorio.ProximoId();

            Contato novoContato = new Contato(id,
                                              nome,
                                              idade,
                                              email);

            _repositorio.Cadastrar(novoContato);
        }

        public void Excluir(int id)
        {
            _repositorio.Excluir(id);
        }

        public void Atualizar(int id, string nome, int idade, string email)
        {
            Contato contatoAtualizado = new Contato(id,
                                                    nome,
                                                    idade,
                                                    email);
            _repositorio.Atualizar(id, contatoAtualizado);
        }

        public Contato Consultar(int id)
        {
            return _repositorio.RetornarPorId(id);
        }

        
    }
}