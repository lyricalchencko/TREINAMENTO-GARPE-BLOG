using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Parametro
{
    public static class UtilBanco
    {
        public static string CapturarCampoString(DataTable table, string chave)
        {
            string valor = String.Empty;

            if (table != null)
            {
                if (table.Rows.Count > 0)
                    valor = CapturarCampoString(table.Rows[0], chave);
            }

            return valor;
        }

        public static string CapturarCampoString(DataRow linha, string chave)
        {
            string valor = String.Empty;

            if (linha != null)
            {
                if (linha.Table.Columns.Contains(chave))
                {
                    valor = Convert.ToString(linha[chave]);
                }
            }

            return valor;
        }

        public static bool CapturarCampoDateTime(DataTable table, string chave, ref DateTime resultado)
        {
            bool executouComSucesso = false;

            if (table != null)
            {
                if (table.Rows.Count > 0)
                    executouComSucesso = CapturarCampoDateTime(table.Rows[0], chave, ref resultado);
            }

            return executouComSucesso;
        }

        public static bool CapturarCampoDateTime(DataRow linha, string chave, ref DateTime resultado)
        {
            bool executouComSucesso = false;

            if (linha != null)
            {
                if (linha.Table.Columns.Contains(chave))
                {
                    string dataTemp = Convert.ToString(linha[chave]);

                    executouComSucesso = DateTime.TryParse(dataTemp, out resultado);
                }
            }

            return executouComSucesso;
        }
    }
}
