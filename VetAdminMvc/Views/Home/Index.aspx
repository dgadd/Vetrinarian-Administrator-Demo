<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
	<div>
    <%= Html.Encode(ViewData["Message"]) %>
    </div>
</asp:Content>