<%@ Page Title="" Language="C#" MasterPageFile="~/page/Site.master"
    AutoEventWireup="true" CodeFile="presenca.aspx.cs" Inherits="page_frequencia_presenca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .Hide {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="alert alert-warning alert-dismissible fade in" role="alert" runat="server" id="avisoLista" visible="false">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h2>AVISO</h2>
                <br />
                <h4 id="lblMotivo" runat="server">O dia em questão não está configurado como dia de treino.</h4>
            </div>
        </div>
    </div>
    <div runat="server" id="divListaFrequencia" visible="false">
        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Lista de frequência - Dia: <%= DateTime.Now.Date.ToShortDateString() %></h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <div class="row">
                            <div class="col-md-4">
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
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Posição</label>
                                    <asp:DropDownList ID="ddlPesquisaPosicao" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Button runat="server" ID="btnPesquisar" class="btn btn-primary" Text="Pesquisar" OnClick="btnPesquisar_Click" />
                                <asp:Button runat="server" ID="btnSalvar" class="btn btn-success" Text="Salvar" OnClick="btnSalvar_Click" />
                            </div>
                        </div>
                        <div class="ln_solid"></div>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="btn-group">
                                    <asp:Button runat="server" ID="btnSelecionar" class="btn btn-success" Text="Todos" OnClick="btnSelecionar_Click" />
                                    <asp:Button runat="server" ID="btnLimpar" class="btn btn-danger" Text="Limpar" OnClick="btnLimpar_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="gvAtleta" runat="server" AutoGenerateColumns="False" EmptyDataText="Nenhum registro encontrado"
                                    AllowPaging="True" CssClass="table table-bordered table-hover table-responsive jambo_table">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbRow" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ATLETACODIGO" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide" />
                                        <asp:BoundField DataField="NOME" HeaderText="Nome" />
                                        <asp:BoundField DataField="POSICAO" HeaderText="Posição" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfCodigo" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

