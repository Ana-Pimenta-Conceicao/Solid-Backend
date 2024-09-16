using Atividade1309.Data;
using Atividade1309.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Atividade1309.Repositorys
{
    public class Repository : IRepository
    {
        protected readonly AtvDbContext _dbContext; 

        public Repository(AtvDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> Get<T>() where T : class
        {
            return _dbContext.Set<T>().AsNoTracking().ToList();
        }

        public T GetById<T>(int id) where T : class
        {
            return _dbContext.Set<T>().AsNoTracking()
                .FirstOrDefault(e => EF.Property<int>(e, "Id") == id);
        }

        public void Adicionar<T>(T entity) where T : class
        {
            _dbContext.Add(entity);
        }

        public void Atualizar<T>(T entity) where T : class
        {
            _dbContext.Update(entity);
        }

        public void Remover<T>(T entity) where T : class
        {
            _dbContext.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() > 0);
        }
    }
}
