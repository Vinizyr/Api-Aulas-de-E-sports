using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.IRepository;
using TccOficial.Domain.Models;
using TccOficial.Infra.Context;

namespace TccOficial.Infra.Repository
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly TccContext _context;

        public TurmaRepository(TccContext context)
        {
            _context = context;
        }

        public async Task SaveTurma(Turma turma)
        {
            _context.Turma.Add(turma);
            await _context.SaveChangesAsync();
        }

        public async Task SaveFrequencia(Frequencia frequencia)
        {
            _context.Frequencia.Add(frequencia);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> GetTurmaExist(string alunoLogado, long planoId, long professorId)
        {
            var existe = await _context.Turma
                    .Where(x => x.Aluno.Pessoa.Usuario.Username == alunoLogado &&
                                x.Plano.PlanoId == planoId &&
                                x.ProfessorId == professorId).FirstOrDefaultAsync();
            if(existe == null)
            {
                return false;
            }
            return true;
            
        }

        public async Task<Frequencia> GetFrequenciaById(long frequenciaId)
        {
            var frequencia = await _context.Frequencia.Where(x => x.FrequenciaId == frequenciaId).FirstOrDefaultAsync();
            return frequencia!;
        }

        public async Task Update(Frequencia frequencia)
        {
            _context.Entry(frequencia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
