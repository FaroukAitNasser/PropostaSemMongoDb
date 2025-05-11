namespace MyApiProject.Models;

public class Telefone
{
    public int Id { get; set; }
    public string Tipo { get; set; } // Celular / Residencial / Comercial
    public string Numero { get; set; }

    public int PessoaId { get; set; } // To link back to Pessoa
}
