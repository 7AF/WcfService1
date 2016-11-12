<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IRC.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>..:: Spletni klepet - 63130239 ::..</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ListBox ID="LB_Pogovor" runat="server" Height="424px" Width="419px"></asp:ListBox>
&nbsp;
        <asp:ListBox ID="LB_Uporabniki" runat="server" Height="427px" Width="223px"></asp:ListBox>
        <asp:Button ID="LB_Odjava" runat="server" OnClick="LB_Odjava_Click" style="z-index: 1; left: 665px; top: 15px; position: absolute; height: 55px; width: 95px" Text="Log Out" ForeColor="Black" />
        <br />
        <asp:TextBox ID="TB_Sporocilo" runat="server" Height="75px" Width="417px"></asp:TextBox>
&nbsp;<asp:Button ID="B_Poslji" runat="server" CausesValidation="true" ValidationGroup="posiljanje" Height="78px" OnClick="B_Poslji_Click" Text="Send" Width="108px" ForeColor="Black" />
&nbsp;<asp:Button ID="B_Osvezi" runat="server" Height="78px" OnClick="B_Osvezi_Click" Text="Refresh" Width="108px" /> 
        <br />
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidator1" 
            runat="server" 
            ControlToValidate="TB_Sporocilo" 
            ErrorMessage="Prazno vnosno polje. Vnesite sporocilo."
            ValidationGroup="posiljanje" ForeColor="Red">Emtpy message field. Type a message!</asp:RequiredFieldValidator>
    </div>
    </form>
</body>
</html>
