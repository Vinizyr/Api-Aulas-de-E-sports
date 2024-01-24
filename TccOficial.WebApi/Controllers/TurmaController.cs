using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccOficial.App.Features.TurmaFeature.Commands;
using TccOficial.App.Features.TurmaFeature.Handlers;

namespace TccOficial.WebApi.Controllers
{
    [Route("[controller]")]
    public class TurmaController : Controller
    {
        private readonly TurmaHandle _turmaHandle;

        public TurmaController(TurmaHandle turmaHandle)
        {
            _turmaHandle = turmaHandle;
        }

        [HttpPost]
        [Route("/{PlanoId:long}/{ProfessorId:long}")]
        [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> GerarTurma(GerarTurmaCommand command)
        {
            command.AlunoLogado = User.Identity.Name;
            if (ModelState.IsValid)
            {
                var result = await _turmaHandle.Handle(command);
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
        [Route("/Presenca/{FrequenciaId:long}")]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> AdicionaPresenca(AdicionaPresencaCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await _turmaHandle.Handle(command);
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
