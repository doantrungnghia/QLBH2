<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchForm.aspx.cs" Inherits="SearchForm.SearchForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sims</title>
    <link href="style1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <h1>XEM THÔNG TIN CƯỚC</h1>
    <form id="form1" runat="server">
        <p>
            &nbsp;</p>
        <div class="center center_top">
            <asp:Label ID="Label3" runat="server" Text="Số điện thoại: " Font-Size="Larger"></asp:Label>
            <asp:TextBox ID="txt_sdt" runat="server" Width="195px" Height="31px" OnTextChanged="txt_sdt_TextChanged"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Tháng: " Font-Size="Larger"></asp:Label>
            <asp:DropDownList ID="lst_thang" runat="server" Height="29px">
                <asp:ListItem Selected="True" Value="-1">all</asp:ListItem>
                <asp:ListItem Value="1">01</asp:ListItem>
                <asp:ListItem Value="2">02</asp:ListItem>
                <asp:ListItem Value="3">03</asp:ListItem>
                <asp:ListItem Value="4">04</asp:ListItem>
                <asp:ListItem Value="5">05</asp:ListItem>
                <asp:ListItem Value="6">06</asp:ListItem>
                <asp:ListItem Value="7">07</asp:ListItem>
                <asp:ListItem Value="8">08</asp:ListItem>
                <asp:ListItem Value="9">09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btn_timkiem" CssClass="btn_Search" runat="server" OnClick="Button1_Click" Text="Tìm Kiếm" Height="37px" />
        </div>
        <div class="center">
            <asp:GridView ID="GridView1" CssClass="dataGridView"  runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" EnableSortingAndPagingCallbacks="True" OnPageIndexChanging="P">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#41595f" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <div style="float:right;150px;margin-right:150px">
            
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger"  Text="Tổng Tiền: "></asp:Label>
        
        <asp:Label ID="lb_tongtien" runat="server" Font-Bold="True" Font-Size="Larger" Text="0"></asp:Label>
        </div>
        </div>
        
        
    </form>
</body>
</html>
