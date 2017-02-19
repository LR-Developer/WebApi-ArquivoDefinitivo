using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquivoDefinitivo.Domain.Entities
{
    public class Aluno
    {
        #region Propriedades

        public int Id { get; private set; }

        public string Nome { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public string Rg { get; private set; }

        #endregion Propriedades

        #region Construtores

        protected Aluno()
        {

        }

        #endregion Construtores

        #region Métodos



        #endregion Métodos
    }
}
