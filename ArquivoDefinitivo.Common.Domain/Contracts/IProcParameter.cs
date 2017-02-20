using System.Data;
using System.Data.Common;

namespace ArquivoDefinitivo.Common.Domain.Contracts
{
    public interface IProcParameter
    {
        string Name { get; set; }
        ParameterDirection Direction { get; set; }
        object Value { get; set; }
        enumParamType ParamType { get; set; }

        DbParameter GetParam();
        void SetValue(object val);
    }

    public enum enumParamType
    {
        Int,
        DecimalNumber,
        Varchar,
        XML,
        Datetime,
        Refcursor
    }
}
