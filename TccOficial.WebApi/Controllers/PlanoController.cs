using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccOficial.App.Features.PlanoFeature.PlanoCommands;
using TccOficial.App.Features.PlanoFeature.PlanoHandler;
using TccOficial.Domain.IRepository;

namespace TccOficial.WebApi.Controllers
{
    [Route("[controller]")]
    public class PlanoController : ControllerBase
    {
        private readonly PlanoHandle _planoHandler;
        private readonly IPlanoRepository _planoRepository;
        public PlanoController(PlanoHandle planoHandler, IPlanoRepository planoRepository)
        {
            _planoHandler = planoHandler;
            _planoRepository = planoRepository;
        }

        [HttpGet]
        [Route("GetPlanos-Professor")]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> GetAll(GetAllPlanosDoUserCommand command)
        {
            command.ProfessorLogado = User.Identity.Name;
            if (ModelState.IsValid)
            {
                var result = await _planoRepository.GetAllPlanosProfessor(command.ProfessorLogado!);
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

        [HttpGet]
        [Route("Meus-Planos")]
        [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> GetAllPlanosDoAluno(GetAllPlanosDoUserCommand command)
        {
            command.ProfessorLogado = User.Identity.Name;
            if (ModelState.IsValid)
            {
                var result = await _planoRepository.GetAllPlanosAluno(command.ProfessorLogado!);
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

        [HttpPost]
        [Route("new-plano")]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> CriarPlano(CreatePlanoCommand command)
        {
            command.ProfessorLogado = User.Identity.Name;
            if (ModelState.IsValid)
            {
                var result = await _planoHandler.Handle(command);
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
        [Route("edit-plano/{PlanoId:long}")]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> EditPlano(AtualizaPlanoCommand command)
        {
            command.ProfessorLogado = User.Identity.Name;
            if (ModelState.IsValid)
            {
                var result = await _planoHandler.Handle(command);
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

        [HttpDelete]
        [Route("delete-plano/{PlanoId:long}")]
        [Authorize(Roles = "Professor")]
        public async Task<IActionResult> DeletePlano(DeletePlanoCommand command)
        {
            command.ProfessorLogado = User.Identity.Name;
            if (ModelState.IsValid)
            {
                var result = await _planoHandler.Handle(command);
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
