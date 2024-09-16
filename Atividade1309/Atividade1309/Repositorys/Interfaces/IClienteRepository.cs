using Atividade1309.Models;
using Atividade1309.Repositorys.Interfaces;

namespace Atividade1309.Repositorys.Interfaces
{
    public interface IClienteRepository : IRepository
    {
 
        Cliente GetClienteByCpf(string cpf);
    }
}
