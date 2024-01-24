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
    public class AlunoRepository : IAlunoRepository
    {
        private readonly TccContext _context;

        public AlunoRepository(TccContext context)
        {
            _context = context;
        }

        public async Task Delete(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Aluno> GetAlunoById(long id)
        {
            return await _context.Aluno
                .Include(x => x.Pessoa)
                .Where(x => x.AlunoId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Aluno> GetByCpf(string cpf)
        {
            return await _context.Aluno
                .Include(x => x.Pessoa)
                    .Where(x => x.Pessoa.Cpf == cpf).FirstOrDefaultAsync();
        }

        public async Task Save(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();
        }
    }
}
