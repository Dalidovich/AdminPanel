using AdminPanel.BLL.DTO;
using AdminPanel.BLL.Interfaces;
using AdminPanel.DAL.Repositories.Interfaces;
using AdminPanel.Domain.Entities;
using AdminPanel.Domain.Enums;
using AdminPanel.Domain.InnerResponse;
using System.Linq.Expressions;

namespace AdminPanel.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _accountRepository;

        public AccountService(IRepository<Account> repo)
        {
            _accountRepository = repo;
        }

        public async Task<BaseResponse<Account>> CreateAccountAsync(Account account)
        {
            var createEntity = await _accountRepository.AddAsync(account);
            await _accountRepository.SaveAsync();

            return new StandartResponse<Account>()
            {
                Data = createEntity,
                InnerStatusCode = InnerStatusCode.AccountCreate,
                Message = "account create"
            };
        }

        public async Task<BaseResponse<bool>> DeleteAccountAsync(Guid deleteId)
        {
            var entity = await _accountRepository
                .GetOneWhereAsync(x => x.Id == deleteId);

            if (entity == null)
            {
                return new StandartResponse<bool>()
                {
                    Data = false,
                    InnerStatusCode = InnerStatusCode.EntityNotFound,
                    Message = "account not found"
                };
            }

            var response = await _accountRepository.DeleteAsync(deleteId);

            return new StandartResponse<bool>()
            {
                Data = response,
                InnerStatusCode = InnerStatusCode.AccountDelete,
                Message = "account deleted"
            };
        }

        public async Task<BaseResponse<Account>> GetAccountAsync(Expression<Func<Account, bool>> expression)
        {
            var entity = await _accountRepository.GetOneWhereAsync(expression);
            if (entity == null)
            {
                return new StandartResponse<Account>()
                {
                    InnerStatusCode = InnerStatusCode.EntityNotFound,
                    Message = "account not found"
                };
            }

            return new StandartResponse<Account>()
            {
                Data = entity,
                InnerStatusCode = InnerStatusCode.AccountRead,
                Message = "account read"
            };
        }

        public async Task<BaseResponse<IEnumerable<Account>>> GetAccountsAsync(Expression<Func<Account, bool>> expression)
        {
            var entities = await _accountRepository.GetAllWhereAsync(expression);

            return new StandartResponse<IEnumerable<Account>>()
            {
                Data = entities,
                InnerStatusCode = InnerStatusCode.AccountRead,
                Message = "account read"
            };
        }

        public async Task<BaseResponse<Account>> UpdateAccountAsync(Guid id, AccountStatus newStatus)
        {
            var updateEntity = await _accountRepository.GetOneWhereAsync(x => x.Id == id);

            if (updateEntity == null)
            {
                return new StandartResponse<Account>()
                {
                    Data = updateEntity,
                    InnerStatusCode = InnerStatusCode.EntityNotFound,
                    Message = "account not found"
                };
            }

            updateEntity.Status = newStatus;
            _accountRepository.Update(updateEntity);
            await _accountRepository.SaveAsync();

            return new StandartResponse<Account>()
            {
                Data = updateEntity,
                InnerStatusCode = InnerStatusCode.AccountUpdate,
                Message = "account update"
            };
        }

        public async Task<BaseResponse<int>> UpdateAccountsAsync(UpdateAccountStatusDTO[] updateAccountStatusDTOs)
        {
            var updateCount = 0;
            for (int i = 0; i < updateAccountStatusDTOs.Length; i++)
            {
                var response = await UpdateAccountAsync(updateAccountStatusDTOs[i].Id, updateAccountStatusDTOs[i].NewStatus);
                updateCount += response.InnerStatusCode == InnerStatusCode.AccountUpdate ? 1 : 0;
            }

            return new StandartResponse<int>()
            {
                Data = updateCount,
                InnerStatusCode = InnerStatusCode.AccountUpdate,
                Message = $"{updateCount} updated from {updateAccountStatusDTOs.Length}"
            };
        }

        public async Task<BaseResponse<int>> DeleteAccountsAsync(Guid[] deleteIds)
        {
            var deleteCount = 0;
            for (int i = 0; i < deleteIds.Length; i++)
            {
                var response = await DeleteAccountAsync(deleteIds[i]);
                deleteCount += response.InnerStatusCode == InnerStatusCode.AccountDelete ? 1 : 0;
            }

            return new StandartResponse<int>()
            {
                Data = deleteCount,
                InnerStatusCode = InnerStatusCode.AccountDelete,
                Message = $"{deleteCount} updated from {deleteIds.Length}"
            };
        }

        public async Task<BaseResponse<Account>> UpdateAccountAsync(Guid id, DateTime lastActivity)
        {
            var updateEntity = await _accountRepository.GetOneWhereAsync(x => x.Id == id);

            if (updateEntity == null)
            {
                return new StandartResponse<Account>()
                {
                    Data = updateEntity,
                    InnerStatusCode = InnerStatusCode.EntityNotFound,
                    Message = "account not found"
                };
            }

            updateEntity.LastActivity = lastActivity;
            _accountRepository.Update(updateEntity);
            await _accountRepository.SaveAsync();

            return new StandartResponse<Account>()
            {
                Data = updateEntity,
                InnerStatusCode = InnerStatusCode.AccountUpdate,
                Message = "account update"
            };
        }
    }
}
