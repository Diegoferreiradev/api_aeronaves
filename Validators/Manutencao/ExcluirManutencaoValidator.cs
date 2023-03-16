using APICiaAerea.Contexts;
using FluentValidation;

namespace APICiaAerea.Validators.Manutencao
{
    public class ExcluirManutencaoValidator : AbstractValidator<int>
    {
        private readonly CiaAreaContext _context;

        public ExcluirManutencaoValidator(CiaAreaContext context)
        {
            _context = context;

            RuleFor(id => _context.Manutencoes.Find(id))
                 .Cascade(CascadeMode.Stop)
                 .NotNull().WithMessage("Id da manutenção inválido.")
                 .Must(manutencao => manutencao!.DataHora > DateTime.Now).WithMessage("Não é possível excluir uma manutenção já realizada.");
        }
    }
}
