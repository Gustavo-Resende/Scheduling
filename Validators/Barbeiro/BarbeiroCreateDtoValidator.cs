using FluentValidation;
using Scheduling.DTOs.Barbeiro;

namespace Scheduling.Validators.Barbeiro
{
    public class BarbeiroCreateDtoValidator : AbstractValidator<BarbeiroCreateDto>
    {
        public BarbeiroCreateDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome � obrigat�rio.");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento � obrigat�ria.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O telefone � obrigat�rio.")
                .Matches(@"^\d{10,11}$").WithMessage("O telefone deve conter apenas n�meros e ter 10 ou 11 d�gitos.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail � obrigat�rio.")
                .EmailAddress().WithMessage("E-mail inv�lido.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O CPF � obrigat�rio.")
                .Length(11).WithMessage("O CPF deve ter 11 d�gitos.")
                .Must(ValidaCpf).WithMessage("CPF inv�lido.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId � obrigat�rio.");

            RuleFor(x => x.ServicoIds)
                .NotNull().WithMessage("Informe ao menos um servi�o.")
                .Must(s => s.Count > 0).WithMessage("Informe ao menos um servi�o.");
        }
        private bool ValidaCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            // CPFs inv�lidos conhecidos
            string[] invalidos = {
                "00000000000", "11111111111", "22222222222", "33333333333",
                "44444444444", "55555555555", "66666666666", "77777777777",
                "88888888888", "99999999999"
            };
            if (invalidos.Contains(cpf))
                return false;

            // Valida��o do primeiro d�gito
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);
            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            // Valida��o do segundo d�gito
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);
            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return cpf[9] - '0' == digito1 && cpf[10] - '0' == digito2;
        }
    }
}
