using FluentValidation;
using Scheduling.DTOs.Cliente;

namespace Scheduling.Validators.Cliente
{
    public class ClienteUpdateDtoValidator : AbstractValidator<ClienteUpdateDto>
    {
        public ClienteUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O Id � obrigat�rio.");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome � obrigat�rio.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O telefone � obrigat�rio.")
                .Matches(@"^\d{10,11}$").WithMessage("O telefone deve conter apenas n�meros e ter 10 ou 11 d�gitos.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId � obrigat�rio.");
        }
    }
}
