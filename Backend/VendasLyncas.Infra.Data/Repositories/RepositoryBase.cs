using Microsoft.EntityFrameworkCore;
using VendasLyncas.Domain.Entities;
using VendasLyncas.Domain.Interfaces.Repositories;
using VendasLyncas.Infra.Context.Context;
using VendasLyncas.Infra.Context.Repositories;

namespace VendasLyncas.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntidadeBase
    {
        protected ApplicationContext _context;
        protected DbSet<TEntity> DbSet;

        public RepositoryBase(ApplicationContext context)
        {
            DbSet = context.Set<TEntity>();
            _context = context;
        }

        public IEnumerable<TEntity> Listar()
        {

            return DbSet.AsEnumerable();
        }

        public TEntity Obter(int id)
        {
            return DbSet.Find(id);
        }

        public void Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void Remover(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
