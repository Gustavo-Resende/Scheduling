using FluentValidation;
using Scheduling.DTOs.Barbeiro;

namespace Scheduling.Validators.Barbeiro
{
    public class BarbeiroUpdateDtoValidator : AbstractValidator<BarbeiroUpdateDto>
    {
        public BarbeiroUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O Id � obrigat�rio.");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome � obrigat�rio.");

            RuleFor(x => x.Status)
                .NotNull().WithMessage("O status � obrigat�rio.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId � obrigat�rio.");

            RuleFor(x => x.ServicoIds)
                .NotNull().WithMessage("Informe ao menos um servi�o.")
                .Must(s => s.Count > 0).WithMessage("Informe ao menos um servi�o.");
        }
    }
}
