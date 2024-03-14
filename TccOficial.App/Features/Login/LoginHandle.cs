using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.App.Features.Autenticacao;
using TccOficial.Domain.IRepository;
using TccOficial.Shared.Commands;

namespace TccOficial.App.Features.Login
{
    public class LoginHandle : ICommandHandler<LoginCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly TokenService _tokenService;

        public LoginHandle(IUsuarioRepository usuarioRepository, TokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        public async Task<ICommandResult> Handle(LoginCommand command)
        {
            var usuarioModel = await _usuarioRepository.GetUsuarioLogin(command.Username, command.Password);
            if (usuarioModel == null)
            {
                return new UsuarioResult()
                {
                    Sucesso = false,
                    Mensagem = "Usuário ou senha incorretos. "
                };
            }

            var token = await _tokenService.GenerateToken(usuarioModel);

            return new UsuarioResult()
            {
                Sucesso = true,
                Mensagem = "Token gerado",
                token = token
            };
        }
    }
}
