using System;
using FluentValidation;
using Prova.MedGrupo.Domain.Entities;
using Prova.MedGrupo.Resources;

namespace Prova.MedGrupo.Domain.Validations
{
    public class ContatoValidator : AbstractValidator<Contato>
    {
        public ContatoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage(TextResource.NomeInvalido)
                .MinimumLength(3)
                .WithMessage(TextResource.NomeInvalido)
                .MaximumLength(128)
                .WithMessage(TextResource.NomeInvalido);

            RuleFor(x => x.DataNascimento)
            .NotEqual(DateTime.MinValue)
            .WithMessage(string.Format(TextResource.DataNascimentoInvalida, DateTime.Now.ToString("dd/MM/yyyy")))
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage(string.Format(TextResource.DataNascimentoInvalida, DateTime.Now.ToString("dd/MM/yyyy")));
        }
    }
}