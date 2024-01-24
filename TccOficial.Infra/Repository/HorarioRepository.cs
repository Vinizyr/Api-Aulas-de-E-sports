using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Enums;
using TccOficial.Domain.IRepository;
using TccOficial.Domain.Models;
using TccOficial.Infra.Context;

namespace TccOficial.Infra.Repository
{
    public class HorarioRepository : IHorarioRepository
    {
        private readonly TccContext _context;

        public HorarioRepository(TccContext context)
        {
            _context = context;
        }

        public async Task AdicionaHorario(Horario horario)
        {
            _context.Horario.Add(horario);
            await _context.SaveChangesAsync();
        }

        public async Task<Horario> GetHorarioDisponivel(long professorId, TimeSpan horaInicio, TimeSpan horaFim, int diaSemana)
        {
   


            var horario = await _context.Horario
                //.Include(x => x.Professor)
                //    .ThenInclude(x => x.Planos)
                .Where(x => x.DiaDaSemana == diaSemana &&
                            horaInicio >= x.HoraInicial && 
                            horaFim <= x.HoraFinal && 
                            professorId == x.ProfessorId &&
                            x.EstaDisponivel == true)
               .FirstOrDefaultAsync();
            return horario!;
        }

        public async Task<Horario> GetHorarios(TimeSpan horaInicio, TimeSpan horaFim, string profLogado, int diaSemana)
        {
            var TemSobreposicao = await _context.Horario.Where(x => horaInicio <= x.HoraFinal && 
            horaFim >= x.HoraInicial && 
            x.DiaDaSemana == diaSemana && 
            x.Professor.Pessoa.Usuario.Username == profLogado).FirstOrDefaultAsync();

            return TemSobreposicao!;
        }

    }
}
