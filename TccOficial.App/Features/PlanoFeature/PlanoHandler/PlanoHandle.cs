using TccOficial.App.Features.PlanoFeature.PlanoCommandResult;
using TccOficial.App.Features.PlanoFeature.PlanoCommands;
using TccOficial.Domain.IRepository;
using TccOficial.Domain.Models;
using TccOficial.Shared.Commands;

namespace TccOficial.App.Features.PlanoFeature.PlanoHandler
{
    public class PlanoHandle : ICommandHandler<CreatePlanoCommand>
    {
        private readonly IPlanoRepository _planoRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IJogoRepository _jogoRepository;
        private readonly IPlanoJogoRepository _planoJogoRepository;
        public PlanoHandle(IPlanoRepository planoRepository, IPessoaRepository pessoaRepository, 
            IJogoRepository jogoRepository, IPlanoJogoRepository planoJogoRepository)
        {
            _planoRepository = planoRepository;
            _pessoaRepository = pessoaRepository;
            _jogoRepository = jogoRepository;
            _planoJogoRepository = planoJogoRepository;
        }

        public async Task<ICommandResult> Handle(CreatePlanoCommand command)
        {
            var existe = await _planoRepository.GetByName(command.Nome, command.ProfessorLogado!);
            var jogoExiste = await _jogoRepository.TodosOsJogosExistem(command.Jogos);
            if(jogoExiste == false)
            {
                return new PlanoResult()
                {
                    Sucesso = false,
                    Mensagem = "Algum jogo selecionado não existe na base de dados. "
                };
            }
            if(existe != null)
            {
                return new PlanoResult()
                {
                    Sucesso = false,
                    Mensagem = "Já existe um plano cadastrado com esse nome. "
                };
            }
            else
            {
                var professor = await _pessoaRepository.GetProfessorByUsername(command.ProfessorLogado!);

                var cargaHorariaConvertida = new TimeSpan(int.Parse(command.CargaHoraria.Split(':')[0]),
                                                int.Parse(command.CargaHoraria.Split(':')[1]), 0);

                var duracaoAulaConvertida = new TimeSpan(int.Parse(command.DuracaoAula.Split(':')[0]),
                                                int.Parse(command.DuracaoAula.Split(':')[1]), 0);

                Plano plano = new()
                {
                    Nome = command.Nome,
                    CargaHoraria = cargaHorariaConvertida,
                    DuracaoAula = duracaoAulaConvertida,
                    Preco = command.Preco,
                    Professor = professor,
                    ProfessorId = professor.ProfessorId,
                    
                };

                var games = await _jogoRepository.GetJogos(command.Jogos);
                List<PlanoJogos> listPlanoJogos = new();

                if(games == null || games.Count != command.Jogos.Count)
                {
                    return new PlanoResult()
                    {
                        Sucesso = false,
                        Mensagem = "Algum dos jogos não foram encontrados. "
                    };
                }
                foreach (var game in games)
                {
                    var planoJogo = new PlanoJogos(plano, game);
                    listPlanoJogos.Add(planoJogo);


                }
                _planoJogoRepository.Save(listPlanoJogos);

                //command.Jogos.ForEach(x =>
                //{
                //    var jogo = _jogoRepository.GetJogo(x);
                //    var planoJogo = new PlanoJogos(plano, jogo);

                //    _planoJogoRepository.Save(planoJogo);
                //});

                await _planoRepository.Save(plano);
                return new PlanoResult()
                {
                    Sucesso = true,
                    Mensagem = "Plano criado com sucesso."
                };
            }
        }

        public async Task<ICommandResult> Handle(AtualizaPlanoCommand command)
        {

            var plano = await _planoRepository.GetByIdAndUsername(command.PlanoId, command.ProfessorLogado!);

            plano.PlanoJogo = null!;

            var cargaHorariaConvertida = new TimeSpan(int.Parse(command.CargaHoraria.Split(':')[0]),
                                                int.Parse(command.CargaHoraria.Split(':')[1]), 0);

            var duracaoAulaConvertida = new TimeSpan(int.Parse(command.DuracaoAula.Split(':')[0]),
                                                int.Parse(command.DuracaoAula.Split(':')[1]), 0);

            if(plano == null)
            {
                return new PlanoResult()
                {
                    Sucesso = false,
                    Mensagem = "Plano não encontrado."
                };
            }
            List<PlanoJogos> listPlanoJogos = new();
            var listaJogos = await _jogoRepository.GetJogos(command.Jogos);
            foreach (var game in listaJogos)
            {
                var planoJogo = new PlanoJogos(plano, game);
                listPlanoJogos.Add(planoJogo);
            }

            plano.AtualizaPlano(command.Nome, command.Preco, cargaHorariaConvertida, duracaoAulaConvertida, listPlanoJogos);
            await _planoRepository.Edit(plano);

            return new PlanoResult()
            {
                Sucesso = true,
                Mensagem = "Plano atualizado com sucesso."
            };
        }

        public async Task<ICommandResult> Handle(DeletePlanoCommand command)
        {
            var plano = await _planoRepository.GetByIdAndUsername(command.PlanoId, command.ProfessorLogado!);

            if(plano == null)
            {
                return new PlanoResult()
                {
                    Sucesso = false,
                    Mensagem = "Plano não encontrado. "
                };
            }

            await _planoRepository.Delete(plano);
            return new PlanoResult()
            {
                Sucesso = true,
                Mensagem = "Plano excluído com sucesso. "
            };
        }
    }
}
