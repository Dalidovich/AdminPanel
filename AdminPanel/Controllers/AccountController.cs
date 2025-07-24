using AdminPanel.BLL.DTO;
using AdminPanel.BLL.Interfaces;
using AdminPanel.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var resourse = await _accountService.GetAccountsAsync(x => x.Id != null);
            var orderedResourse = resourse.Data.OrderBy(x => x.Email);
            if (resourse.InnerStatusCode == InnerStatusCode.AccountRead)
            {
                return Ok(orderedResourse);
            }

            return StatusCode(500);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccounts([FromBody] params UpdateAccountStatusDTO[] updateAccountStatusDTOs)
        {
            var resourse = await _accountService.UpdateAccountsAsync(updateAccountStatusDTOs);
            if (resourse.InnerStatusCode == InnerStatusCode.AccountUpdate)
            {
                return Ok(resourse.Data);
            }

            return StatusCode(500);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAccounts([FromBody] params Guid[] deleteIds)
        {
            var resourse = await _accountService.DeleteAccountsAsync(deleteIds);
            if (resourse.InnerStatusCode == InnerStatusCode.AccountUpdate)
            {
                return Ok(resourse.Data);
            }

            return StatusCode(500);
        }
    }
}
