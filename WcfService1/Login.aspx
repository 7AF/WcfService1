<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IRC.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            position: static;
            left: 0;
            top: 0;
            z-index: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="z-index: 1; left: 10px; top: 15px; position: absolute; height: 625px; width: 750px">
    
        <span class="auto-style1">
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" Height="171px" style="z-index: 1; left: 20px; top: 40px; position: absolute; width: 225px" ImageUrl="/Pictures/Logo.jpg" />
        </span>
        <br />
        <br />
        <br />
        <span class="auto-style1">
        <asp:Image ID="Image2" runat="server" Height="18px" style="z-index: 2; left: 0px; top: 240px; position: absolute; width: 755px;" ImageUrl="/Pictures/horizontalLine.gif" />
        </span>
        <br />
        <br />
        <br />
        <br />
        <asp:TextBox ID="password" runat="server" style="z-index: 1; top: 455px; position: absolute; left: 145px" TextMode="Password"></asp:TextBox>
        <asp:TextBox ID="username" runat="server" style="z-index: 1; left: 145px; top: 365px; position: absolute; "></asp:TextBox>
        <asp:TextBox ID="name" runat="server" style="z-index: 1; left: 145px; top: 395px; position: absolute"></asp:TextBox>
        <asp:TextBox ID="surname" runat="server" style="z-index: 1; left: 145px; top: 425px; position: absolute"></asp:TextBox>
        <span class="auto-style1">
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="XX-Large" style="font-size: xx-large; z-index: 1; left: 280px; top: 115px; position: absolute" Text="Internal Messaging - VR42X"></asp:Label>
        </span>
        <asp:Label ID="Label4" runat="server" Font-Size="X-Large" style="z-index: 1; left: 415px; top: 300px; position: absolute; font-weight: 700" Text="Log In"></asp:Label>
        <asp:Label ID="Label5" runat="server" Font-Size="Small" ForeColor="#666666" style="z-index: 1; left: 415px; top: 330px; position: absolute" Text="Existing user:"></asp:Label>
        <asp:Label ID="error" runat="server" ForeColor="Red" style="position: absolute; z-index: 2; left: 30px; top: 580px"></asp:Label>
        <asp:Image ID="Image3" runat="server" style="z-index: 1; left: 345px; top: 210px; position: absolute; width: 55px; height: 465px" ImageUrl="/Pictures/verticalLine.jpg" />
        <asp:Label ID="Label6" runat="server" style="z-index: 1; left: 30px; top: 425px; position: absolute; height: 20px; right: 1411px" Text="Surname:"></asp:Label>
        <asp:Label ID="Label7" runat="server" style="z-index: 1; left: 30px; top: 360px; position: absolute; height: 20px" Text="Username:"></asp:Label>
        <asp:Label ID="Label8" runat="server" style="z-index: 1; left: 30px; top: 395px; position: absolute; height: 20px" Text="Name:"></asp:Label>
        <asp:Label ID="Label9" runat="server" style="z-index: 1; left: 30px; top: 455px; position: absolute; height: 20px; right: 1411px" Text="Password:"></asp:Label>
        <asp:TextBox ID="password1" runat="server" style="z-index: 1; left: 530px; top: 395px; position: absolute; bottom: 208px" TextMode="Password"></asp:TextBox>
        <asp:TextBox ID="username1" runat="server" style="z-index: 1; left: 530px; top: 365px; position: absolute; bottom: 238px"></asp:TextBox>
        <asp:Label ID="Label10" runat="server" Font-Size="X-Large" style="z-index: 1; left: 30px; top: 300px; position: absolute; font-weight: 700" Text="Registration"></asp:Label>
        <asp:Label ID="Label11" runat="server" Font-Size="Small" ForeColor="#666666" style="z-index: 1; left: 30px; top: 330px; position: absolute; right: 660px;" Text="New user:"></asp:Label>
        <asp:Label ID="Label12" runat="server" style="z-index: 1; left: 415px; top: 395px; position: absolute; height: 20px" Text="Password:"></asp:Label>
        <asp:Label ID="Label13" runat="server" style="z-index: 1; left: 415px; top: 365px; position: absolute; height: 20px" Text="Username:"></asp:Label>
        <asp:Button ID="registerB" runat="server" style="z-index: 1; left: 145px; top: 505px; position: absolute; width: 145px; background-color: #666666" Text="Register" OnClick="registerB_Click" />
        <asp:Button ID="logInB" runat="server" style="z-index: 1; left: 530px; top: 445px; position: absolute; width: 145px; background-color: #666666" Text="Log In" OnClick="logInB_Click" />
    
    </div>
    </form>
</body>
</html>
