using FluentValidation;
using Scheduling.DTOs.Barbeiro;

namespace Scheduling.Validators.Barbeiro
{
    public class BarbeiroCreateDtoValidator : AbstractValidator<BarbeiroCreateDto>
    {
        public BarbeiroCreateDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\d{10,11}$").WithMessage("O telefone deve conter apenas números e ter 10 ou 11 dígitos.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Length(11).WithMessage("O CPF deve ter 11 dígitos.")
                .Must(ValidaCpf).WithMessage("CPF inválido.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId é obrigatório.");

            RuleFor(x => x.ServicoIds)
                .NotNull().WithMessage("Informe ao menos um serviço.")
                .Must(s => s.Count > 0).WithMessage("Informe ao menos um serviço.");
        }
        private bool ValidaCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            // CPFs inválidos conhecidos
            string[] invalidos = {
                "00000000000", "11111111111", "22222222222", "33333333333",
                "44444444444", "55555555555", "66666666666", "77777777777",
                "88888888888", "99999999999"
            };
            if (invalidos.Contains(cpf))
                return false;

            // Validação do primeiro dígito
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);
            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            // Validação do segundo dígito
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);
            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return cpf[9] - '0' == digito1 && cpf[10] - '0' == digito2;
        }
    }
}
