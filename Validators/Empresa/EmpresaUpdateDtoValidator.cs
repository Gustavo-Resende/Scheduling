using FluentValidation;
using Scheduling.DTOs.Empresa;

namespace Scheduling.Validators.Empresa
{
    public class EmpresaUpdateDtoValidator : AbstractValidator<EmpresaUpdateDto>
    {
        public EmpresaUpdateDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\d{10,11}$").WithMessage("O telefone deve conter apenas números e ter 10 ou 11 dígitos.");

            RuleFor(x => x.Endereco)
                .NotEmpty().WithMessage("O endereço é obrigatório.");
        }
    }
}
