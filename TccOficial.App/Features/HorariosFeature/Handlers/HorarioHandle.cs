using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.App.Features.HorariosFeature.Commands;
using TccOficial.App.Features.HorariosFeature.HorarioResult;
using TccOficial.Domain.IRepository;
using TccOficial.Domain.Models;
using TccOficial.Shared.Commands;

namespace TccOficial.App.Features.HorariosFeature.Handlers
{
    public class HorarioHandle : ICommandHandler<AdicionaHorarioCommand>
    {
        private readonly IHorarioRepository _horarioRepository;
        private readonly IPessoaRepository _pessoaRepository;
        public HorarioHandle(IHorarioRepository horarioRepository, IPessoaRepository pessoaRepository)
        {
            _horarioRepository = horarioRepository;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<ICommandResult> Handle(AdicionaHorarioCommand command)
        {
            var novaHoraInicio = new TimeSpan(int.Parse(command.HoraInicio.Split(':')[0]),
                                                int.Parse(command.HoraInicio.Split(':')[1]), 0);
            var novaHoraFim = new TimeSpan(int.Parse(command.HoraFim.Split(':')[0]),
                                                int.Parse(command.HoraFim.Split(':')[1]), 0);

            var professor = await _pessoaRepository.GetProfessorByUsername(command.professorLogado!);

            var sobreposicao = await _horarioRepository.GetHorarios(novaHoraInicio, novaHoraFim, command.professorLogado!, command.DiaSemana);

            if(sobreposicao == null)
            {
                var horario = new Horario()
                {
                    HoraInicial = novaHoraInicio,
                    HoraFinal = novaHoraFim,
                    DiaDaSemana = command.DiaSemana,
                    ProfessorId = professor.ProfessorId,
                    EstaDisponivel = true
                };
                await _horarioRepository.AdicionaHorario(horario);
                return new HorarioCommandResult()
                {
                    Sucesso = true,
                    Mensagem = "Horário adicionado com sucesso. "
                };
                
            }
            else
            {
                return new HorarioCommandResult()
                {
                    Sucesso = false,
                    Mensagem = "Existe sobreposição de horários. "
                };
            }

        }
    }
}
