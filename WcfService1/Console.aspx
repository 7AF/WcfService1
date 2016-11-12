<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Console.aspx.cs" Inherits="WcfService1.Console" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="position: relative; top: 2px; left: 0px" Text="Log Out" />
        <br />
        <br />
    
        <asp:GridView ID="GridView1" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="SqlDataSource1" Height="200px" Width="1000px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True" AllowSorting="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" />
                <asp:BoundField DataField="username" HeaderText="Username" ReadOnly="True" SortExpression="username" />
                <asp:BoundField DataField="ime" HeaderText="Name" ReadOnly="True" SortExpression="ime" />
                <asp:BoundField DataField="priimek" HeaderText="Surname" ReadOnly="True" SortExpression="priimek" />
                <asp:BoundField DataField="geslo" HeaderText="Password" ReadOnly="True" SortExpression="geslo" />
                <asp:BoundField DataField="messageCount" HeaderText="Message count" ReadOnly="True" SortExpression="messageCount"/>
                <asp:CheckBoxField DataField="admin" HeaderText="Admin" ReadOnly="False" SortExpression="admin" />
            </Columns>
            <RowStyle HorizontalAlign="Center" Width="600px" Height="20px" />
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:friisConnectionString %>" 
            SelectCommand="SELECT username, ime, priimek, geslo, admin, (SELECT COUNT(besedilo) FROM Pogovor WHERE (username = Uporabnik.username)) AS MessageCount FROM Uporabnik"
            UpdateCommand="UPDATE Uporabnik SET admin = @admin WHERE username = @username"
            DeleteCommand="ALTER TABLE Pogovor nocheck constraint all; DELETE FROM Uporabnik WHERE username = @username; DELETE FROM Pogovor WHERE username = @username; ALTER TABLE Pogovor check constraint all" >
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>