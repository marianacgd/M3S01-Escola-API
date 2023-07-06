using Escola.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace Escola.API.DataBase.Repositories
{
    public class BaseRepository<TEntity>  
        where TEntity : class // utilizamos essa sintaxe para limitar o tipo generico a apenas objetos classes 
    {

        protected readonly EscolaDbContexto _context;
        public BaseRepository(EscolaDbContexto contexto)
        {
            _context = contexto;
        }

        public TEntity Atualizar(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Excluir(TEntity entity)
        {

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public TEntity Inserir(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TEntity ObterPorId(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public List<TEntity> ObterTodos()
        {
            return _context.Set<TEntity>().ToList();
        }
    }
}
