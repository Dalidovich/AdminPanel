using AdminPanel.DAL.Repositories.Interfaces;
using AdminPanel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdminPanel.DAL.Implements
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly AppDBContext _db;

        public AccountRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<Account> AddAsync(Account entity)
        {
            var createdEntity = await _db.Accounts.AddAsync(entity);

            return createdEntity.Entity;
        }

        public async Task<bool> DeleteAsync(Guid deleteId)
        {
            await _db.Accounts.Where(x => x.Id == deleteId).ExecuteDeleteAsync();

            return true;
        }

        public async Task<IEnumerable<Account>> GetAllWhereAsync(Expression<Func<Account, bool>> expression)
        {
            return await _db.Accounts.Where(expression).ToListAsync();
        }

        public async Task<Account?> GetOneWhereAsync(Expression<Func<Account, bool>> expression)
        {
            return await _db.Accounts.Where(expression).SingleOrDefaultAsync();
        }

        public async Task<bool> SaveAsync()
        {
            await _db.SaveChangesAsync();

            return true;
        }

        public Account Update(Account entity)
        {
            var updatedEntity = _db.Accounts.Update(entity);

            return updatedEntity.Entity;
        }
    }
}
