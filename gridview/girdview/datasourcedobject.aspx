<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="datasourcedobject.aspx.cs" Inherits="girdview.datasource_dobject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="heading">
          
            <asp:Button ID="btn_sqldatasource" runat="server" Height="48px" OnClick="btn_sqldatasource_Click" Text="SqlDataSource Show the Data" Width="214px" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_sqldataobj" runat="server" Height="48px" OnClick="btn_sqldataobj_Click" Text="SqlDataObject Show the Data" Width="214px" />
        </div>
        <div class="container">
            <div class="leftsidebar">
                <ul>
                    <li><a>link click</a></li>
                    <li><a>link click</a></li>
                    <li><a>link click</a></li>
                    <li><a>link click</a></li>
                </ul>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="fname" DataValueField="fname" Height="40px" Width="100%" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True" >
                    
                </asp:DropDownList>
            </div>
            <div class="rightsidebar">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="SqlDataSource1" Visible="False" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="higesteducation" HeaderText="higesteducation" SortExpression="higesteducation" />
                        <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                        <asp:BoundField DataField="age" HeaderText="age" SortExpression="age" />
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
                <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="ObjectDataSource1" ForeColor="Black" GridLines="Vertical" Visible="False" AutoGenerateColumns="False" Width="70%">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="fname" HeaderText="fname" SortExpression="fname" />
                        <asp:BoundField DataField="lname" HeaderText="lname" SortExpression="lname" />
                        <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
                        <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource2" ForeColor="#333333" GridLines="None" Visible="false" Width="70%">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="fname" HeaderText="fname" SortExpression="fname" />
                        <asp:BoundField DataField="lname" HeaderText="lname" SortExpression="lname" />
                        <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
                        <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getsearchperson" TypeName="girdview.search">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="fn" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getperson" TypeName="girdview.DataAccess"></asp:ObjectDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbcs %>" SelectCommand="SELECT * FROM [PersonDetails]"></asp:SqlDataSource>
            </div>
        </div>
    </form>
</body>
</html>
