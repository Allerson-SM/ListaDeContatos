namespace ListaContatos.Domain.Model
{
    public class Contato : Base
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
    }
}