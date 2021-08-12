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

        
    }
}