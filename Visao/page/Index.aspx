<%@ Page Title="" Language="C#" MasterPageFile="~/page/Site.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="page_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="row">
        <div class="row top_tiles">
            <div class="animated flipInY col-lg-4 col-md-4 col-sm-6 col-xs-12">
                <div class="tile-stats">
                    <div class="icon">
                        <i class="fa fa-check-square-o"></i>
                    </div>
                    <div class="count">10</div>

                    <h3>Contratos em vigor</h3>
                    <p><a href="#">Verificar</a></p>
                </div>
            </div>
            <div class="animated flipInY col-lg-4 col-md-4 col-sm-6 col-xs-12">
                <div class="tile-stats">
                    <div class="icon">
                        <i class="fa fa-calendar"></i>
                    </div>
                    <div class="count">4</div>

                    <h3>Vencimentos (60 dias)</h3>
                    <p><a href="#">Verificar</a></p>
                </div>
            </div>
            <div class="animated flipInY col-lg-4 col-md-4 col-sm-6 col-xs-12">
                <div class="tile-stats">
                    <div class="icon">
                        <i class="fa fa-retweet"></i>
                    </div>
                    <div class="count">2</div>

                    <h3>Processo de renovação</h3>
                    <p><a href="#">Verificar</a></p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
