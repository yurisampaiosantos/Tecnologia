<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="Assinatura.ascx" tagname="Assinatura" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .modalBackground
        {
              background-color:#CCCCFF;
              filter:alpha(opacity=40);
              opacity:0.5;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" >
            <br />
            <br />
            <br />
            <uc1:Assinatura ID="Assinatura1" runat="server" />
        </asp:Panel>
    </div>
    </form>
</body>
</html>
