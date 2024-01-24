using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccOficial.App.Features.HorariosFeature.Commands;
using TccOficial.App.Features.HorariosFeature.Handlers;
using TccOficial.Domain.IRepository;

namespace TccOficial.WebApi.Controllers
{
    [Route("[controller]")]
    public class HorarioProfessorController : ControllerBase
    {
        private readonly HorarioHandle _horarioHandler;
        private readonly IHorarioRepository _horarioRepository;

        public HorarioProfessorController(HorarioHandle horarioHandler, IHorarioRepository horarioRepository)
        {
            _horarioHandler = horarioHandler;
            _horarioRepository = horarioRepository;
        }

        
        [Route("")]
        [Authorize(Roles = "Professor")]
        [HttpPost]
        public async Task<IActionResult> AdicionarHorario(AdicionaHorarioCommand command)
        {
            command.professorLogado = User.Identity.Name;
            if(ModelState.IsValid)
            {
                var result = await _horarioHandler.Handle(command);
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
