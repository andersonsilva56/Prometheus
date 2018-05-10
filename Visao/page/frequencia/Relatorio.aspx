<%@ Page Title="" Language="C#" MasterPageFile="~/page/Site.master"
    AutoEventWireup="true" CodeFile="relatorio.aspx.cs" Inherits="page_frequencia_Relatorio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                                    AutoPostBack="true">
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
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:RadioButtonList ID="rblCriar" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="0">Dia</asp:ListItem>
                                    <asp:ListItem Value="1">Mês e Ano</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                    <div class="ln_solid"></div>
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Button runat="server" ID="btnCriar" class="btn btn-primary" Text="Criar" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

