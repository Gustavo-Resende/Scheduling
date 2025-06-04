using FluentValidation;
using Scheduling.DTOs.Servico;

namespace Scheduling.Validators.Servico
{
    public class ServicoUpdateDtoValidator : AbstractValidator<ServicoUpdateDto>
    {
        public ServicoUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O Id é obrigatório.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .MaximumLength(100).WithMessage("A descrição deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Preco)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId é obrigatório.");
        }
    }
}
