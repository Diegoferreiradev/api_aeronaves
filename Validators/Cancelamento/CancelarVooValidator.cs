using APICiaAerea.Contexts;
using APICiaAerea.ViewModels.Cancelamento;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace APICiaAerea.Validators.Cancelamento
{
    public class CancelarVooValidator : AbstractValidator<CancelarVooViewModel>
    {
        private CiaAreaContext _context;

        public CancelarVooValidator(CiaAreaContext context)
        {
            _context = context;

            RuleFor(c => c).Custom((cancelamento, validationContext) => {
                var voo = _context.Voos.Include(v => v.Cancelamento)
                                       .FirstOrDefault(v => v.Id == cancelamento.VooId);

                if (voo == null)
                {
                    validationContext.AddFailure("Id do voo inválidao!");
                }
                else
                {
                    if (voo.Cancelamento != null)
                    {
                        validationContext.AddFailure("Não é possível cancelar um voo que já foi cancelado.");
                    }

                    if (voo.DataHoraPartida <= DateTime.Now && voo.DataHoraChegada >= DateTime.Now)
                    {
                        validationContext.AddFailure("Não é possível cancelar um voo em andamento.");
                    }

                    if (voo.DataHoraChegada <= DateTime.Now)
                    {
                        validationContext.AddFailure("Não é possível cancelar um voo já finalizado!");
                    }
                }
            });
        }
    }
}
