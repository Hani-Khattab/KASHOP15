

using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KASHOP.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        // Start CreateAsync//
        public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
           await _context.Set<T>().AddAsync(entity , cancellationToken);
           await _context.SaveChangesAsync(cancellationToken);
        }
        // End CreateAsync//

        // Start UpdateAsync//
        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Update(entity);
          await  _context.SaveChangesAsync(cancellationToken);
        }
        // End UpdateAsync//

        // Start RemoveAsync//
        public async Task RemoveAsync(T entity, CancellationToken cancellationToken = default) {
            _context.Set<T>().Remove(entity);
          await  _context.SaveChangesAsync(cancellationToken);
        }
        // End RemoveAsync//

        // Start GetAsync//
        public async Task<List<T>> GetAsync(Expression<Func<T, bool>>? filter = null,
            List<Expression<Func<T , object>>>? includes = null , bool tracked = false,
            CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();
            if(!tracked)
                query = query.AsNoTracking();

            if(filter != null)
                query = query.Where(filter);

            if (includes != null)
            {
               foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }


            return await query.ToListAsync(cancellationToken);

            //var entities = await  _context.Set<T>().AsNoTracking().ToListAsync();
            //return entities;
        }
        // End GetAsync//

        // Start GetOneAsync//
        public async Task<T?> GetOneAsync(Expression<Func<T, bool>> filter = null,
         List<Expression<Func<T, object>>>? includes = null,
         bool tracked = false,
         CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();
            if (!tracked)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }


            return await query.FirstOrDefaultAsync(filter, cancellationToken);
        }
        // End GetOneAsync//

        public Task GetAsync(Func<Category, bool> value, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
