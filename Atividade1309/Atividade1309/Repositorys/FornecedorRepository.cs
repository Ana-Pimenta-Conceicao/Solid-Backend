using Atividade1309.Data;
using Atividade1309.Repositorys.Interfaces;

namespace Atividade1309.Repositorys
{
    public class FornecedorRepository : Repository, IFornecedorRepository
    {
        public FornecedorRepository(AtvDbContext dbContext) : base(dbContext) 
        { 
        }
    }
}
