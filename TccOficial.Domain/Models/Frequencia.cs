using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccOficial.Domain.Models
{
    public class Frequencia
    {
        public long FrequenciaId { get; set; }

        public long TurmaId { get; set; }
        public virtual Turma Turma { get; set; }

        public bool Presenca { get; set; }
        public DateTime DataAula { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }

    }
}
