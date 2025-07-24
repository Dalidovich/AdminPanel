using AdminPanel.BLL.DTO;
using AdminPanel.Domain.InnerResponse;

namespace AdminPanel.BLL.Interfaces
{
    public interface IRegistrationService
    {
        public Task<BaseResponse<AuthDTO>> Registration(AccountDTO DTO);
        public Task<BaseResponse<AuthDTO>> Authenticate(AccountDTO DTO);
    }
}
