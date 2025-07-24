using AdminPanel.BLL.DTO;
using AdminPanel.BLL.Interfaces;
using AdminPanel.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public AuthController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AccountDTO accountDTO)
        {
            if (accountDTO == null)
            {
                return BadRequest();
            }
            var resourse = await _registrationService.Authenticate(accountDTO);
            if (resourse.InnerStatusCode == InnerStatusCode.AccountAuthenticate)
            {
                return Ok(resourse.Data);
            }

            return Unauthorized();
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] AccountDTO accountDTO)
        {
            var resourse = await _registrationService.Registration(accountDTO);
            if (resourse.InnerStatusCode == InnerStatusCode.AccountCreate)
            {
                return Created("", resourse.Data);
            }

            return BadRequest();
        }

    }
}
