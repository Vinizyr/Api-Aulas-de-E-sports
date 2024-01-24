using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Enums;

namespace TccOficial.Domain.Models
{
    public class Horario
    {
        public long HorarioId { get; set; }

        public long ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }

        public int DiaDaSemana { get; set; }
        public TimeSpan HoraInicial { get; set; }
        public TimeSpan HoraFinal { get; set; }
        public bool EstaDisponivel { get; set; }

    }
}
