using Atividade1309.Models;
using Atividade1309.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Atividade1309.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repo;

        public ClienteController(IClienteRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Cliente> clientes = _repo.Get<Cliente>();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Cliente cliente = _repo.GetById<Cliente>(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }
            return Ok(cliente);
        }

        [HttpGet("cpf/{cpf}")]
        public IActionResult GetClienteByCpf(string cpf)
        {
            Cliente cliente = _repo.GetClienteByCpf(cpf);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Cliente não pode ser nulo");
            }

            _repo.Adicionar(cliente);
            if (_repo.SaveChanges())
            {
                return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
            }
            return StatusCode(500, "Erro ao adicionar cliente");
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Cliente cliente)
        {
            if (cliente == null || cliente.Id != id)
            {
                return BadRequest("Dados inválidos");
            }

            Cliente clienteExistente = _repo.GetById<Cliente>(id);
            if (clienteExistente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            _repo.Atualizar(cliente);
            if (_repo.SaveChanges())
            {
                return NoContent(); 
            }
            return StatusCode(500, "Erro ao atualizar cliente");
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            Cliente cliente = _repo.GetById<Cliente>(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado");
            }

            _repo.Remover(cliente);
            if (_repo.SaveChanges())
            {
                return NoContent(); 
            }
            return StatusCode(500, "Erro ao remover cliente");
        }
    }
}
