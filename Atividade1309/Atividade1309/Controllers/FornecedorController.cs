using Atividade1309.Models;
using Atividade1309.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atividade1309.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository _repo;

        public FornecedorController(IFornecedorRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Fornecedor> fornecedores = _repo.Get<Fornecedor>();
            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Fornecedor fornecedor = _repo.GetById<Fornecedor>(id);
            if (fornecedor == null)
            {
                return NotFound("fornecedor não encontrado");
            }
            return Ok(fornecedor);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null)
            {
                return BadRequest("fornecedor não pode ser nulo");
            }

            _repo.Adicionar(fornecedor);
            if (_repo.SaveChanges())
            {
                return CreatedAtAction(nameof(GetById), new { id = fornecedor.Id }, fornecedor);
            }
            return StatusCode(500, "Erro ao adicionar fornecedor");
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null || fornecedor.Id != id)
            {
                return BadRequest("Dados inválidos");
            }

            Fornecedor fornecedorExistente = _repo.GetById<Fornecedor>(id);
            if (fornecedorExistente == null)
            {
                return NotFound("Fornecedor não encontrado");
            }

            _repo.Atualizar(fornecedor);
            if (_repo.SaveChanges())
            {
                return NoContent();
            }
            return StatusCode(500, "Erro ao atualizar fornecedor");
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            Fornecedor fornecedor = _repo.GetById<Fornecedor>(id);
            if (fornecedor == null)
            {
                return NotFound("Fornecedor não encontrado");
            }

            _repo.Remover(fornecedor);
            if (_repo.SaveChanges())
            {
                return NoContent();
            }
            return StatusCode(500, "Erro ao remover Fornecedor");
        }

    }
}
