<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inupdelete.aspx.cs" Inherits="girdview.inupdelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btn_source" runat="server" OnClick="btn_source_Click" Text="datasource" />
        <asp:Button ID="btn_object" runat="server" OnClick="btn_object_Click" Text="Object" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="ObjectDataSource2" DataKeyNames="getid" OnRowUpdated="GridView1_RowUpdated">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="education" HeaderText="education" SortExpression="education" ConvertEmptyStringToNull="false" />
                <asp:TemplateField HeaderText="status" SortExpression="status">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("status") %>' >
                            <asp:ListItem>Do you?</asp:ListItem>
                            <asp:ListItem>Married</asp:ListItem>
                            <asp:ListItem>UnMarried</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownList1" ErrorMessage="Status Needed" InitialValue="Do you?"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:BoundField DataField="age" HeaderText="age" SortExpression="age" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="getid" HeaderText="getid" SortExpression="getid" ReadOnly="true" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="id" DataSourceID="SqlDataSource1" ForeColor="Black" OnRowDeleted="GridView2_RowDeleted" ShowFooter="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:TemplateField HeaderText="id" InsertVisible="False" SortExpression="id">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" ValidationGroup="i" OnClick="LinkButton1_Click">Insert</asp:LinkButton>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="higesteducation" SortExpression="higesteducation">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("higesteducation") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox5" ErrorMessage="Enter education" ValidationGroup="i">*</asp:RequiredFieldValidator>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("higesteducation") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="status" SortExpression="status">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem>Are you</asp:ListItem>
                            <asp:ListItem>Married</asp:ListItem>
                            <asp:ListItem>UnMarried</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList2" ErrorMessage="select status" InitialValue="Are you" ValidationGroup="i">*</asp:RequiredFieldValidator>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="age" SortExpression="age">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("age") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox6" ErrorMessage="Age" ValidationGroup="i"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("age") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="name" SortExpression="name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox7" ErrorMessage="Name" ValidationGroup="i" Text="*"></asp:RequiredFieldValidator>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="i" />
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getmethod" TypeName="girdview.getpersondetailsd2" UpdateMethod="mUpdtae" DeleteMethod="mDeleteconfilct" ConflictDetection="CompareAllValues" OldValuesParameterFormatString="orginal_{0}" OnUpdated="ObjectDataSource2_Updated">
            <DeleteParameters>
                <asp:Parameter Name="orginal_getid" Type="Int32" />
                <asp:Parameter Name="orginal_name" Type="String" />
                <asp:Parameter Name="orginal_education" Type="String" ConvertEmptyStringToNull="false" />
                <asp:Parameter Name="orginal_status" Type="String" />
                <asp:Parameter Name="orginal_age" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="education" Type="String" ConvertEmptyStringToNull="false" />
                <asp:Parameter Name="status" Type="String" />
                <asp:Parameter Name="age" Type="Int32" />
                <asp:Parameter Name="orginal_getid" Type="Int32" />
                <asp:Parameter Name="orginal_name" Type="String" />
                <asp:Parameter Name="orginal_education" Type="String" />
                <asp:Parameter Name="orginal_status" Type="String" />
                <asp:Parameter Name="orginal_age" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:dbcs %>" DeleteCommand="DELETE FROM [PersonDetails] WHERE [id] = @original_id AND (([higesteducation] = @original_higesteducation) OR ([higesteducation] IS NULL AND @original_higesteducation IS NULL)) AND (([status] = @original_status) OR ([status] IS NULL AND @original_status IS NULL)) AND (([age] = @original_age) OR ([age] IS NULL AND @original_age IS NULL)) AND (([name] = @original_name) OR ([name] IS NULL AND @original_name IS NULL))" InsertCommand="INSERT INTO [PersonDetails] ([higesteducation], [status], [age], [name]) VALUES (@higesteducation, @status, @age, @name)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [PersonDetails]" UpdateCommand="UPDATE [PersonDetails] SET [higesteducation] = @higesteducation, [status] = @status, [age] = @age, [name] = @name WHERE [id] = @original_id AND (([higesteducation] = @original_higesteducation) OR ([higesteducation] IS NULL AND @original_higesteducation IS NULL)) AND (([status] = @original_status) OR ([status] IS NULL AND @original_status IS NULL)) AND (([age] = @original_age) OR ([age] IS NULL AND @original_age IS NULL)) AND (([name] = @original_name) OR ([name] IS NULL AND @original_name IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_id" Type="Int32" />
                <asp:Parameter Name="original_higesteducation" Type="String" />
                <asp:Parameter Name="original_status" Type="String" />
                <asp:Parameter Name="original_age" Type="String" />
                <asp:Parameter Name="original_name" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="higesteducation" Type="String" />
                <asp:Parameter Name="status" Type="String" />
                <asp:Parameter Name="age" Type="String" />
                <asp:Parameter Name="name" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="higesteducation" Type="String" />
                <asp:Parameter Name="status" Type="String" />
                <asp:Parameter Name="age" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="original_id" Type="Int32" />
                <asp:Parameter Name="original_higesteducation" Type="String" />
                <asp:Parameter Name="original_status" Type="String" />
                <asp:Parameter Name="original_age" Type="String" />
                <asp:Parameter Name="original_name" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
