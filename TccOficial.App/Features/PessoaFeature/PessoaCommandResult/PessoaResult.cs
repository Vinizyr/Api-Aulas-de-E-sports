﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Shared.Commands;

namespace TccOficial.App.Features.PessoaFeature.PessoaCommandResult
{
    public class PessoaResult : ICommandResult
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
    }
}
