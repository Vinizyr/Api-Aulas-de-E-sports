using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Enums;

namespace TccOficial.Domain.Models
{
    public class HorariosQueOAlunoEscolheu
    {
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public int Dia { get; set; }
    }
}
