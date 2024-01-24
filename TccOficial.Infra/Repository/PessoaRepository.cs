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
    public class PessoaRepository : IPessoaRepository
    {
        private readonly TccContext _context;

        public PessoaRepository(TccContext context)
        {
            _context = context;
        }

        public async Task<Pessoa> GetByCpf(string cpf)
        {
            var pessoaCpf = await _context.Pessoa
                    .Where(x => x.Cpf == cpf).FirstOrDefaultAsync();

            return pessoaCpf!;
        }

        public async Task<Pessoa> GetPessoaByUsername(string username)
        {
            var pessoa = await _context.Pessoa
                    .Include(x => x.Usuario)
                        .Where(x => x.Usuario.Username == username).FirstOrDefaultAsync();

            return pessoa!;
        }

        public async Task<Professor> GetProfessorByUsername(string username)
        {
            var professor = await _context.Professor
                    .Include(x => x.Pessoa)
                        .ThenInclude(x => x.Usuario)
                    .Where(x => x.Pessoa.Usuario.Username == username).FirstOrDefaultAsync();

            return professor!;
        }

        public async Task Save(Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePessoa(Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
