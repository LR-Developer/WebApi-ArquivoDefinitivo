using ArquivoDefinitivo.Domain.Filters;
using FluentValidation;

namespace ArquivoDefinitivo.Domain.Validators
{
    public class ConsultarAlunoValidator : AbstractValidator<ConsultarAlunoFilter>
    {
        public ConsultarAlunoValidator()
        {
            Validar();
        }

        private void Validar()
        {

        }
    }
}
