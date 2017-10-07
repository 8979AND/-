<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Dashboard.aspx.vb" Inherits="ShantaraProduction.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h1><%: Title %>.</h1>
        <h2>Where would you like to go?</h2>
        <hr />
        <div class="col-md-4">
            <asp:LinkButton runat="server" OnClick="ManageUsers" Text="Manage Users" CssClass="btn btn-default btn-lg" style="Font-Size:30px">
                <span class="glyphicon glyphicon-user" aria-hidden="true"></span> Manage Users
            </asp:LinkButton>
        </div>
        <div class="col-md-5">
        <asp:Linkbutton runat="server" OnClick="ManageTickets" Text="Manage Job Tickets" cssclass="btn btn-default btn-lg" style="font-size:30px">
                    <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span> 
                     Manage Job Tickets
                </asp:Linkbutton>
        </div>
        <div class="col-md-3">
        <asp:LinkButton runat="server" OnClick="Reports" Text="Reports" CssClass="btn btn-default btn-lg" style="font-size:30px">
            <span class="glyphicon glyphicon-stats" aria-hidden="true"></span> 
                     Reports
        </asp:LinkButton>
        </div>
        <br />
         <div class="col-md-2">
        <asp:LinkButton runat="server" OnClick="SLA" Text="SLA" CssClass="btn btn-default btn-lg" style="font-size:30px">
            <span class="glyphicon glyphicon-stats" aria-hidden="true"></span> 
                     SLA
        </asp:LinkButton>
        </div>
    
</asp:Content>
