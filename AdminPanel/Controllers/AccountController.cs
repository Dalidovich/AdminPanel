using AdminPanel.BLL.DTO;
using AdminPanel.BLL.Interfaces;
using AdminPanel.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet("valid/{id}")]
        public async Task<IActionResult> IsValidAccount(Guid id)
        {
            var resourse = await _accountService.GetAccountAsync(x => x.Id == id && x.Status != AccountStatus.Blocked);
            switch (resourse.InnerStatusCode)
            {
                case InnerStatusCode.EntityNotFound:
                    return NotFound();
                case InnerStatusCode.AccountRead:
                    return Ok();
                default:
                    return StatusCode(500);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> IsValidAccount(Guid id, [FromBody] DateTime lastActivity)
        {
            var resourse = await _accountService.UpdateAccountAsync(id, lastActivity);
            switch (resourse.InnerStatusCode)
            {
                case InnerStatusCode.EntityNotFound:
                    return NotFound();
                case InnerStatusCode.AccountUpdate:
                    return Ok();
                default:
                    return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var resourse = await _accountService.GetAccountsAsync(x => x.Id != null);
            var orderedResourse = resourse.Data.OrderBy(x => x.LastActivity);
            if (resourse.InnerStatusCode == InnerStatusCode.AccountRead)
            {
                return Ok(orderedResourse);
            }

            return StatusCode(500);
        }

        [Authorize]
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

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteAccounts([FromBody] params Guid[] deleteIds)
        {
            var resourse = await _accountService.DeleteAccountsAsync(deleteIds);
            if (resourse.InnerStatusCode == InnerStatusCode.AccountDelete)
            {
                return Ok(resourse.Data);
            }

            return StatusCode(500);
        }
    }
}
