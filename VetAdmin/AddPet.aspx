<%@ Page Language="C#" MasterPageFile="~/Support/MasterPages/VetAdminMaster.master" AutoEventWireup="true" CodeBehind="AddPet.aspx.cs" Inherits="VetAdmin.AddPet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
	<div>
	<b>Add Pet</b>
	<table border="0">
	<tr><th>Name</th><td><asp:TextBox ID="txtName" runat="server" /></td></tr>
	<tr><th>Breed</th><td><asp:TextBox ID="txtBreed" runat="server" /></td></tr>
	<tr><th>Age</th><td><asp:TextBox ID="txtAge" runat="server" /></td></tr>
	<tr><th></th><td>
        <asp:Button ID="btnAddPet" runat="server" onclick="btnAddPet_Click" 
            Text="Add Pet" />
        </td></tr>
	</table>
    </div>
</asp:Content>