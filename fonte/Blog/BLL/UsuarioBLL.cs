using Biblioteca.Parametro;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        public SortedList Consultar(SortedList Parametros)
        {
            SortedList Resultado = new SortedList();

            try
            {
                string Mensagem = "";                

                //Validar Nome do Usuario
                string Nome = UtilParametro.CapturarCampoString(Parametros, "NM_USUARIO");

                if (!string.IsNullOrEmpty(Nome))
                {
                    if (Nome.Length > 200)
                        Mensagem += "O campo Nome do filtro só pode ter no maximo 200 letras";
                }

                //Validar
                string Email = UtilParametro.CapturarCampoString(Parametros, "DS_EMAIL");

                if (!string.IsNullOrEmpty(Email))
                {
                    if (Nome.Length > 200)
                        Mensagem += "O campo Email do filtro só pode ter no maximo 200 letras";
                }

                if (string.IsNullOrEmpty(Mensagem))
                {
                    UsuarioDAL Usuario = new UsuarioDAL();

                    Resultado = Usuario.Consultar(Parametros);
                }
                else
                {
                    Resultado["Tipo"] = "Aviso";
                    Resultado["Mensagem"] = Mensagem;
                }

            }
            catch (Exception Erro)
            {
                Resultado["Tipo"] = "Erro";
                Resultado["Mensagem"] = "Erro encontrado: " + Erro.Message;
            }

            return Resultado;
        }

        public SortedList Incluir(SortedList Parametros)
        {
            SortedList Resultado = new SortedList();

            try
            {
                string Mensagem = "";

                //Validar Nome do Usuario
                string Nome = UtilParametro.CapturarCampoString(Parametros, "NM_USUARIO");

                if (!string.IsNullOrEmpty(Nome))
                {
                    if (Nome.Length > 200)
                        Mensagem += "O campo Nome só pode ter no maximo 200 letras";
                }
                else
                {
                    Mensagem += "O campo Nome deve ser preenchido.";
                }

                //Validar Email
                string Email = UtilParametro.CapturarCampoString(Parametros, "DS_EMAIL");

                if (!string.IsNullOrEmpty(Email))
                {
                    if (Nome.Length > 200)
                        Mensagem += "O campo Email só pode ter no maximo 200 letras";
                }
                else
                {
                    Mensagem += "O campo de email deve ser preenchido.";
                }

                //Validar Senha
                string Senha = UtilParametro.CapturarCampoString(Parametros, "DS_SENHA");

                if (!string.IsNullOrEmpty(Senha))
                {
                    if(Senha.Length > 15)
                    {
                        Mensagem += "O campo Senha só pode ter no máximo 15 caracteres";
                    }
                }
                else
                {
                    Mensagem += "O campo de senha deve ser preenchido.";
                }

                if (string.IsNullOrEmpty(Mensagem))
                {
                    UsuarioDAL Usuario = new UsuarioDAL();
                    Resultado = Usuario.Incluir(Parametros);
                }
                else
                {
                    Resultado["Tipo"] = "Aviso";
                    Resultado["Mensagem"] = Mensagem;
                }

            }
            catch (Exception Erro)
            {
                Resultado["Tipo"] = "Erro";
                Resultado["Mensagem"] = "Erro encontrado: " + Erro.Message;
            }

            return Resultado;
        }

        public SortedList Alterar(SortedList Parametros)
        {
            SortedList Resultado = new SortedList();
            string Mensagem = "";

            try
            {
                //Validar Nome do Usuario
                string Nome = UtilParametro.CapturarCampoString(Parametros, "NM_USUARIO");

                if (!string.IsNullOrEmpty(Nome))
                {
                    if (Nome.Length > 200)
                        Mensagem += "O campo Nome só pode ter no maximo 200 letras";
                }
                else
                {
                    Mensagem += "O campo Nome deve ser preenchido.";
                }

                //Validar Email
                string Email = UtilParametro.CapturarCampoString(Parametros, "DS_EMAIL");

                if (!string.IsNullOrEmpty(Email))
                {
                    if (Nome.Length > 200)
                        Mensagem += "O campo Email só pode ter no maximo 200 letras";
                }
                else
                {
                    Mensagem += "O campo de email deve ser preenchido.";
                }

                ////Validar Senha
                //string Senha = UtilParametro.CapturarCampoString(Parametros, "DS_SENHA");

                //if (!string.IsNullOrEmpty(Senha))
                //{
                //    if (Senha.Length > 15)
                //    {
                //        Mensagem += "O campo Senha só pode ter no máximo 15 caracteres";
                //    }
                //}
                //else
                //{
                //    Mensagem += "O campo de senha deve ser preenchido.";
                //}

                if (string.IsNullOrEmpty(Mensagem))
                {
                    UsuarioDAL Usuario = new UsuarioDAL();
                    Resultado = Usuario.Alterar(Parametros);
                }
                else
                {
                    Resultado["Tipo"] = "Aviso";
                    Resultado["Mensagem"] = Mensagem;
                }
            }
            catch(Exception Erro)
            {
                Resultado["Tipo"] = "Erro";
                Resultado["Mensagem"] = "Erro encontrado: " + Erro.Message;
            }

            return Resultado;
        }

        public SortedList Excluir(SortedList Parametros)
        {
            SortedList Resultado = new SortedList();
            UsuarioDAL Usuario = new UsuarioDAL();

            Resultado = Usuario.Excluir(Parametros);

            return Resultado;

        }

        public SortedList IncluirPublicacao(SortedList Parametros)
        {
            SortedList Resultado = new SortedList();
            string mensagem = "";

            try
            {
                string SQ_USUARIO = UtilParametro.CapturarCampoString(Parametros, "SQ_USUSARIO");

                //valida SQ_USUARIO
                if(string.IsNullOrEmpty(SQ_USUARIO))
                {
                    mensagem = "O campo \"SQ_USUARIO\" deve ser preenchido!";
                }

                //valida NM_PUBLICACAO
                if(string.IsNullOrEmpty(SQ_USUARIO))
                {
                    mensagem = "O título da publicação deve ser preenchido!";
                }
                else if(SQ_USUARIO.Length > 200)
                {
                    mensagem = "O o título não pode passar de 200 caracteres.";
                }

                //Se tudo estiver validado, faz requisição à DAL
                if (string.IsNullOrEmpty(mensagem))
                {
                    UsuarioDAL Usuario = new UsuarioDAL();
                    Usuario.IncluirPublicacao(Parametros);
                }
                else
                {
                    Resultado["Tipo"] = "Aviso";
                    Resultado["Mensagem"] = mensagem;
                }
            }
            catch (Exception erro)
            {
                Resultado["Tipo"] = "Erro";
                Resultado["Mensagem"] = "Erro em UsuarioBLL: " + erro;
            }

            return Resultado;
        }
    }
}
