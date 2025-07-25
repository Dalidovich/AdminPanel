using AdminPanel.BLL.DTO;
using AdminPanel.Domain.Entities;
using AdminPanel.Domain.Enums;
using AdminPanel.Domain.InnerResponse;
using System.Linq.Expressions;

namespace AdminPanel.BLL.Interfaces
{
    public interface IAccountService
    {
        public Task<BaseResponse<Account>> GetAccountAsync(Expression<Func<Account, bool>> expression);
        public Task<BaseResponse<IEnumerable<Account>>> GetAccountsAsync(Expression<Func<Account, bool>> expression);
        public Task<BaseResponse<Account>> CreateAccountAsync(Account createDTO);
        public Task<BaseResponse<Account>> UpdateAccountAsync(Guid id, AccountStatus newStatus);
        public Task<BaseResponse<Account>> UpdateAccountAsync(Guid id, DateTime lastActivity);
        public Task<BaseResponse<int>> UpdateAccountsAsync(UpdateAccountStatusDTO[] updateAccountStatusDTOs);
        public Task<BaseResponse<bool>> DeleteAccountAsync(Guid deleteId);
        public Task<BaseResponse<int>> DeleteAccountsAsync(Guid[] deleteIds);
    }
}
