<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
<div>
	<b>User Story #1: Vet admin can enter pet details (register the pet)</b>
	&nbsp;<br />
	&nbsp;<br />
	
	<form action="<%=Url.Content("~/PetManagement/SavePet")%>" method="post">

	<table border="0">
	<tr><th valign="top" align="left">Name</th><td><input id="Name" type="text" name="Name"/></td></tr>
	<tr><th valign="top" align="left">Breed</th><td><input id="Breed" type="text" name="Breed"/></td></tr>
	<tr><th valign="top" align="left">Age</th><td><input id="Age" type="text" name="Age"/></td></tr>
	<tr><th valign="top" align="left">Health History</th><td>
	<textarea cols="20" rows="5" id="HealthHistory" name="HealthHistory" >
	</textarea>
	</td></tr>
	<tr><th valign="top"></th><td><input type="submit" value="Save" /></td></tr>
	</table>
</form>

    <%= Html.Encode(ViewData["Message"]) %>
</div>   
</asp:Content>