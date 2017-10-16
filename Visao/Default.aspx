<%@ Page Title="" Language="C#" MasterPageFile="~/mpLogin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        body{padding-top: 3%;}
        .btn-label {position: relative;left: -12px;display: inline-block;padding: 6px 12px;background: rgba(0,0,0,0.15);border-radius: 3px 0 0 3px;}
        .btn-labeled {padding-top: 0;padding-bottom: 0;}
        .btn { margin-bottom:10px; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div id="divProcessando" style="display: none"></div>
            <div class="col-md-4 col-md-offset-4 well">
                <div class="modal-header">
                    <img style="margin-left: 35%;" alt="" src="img/LogoDef.png" />
                    <h3 style="text-align: center;">Prometheus</h3>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title" style="text-align: center;"></h3>
                    </div>
                    <div class="panel-body">
                        <fieldset>

                            <div class="form-group">
                                <input type="text" runat="server" id="login" name="login" class="form-control" placeholder="Usuário" />
                                <%--required autofocus--%>
                            </div>
                            <div class="form-group">
                                <input type="password" runat="server" id="senha" name="senha" class="form-control" placeholder="Senha" />
                            </div>
                            <asp:Button ID="btnEntrar" runat="server" CssClass="btn btn-lg btn-success btn-block active" Text="Entrar" OnClick="btnEntrar_Click" />
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

