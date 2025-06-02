using FluentValidation;
using Scheduling.DTOs.Agendamento;

namespace Scheduling.Validators.Agendamento
{
    public class AgendamentoUpdateDtoValidator : AbstractValidator<AgendamentoUpdateDto>
    {
        public AgendamentoUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O Id � obrigat�rio.");

            RuleFor(x => x.Data)
                .NotEmpty().WithMessage("A data � obrigat�ria.")
                .Must(data => data.Date >= DateTime.Today).WithMessage("A data n�o pode ser no passado.");

            RuleFor(x => x.Horario)
                .NotEmpty().WithMessage("O hor�rio � obrigat�rio.");

            RuleFor(x => x.ClienteId)
                .GreaterThan(0).WithMessage("ClienteId � obrigat�rio.");

            RuleFor(x => x.BarbeiroId)
                .GreaterThan(0).WithMessage("BarbeiroId � obrigat�rio.");

            RuleFor(x => x.ServicoId)
                .GreaterThan(0).WithMessage("ServicoId � obrigat�rio.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId � obrigat�rio.");
        }
    }
}
