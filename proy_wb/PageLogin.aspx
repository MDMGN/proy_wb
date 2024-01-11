<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageLogin.aspx.cs" Inherits="proy_wb.PageLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="./assets/css/styles.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h1>Iniciar Sesión</h1>
                <asp:TextBox  ID="TextUserName" runat="server" placeholder="Usuario" pattern="^[a-zA-Z0-9._@#$% ]+$"/>
                <div class="panelValidator">
                    <asp:RequiredFieldValidator id="RequiredFieldValidatorUserName" runat="server" 
                    errormessage="Usuario obligatorio" 
                    controltovalidate="TextUsername"
                    foreColor="red"
                    />
                    <asp:regularexpressionvalidator id="RegularexpressionvalidatorUserName" runat="server" 
                     controltovalidate="TextUserName"
                    errormessage="El usuario tiene que ser de 4 a 16 dígitos y solo puede contener letras y números." 
                    validationexpression="^[a-zA-ZÀ-ÿ0-9]{4,16}$"
                    foreColor="red"
                    />
                </div>
            <asp:TextBox ID="TextPassword" runat="server" placeholder="Contraseña" TextMode="Password"/>
            <div class="panelValidator">
                 <asp:RequiredFieldValidator id="RequiredFieldValidatorPassword" runat="server" 
                errormessage="Contraseña obligatoria" 
                controltovalidate="TextPassword"
                foreColor="red"
                />
                <asp:regularexpressionvalidator id="RegularexpressionvalidatorPassword" runat="server" 
                     controltovalidate="TextPassword"
                    errormessage="La contraseña puede contener como mínimo  un dígito, mínuscula, mayúscula y 6 caracteres." 
                    validationexpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{6,}$"
                    foreColor="red"
                 />
            </div>
            <asp:Button ID="Button1" runat="server" Text="Iniciar" OnClick="Button1_Click" />
            <asp:Literal ID="LiteralErrorMsg" runat="server" />
            <p> Registrar <a href="~/PageRegister" runat="server">aquí</a></p>
        </div>
    </form>
</body>
</html>
