using AdminPanel.Domain.DTO;
using AdminPanel.Domain.Entities;
using AdminPanel.Domain.Enums;
using AdminPanel.Domain.InnerResponse;
using System.Linq.Expressions;

namespace AdminPanel.BLL.Interfaces
{
    public interface IAccountService
    {
        public Task<BaseResponse<Account>> GetClientAsync(Expression<Func<Account, bool>> expression);
        public Task<BaseResponse<IEnumerable<Account>>> GetClientsAsync(Expression<Func<Account, bool>> expression);
        public Task<BaseResponse<Account>> CreateClientAsync(AccountDTO createDTO);
        public Task<BaseResponse<Account>> UpdateClientAsync(Guid id, AccountStatus newStatus);
        public Task<BaseResponse<bool>> DeleteClientAsync(Guid deleteId);
    }
}
