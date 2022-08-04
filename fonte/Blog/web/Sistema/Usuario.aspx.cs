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

    }
}