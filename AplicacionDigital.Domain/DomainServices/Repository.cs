using AplicacionDigital.Domain.Contracts;
using AplicacionDigital.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionDigital.Domain.DomainServices
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Properties
        private PRUEBASContext _context;
        private DbSet<TEntity> _dbset;

        #endregion

        #region Buildrs
        public Repository(PRUEBASContext context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<TEntity>> GetAsync()
           => await Task.FromResult(_dbset.ToList());

        public async Task<TEntity> GetAsyncById(Guid id)
            => await Task.FromResult(_dbset.Find(id));

        public async Task DeleteAsync(TEntity id)
        {
            var dataToDelete = await Task.FromResult(_dbset.Find(id));
            await Task.FromResult(_dbset.Remove(dataToDelete));
        }
        public async Task AddAsync(TEntity data)
            => await Task.FromResult(_dbset.Add(data));

        public async Task Save()
            => await Task.FromResult(_context.SaveChanges());

        public async Task UpdateAsync(TEntity data)
        {
            _dbset.Find(data);
            await Task.FromResult(_context.Entry(data).State = EntityState.Modified);
        }
        #endregion



    }
}
