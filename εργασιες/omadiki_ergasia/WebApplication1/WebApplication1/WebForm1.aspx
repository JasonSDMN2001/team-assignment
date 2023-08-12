<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    	<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Προβολή" BackColor="#66FFFF" Font-Bold="True" />
		<asp:Button ID="Button2" runat="server" BackColor="#66FFFF" Font-Bold="True" OnClick="Button2_Click" Text="Πλήθος Ανδρών" />
        <asp:Button ID="Button3" runat="server" BackColor="#66FFFF" Font-Bold="True" OnClick="Button3_Click" Text="Πλήθος Γυναικών" />
		<p>
			<asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Προβολή καταγεγραμένων κρουσμάτων:" BackColor="#66FF33"></asp:Label>
		</p>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Το πλήθος ανδρών είναι:"></asp:Label>
        </p>
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Το πλήθος γυναικών είναι:"></asp:Label>
        </p>
        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
