<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="basic.aspx.cs" Inherits="ado.basic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 40%;
        }

        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btn_goto" runat="server" Text="Go to SqlDataReader And Adapter demo " Height="34px" Width="269px" OnClick="btn_goto_Click" />
            <br />
            <asp:TextBox ID="txt_search" runat="server"></asp:TextBox><asp:Button ID="btn_search" runat="server" Text="Search" Height="34px" Width="74px" OnClick="btn_search_Click" />
            &nbsp;<asp:Button ID="btn_show" runat="server" Text="Show all" Height="34px" Width="74px"  Visible="False" OnClick="btn_show_Click" />
             <br />

            <asp:GridView ID="grd_view" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" >
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>

            <br />
            For insertation the data fill the tex:&nbsp;<table class="auto-style1" border="1">
                <tr>
                    <td class="auto-style2">First Name</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txt_fname" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2">Address</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txt_address" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Last Name</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txt_lastname" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style3">City</td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="drp_city" runat="server" Height="30px" Width="100px">
                            <asp:ListItem Enabled="False" Value="-1">Select City</asp:ListItem>
                            <asp:ListItem>Dhaka</asp:ListItem>
                            <asp:ListItem>Khulna</asp:ListItem>
                            <asp:ListItem>Chittagong</asp:ListItem>
                            <asp:ListItem>Rajshahi</asp:ListItem>
                            <asp:ListItem>Barisal</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btn_save" runat="server" Text="Save" Font-Bold="True" Height="35px" OnClick="btn_save_Click" Width="121px" />
            &nbsp;&nbsp;
            <asp:Button ID="btn_update" runat="server" Text="Update" Font-Bold="True" Height="35px" Width="121px" OnClick="btn_update_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_delete" runat="server" Text="Delete" Font-Bold="True" Height="35px" Width="121px" OnClick="btn_delete_Click" />
            &nbsp;Give id to update or delete
                        <asp:TextBox ID="txt_id" runat="server" Width="28px"></asp:TextBox>
            <br />
            <asp:Label ID="lbl" runat="server" ForeColor="#009900"></asp:Label>
            &nbsp;
        </div>
    </form>
</body>
</html>
