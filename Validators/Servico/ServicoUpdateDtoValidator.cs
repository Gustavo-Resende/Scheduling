using FluentValidation;
using Scheduling.DTOs.Servico;

namespace Scheduling.Validators.Servico
{
    public class ServicoUpdateDtoValidator : AbstractValidator<ServicoUpdateDto>
    {
        public ServicoUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O Id � obrigat�rio.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A descri��o � obrigat�ria.")
                .MaximumLength(100).WithMessage("A descri��o deve ter no m�ximo 100 caracteres.");

            RuleFor(x => x.Preco)
                .GreaterThan(0).WithMessage("O pre�o deve ser maior que zero.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId � obrigat�rio.");
        }
    }
}
