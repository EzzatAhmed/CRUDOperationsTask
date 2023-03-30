using ApplicationCore.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInfrastructure
{
    public class GenericRepository<T> :IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> table ;
        public GenericRepository(ApplicationDbContext Context)
        {
            _context = Context;
            table = Context.Set<T>();
        }
        public T Create(T entity)
        {
            table.Add(entity);
            return entity;
        }
        public bool Delete(object id)
        {
            T? existing = GetByID(id);
            if(existing != null)
                table.Remove(existing);
            return true;
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T? GetByID(object ID)
        {
            return table.Find(ID);
        }
        public T update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.Where(criteria).ToList();
        }
        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public T Save(T entity)
        {
            _context.SaveChanges();
            return entity;
        }
        public bool save()
        {
            if (_context.SaveChanges() > 0)
                return true;
            else
                return false;
        }
    }
}
