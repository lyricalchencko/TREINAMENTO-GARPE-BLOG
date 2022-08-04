using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Parametro
{
    public static class UtilParametro
    {
        public static SqlParameter CapturarParametroSql(SortedList Lista, string Chave, bool retornarNull)
        {
            string valor = CapturarCampoString(Lista, Chave);

            if (String.IsNullOrEmpty(valor) && retornarNull)
                valor = null;

            return new SqlParameter("@" + Chave, valor);
        }

        public static string CapturarCampoString(SortedList Lista, string Chave)
        {
            string valor = String.Empty;

            if (Lista != null)
            {
                if (Lista.ContainsKey(Chave))
                    valor = Convert.ToString(Lista[Chave]);
            }

            return valor;
        }
    }
}
