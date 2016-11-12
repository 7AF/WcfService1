<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="WcfService1.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 375px; top: 140px; position: absolute" Text="Username:"></asp:Label>
        <asp:Image ID="Image1" runat="server" Height="156px" ImageUrl="~/Pictures/Logo.jpg" style="z-index: 1; left: 110px; top: 100px; position: absolute" Width="205px" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" style="z-index: 1; left: 330px; top: 75px; position: absolute; height: 40px; width: 405px" Text="CONSOLE VR42X_IRC"></asp:Label>
        <br />
        <br />
        <asp:Label ID="logError" runat="server" ForeColor="Red" style="position: absolute; z-index: 1; left: 400px; top: 215px; height: 19px" Text="Wrong username or password!" Visible="False"></asp:Label>
        <br />
        <asp:TextBox ID="name" runat="server" style="z-index: 1; left: 460px; top: 140px; position: absolute"></asp:TextBox>
        <asp:TextBox ID="pass" runat="server" style="z-index: 1; left: 460px; top: 175px; position: absolute" TextMode="Password"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 375px; top: 175px; position: absolute" Text="Password:"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="LogInClick" runat="server" style="z-index: 1; left: 470px; top: 250px; position: absolute" Text="Sign In" OnClick="LogInClick_Click" />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
