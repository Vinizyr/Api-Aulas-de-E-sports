using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TccOficial.Domain.Enums;
using TccOficial.Shared.Commands;

namespace TccOficial.App.Features.PessoaFeature.PessoaCommand
{
    public class CreatePessoaCommand : ICommand
    {

        // DTO Pessoa
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Nome precisa estar entre 3 e 30 caracteres. ")]
        public string Nome { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome precisa estar entre 3 e 100 caracteres. ")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória", AllowEmptyStrings = false)]
        public DateTime DataNascimento { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "Cpf deve ter 11 caracteres. ")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Ter discord é obrigatório. Caso não tenha, crie-o. ", AllowEmptyStrings = false)]
        public string Discord { get; set; }

        [Required(ErrorMessage = "Informe o seu sexo.", AllowEmptyStrings = false)]
        public ESexo Sexo { get; set; }


        // Command Usuário
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Username precisa estar entre 8 e 30 caracteres. ")]
        [Required(ErrorMessage = "Username é obrigatório", AllowEmptyStrings = false)]
        public string Username { get; set; }

        [StringLength(20, MinimumLength = 8, ErrorMessage = "Username precisa estar entre 8 e 20 caracteres. ")]
        [Required(ErrorMessage = "Password é obrigatório", AllowEmptyStrings = false)]
        public string Password { get; set; }

        // Command Perfil
        [Required(ErrorMessage = "Escolha o tipo de perfil que deseja ter. ", AllowEmptyStrings = false)]
        public string TipoPerfil { get; set; }

        // Command Professor 
        public string? NomeCanalYoutube { get; set; }
    }
}
