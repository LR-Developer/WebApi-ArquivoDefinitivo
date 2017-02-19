using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquivoDefinitivo.Domain.DTO
{
    public class AlunoDto
    {
        #region Propriedades

        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Rg { get; private set; }

        #endregion
    }
}
