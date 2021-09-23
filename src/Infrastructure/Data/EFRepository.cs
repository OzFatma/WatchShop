using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EFRepository<T> : IAsyncRepository<T>
        where T : BaseEntity
    {
        private readonly ApplicationDbContext _db;

        public EFRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<T> AddAsync(T entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public Task CountAsync(ISpecification<T> spec)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(T entity)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public Task<T> FirstAsync(ISpecification<T> spec)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> FirstOrDefaultAsync(ISpecification<T> spec)
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
