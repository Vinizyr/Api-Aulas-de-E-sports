using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccOficial.Domain.Enums
{
    public enum ETipoPerfil
    {
        [Display(Name = "Aluno")]
        Aluno = 1,

        [Display(Name = "Professor")]
        Professor = 2,

        [Display(Name = "Administrador")]
        Adm = 3

    }
}
