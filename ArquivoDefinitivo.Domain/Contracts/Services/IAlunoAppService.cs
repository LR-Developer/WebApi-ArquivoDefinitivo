using ArquivoDefinitivo.Domain.DTO;
using ArquivoDefinitivo.Domain.Filters;
using System;

namespace ArquivoDefinitivo.Domain.Contracts.Services
{
    public interface IAlunoAppService : IDisposable
    {
        ConsultarAlunoDto ConsultarAluno(ConsultarAlunoFilter filter);
    }
}
