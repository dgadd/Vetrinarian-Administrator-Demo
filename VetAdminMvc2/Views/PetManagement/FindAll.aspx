<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Gaddzeit.VetAdmin.Shared.PaginatedList<Gaddzeit.VetAdmin.Domain.Entities.Pet>>" %>
<%@ Import Namespace="MvcContrib.UI.Grid" %>

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
	
	<h3>This data grid can be displayed in two ways:</h3>
	<h4>MvcContrib Grid: simple call to: Html.Grid(Model).Columns()</h4>
	<%= Html.Grid(Model).Columns(column => {
 		column.For(x => x.Name);
        column.For(x => x.Breed);
        column.For(x => x.Age);
        column.For(x => x.HealthHistory);
        column.For(x => Html.ActionLink("View Pet", "Show", new { id = x.Id })).DoNotEncode();
}) %>

	<h4>Table Grid: hard-coded HTML &lt;table&gt; tags</h4>
	<table class="tableRefined" border="0">
	    <tr>
	        <th>Name</th>
	        <th>Breed</th>
	        <th>Age</th>
	        <th>Health History</th>
	    </tr>
	<% foreach(var pet in Model) { %>
	    <tr class="trRefined">
	        <td><%= Html.Encode(pet.Name)%></td>
	        <td><%= Html.Encode(pet.Breed)%></td>
	        <td><%= Html.Encode(pet.Age)%></td>
	        <td><%= Html.Encode(pet.HealthHistory)%></td>
	    </tr>
    <% } %>
    </table>
</div>   
</asp:Content>
