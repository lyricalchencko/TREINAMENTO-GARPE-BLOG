using Biblioteca.Parametro;
using DAL.Conexao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL : Banco
    {
        public SortedList Incluir(SortedList registros)
        {
            SortedList Resultado = new SortedList();

            try
            {
                SqlCommand comando = new SqlCommand("STP_USUARIO_INCLUIR");

                comando.Parameters.Add(UtilParametro.CapturarParametroSql(registros, "NM_USUARIO", false));
                comando.Parameters.Add(UtilParametro.CapturarParametroSql(registros, "DS_EMAIL", false));
                comando.Parameters.Add(UtilParametro.CapturarParametroSql(registros, "DS_SENHA", false));

                Resultado = ExecutarComandoManutencao(comando);
            }
            catch (SqlException ex)
            {
                Resultado["Tipo"] = TipoMensagem.Erro;
                Resultado["Mensagem"] = ex.Message;
            }

            return Resultado;
        }

        public SortedList Consultar(SortedList Parametros)
        {
            SortedList Resultado = new SortedList();

            try
            {
                SqlCommand Comando = new SqlCommand("STP_USUARIO_CONSULTAR");

                Comando.Parameters.Add(UtilParametro.CapturarParametroSql(Parametros, "SQ_USUARIO", false));
                Comando.Parameters.Add(UtilParametro.CapturarParametroSql(Parametros, "NM_USUARIO", false));
                Comando.Parameters.Add(UtilParametro.CapturarParametroSql(Parametros, "DS_EMAIL", false));

                Resultado = ExecutarComandoConsulta(Comando);
            }
            catch (SqlException erro)
            {
                Resultado["Tipo"] = TipoMensagem.Erro;
                Resultado["Mensagem"] = "Erro encontrado: " + erro.Message;
            }

            return Resultado;
        }

        public SortedList Alterar(SortedList Parametros)
        {
            SortedList Resultado = new SortedList();

            try
            {
                SqlCommand Comando = new SqlCommand("STP_USUARIO_ALTERAR");

                Comando.Parameters.Add(UtilParametro.CapturarParametroSql(Parametros, "SQ_USUARIO", false));
                Comando.Parameters.Add(UtilParametro.CapturarParametroSql(Parametros, "NM_USUARIO", false));
                Comando.Parameters.Add(UtilParametro.CapturarParametroSql(Parametros, "DS_EMAIL", false));
                Comando.Parameters.Add(UtilParametro.CapturarParametroSql(Parametros, "DS_SENHA", false));

                Resultado = ExecutarComandoManutencao(Comando);
            }
            catch(Exception Erro)
            {
                Resultado["Tipo"] = TipoMensagem.Erro;
                Resultado["Mensagem"] = "Erro encontrado: " + Erro.Message;
            }
            return Resultado;
        }
    }
}



