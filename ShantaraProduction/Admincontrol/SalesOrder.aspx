<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SalesOrder.aspx.vb" Inherits="ShantaraProduction.SalesOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h1>Sales Order</h1>
	<br />
	<div class="row">
		<div class="col-sm-4">
			<label for="ddlCustomer">Customer </label>
			<asp:DropDownList ID="ddlCustomer" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
				OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" AppendDataBoundItems="True">
				<asp:ListItem Text="--Select Customer--" Value=""></asp:ListItem>
			</asp:DropDownList>
		</div>

	</div>
	<br />
	<div class="row">
		<div class="col-sm-4">
			<label for="txtdate">Required by date(yyyy/mm/dd)</label>
			<asp:TextBox runat="server" ID="txtdate" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" AutoPostBack="True" />
		</div>
		<div class="col-sm-4">
		
		</div>
		<div class="col-sm-4">
			<label for="ddlSize">Size</label>
			<asp:DropDownList ID="ddlSize" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlYtype_SelectedIndexChanged" Enabled="False" AppendDataBoundItems="True">
				<asp:ListItem Text="--Select Size--" Value=""></asp:ListItem>
			</asp:DropDownList>
		</div>
		<div class="col-sm-4">
			<label for="ddlYtype">Yarn Type</label>
			<asp:DropDownList ID="ddlYtype" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlYtype_SelectedIndexChanged" Enabled="False" AppendDataBoundItems="True">
				<asp:ListItem Text="--Select Yarn Type--" Value=""></asp:ListItem>
			</asp:DropDownList>
		</div>
		<div class="col-sm-4">
			<label for="txtQuantity">Quatity</label>
			<asp:TextBox runat="server" ID="txtQuantity" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" AutoPostBack="True" />
		</div>
	</div>
	<br />
	<div class="row">
		<div class="col-sm-4">
			<asp:LinkButton runat="server" ID="btnCapture" CssClass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>
                    Capture Product
			</asp:LinkButton>
		</div>
	</div>
</asp:Content>
