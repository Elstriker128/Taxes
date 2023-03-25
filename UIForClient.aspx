<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UIForClient.aspx.cs" Inherits="Taxes.UIForClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="~/StyleForUI.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <br />
            <div class="center">
            <asp:Label ID="Label1" runat="server" Text="Input citizens' data file"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Citizens file is essential" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Input taxes' data file"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload2" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload2" ErrorMessage="Taxes file is essential" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <div class="center">
                <asp:Label ID="Label5" runat="server" Text="Input required tax (english):"></asp:Label>
                <br />
            <asp:TextBox ID="TextBox5" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox5" ErrorMessage="Required tax is essential" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
                <asp:Label ID="Label6" runat="server" Text="Input required month (english):"></asp:Label>
                <br />
            <asp:TextBox ID="TextBox4" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="Required month is essential" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Calculate" />
            <br />
            <asp:Button ID="Button2" runat="server" CausesValidation="false" Text="Remove" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Table ID="Table2" runat="server" BorderColor="Black" BorderWidth="1px" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Table ID="Table3" runat="server" BorderColor="Black" BorderWidth="1px" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Label ID="Label3" runat="server" CssClass="lab"></asp:Label>
            <br />
            <asp:Table ID="Table5" runat="server" BorderColor="Black" BorderWidth="1px" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Label ID="Label4" runat="server" CssClass="lab"></asp:Label>
            <br />
            <br />
            <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="1px" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Table ID="Table4" runat="server" BorderColor="Black" BorderWidth="1px" GridLines="Both">
            </asp:Table>
            <br />
        </div>
    </form>
</body>
</html>
