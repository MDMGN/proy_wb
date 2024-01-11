<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Email.aspx.cs" Inherits="proy_wb.Email" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="./assets/css/styles.css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%if (emailIsvalid){%>
            <div class="isEmailValid" style="background-color:green;">
                <asp:Literal ID="Literal1" runat="server" />
            </div>

        <%}else{%>
            <div class="isEmailValid" style="background-color: red;">
                <p> <asp:Literal ID="Literal2" runat="server" /></p>
            </div>
         <%} %>
    </form>
</body>
</html>
