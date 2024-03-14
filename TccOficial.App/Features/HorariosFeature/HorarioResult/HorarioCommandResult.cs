using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Shared.Commands;

namespace TccOficial.App.Features.HorariosFeature.HorarioResult
{
    public class HorarioCommandResult : ICommandResult
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
    }
}
