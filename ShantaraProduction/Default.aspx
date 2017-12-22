<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="ShantaraProduction._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Shantara Industries</h1>
       <a runat="server" href="~/">
				<asp:Image ID="ShantaraLogo" runat="server" ImageUrl="~/Images/Shantara_Logo.jpg" BorderStyle="Solid" />
			</a>
    </div>
	<br />

            <p>
               School Jersey Manufaturing at it's finest
            </p>
	<br />
    <div class="row">
        <div class="col-md-4">
            <h2>Knitt</h2>
            <p>
                <a class="btn btn-default" href="Knitt/DisplayBatches">Go &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Check Store</h2>
            <p>
                <a class="btn btn-default" href="CheckStore/CheckOverview">Go &raquo;</a>
            </p>
        </div>
		<div class="col-md-4">
            <h2>CMT</h2>
            <p>
                <a class="btn btn-default" href="CMT/CMTJob">Go &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
