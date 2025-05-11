using Microsoft.AspNetCore.Mvc;
using MyApiProject.Data;
using MyApiProject.Models;

namespace MyApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PessoaController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Pessoa>> GetAll()
        => Ok(InMemoryDatabase.Pessoas);

    [HttpGet("{id}")]
    public ActionResult<Pessoa> GetById(int id)
    {
        var pessoa = InMemoryDatabase.Pessoas.FirstOrDefault(p => p.Id == id);
        return pessoa == null ? NotFound() : Ok(pessoa);
    }

    [HttpPost]
    public ActionResult<Pessoa> Create(Pessoa pessoa)
    {
        pessoa.Id = InMemoryDatabase.NextPessoaId++;
        foreach (var tel in pessoa.Telefones)
        {
            tel.Id = InMemoryDatabase.NextTelefoneId++;
            tel.PessoaId = pessoa.Id;
        }
        InMemoryDatabase.Pessoas.Add(pessoa);
        return CreatedAtAction(nameof(GetById), new { id = pessoa.Id }, pessoa);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pessoa updatedPessoa)
    {
        var pessoa = InMemoryDatabase.Pessoas.FirstOrDefault(p => p.Id == id);
        if (pessoa == null) return NotFound();

        pessoa.Nome = updatedPessoa.Nome;
        pessoa.CPF = updatedPessoa.CPF;
        pessoa.DataNascimento = updatedPessoa.DataNascimento;
        pessoa.EstaAtivo = updatedPessoa.EstaAtivo;

        pessoa.Telefones = updatedPessoa.Telefones.Select(t =>
        {
            t.Id = t.Id == 0 ? InMemoryDatabase.NextTelefoneId++ : t.Id;
            t.PessoaId = id;
            return t;
        }).ToList();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pessoa = InMemoryDatabase.Pessoas.FirstOrDefault(p => p.Id == id);
        if (pessoa == null) return NotFound();
        InMemoryDatabase.Pessoas.Remove(pessoa);
        return NoContent();
    }
}
