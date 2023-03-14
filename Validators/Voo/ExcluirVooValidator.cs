using APICiaAerea.Contexts;
using FluentValidation;

namespace APICiaAerea.Validators.Voo
{
    public class ExcluirVooValidator : AbstractValidator<int>
    {
       private readonly CiaAreaContext _context;

        public ExcluirVooValidator(CiaAreaContext context)
        {
            _context = context;

            RuleFor(id => _context.Voos.Find(id))
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Id de voo inválido.")
                .Must(voo => voo!.DataHoraChegada >= DateTime.Now).WithMessage("Não é possível excluir um voo já finalizado.");
        }
    }
}
