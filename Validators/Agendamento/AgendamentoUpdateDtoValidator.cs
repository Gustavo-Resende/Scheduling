using FluentValidation;
using Scheduling.DTOs.Agendamento;

namespace Scheduling.Validators.Agendamento
{
    public class AgendamentoUpdateDtoValidator : AbstractValidator<AgendamentoUpdateDto>
    {
        public AgendamentoUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("O Id é obrigatório.");

            RuleFor(x => x.Data)
                .NotEmpty().WithMessage("A data é obrigatória.")
                .Must(data => data.Date >= DateTime.Today).WithMessage("A data não pode ser no passado.");

            RuleFor(x => x.Horario)
                .NotEmpty().WithMessage("O horário é obrigatório.");

            RuleFor(x => x.ClienteId)
                .GreaterThan(0).WithMessage("ClienteId é obrigatório.");

            RuleFor(x => x.BarbeiroId)
                .GreaterThan(0).WithMessage("BarbeiroId é obrigatório.");

            RuleFor(x => x.ServicoId)
                .GreaterThan(0).WithMessage("ServicoId é obrigatório.");

            RuleFor(x => x.EmpresaId)
                .GreaterThan(0).WithMessage("EmpresaId é obrigatório.");
        }
    }
}
