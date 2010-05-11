<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<VetAdminMvc2.Models.AddPetFormResponse>"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
<div>
	<b>User Story #1: Vet admin can enter pet details (register the pet)</b>
	&nbsp;<br />
	&nbsp;<br />
	
    <% using (Html.BeginForm("SavePet", "PetManagement")) {%>
    <fieldset>
        <legend>Fields</legend>
        <p>
            <%= Html.LabelFor(model => model.Name) %>
            <%= Html.TextBoxFor(model => model.Name) %>  
        </p>
        <p>
            <%= Html.LabelFor(model => model.Breed) %>
            <%= Html.TextBoxFor(model => model.Breed) %> 
        </p>
        <p>
            <%= Html.LabelFor(model => model.Age) %>
            <%= Html.TextBoxFor(model => model.Age) %> 
        </p>
        <p>
            <%= Html.LabelFor(model => model.HealthHistory) %>
            <%= Html.TextAreaFor(model => model.HealthHistory) %>
        </p>
        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
<% } %>  

    <%= Html.Encode(ViewData["Message"]) %>
</div>   
</asp:Content>