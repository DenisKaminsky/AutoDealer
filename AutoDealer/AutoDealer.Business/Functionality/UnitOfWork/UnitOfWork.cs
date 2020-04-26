using System;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace AutoDealer.Business.Functionality.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _dbContext;
        private IDbContextTransaction _dbTransaction;

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task BeginTransactionAsync()
        {
            _dbTransaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public Task RollbackAsync()
        {
            return _dbTransaction.RollbackAsync();
        }

        public async Task CommitAsync()
        {
            if (_dbContext != null)
            {
                await _dbContext.SaveChangesAsync();
            }

            if (_dbTransaction != null)
            {
                await _dbTransaction.CommitAsync();
            }
        }
        
        public void Dispose()
        {
            _dbTransaction?.Dispose();
            _dbContext?.Dispose();
        }
    }
}
