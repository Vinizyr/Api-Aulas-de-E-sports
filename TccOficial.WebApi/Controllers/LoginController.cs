using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccOficial.App.Features.Login;

namespace TccOficial.WebApi.Controllers
{
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginHandle _loginHandle;
        public LoginController(LoginHandle loginHandle)
        {
            _loginHandle = loginHandle;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {

            if (ModelState.IsValid)
            {
                var result = await _loginHandle.Handle(command);
                return Ok(result);
            }
            else
            {
                var erros = ModelState.Values.SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage)
                                    .ToList();
                return BadRequest(erros);
            }
        }
    }
}
