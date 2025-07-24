using AdminPanel.BLL.DTO;
using AdminPanel.BLL.Extension;
using AdminPanel.BLL.Interfaces;
using AdminPanel.Domain.Entities;
using AdminPanel.Domain.Enums;
using AdminPanel.Domain.InnerResponse;

namespace AdminPanel.BLL.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public RegistrationService(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        public async Task<BaseResponse<AuthDTO>> Authenticate(AccountDTO DTO)
        {
            var response = await _accountService.GetAccountAsync(x => x.Email == DTO.Email);
            if (response.Data == null ||
                !_tokenService.VerifyPasswordHash(DTO.Password, Convert.FromBase64String(response.Data.Password), Convert.FromBase64String(response.Data.Salt)))
            {
                return new StandartResponse<AuthDTO>()
                {
                    InnerStatusCode = InnerStatusCode.EntityNotFound,
                    Message = "account not found"
                };
            }

            var authDTO = new AuthDTO(_tokenService.GetToken(response.Data), (Guid)response.Data.Id);

            return new StandartResponse<AuthDTO>()
            {
                Data = authDTO,
                InnerStatusCode = InnerStatusCode.AccountAuthenticate,
                Message = "account authenticate"
            };
        }

        public async Task<BaseResponse<AuthDTO>> Registration(AccountDTO DTO)
        {
            _tokenService.CreatePasswordHash(DTO.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newAccount = new Account().Create(DTO, Convert.ToBase64String(passwordSalt), Convert.ToBase64String(passwordHash));
            DTO.Password = Convert.ToBase64String(passwordHash);
            newAccount = (await _accountService.CreateAccountAsync(newAccount)).Data;

            return new StandartResponse<AuthDTO>()
            {
                Data = (await Authenticate(DTO)).Data,
                InnerStatusCode = InnerStatusCode.AccountCreate,
                Message = "account registrated"
            };
        }
    }
}
