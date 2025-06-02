using FluentValidation;
using Scheduling.DTOs.Cliente;

namespace Scheduling.Validators.Cliente
{
    public class ClienteUpdateDtoValidator : AbstractValidator<ClienteUpdateDto>
    {
        public ClienteUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O Id é obrigatório.");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\d{10,11}$").WithMessage("O telefone deve conter apenas números e ter 10 ou 11 dígitos.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId é obrigatório.");
        }
    }
}
