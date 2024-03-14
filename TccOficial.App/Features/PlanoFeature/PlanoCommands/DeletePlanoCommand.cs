using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Shared.Commands;

namespace TccOficial.App.Features.PlanoFeature.PlanoCommands
{
    public class DeletePlanoCommand : ICommand
    {
        [Required]
        [FromRoute]
        public long PlanoId { get; set; }

        public string? ProfessorLogado { get; set; }

    }
}
