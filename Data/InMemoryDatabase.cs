using MyApiProject.Models;

namespace MyApiProject.Data;

public static class InMemoryDatabase
{
    public static List<Pessoa> Pessoas { get; set; } = new();
    public static int NextPessoaId = 1;
    public static int NextTelefoneId = 1;
}