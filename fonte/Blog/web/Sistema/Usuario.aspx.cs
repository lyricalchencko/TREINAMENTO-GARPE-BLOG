using Biblioteca.Parametro;
using BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Sistema
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Filtrar();
            }

            if (AreaMensagem.Visible)
            {
                AreaMensagem.Visible = false;
            }
        }

        protected void Filtrar()
        {
            AreaFiltro.Visible = true;
            AreaConsulta.Visible = true;
            AreaDados.Visible = false;

            SortedList Parametros = new SortedList();
            SortedList Resultado = new SortedList();

            //FILTRAR
            Parametros["NM_USUARIO"] = NM_USUARIO_FILTRO.Text;
            Parametros["DS_EMAIL"] = DS_EMAIL_FILTRO.Text;
            Parametros["SQ_USUARIO"] = SQ_USUARIO_FILTRO.Text;

            //Faz a consulta no banco
            UsuarioBLL Usuario = new UsuarioBLL();
            Resultado = Usuario.Consultar(Parametros);

            //Processa o resultado

            string Tipo = Resultado["Tipo"].ToString();


            if (Tipo == "Sucesso")
            {
                DataTable Retorno = (DataTable)Resultado["Retorno"];

                GdvConsulta.DataSource = Retorno;
                GdvConsulta.DataBind();
            }
            else if (Tipo == "Aviso")
            {
                MensagemErro.Text = Resultado["Mensagem"].ToString();
            }
        }
        protected void BtnFiltrar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        protected void BtnNovo_Click(object sender, EventArgs e)
        {
            AreaFiltro.Visible = false;
            AreaConsulta.Visible = false;
            AreaDados.Visible = true;

            NM_USUARIO.Text = "";
            DS_EMAIL.Text = "";
            DS_SENHA.Text = "";

        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        protected void BtnIncluir_Click(object sender, EventArgs e)
        {
            SortedList Parametros = new SortedList();
            SortedList Resultado = new SortedList();

            Parametros["NM_USUARIO"] = NM_USUARIO.Text;
            Parametros["DS_EMAIL"] = DS_EMAIL.Text;
            Parametros["DS_SENHA"] = DS_SENHA.Text;

            //Faz a consulta no banco
            UsuarioBLL Usuario = new UsuarioBLL();
            Resultado = Usuario.Incluir(Parametros);

            //Processa o resultado

            string Tipo = Resultado["Tipo"].ToString();


            if (Tipo == "Sucesso")
            {
                Filtrar();
            }
            else if (Tipo == "Aviso")
            {
                MensagemErro.Text = Resultado["Mensagem"].ToString();
                AreaMensagem.Visible = true;
            }
            else
            {
                MensagemErro.Text = Resultado["Mensagem"].ToString();
            }
        }

        protected void BotaoAlterarUsuario_Click(object sender, EventArgs e)
        {
            Button BotaoAlterar = (Button)sender;

            SortedList Parametros = new SortedList();

            Parametros["SQ_USUARIO"] = BotaoAlterar.CommandArgument;

            Detalhar(Parametros);
        }

        protected void Detalhar(SortedList Parametros)
        {
            AreaDados.Visible = true;
            AreaFiltro.Visible = false;
            AreaConsulta.Visible = false;

            SortedList Resultado = new SortedList();

            UsuarioBLL Usuario = new UsuarioBLL();
            Resultado = Usuario.Consultar(Parametros);

            if (Resultado["Tipo"].ToString() == "Sucesso")
            {
                DataTable TabelaResultado = (DataTable)Resultado["Retorno"];

                NM_USUARIO.Text = (String)TabelaResultado.Rows[0]["NM_USUARIO"];
                DS_EMAIL.Text = (String)TabelaResultado.Rows[0]["DS_EMAIL"];
                DS_SENHA.Text = (String)TabelaResultado.Rows[0]["DS_SENHA"];
            }

        }

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            Button BtnAlterar = (Button)sender;
            SortedList Parametros = new SortedList();

            Parametros["SQ_USUARIO"] = BtnAlterar.CommandArgument;
            Parametros["NM_USUAIO"] = NM_USUARIO.Text;
            Parametros["DS_EMAIL"] = DS_EMAIL.Text;
            Parametros["DS_SENHA"] = DS_SENHA.Text;

            Alterar(Parametros);

        }

        protected void Alterar(SortedList Parametros)
        {
            SortedList Resultado = new SortedList();

            UsuarioBLL Usuario = new UsuarioBLL();
            Resultado = Usuario.Consultar(Parametros);

            if (Resultado["Tipo"].ToString() == "Sucesso")
            {
                Usuario.Alterar(Parametros);
            }
        }
    }
}