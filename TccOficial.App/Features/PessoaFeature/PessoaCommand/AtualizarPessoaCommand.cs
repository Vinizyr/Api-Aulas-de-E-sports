using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Shared.Commands;

namespace TccOficial.App.Features.PessoaFeature.PessoaCommand
{
    public class AtualizarPessoaCommand : ICommand
    {
        public string? PessoaLogada { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Nome precisa estar entre 3 e 30 caracteres. ")]
        public string Nome { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome precisa estar entre 3 e 100 caracteres. ")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória", AllowEmptyStrings = false)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Ter discord é obrigatório. Caso não tenha, crie-o. ", AllowEmptyStrings = false)]
        public string Discord { get; set; }
    }
}
