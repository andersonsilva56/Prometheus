<%@ Page Title="" Language="C#" MasterPageFile="~/page/Site.master" AutoEventWireup="true"
    CodeFile="justificados.aspx.cs" Inherits="page_frequencia_justificados" %>

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
            <div class="x_panel">
                <div class="x_title">
                    <h2>Lista de justificativas - Dia: <%= DateTime.Now.Date.ToShortDateString() %></h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Dia</label>
                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDia" 
                                 AutoPostBack="true" OnSelectedIndexChanged="ddlDia_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Mês</label>
                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlMes" AutoPostBack="true" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged">
                                    <asp:ListItem Value="01">Janeiro</asp:ListItem>
                                    <asp:ListItem Value="02">Fevereiro</asp:ListItem>
                                    <asp:ListItem Value="03">Março</asp:ListItem>
                                    <asp:ListItem Value="04">Abril</asp:ListItem>
                                    <asp:ListItem Value="05">Maio</asp:ListItem>
                                    <asp:ListItem Value="06">Junho</asp:ListItem>
                                    <asp:ListItem Value="07">Julho</asp:ListItem>
                                    <asp:ListItem Value="08">Agosto</asp:ListItem>
                                    <asp:ListItem Value="09">Setembro</asp:ListItem>
                                    <asp:ListItem Value="10">Outubro</asp:ListItem>
                                    <asp:ListItem Value="11">Novembro</asp:ListItem>
                                    <asp:ListItem Value="12">Dezembro</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Ano</label>
                                <asp:TextBox ID="txtAno" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
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
                                <asp:Button runat="server" ID="btnTodosJus" class="btn btn-success" Text="Todos" OnClick="btnTodosJus_Click" />
                                <asp:Button runat="server" ID="btnLimparJus" class="btn btn-danger" Text="Limpar" OnClick="btnLimparJus_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvJustificados" runat="server" AutoGenerateColumns="False" EmptyDataText="Nenhum registro encontrado"
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
                                    <asp:TemplateField HeaderText="Justificativa">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtJustificativa" runat="server" CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
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

