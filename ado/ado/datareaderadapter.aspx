<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="datareaderadapter.aspx.cs" Inherits="ado.datareader_adapter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btn_go_tobasic" runat="server" Text="Go To Basic" Height="34px" OnClick="btn_go_tobasic_Click" Width="120px" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_go_toanother" runat="server" Text="Go To Another" Height="34px" Width="120px" OnClick="btn_go_toanother_Click" />
        <br />
        <asp:Button ID="btn_show_sqlrdr" runat="server" Height="42px" OnClick="btn_show_sqlrdr_Click" Text="SqlDataReader Showing this result" Width="221px" />
&nbsp;<asp:Button ID="btn_showdad" runat="server" Height="42px" OnClick="btn_showdad_Click" Text="SqlDataAdapter Showing this result" Width="221px" />
        <br />
        <asp:Label ID="lblr" runat="server"></asp:Label>
    <br />
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
        <br />
        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
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
    
    </div>
    </form>
</body>
</html>
