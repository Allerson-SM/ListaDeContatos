namespace ListaContatos.Domain.Model
{
    public class Contato : Base
    {
        private string Nome { get; set; }
        private int Idade { get; set; }
        private string Email { get; set; }
    
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