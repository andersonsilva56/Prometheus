<%@ Page Title="" Language="C#" MasterPageFile="~/page/Site.master" AutoEventWireup="true" CodeFile="comissao.aspx.cs" Inherits="page_administracao_comissao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="alert alert-error alert-dismissible fade in" role="alert" runat="server" id="avisocadastro" visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h2>Erro</h2>
                <br />
                <h4 id="lblMotivo" runat="server"></h4>
            </div>
        </div>
    </div>
    <div id="divConsulta" runat="server" class="row">
        <div class="col-md-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Gerenciamento de cadastro da comissão técnica</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Nome</label>
                                <asp:TextBox ID="TxtNomePesquisa" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Status</label>
                                <asp:DropDownList ID="ddlPesquisaStatus" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="ln_solid"></div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Button runat="server" ID="btnPesquisar" class="btn btn-primary" Text="Pesquisar" />
                                <asp:Button runat="server" ID="btnNovo" class="btn btn-success" Text="Novo" OnClick="btnNovo_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvComissao" runat="server" AutoGenerateColumns="False" OnRowCommand="gvComissao_RowCommand"
                                AllowPaging="True" CssClass="table table-bordered table-hover table-responsive jambo_table">
                                <Columns>
                                    <asp:BoundField DataField="NOME" HeaderText="Nome" />
                                    <asp:BoundField DataField="DESCRICAO" HeaderText="Cargo" />
                                    <asp:ButtonField HeaderText="Visualizar"
                                        ButtonType="Link"
                                        Text='<i class="fa fa-pencil-square-o"></i>'
                                        CommandName="Visualizar"
                                        ControlStyle-CssClass="btn btn-xs btn-success" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divCadastro" visible="false" runat="server">
        <div class="page-title">
            <div class="title_left">
                <h3>Informações Gerais</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Dados cadastrais</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <div class="row">
                            <div class="col-md-5">
                                <div class="form-group">
                                    <label>Foto</label>
                                    <asp:Image ID="ImgFoto" Width="150" Height="150" CssClass="form-control img-thumbnail" runat="server" />
                                </div>
                                <div class="form-group">
                                    <asp:FileUpload ID="fuImagem" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Nome</label>
                                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Nascimento</label>
                                    <asp:TextBox ID="txtNascimento" runat="server" CssClass="form-control" data-inputmask="'mask': '99/99/9999'"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Profissão</label>
                                    <asp:TextBox ID="txtProfissao" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>E-mail</label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Telefone</label>
                                    <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control" data-inputmask="'mask': '(99)9999-9999'"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Escolaridade</label>
                                    <asp:DropDownList ID="ddlEscolaridade" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="Ensino Fundamental">Ensino Fundamental</asp:ListItem>
                                        <asp:ListItem Value="Ensino Médio">Ensino Médio</asp:ListItem>
                                        <asp:ListItem Value="Ensino Superior">Ensino Superior</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Rg</label>
                                    <asp:TextBox ID="txtRg" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Cpf</label>
                                    <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control" data-inputmask="'mask': '999.999.999-99'"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Celular</label>
                                    <asp:TextBox ID="TxtCelular" runat="server" CssClass="form-control" data-inputmask="'mask': '(99)9999-9999'"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Plano de Saúde</label>
                                    <asp:TextBox ID="txtPlanoSaude" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Contato para emergência</label>
                                    <asp:TextBox ID="txtContato" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox ID="txtDescricaoComissao" runat="server" CssClass="form-control countedCom"></asp:TextBox>
                                    <h6 class="pull-right" id="counter">20 caracteres remanescente</h6>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="ln_solid"></div>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Button runat="server" ID="btnSalvar" class="btn btn-primary" Text="Salvar" OnClick="btnSalvar_Click" />
                    <asp:Button runat="server" ID="btnVoltar" class="btn btn-dark" Text="Voltar" />
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfCodigoPessoa" runat="server" />
    <asp:HiddenField ID="hfCodigoComissao" runat="server" />    
    <asp:HiddenField ID="hfFoto" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
    <script src="<%= ResolveClientUrl("~/js/input_mask/jquery.inputmask.js")%>"></script>
    <script src="<%= ResolveClientUrl("~/js/input_mask/Mascara.js")%>"></script>
    <script src="<%= ResolveClientUrl("~/js/Counter.js")%>"></script>
    <script>
        $(document).ready(function () {
            $(":input").inputmask();
        });
    </script>
</asp:Content>
