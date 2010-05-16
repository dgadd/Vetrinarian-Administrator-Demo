<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Gaddzeit.VetAdmin.Shared.PaginatedList<Gaddzeit.VetAdmin.Domain.Entities.Pet>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" Runat="Server">
<div>
	<b>User Story #1: Vet admin can enter pet details / sub: find all pets</b>
	&nbsp;<br />
	&nbsp;<br />
	
	<% if (Model.HasPreviousPage) { %>
 
        <%= Html.RouteLink("[prev]", "FindAllPetsPaginated", new { page = (Model.PageIndex-1) }) %>
 
    <% } %>
         
    <% if (Model.HasNextPage) {  %>
     
        <%= Html.RouteLink("[next]", "FindAllPetsPaginated", new { page = (Model.PageIndex + 1) }) %>
     
    <% } %>     
	
	<table class="tableRefined" border="0">
	    <tr>
	        <th class="tdRefined">Name</th>
	        <th class="tdRefined">Breed</th>
	        <th class="tdRefined">Age</th>
	        <th class="tdRefined">Health History</th>
	    </tr>
	<% foreach(var pet in Model) { %>
	    <tr>
	        <td class="tdRefined"><%= pet.Name %></td>
	        <td class="tdRefined"><%= pet.Breed %></td>
	        <td class="tdRefined"><%= pet.Age %></td>
	        <td class="tdRefined"><%= pet.HealthHistory %></td>
	    </tr>
    <% } %>
    </table>
</div>   
</asp:Content>
