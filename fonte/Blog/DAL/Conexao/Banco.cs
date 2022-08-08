using Biblioteca.Parametro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Conexao
{
    public class Banco
    {
        //casa DESKTOP-CFMHUD3 garpe DESKTOP-8T2BFT2
        private static string stringConexao = @"Data Source=DESKTOP-8T2BFT2;Initial Catalog=treinamento;Integrated Security=SSPI;"; // User ID=sa;Password=shell";

        private SqlConnection conexao;

        private SqlTransaction transacaoAtual;

        public Banco()
        {
            conexao = new SqlConnection(stringConexao);
        }

        public SqlConnection FechaConexao()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }

            return conexao;
        }

        public SqlConnection AbreConexao()
        {
            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            return conexao;
        }

        public SqlTransaction IniciarTransacao()
        {
            if (conexao.State == ConnectionState.Open)
            {
                transacaoAtual = conexao.BeginTransaction();
                return transacaoAtual;
            }
            else
                throw new Exception("Não foi possível criar uma transação");
        }

        public void SetCommit()
        {
            transacaoAtual.Commit();
        }

        public void SetAbort()
        {
            transacaoAtual.Rollback();
        }

        public SortedList ExecutarComandoConsulta(SqlCommand comando)
        {
            SortedList Resultado = new SortedList();

            try
            {
                //Abre Conexao com banco
                comando.Connection = AbreConexao();

                //Defino que vai usar stored procedures
                comando.CommandType = CommandType.StoredProcedure;

                //Tempo maximo para execucao do comando no banco de 1 minuto
                comando.CommandTimeout = 60 * 1;

                //Manda executar o comando no banco de dados
                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                //Tabela para guardar o retorno do banco
                DataTable tbRetorno = new DataTable();

                //Coloca os campos do retorno na tabela
                adapter.Fill(tbRetorno);

                if (tbRetorno == null)
                {
                    throw new Exception("A tabela de retorno do comando é nula");
                }
                else
                {
                    //Na consulta se não retornar erro considera sucesso
                    Resultado["Tipo"] = TipoMensagem.Sucesso;
                    Resultado["Mensagem"] = "";
                    Resultado["Retorno"] = tbRetorno;
                }
            }
            catch (SqlException ex)
            {
                //#aqui deve gravar mensagem de erro
                Resultado["Tipo"] = TipoMensagem.Erro;
                Resultado["Mensagem"] = ex.Message;
            }
            finally
            {
                FechaConexao();
            }

            return Resultado;
        }

        public SortedList ExecutarComandoManutencao(SqlCommand comando)
        {
            SortedList Resultado = new SortedList();

            try
            {
                //Abre Conexao com banco
                comando.Connection = AbreConexao();

                //Defino que vai usar stored procedures
                comando.CommandType = CommandType.StoredProcedure;

                //Tempo maximo para execucao do comando no banco de 1 minuto
                comando.CommandTimeout = 60 * 1;

                //Cria uma transacao e atribui
                comando.Transaction = IniciarTransacao();

                //Manda executar o comando no banco de dados
                SqlDataAdapter adapter = new SqlDataAdapter(comando);

                //Tabela para guardar o retorno do banco
                DataTable tbRetorno = new DataTable();

                //Coloca os campos do retorno na tabela
                adapter.Fill(tbRetorno);

                if (tbRetorno == null)
                {
                    throw new Exception("O parametro tabela é nullo");
                }
                else if (tbRetorno.Rows.Count == 0)
                {
                    throw new Exception("A tabela não retornou registros");
                }
                else
                {
                    //Captura retorno do banco
                    string Tipo = UtilBanco.CapturarCampoString(tbRetorno, "CT_TIPO");
                    string Mensagem = UtilBanco.CapturarCampoString(tbRetorno, "CT_MENSAGEM");

                    //O comando deve retornar o campo tipo
                    if (String.IsNullOrEmpty(Tipo))
                        throw new Exception("Não foi possível obter o campo CT_TIPO");

                    //Mensagem
                    Resultado["Tipo"] = Tipo;
                    Resultado["Mensagem"] = Mensagem;
                    Resultado["Retorno"] = tbRetorno;
                }

                //Se o o banco retornou sucesso salva as alterações do banco
                if (UtilParametro.CapturarCampoString(Resultado, "Tipo") == TipoMensagem.Sucesso)
                    SetCommit();
                else
                    SetAbort();
            }
            catch (SqlException ex)
            {
                SetAbort();
                Resultado["Tipo"] = TipoMensagem.Erro;
                Resultado["Mensagem"] = "Erro em Banco.cs: " + ex.Message;
            }
            finally
            {
                FechaConexao();
            }

            return Resultado;
        }
    }
}
