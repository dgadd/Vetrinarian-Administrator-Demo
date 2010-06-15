<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<VetAdminMvc2.Models.AddPetFormResponse>" %>

<% Html.EnableClientValidation(); %>
<%= Html.ValidationSummary(true, "Test was unsuccessful.") %> 

OVERRIDE TEMPLATE
        <p>
            <%= Html.LabelFor(model => model.Name) %>
            <%= Html.TextBoxFor(model => model.Name) %>  
            <%= Html.ValidateFor(model => model.Name) %>  
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

