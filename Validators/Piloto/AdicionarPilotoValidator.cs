﻿using APICiaAerea.Contexts;
using APICiaAerea.ViewModels.Piloto;
using FluentValidation;

namespace APICiaAerea.Validators.Piloto
{
    public class AdicionarPilotoValidator : AbstractValidator<AdicionarPilotoViewModel>
    {
        private readonly CiaAreaContext _context;

        public AdicionarPilotoValidator(CiaAreaContext context)
        {
            _context = context;

            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("É necessário informar o nome do piloto.")
                .MaximumLength(100).WithMessage("O nome do piloto deve ter no máximo 100 caracteres.");

            RuleFor(p => p.Matricula)
                .NotEmpty().WithMessage("É necessário informar a matrícula do piloto.")
                .MaximumLength(10).WithMessage("A matrícula do piloto deve ter no máximo 10 caracteres.")
                .Must(matricula => _context.Pilotos.Count(p => p.Matricula == matricula) == 0).WithMessage("Já existe um piloto com essa matrícula.");
        }
    }
}
