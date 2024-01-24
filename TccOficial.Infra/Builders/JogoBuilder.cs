using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Models;

namespace TccOficial.Infra.Builders
{
    public class JogoBuilder : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.HasKey(x => x.JogoId);

            builder.HasMany(x => x.JogoProfessor)
                .WithOne(x => x.Jogo)
                .HasForeignKey(x => x.JogoId);

            builder.HasMany(x => x.PlanoJogos)
                .WithOne(x => x.Jogo)
                .HasForeignKey(x => x.JogoId);

            builder.HasData(new { JogoId = 1, Nome = "Rocket League" },
                            new { JogoId = 2, Nome = "League of Legends (LOL)" },
                            new { JogoId = 3, Nome = "FIFA" },
                            new { JogoId = 4, Nome = "Pro Evolution Soccer (PES)" },
                            new { JogoId = 5, Nome = "CSGO: Counter Strike Global Offenssive" },
                            new { JogoId = 6, Nome = "Dota 2" },
                            new { JogoId = 7, Nome = "Fortnite" },
                            new { JogoId = 8, Nome = "Call of Duty" },
                            new { JogoId = 9, Nome = "Free Fire" },
                            new { JogoId = 10, Nome = "Apex Legends" });
        }
    }

}
