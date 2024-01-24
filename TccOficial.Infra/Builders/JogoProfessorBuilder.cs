using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Models;

namespace TccOficial.Infra.Builders
{
    public class JogoProfessorBuilder : IEntityTypeConfiguration<JogoProfessor>
    {
        public void Configure(EntityTypeBuilder<JogoProfessor> builder)
        {
            builder.HasKey(x => new { x.JogoId, x.ProfessorId });
        }
    }
}
