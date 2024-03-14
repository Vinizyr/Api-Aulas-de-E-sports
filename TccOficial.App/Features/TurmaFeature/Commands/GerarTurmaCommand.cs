using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TccOficial.Domain.Models;
using TccOficial.Shared.Commands;

namespace TccOficial.App.Features.TurmaFeature.Commands
{
    public class GerarTurmaCommand : ICommand
    {
        public string? AlunoLogado { get; set; }

        [FromRoute]
        [Required(ErrorMessage ="PlanoId é obrigatório.")]
        public long PlanoId { get; set; }
        [Required(ErrorMessage = "ProfessorId é obrigatório.")]
        public long ProfessorId { get; set; }
        [Required(ErrorMessage = "Horarios são obrigatórios.")]

        [FromBody]
        public List<HorariosQueOAlunoEscolheu> Horarios { get; set; }
    }
}
