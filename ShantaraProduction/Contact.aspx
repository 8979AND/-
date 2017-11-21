<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="ShantaraProduction.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p>Your contact page.</p>

    <address>
        70 Harry Street<br />
        Robertsham, Johannesburg 2135<br />
        <abbr title="Phone">Phone:</abbr>
        0114338840

    </address>

    <address>
        <strong>Support:Anil@shantara.co.za</strong><br />
        <strong>Marketing:</strong><a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>
