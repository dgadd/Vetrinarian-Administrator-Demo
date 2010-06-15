<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<VetAdminMvc2.Models.AddPetFormResponse>"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
<div>
	<b>User Story #1: Vet admin can enter pet details (register the pet)</b>
	&nbsp;<br />
	&nbsp;<br />
		
    <% using (Html.BeginForm("SavePet", "PetManagement")) {%>
    <fieldset>
        <legend>Fields</legend>
        <%=Html.EditorForModel() %>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
<% } %>  

    <%= Html.Encode(ViewData["Message"]) %>
</div>   
</asp:Content>