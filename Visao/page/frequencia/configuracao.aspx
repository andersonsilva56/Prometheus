﻿<%@ Page Title="" Language="C#" MasterPageFile="~/page/Site.master" AutoEventWireup="true" CodeFile="configuracao.aspx.cs" Inherits="page_frequencia_configuracao" %>

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
                    <h2>Configuração frequência</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Data</label>
                                <asp:TextBox ID="txtNascimento" runat="server" CssClass="form-control" data-inputmask="'mask': '99/99/9999'"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Mês</label>
                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlMes">
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
                        <div class="col-md-2">
                            <div class="form-group">
                                <label>Ano</label>
                                <asp:TextBox ID="txtAno" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="ln_solid"></div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Button runat="server" ID="btnPesquisar" class="btn btn-primary" Text="Pesquisar" />
                                <asp:Button runat="server" ID="btnNovo" class="btn btn-success" Text="Novo" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="gvFrequencia" runat="server" AutoGenerateColumns="False"
                                AllowPaging="True" CssClass="table table-bordered table-hover table-responsive jambo_table">
                                <Columns>
                                    <asp:BoundField DataField="NOME" HeaderText="Nome" />
                                    <asp:BoundField DataField="POSICAO" HeaderText="Posição" />
                                    <asp:BoundField DataField="STATUS" HeaderText="Status" />
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
                <h3>Cadastro</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Dados</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <div class="row">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
    <script src="<%= ResolveClientUrl("~/js/input_mask/jquery.inputmask.js")%>"></script>
    <script src="<%= ResolveClientUrl("~/js/input_mask/Mascara.js")%>"></script>
</asp:Content>

