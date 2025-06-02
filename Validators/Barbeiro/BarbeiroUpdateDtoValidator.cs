using FluentValidation;
using Scheduling.DTOs.Barbeiro;

namespace Scheduling.Validators.Barbeiro
{
    public class BarbeiroUpdateDtoValidator : AbstractValidator<BarbeiroUpdateDto>
    {
        public BarbeiroUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O Id é obrigatório.");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.");

            RuleFor(x => x.Status)
                .NotNull().WithMessage("O status é obrigatório.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId é obrigatório.");

            RuleFor(x => x.ServicoIds)
                .NotNull().WithMessage("Informe ao menos um serviço.")
                .Must(s => s.Count > 0).WithMessage("Informe ao menos um serviço.");
        }
    }
}
