<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CMTJob.aspx.vb" Inherits="ShantaraProduction.CMTJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container-fluid">
		<br />
		<h1>Select Operation</h1>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<asp:LinkButton runat="server" ID="btncutting" CssClass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-scissors" aria-hidden="true"></span> Cutting
				</asp:LinkButton>
			</div>
			<div class="col-sm-4">
				<asp:LinkButton runat="server" ID="btnattachVN" CssClass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-pushpin" aria-hidden="true"></span> Attach V-neck
				</asp:LinkButton>
			</div>
			<div class="col-sm-4">
				<asp:LinkButton runat="server" ID="btnSideseam" CssClass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-triangle-right" aria-hidden="true"></span> Side Seams
				</asp:LinkButton>
			</div>
		</div>
			<br />
		<div class="row">
			<div class="col-sm-4">
				<asp:LinkButton runat="server" ID="btnPressing" CssClass="btn btn-default btn-lg">
                    <span class="	glyphicon glyphicon-save" aria-hidden="true"></span> Pressing
				</asp:LinkButton>
			</div>
			<div class="col-sm-4">
				<asp:LinkButton runat="server" ID="btnDispatchs" CssClass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-upload" aria-hidden="true"></span> Dispatch
				</asp:LinkButton>
			</div>
		</div>
	</div>
</asp:Content>
