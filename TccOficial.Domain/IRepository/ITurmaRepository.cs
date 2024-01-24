using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Models;

namespace TccOficial.Domain.IRepository
{
    public interface ITurmaRepository
    {
        Task SaveTurma(Turma turma);
        Task SaveFrequencia(Frequencia frequencia);
        Task<bool> GetTurmaExist(string alunoLogado, long planoId, long professorId);
        Task<Frequencia> GetFrequenciaById(long frequenciaId);
        Task Update(Frequencia frequencia);
    }
}
