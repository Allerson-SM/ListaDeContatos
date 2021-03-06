using System;
using System.Linq;
using ListaContatos.ConsoleUI.Services;
using ListaContatos.Data.Repository;

namespace ListaContatos.ConsoleUI
{

    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        private static readonly ContatoRepository _repositorio = new ContatoRepository();
        static ServiceContato _services = new ServiceContato(_repositorio);

        public static void Menu()
        {
            Console.Clear();
            System.Console.WriteLine("===========Lista de contatos===========");
            System.Console.WriteLine();
            System.Console.WriteLine("Digite uma das opções abaixo");
            System.Console.WriteLine("1 - Listar contatos");
            System.Console.WriteLine("2 - Cadastrar contato");
            System.Console.WriteLine("3 - Excluir contato");
            System.Console.WriteLine("4 - Atualizar contato");
            System.Console.WriteLine("5 - Consultar contato");
            System.Console.WriteLine("X - Sair");

            var opcao = Console.ReadLine().ToUpper();

            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                        Listar();
                        break;
                    case "2":
                        Cadastrar();
                        break;
                    case "3":
                        Excluir();
                        break;
                    case "4":
                        Atualizar();
                        break;
                    case "5":
                        Consultar();
                        break;
                    default:
                        Menu();
                        break;
                }
                Menu();
            }
            System.Console.WriteLine("Obrigado por utilizar o sistema!");
            System.Console.WriteLine("Pressione qualquer tecla para encerrar");
            Console.ReadLine();
            Environment.Exit(0);
        }

        public static void Listar()
        {
            Console.Clear();
            var lista = _services.Listar();

            if (lista.Count() == 0)
            {
                System.Console.WriteLine("Não há contatos cadastrados");
                Console.ReadKey();
                Menu();
            }

            foreach (var contato in lista)
            {
                System.Console.WriteLine($"ID: {contato.retornaId()}");
                System.Console.WriteLine($"Nome: {contato.retornaNome()}");
                System.Console.WriteLine($"Idade: {contato.retornaIdade()}");
                System.Console.WriteLine($"E-mail: {contato.retornaEmail()}");
                System.Console.WriteLine($"Celular: {contato.retornaCelular()}");
                System.Console.WriteLine();
                System.Console.WriteLine("Pressione qualquer tecla para retornar ao menu");
                Console.ReadKey();
            }
            Menu();
        }
        public static void Cadastrar()
        {
            Console.Clear();
            System.Console.WriteLine("Informe o nome");
            var nome = Console.ReadLine();

            System.Console.WriteLine("Informe a idade");
            var idade = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Informe o e-mail");
            var email = Console.ReadLine();

            System.Console.WriteLine("Informe o celular");
            var celular = Console.ReadLine();

            _services.Cadastrar(nome,
                                idade,
                                email,
                                celular);

            System.Console.WriteLine("Contato registrado com sucesso!");
            System.Console.WriteLine("Pressione qualquer tecla para retornar ao menu");
            Console.ReadKey();
            Menu();
        }

        public static void Excluir()
        {
            Console.Clear();
            System.Console.WriteLine("Informe um Id para exclusão");
            var id = int.Parse(Console.ReadLine());

            try
            {

                System.Console.WriteLine("Tem certeza que deseja realizar a exclusão do contato abaixo? S/N");
                System.Console.WriteLine();
                var contato = _services.Consultar(id);
                System.Console.WriteLine($"ID: {contato.retornaId()}");
                System.Console.WriteLine($"Nome: {contato.retornaNome()}");
                System.Console.WriteLine($"Idade: {contato.retornaIdade()}");
                System.Console.WriteLine($"E-mail: {contato.retornaEmail()}");
                System.Console.WriteLine($"Celular: {contato.retornaCelular()}");
                System.Console.WriteLine();

                var resposta = Console.ReadLine().ToUpper();

                if (resposta.ToUpper() == "N")
                {
                    Menu();
                }
                else if (resposta.ToUpper() == "S")
                {
                    _services.Excluir(id);
                    System.Console.WriteLine("Contato excluído com sucesso!");
                    System.Console.WriteLine("Pressione qualquer tecla para retornar ao menu");
                    Console.ReadKey();
                    Menu();
                }
                else
                {
                    System.Console.WriteLine("Id informado está errado");
                    Console.ReadKey();
                    Menu();
                }


            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Id informado está errado");
                Menu();
            }



        }

        public static void Atualizar()
        {
            Console.Clear();
            System.Console.WriteLine("Informe um Id para atualizar");
            var id = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Informe o nome");
            var nome = Console.ReadLine();

            System.Console.WriteLine("Informe a idade");
            var idade = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Informe o e-mail");
            var email = Console.ReadLine();

            System.Console.WriteLine("Informe o celular");
            var celular = Console.ReadLine();

            _services.Atualizar(id,
                                nome,
                                idade,
                                email,
                                celular);

            System.Console.WriteLine("Contato atualizado com sucesso!");
            System.Console.WriteLine("Aperte qualquer tecla para retornar ao menu");
            Console.ReadKey();
            Menu();
        }

        public static void Consultar()
        {
            Console.Clear();
            var lista = _services.Listar();

            if (lista.Count() == 0)
            {
                System.Console.WriteLine("Não há contatos cadastrados");
                Menu();
            }

            System.Console.WriteLine("Informe um Id para consultar");
            var id = int.Parse(Console.ReadLine());

            try
            {
                var contato = _services.Consultar(id);
                System.Console.WriteLine($"ID: {contato.retornaId()}");
                System.Console.WriteLine($"Nome: {contato.retornaNome()}");
                System.Console.WriteLine($"Idade: {contato.retornaIdade()}");
                System.Console.WriteLine($"E-mail: {contato.retornaEmail()}");
                System.Console.WriteLine($"Celular: {contato.retornaCelular()}");
                System.Console.WriteLine();
                System.Console.ReadLine();

                Menu();

            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Id informado está errado");
                Menu();
            }



        }

    }
}
