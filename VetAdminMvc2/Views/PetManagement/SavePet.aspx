<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
<div>
	<b>User Story #1: Vet admin can enter pet details (register the pet)</b>
	&nbsp;<br />
	&nbsp;<br />
	
 <%= Html.Encode(ViewData["Message"]) %>
</div>   
</asp:Content>