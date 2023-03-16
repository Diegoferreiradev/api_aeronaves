using APICiaAerea.Contexts;
using APICiaAerea.ViewModels.Manutencao;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace APICiaAerea.Validators.Manutencao
{
    public class AtualizarManutencaoValidator : AbstractValidator<AtualizarManutencaoViewModel>
    {
        private readonly CiaAreaContext _context;

        public AtualizarManutencaoValidator(CiaAreaContext context)
        {
            _context = context;

            RuleFor(m => m.DataHora)
                .NotEmpty().WithMessage("A data/hora da manutenção deve ser informada.");

            RuleFor(m => m.Tipo)
                .NotNull().WithMessage("O tipo da manutenção de ser informada.");

            RuleFor(m => m).Custom((manutencao, validationContext) => {
                var aeronave = _context.Aeronaves.Include(a => a.Voos)
                                                 .FirstOrDefault(a => a.Id == manutencao.AeronaveId);

                if (aeronave == null)
                {
                    validationContext.AddFailure("");
                }
                else
                {
                    var emVoo = aeronave.Voos.Any(v => v.DataHoraPartida <= manutencao.DataHora && v.DataHoraChegada >= manutencao.DataHora);

                    if (emVoo)
                    {
                        validationContext.AddFailure("A aeronave selecionada estará em voo neste horário.");
                    }
                }
            });
        }
    }
}
