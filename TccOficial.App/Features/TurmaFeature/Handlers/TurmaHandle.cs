using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.App.Features.Common;
using TccOficial.App.Features.TurmaFeature.Commands;
using TccOficial.App.Features.TurmaFeature.Result;
using TccOficial.Domain.IRepository;
using TccOficial.Domain.Models;
using TccOficial.Shared.Commands;

namespace TccOficial.App.Features.TurmaFeature.Handlers
{

    public class TurmaHandle : ICommandHandler<GerarTurmaCommand>, 
        ICommandHandler<AdicionaPresencaCommand>
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IHorarioRepository _horarioRepository;
        private readonly IPlanoRepository _planoRepository;
        public TurmaHandle(ITurmaRepository turmaRepository, IPessoaRepository pessoaRepository, 
            IHorarioRepository horarioRepository, IPlanoRepository planoRepository)
        {
            _turmaRepository = turmaRepository;
            _pessoaRepository = pessoaRepository;
            _horarioRepository = horarioRepository;
            _planoRepository = planoRepository;
        }

        public async Task<ICommandResult> Handle(GerarTurmaCommand command)
        {
            var aluno = await _pessoaRepository.GetPessoaByUsername(command.AlunoLogado!);
            if(aluno == null)
            {
                return new TurmaCommandResult()
                {
                    Sucesso = false,
                    Mensagem = "O aluno deve estar logado. "
                };  
            }
            
            //Testa se turma já existe
            var turmaExiste = await _turmaRepository.GetTurmaExist(command.AlunoLogado!, command.PlanoId, command.ProfessorId);
            if (turmaExiste)
            {
                return new TurmaCommandResult()
                {
                    Sucesso = false,
                    Mensagem = "O Aluno já faz parte de uma turma deste plano. "
                };
            }


            var contadorDatas = DateTime.Now.Date;

            // Calculando a diferença entre o dia da semana atual e o dia desejado
            int diferencaDias = command.Horarios.First().Dia - (int)contadorDatas.DayOfWeek;

            DateTime dataCorreta = DateTime.Now;
            var turma = new Turma()
            {
                AlunoId = aluno.PessoaId,
                PlanoId = command.PlanoId,
                ProfessorId = command.ProfessorId,
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now //Somente para inicializar
            };

            //recupera plano
            var plano = await _planoRepository.GetById(command.PlanoId);

            //Inicia a variavel que vai acumular as horas até chegar na mesma quantidade da carga horária do curso
            var contadorHoras = TimeSpan.FromMinutes(0);
          
            var tamanho = command.Horarios.Count() - 1;
            var index = 0;
            while (plano.CargaHoraria > contadorHoras)
            {
                var horarioRequet = command.Horarios[index];

                //converte a string para timeSpan
                var horaInicioConvertido = new TimeSpan(int.Parse(horarioRequet.HoraInicio.Split(':')[0]),
                                                    int.Parse(horarioRequet.HoraInicio.Split(':')[1]), 0);

                var horaFimConvertido = new TimeSpan(int.Parse(horarioRequet.HoraFim.Split(':')[0]),
                                                    int.Parse(horarioRequet.HoraFim.Split(':')[1]), 0);

                var minutosDeAulaRequest = horaFimConvertido - horaInicioConvertido;
                contadorHoras += minutosDeAulaRequest;
                if (minutosDeAulaRequest > plano.DuracaoAula)
                {
                    return new TurmaCommandResult()
                    {
                        Sucesso = false,
                        Mensagem = "O horário escolhido é maior que a duração da aula"

                    };
                }
                if (minutosDeAulaRequest < plano.DuracaoAula)
                {
                    return new TurmaCommandResult()
                    {
                        Sucesso = false,
                        Mensagem = "O horário escolhido é menor que a duração da aula"
                    };
                }

                var horariosProfessor = await _horarioRepository
                    .GetHorarioDisponivel(command.ProfessorId, horaInicioConvertido, horaFimConvertido, horarioRequet.Dia);

                if (horariosProfessor != null)
                {
                    //vai gerar todas as frequências até que os horários acumulados seja igual a carga horária do curso
                    dataCorreta = dataCorreta.Next((DayOfWeek)horarioRequet.Dia);
                    var frequencia = new Frequencia()
                    {
                        DataAula = dataCorreta,
                        HoraInicio = horaInicioConvertido,
                        HoraFim = horaFimConvertido,
                        Presenca = false,
                        Turma = turma
                    };
                    //turma.DataInicio =     
                    turma.DataFim = dataCorreta;
                    
                    
                    turma.Frequencia.Add(frequencia);


                }
                else
                {
                    return new TurmaCommandResult()
                    {
                        Sucesso = false,
                        Mensagem = "Não existe esse horário. Horário ocupado."
                    };
                }

                index++;
                if(index > tamanho)
                {
                    index = 0;

                }
                if (contadorHoras >= plano.CargaHoraria)
                {
                    horariosProfessor.EstaDisponivel = false;
                }

            }

            await _turmaRepository.SaveTurma(turma);

            return new TurmaCommandResult()
            {
                Sucesso = true,
                Mensagem = "Turma e frequencias geradas com sucesso"
            };

        }

        public async Task<ICommandResult> Handle(AdicionaPresencaCommand command)
        {
            //Busca a frequenciaId
            var frequencia = await _turmaRepository.GetFrequenciaById(command.FrequenciaId);

            if (frequencia == null)
            {
                return new TurmaCommandResult()
                {
                    Sucesso = false,
                    Mensagem = "Frequencia não encontrada. "
                };
            }

            if(frequencia.DataAula <= DateTime.Now.Date)
            {
                frequencia.Presenca = true;
                await _turmaRepository.Update(frequencia);
                return new TurmaCommandResult()
                {
                    Sucesso = true,
                    Mensagem = "Presença confirmada. "
                };
            }
            else
            {
                return new TurmaCommandResult()
                {
                    Sucesso = false,
                    Mensagem = "Não é permitido adicionar presença em dia diferente a aula. "
                };
            }
        }
    }
}
