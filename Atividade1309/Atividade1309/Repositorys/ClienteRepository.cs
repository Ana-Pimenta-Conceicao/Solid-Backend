using Atividade1309.Data;
using Atividade1309.Models;
using Atividade1309.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Atividade1309.Repositorys
{
    public class ClienteRepository : Repository, IClienteRepository
    {
        public ClienteRepository(AtvDbContext dbContext) : base(dbContext)
        {
        }

   //Método especifico do Cliente 
       

        public Cliente GetClienteByCpf(string cpf)
        {
            return _dbContext.Set<Cliente>().AsNoTracking()
                .FirstOrDefault(c => c.cpf == cpf);
        }
    }
}