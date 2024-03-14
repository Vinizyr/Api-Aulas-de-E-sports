using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Shared.Commands;

namespace TccOficial.App.Features.PlanoFeature.PlanoCommands
{
    public class CreatePlanoCommand : ICommand
    {
        public string? ProfessorLogado { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Nome do plano precisa estar entre 3 e 30 caracteres. ")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório. ")] public float Preco { get; set; }
        [Required(ErrorMessage = "Campo obrigatório. ")] public string CargaHoraria { get; set; }
        [Required(ErrorMessage = "Campo obrigatório. ")] public string DuracaoAula { get; set; }
        [Required(ErrorMessage = "Campo obrigatório. ")] public List<int> Jogos { get; set; }

        
    }
}
