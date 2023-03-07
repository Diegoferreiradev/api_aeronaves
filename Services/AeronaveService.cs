using APICiaAerea.Contexts;
using APICiaAerea.Entities;
using APICiaAerea.Validators.Aeronave;
using APICiaAerea.ViewModels.Aeronave;
using FluentValidation;

namespace APICiaAerea.Services
{
    public class AeronaveService
    {
        private readonly CiaAreaContext _context;
        private readonly AdicionarAeronaveValidator _adicionarAeronaveValidator;
        private readonly AtualizarAeronaveValidator _atualizarAeronaveValidator;
        private readonly ExcluirAeronaveValidator _excluirAeronaveValidator;

        public AeronaveService(
            CiaAreaContext context,
            AdicionarAeronaveValidator adicionarAeronaveValidator,
            AtualizarAeronaveValidator atualizarAeronaveValidator,
            ExcluirAeronaveValidator excluirAeronaveValidator)
        {
            _context = context;
            _adicionarAeronaveValidator = adicionarAeronaveValidator;
            _atualizarAeronaveValidator = atualizarAeronaveValidator;
            _excluirAeronaveValidator = excluirAeronaveValidator;
        }

        public DetalhesAeronaveViewModel Adicionar(AdicionarAeronaveViewModel dados)
        {
            _adicionarAeronaveValidator.ValidateAndThrow(dados);

            var aeronave = new Aeronave(dados.Fabricante, dados.Modelo, dados.Codigo);
            
            _context.Add(aeronave);
            _context.SaveChanges();

            return new DetalhesAeronaveViewModel(aeronave.Id, aeronave.Fabricante, aeronave.Modelo, aeronave.Codigo);
        }

        public IEnumerable<ListarAeronaveViewModel> ListarAeronaves()
        {
            return _context.Aeronaves.Select(a => new ListarAeronaveViewModel(a.Id, a.Modelo, a.Codigo));
        }

        public DetalhesAeronaveViewModel? ListarAeronaveId(int id)
        {
            var aeronave = _context.Aeronaves.Find(id);

            if (aeronave != null)
            {
                return new DetalhesAeronaveViewModel
                (
                    aeronave.Id,
                    aeronave.Modelo,
                    aeronave.Codigo,
                    aeronave.Fabricante
                );
            }

            return null;
        }

        public DetalhesAeronaveViewModel? AtualizarAeronave(AtualizarAeronaveViewModel dados)
        {
            _atualizarAeronaveValidator.ValidateAndThrow(dados);

            var aeronave = _context.Aeronaves.Find(dados.Id);
            if (aeronave != null)
            {
                aeronave.Fabricante = dados.Fabricante;
                aeronave.Codigo = dados.Codigo;
                aeronave.Modelo = dados.Modelo;

                _context.Update(aeronave);
                _context.SaveChanges();

                return new DetalhesAeronaveViewModel(aeronave.Id, aeronave.Fabricante, aeronave.Modelo, aeronave.Codigo);
            }
            return null;
        }

        public void ExcluirAeronave(int id)
        {
            _excluirAeronaveValidator.ValidateAndThrow(id);

            var aeronave = _context.Aeronaves.Find(id);
            if (aeronave != null)
            {
                _context.Remove(aeronave);
                _context.SaveChanges();
            }
        }
    }
}
