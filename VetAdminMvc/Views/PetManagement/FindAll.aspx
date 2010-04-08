<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Gaddzeit.VetAdmin.Domain.Pet>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
<div>
	<b>User Story #1: Vet admin can enter pet details / sub: find all pets</b>
	&nbsp;<br />
	&nbsp;<br />
	
	<table class="tableRefined" border="0">
	    <tr><th class="tdRefined">Name</th><th class="tdRefined">Breed</th><th class="tdRefined">Age</th></tr>
	<% foreach(var pet in Model) { %>
	    <tr><td class="tdRefined"><%= pet.PetName %></td><td class="tdRefined"><%= pet.Breed %></td><td class="tdRefined"><%= pet.Age %></td></tr>
    <% } %>
    </table>
</div>   
</asp:Content>
