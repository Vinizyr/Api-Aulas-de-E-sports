using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Enums;
using TccOficial.Shared.Commands;

namespace TccOficial.App.Features.HorariosFeature.Commands
{
    public class AdicionaHorarioCommand : ICommand
    {
        public string? professorLogado { get; set; }

        [Required(ErrorMessage = "Horário inicial é obrigatório. ")]
        public string HoraInicio { get; set; }

        [Required(ErrorMessage = "Horário final é obrigatório. ")]
        public string HoraFim { get; set; }

        [Required(ErrorMessage = "Dia da semana é obrigatório. ")]
        public int DiaSemana { get; set; } 
    }
}
