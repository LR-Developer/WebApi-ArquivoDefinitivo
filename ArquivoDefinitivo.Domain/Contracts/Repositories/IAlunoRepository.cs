using ArquivoDefinitivo.Common.Domain.Contracts;
using ArquivoDefinitivo.Domain.Entities;
using ArquivoDefinitivo.Domain.Filters;
using System.Collections.Generic;

namespace ArquivoDefinitivo.Domain.Contracts
{
    public interface IAlunoRepository : IRepositoryReadOnly<Aluno>
    {
        IEnumerable<Aluno> ConsultarAluno(ConsultarAlunoFilter filter);
    }
}
