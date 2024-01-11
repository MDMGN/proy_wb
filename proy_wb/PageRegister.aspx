<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageRegister.aspx.cs" Inherits="proy_wb.PageRegister" %>

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
            <h1>Registrarse</h1>
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
                    errormessage="La contraseña puede contener como mínimo  un dígito, mínuscula, mayúscula y de 6 a 10 caracteres." 
                    validationexpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{6,10}$"
                    foreColor="red"
                 />
            </div>
            <asp:TextBox ID="TextEmail" runat="server" placeholder="Email" TextMode="Email"/>
            <div class="panelValidator">
                 <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" 
                errormessage="Correo obligatorio" 
                controltovalidate="TextEmail"
                foreColor="red"
                />
                <asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" 
                     controltovalidate="TextEmail"
                    errormessage="El email solo puede contener letras, numeros, puntos, guiones y guion bajo." 
                    validationexpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"
                    foreColor="red"
                 />
            </div>
            <asp:Button ID="Button1" runat="server" Text="Registrar" OnClick="Button1_Click" />
            <asp:Literal ID="LiteralErrorMsg" runat="server" />
            <br />
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <p>Iniciar sesión <a href="~/PageLogin" runat="server">aquí</a></p>
        </div>
    </form>
</body>
</html>
