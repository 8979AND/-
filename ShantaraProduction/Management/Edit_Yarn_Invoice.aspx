<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Edit_Yarn_Invoice.aspx.vb" Inherits="ShantaraProduction.Edit_Yarn_Invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container-fluid">
				<br />
		<h1>Edit Stock</h1>
		<br />
		<div class="row">
			<asp:Label ID="lblYarn" runat="server" Text="YarnID:"></asp:Label>
		</div>
		<div class="row">
			
			<div class="col-sm-4">
				<label for="txteYdyelot">Yarn Dyelot</label>
				<asp:TextBox runat="server" ID="txteYdyelot" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" />
			</div>
			<div class="col-sm-4">
				<label for="ddleYcolour">Yarn Colour</label>
				<asp:DropDownList ID="ddleYcolour" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
					OnSelectedIndexChanged="ddleYcolour_SelectedIndexChanged" AppendDataBoundItems="True">
					<asp:ListItem Text="--Select Yarn Colour--" Value=""></asp:ListItem>
				</asp:DropDownList>
			</div>
			<div class="col-sm-4">
				<label for="txteYweight">Yarn Weight</label>
				<asp:TextBox runat="server" ID="txteYweight" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" />
			</div>
			<div class="col-sm-4">
				<label for="txteYcartons">Yarn Cartons</label>
				<asp:TextBox runat="server" ID="txteYcartons" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" />
			</div>					
		</div>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<asp:LinkButton runat="server" ID="btnEdit" CssClass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-send" aria-hidden="true"></span>
                    Edit Dyelot
				</asp:LinkButton>
			</div>
			<div class="col-sm-4">
			</div>
			<div class="col-sm-4">
				<asp:LinkButton runat="server" ID="btnBack" OnClick="Back" Text="Back" CssClass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span> Back
				</asp:LinkButton>
			</div>
		</div>

	</div>
	
</asp:Content>
