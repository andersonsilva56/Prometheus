<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoadReport.aspx.cs"
    Inherits="APB.Mercury.WebInterface.SCPWeb.Www.Pages.Aut_Reports_LoadReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SCPJ - Relatório</title>
</head>
<body>
    <form id="form1" runat="server">

        <span style="color: Red">
            <label id="msgErro" runat="server" visible="false">Dados não encontrados. Realize uma nova consulta.</label>
        </span>

        <asp:HiddenField ID="hidReportName" runat="server" />
        <asp:HiddenField ID="HidData" runat="server" />

        <CR:CrystalReportViewer ID="CrystalReportViewer1" PrintMode="ActiveX" runat="server" Width="350px" />

    </form>
</body>
</html>
