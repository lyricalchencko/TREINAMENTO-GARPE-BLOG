<%@ Page Language="C#" MasterPageFile="/biblioteca/Aparencia/Principal.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="web.Sistema.Usuario" %>

<asp:Content ContentPlaceHolderID="AreaPrincipal" runat="server">

    <div class="container-fluid conteudo">
        <div class="row">
            <div class="col col-md-10 mr-auto ml-auto conteudo-cadastro"> <%-- <==Coloca a cor branca no fundo--%>

                <%-- Titulo Pagina --%>
                <div class="row justify-content-center">
                    <div class="col col-sm-11 cadastro-titulo">
                        <h1>Cadastro de Usuários - <small>consultar</small></h1>
                    </div>
                </div>

                <%-- Area Mensagem --%>
                <asp:Panel ID="AreaMensagem" runat="server" CssClass="row justify-content-center">
                    <div class="col col-md-10 col-lg-6 text-center">
                        <div class="alert alert-warning">
                            <asp:Literal runat="server" ID="MensagemErro"></asp:Literal>
                        </div>
                    </div>
                </asp:Panel>

                <%-- Filtros --%>
                <asp:Panel ID="AreaFiltro" runat="server" CssClass="row justify-content-center">
                    <div class="col col-md-10 col-lg-6 ">
                        <div class="formulario-filtro">

                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Nome</label>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" ID="NM_USUARIO_FILTRO" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Email</label>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" ID="DS_EMAIL_FILTRO" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Código</label>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" ID="SQ_USUARIO_FILTRO" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col text-center">
                                    <asp:Button runat="server" ID="BtnFiltrar" CssClass="btn btn-primary" Text="Filtrar" OnClick="BtnFiltrar_Click" />
                                    <asp:Button runat="server" ID="BtnNovo" CssClass="btn btn-primary" Text="Novo" OnClick="BtnNovo_Click" />
                                </div>
                            </div>
                           
                        </div>
                    </div>
                </asp:Panel>

                <%-- Consulta --%>
                <asp:Panel ID="AreaConsulta" runat="server" CssClass="row justify-content-center">
                    <div class="col col-md-10">
                        <asp:GridView ID="GdvConsulta" AutoGenerateColumns="false" CssClass="table table-hover table-striped thead-dark" runat="server">
                            <Columns>
                                <asp:BoundField DataField="SQ_USUARIO" HeaderText="Código" />
                                <asp:BoundField DataField="NM_USUARIO" HeaderText="Nome" />
                                <asp:BoundField DataField="DS_EMAIL" HeaderText="Email" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button Text="Alterar" 
                                            runat="server" 
                                            ID="BotaoAlterarUsuario"
                                            CssClass="btn btn-outline-primary"
                                            OnClick="BotaoAlterarUsuario_Click"
                                            CommandArgument='<%# Eval("SQ_USUARIO") %>' />
                                        <asp:Button Text="Excluir" 
                                            runat="server" 
                                            ID="BtnExcluirUsuario"
                                            CssClass="btn btn-outline-danger"
                                            OnClick="BtnExcluirUsuario_Click"
                                            CommandArgument='<%# Eval("SQ_USUARIO") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>

                <%-- Dados --%>
                <asp:Panel ID="AreaDados" runat="server" CssClass="row justify-content-center">
                    <div class="col col-md-10 col-lg-6">

                        <div>
                            <asp:HiddenField ID="SQ_USUARIO" runat="server"></asp:HiddenField>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Nome</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="NM_USUARIO" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Email</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="DS_EMAIL" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Senha</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="DS_SENHA" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-12 text-center">
                                    <asp:Button ID="BtnAlterar" runat="server" CssClass="btn btn-primary" Text="Alterar" OnClick="BtnAlterar_Click" CommandArgument='<%# Eval("SQ_USUARIO_CAMPO") %>'/>
                                    <asp:Button ID="BtnVoltar" runat="server" CssClass="btn btn-secondary" OnClick="BtnVoltar_Click" Text="Voltar" ValidateRequestMode="Disabled" />
                                    <asp:Button ID="BtnIncluir" runat="server" CssClass="btn btn-secondary" OnClick="BtnIncluir_Click" Text="Incluir" ValidateRequestMode="Disabled" />
                                </div>
                            </div>
                        </div>

                    </div>
                </asp:Panel>

                <%-- Detalhamento Usuário --%>
                <asp:Panel ID="AreaDetalhamentoUsuario" runat="server" CssClass="row justify-content-center">
                    <form>
                        <fieldset disabled>
                            <div class="form-group">
                                <label for="disabledTextInput">Nome:</label>
                                <asp:TextBox ID="NOMEUSUARIOEXCLUIR" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="disabledTextInput">E-mail:</label>
                                <asp:TextBox ID="EMAILUSUARIOEXCLUIR" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group row">
                               <div class="col-sm-12 text-center">
                                </div>
                            </div>
                        </fieldset>
                        <asp:HiddenField ID="SQ_USUARIO_EXCLUIR" runat="server"/>
                        <div class="form-group row">
                            <div class="col">
                                   <asp:Button ID="Button1" 
                                       runat="server" 
                                       CssClass="btn btn-danger col-sm-2" 
                                       Text="Excluir" 
                                       OnClick="BtnExcluir_Click"/>
                                   <asp:Button ID="Button2" 
                                       runat="server" 
                                       CssClass="btn btn-secondary col-sm-2" 
                                       OnClick="BtnVoltar_Click" 
                                       Text="Voltar" 
                                       ValidateRequestMode="Disabled" />
                            </div>
                        </div>
                    </form>
                </asp:Panel>

                <%--Área incluir Publicação--%>
                <asp:Panel ID="AreaIncluirPublicacao" runat="server" CssClass="row justify-content-center">
                    <div class="col col-md-10 col-lg-6 ">
                        <div class="formulario-filtro">

                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">SQ DO USUÁRIO:</label>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" ID="SQ_USUARIO_PUBLICACAO" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">TÍTULO: </label>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" ID="NM_PUBLICACAO" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <label class="col-sm-2 col-form-label">Conteúdo: </label>
                                <div class="col-sm-10">
                                    <asp:TextBox runat="server" ID="DS_CONTEUDO" CssClass="form-control" Rows="6" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col text-center">
                                    <asp:Button runat="server" ID="BtnIncluirPost" CssClass="btn btn-primary" Text="Incluir" OnClick="BtnIncluirPost_Click" />
                                </div>
                            </div>
                           
                        </div>
                    </div>
                </asp:Panel>

            </div>

        </div>
    </div>

</asp:Content>