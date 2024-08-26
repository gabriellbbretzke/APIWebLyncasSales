using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasLyncas.Domain.Entities;

namespace VendasLyncas.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : EntidadeBase 
    {
        IEnumerable<TEntity> Listar();
        TEntity Obter(int id);
        void Adicionar (TEntity entity);
        void Atualizar (TEntity entity);
        void Remover (TEntity entity);
        void Commit();
    }
}
