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
    public class PlanoRepository : IPlanoRepository
    {
        private readonly TccContext _context;

        public PlanoRepository(TccContext context)
        {
            _context = context;
        }

        public async Task Delete(Plano plano)
        {
            _context.Plano.Remove(plano);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Plano plano)
        {
            _context.Entry(plano).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Plano>> GetAllPlanosAluno(string usuarioLogado)
        {
            var planos = await _context.Plano
               .Include(x => x.Turmas)
               .Include(x => x.PlanoJogo)
                   .Where(x => x.Turmas.Any(x => x.Aluno.Pessoa.Usuario.Username == usuarioLogado))
                       .ToListAsync();
            return planos;
        }

        public async Task<IList<Plano>> GetAllPlanosProfessor(string professorLogado)
        {
            var planos = await _context.Plano
                .Include(x => x.PlanoJogo)
                    .Where(x => x.Professor.Pessoa.Usuario.Username == professorLogado)
                        .ToListAsync();
            return planos;
        }

        public async Task<Plano> GetById(long id)
        {
            var plano = await _context.Plano
                .Include(x => x.Professor)
                    .ThenInclude(x => x.Pessoa)
                        .ThenInclude(x => x.Usuario)
                .Include(x => x.PlanoJogo)
                            .Where(x => x.PlanoId == id)
                        .FirstOrDefaultAsync();

            return plano!;
        }

        public async Task<Plano> GetByIdAndUsername(long id, string professorLogado)
        {
            var plano = await _context.Plano
                .Include(x => x.Professor)
                    .ThenInclude(x => x.Pessoa)
                        .ThenInclude(x => x.Usuario)
                .Include(x => x.PlanoJogo)
                            .Where(x => x.PlanoId == id && x.Professor.Pessoa.Usuario.Username == professorLogado)
                        .FirstOrDefaultAsync();

            return plano!;
        }

        public async Task<Plano> GetByName(string nome, string usuarioLogado)
        {
            var plano = await _context.Plano
                    .Include(x => x.Professor)
                        .ThenInclude(x => x.Pessoa)
                            .ThenInclude(x => x.Usuario)
                        .Where(x => x.Nome == nome && x.Professor.Pessoa.Usuario.Username == usuarioLogado)
                            .FirstOrDefaultAsync();

            return plano!;
        }

        public async Task Save(Plano plano)
        {
            _context.Plano.Add(plano);
            await _context.SaveChangesAsync();
        }
    }
}
