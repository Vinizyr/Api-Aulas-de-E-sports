using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TccOficial.App.Features.PessoaFeature.PessoaCommand;
using TccOficial.App.Features.PessoaFeature.PessoaCommandResult;
using TccOficial.Domain.IRepository;
using TccOficial.Domain.Models;
using TccOficial.Infra.Context;
using TccOficial.Shared.Commands;

namespace TccOficial.App.Features.PessoaFeature.PessoaHandler
{
    public class PessoaHandle : ICommandHandler<CreatePessoaCommand>
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPerfilRepository _perfilRepository;

        public PessoaHandle(IPessoaRepository pessoaRepository, IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository)
        {
            _pessoaRepository = pessoaRepository;
            _usuarioRepository = usuarioRepository;
            _perfilRepository = perfilRepository;
        }

        public async Task<ICommandResult> Handle(CreatePessoaCommand command)
        {
            var existeUsername = await _usuarioRepository.ExisteUsuario(command.Username);
            if (existeUsername != null)
            {
                return new PessoaResult()
                {
                    Sucesso = false,
                    Mensagem = "Esse username já está em uso. "
                };
            }

            var existe = await _pessoaRepository.GetByCpf(command.Cpf);
            if (existe != null)
            {
                return new PessoaResult()
                {
                    Sucesso = false,
                    Mensagem = "Esse cpf já está em uso. "
                };
            }
            var usuario = new Usuario(command.Username, command.Password);
            var perfil = await _perfilRepository.GetPerfil(command.TipoPerfil);
            var usuarioPerfil = new UsuarioPerfil(usuario, perfil);
            usuario.UsuarioPerfil.Add(usuarioPerfil);

            Pessoa pessoa = new Pessoa()
            {
                Nome = command.Nome,
                Sobrenome = command.Sobrenome,
                DataNascimento = command.DataNascimento,
                Cpf = command.Cpf,
                Discord = command.Discord,
                Sexo = command.Sexo,
                Ativo = true,
                Usuario = usuario,

            };
            if (command.TipoPerfil == "Aluno")
            {
                Aluno aluno = new Aluno()
                {
                    DataCriado = DateTime.Now
                };
                pessoa.Aluno = aluno;
            }

            if (command.TipoPerfil == "Professor")
            {
                Professor professor = new Professor()
                {
                    DataCriado = DateTime.Now,
                    NomeCanalYoutube = command.NomeCanalYoutube
                };
                pessoa.Professor = professor;
            }

            await _pessoaRepository.Save(pessoa);
            return new PessoaResult()
            {
                Sucesso = true,
                Mensagem = "Cadastro realizado com sucesso. "
            };


        }   

        public async Task<ICommandResult> Handle(AtualizarPessoaCommand command)
        {
            var existe = await _pessoaRepository.GetPessoaByUsername(command.PessoaLogada!);
            if(existe == null)
            {
                return new PessoaResult()
                {
                    Sucesso = false,
                    Mensagem = "Pessoa não encontrada. Não é possível atualizar"
                };
            }

            existe.AtualizarPessoa(command.Nome, command.Sobrenome, command.DataNascimento, command.Discord);
            await _pessoaRepository.UpdatePessoa(existe);

            return new PessoaResult()
            {
                Sucesso = true,
                Mensagem = "Pessoa Atualizada com sucesso. "
            };


        }
    }
}
