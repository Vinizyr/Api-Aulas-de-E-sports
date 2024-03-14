using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Shared.Commands;

namespace TccOficial.App.Features.TurmaFeature.Commands
{
    public class AdicionaPresencaCommand : ICommand
    {

        [FromRoute]
        [Required]
        public long FrequenciaId { get; set; }
    }
}
