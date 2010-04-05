<%@ Page Language="C#" MasterPageFile="~/Support/MasterPages/VetAdminMaster.master" AutoEventWireup="true" CodeBehind="AddPet.aspx.cs" Inherits="VetAdmin.AddPet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
	<div>
	<b>User Story #1: Vet admin can enter pet details (register the pet)</b>
	&nbsp;<br />
	&nbsp;<br />
	<table border="0">
	<tr><th valign="top" align="left">Name</th><td><asp:TextBox ID="txtName" runat="server" /></td></tr>
	<tr><th valign="top" align="left">Breed</th><td><asp:TextBox ID="txtBreed" runat="server" /></td></tr>
	<tr><th valign="top" align="left">Age</th><td><asp:TextBox ID="txtAge" runat="server" /></td></tr>
	<tr><th valign="top" align="left">Health History</th><td><asp:TextBox ID="txtHealthHistory" TextMode="MultiLine" Rows="5" runat="server" /></td></tr>
	<tr><th valign="top"></th><td>
        <asp:Button ID="btnAddPet" runat="server" onclick="btnAddPet_Click" 
            Text="Add Pet" />
        </td></tr>
	</table>
	<asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
    </div>
</asp:Content>