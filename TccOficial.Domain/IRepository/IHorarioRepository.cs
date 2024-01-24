using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Enums;
using TccOficial.Domain.Models;

namespace TccOficial.Domain.IRepository
{
    public interface IHorarioRepository
    {
        Task AdicionaHorario(Horario horario);
        Task<Horario> GetHorarios(TimeSpan horaInicio, TimeSpan horaFim, string profLogado, int diaSemana);
        Task<Horario> GetHorarioDisponivel(long professorId, TimeSpan horaInicio, TimeSpan horaFim, int diaSemana);
    }
}
