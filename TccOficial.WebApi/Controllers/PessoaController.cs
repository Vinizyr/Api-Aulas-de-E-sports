using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccOficial.App.Features.PessoaFeature.PessoaCommand;
using TccOficial.App.Features.PessoaFeature.PessoaHandler;

namespace TccOficial.WebApi.Controllers
{
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaHandle _pessoaHandler;
        public PessoaController(PessoaHandle pessoaHandler)
        {
            _pessoaHandler = pessoaHandler;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> PostPessoa([FromBody] CreatePessoaCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await _pessoaHandler.Handle(command);
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

        [HttpPut]
        [Authorize(Roles = "Professor, Aluno")]
        [Route("update-pessoa")]
        public async Task<IActionResult> PutPessoa([FromBody] AtualizarPessoaCommand command)
        {
            command.PessoaLogada = User.Identity.Name;
            if (ModelState.IsValid)
            {
                var result = await _pessoaHandler.Handle(command);
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
