using APICiaAerea.Contexts;
using APICiaAerea.Entities;
using APICiaAerea.Validators.Piloto;
using APICiaAerea.ViewModels.Piloto;
using FluentValidation;

namespace APICiaAerea.Services
{
    public class PilotoService
    {
        private readonly CiaAreaContext _context;
        private readonly AdicionarPilotoValidator _adicionarPilotoValidator;
        private readonly AtualizarPilotoValidator _atualizarPilotoValidator;
        private readonly ExcluirPilotoValidator _excluirPilotoValidator;

        public PilotoService(
            CiaAreaContext context,
            AdicionarPilotoValidator adicionarPilotoValidator,
            AtualizarPilotoValidator atualizarPilotoValidator,
            ExcluirPilotoValidator excluirPilotoValidator)
        {
            _context = context;
            _adicionarPilotoValidator = adicionarPilotoValidator;
            _atualizarPilotoValidator = atualizarPilotoValidator;
            _excluirPilotoValidator = excluirPilotoValidator;
        }

        public DetalhesPilotoViewModel AdicionarPiloto(AdicionarPilotoViewModel dados)
        {
            _adicionarPilotoValidator.ValidateAndThrow(dados);

            var piloto = new Piloto(dados.Nome, dados.Matricula);

            _context.Add(piloto);
            _context.SaveChanges();

            return new DetalhesPilotoViewModel(piloto.Id, piloto.Nome, piloto.Matricula);
        }

        public IEnumerable<ListarPilotoViewModel> ListarPilotos()
        {
            return _context.Pilotos.Select(p => new ListarPilotoViewModel(p.Id, p.Nome));
        }

        public DetalhesPilotoViewModel? ListarPilotosId(int id)
        {
            var piloto = _context.Pilotos.Find(id);

            if(piloto != null)
            {
                return new DetalhesPilotoViewModel
                (
                    piloto.Id,
                    piloto.Nome,
                    piloto.Matricula
                );
            }

            return null;
        }

        public DetalhesPilotoViewModel? AtualizarPiloto(AtualizarPilotoViewModel dados)
        {
            _atualizarPilotoValidator.ValidateAndThrow(dados);

            var piloto = _context.Pilotos.Find(dados.Id);

            if (piloto != null)
            {
                piloto.Nome = dados.Nome;
                piloto.Matricula = dados.Matricula;

                _context.Pilotos.Update(piloto);
                _context.SaveChanges();

                return new DetalhesPilotoViewModel(piloto.Id, piloto.Nome, piloto.Matricula);
            }

            return null;
        }

        public void ExcluirPiloto(int id)
        {
            _excluirPilotoValidator.ValidateAndThrow(id);

            var piloto = _context.Pilotos.Find(id);

            if (piloto != null)
            {
                _context.Remove(piloto);
                _context.SaveChanges();
            }
        }
    }
}
