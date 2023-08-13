using Infrastructure.Dal.Interfaces.UnitsOfWork;
using Microsoft.EntityFrameworkCore;

namespace Dal.UnitsOfWork
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        #region Private Fields

        private readonly DbContext _context = null;

        #endregion

        #region Constructor

        public UnitOfWork(DbContext dbContext)
        {
            _context = dbContext;
        }

        #endregion

        protected async Task ExecuteWithStrategy(Func<Task> operation, Func<Task<bool>> validation = null)
        {
            /* USAGE

            await ExecuteWithStrategy(async () =>
            {
                // repository calls here
                await Task.FromResult(0);
            });
             
             */

            var strategy = _context.Database.CreateExecutionStrategy();
            if (validation == null)
            {
                await strategy.ExecuteInTransactionAsync(operation, async () =>
                {
                    return await Task.FromResult(true);
                });
            }
            else
            {
                await strategy.ExecuteInTransactionAsync(operation, validation);
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CancelChanges();
                throw;
            }
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CancelChanges();
                throw;
            }
        }

        public void CancelChanges()
        {
            var changedEntries = _context.ChangeTracker.Entries();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }
}
