using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Shared.Commands;

namespace TccOficial.App.Features.PlanoFeature.PlanoCommands
{
    public class GetAllPlanosDoUserCommand : ICommand
    {
        public string? ProfessorLogado { get; set; }
    }
}
