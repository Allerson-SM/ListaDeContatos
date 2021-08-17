namespace ListaContatos.Domain.Model
{
    public class Contato : Base
    {
        public string Nome { get; protected set; }
        public int Idade { get; protected set; }
        public string Email { get; protected set; }
    
    public Contato(int id, string nome, int idade, string email)
    {
        Id = id;
        Nome = nome;
        Idade = idade;
        Email = email;
    }
    public int retornaId()
    {
        return Id;
    }

    public string retornaNome()
    {
        return Nome;
    }

    public int retornaIdade()
    {
        return Idade;
    }

    public string retornaEmail()
    {
        return Email;
    }
    
    }
}