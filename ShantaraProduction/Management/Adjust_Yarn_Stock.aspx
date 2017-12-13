<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Adjust_Yarn_Stock.aspx.vb" Inherits="ShantaraProduction.Adjust_Yarn_Stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<div class="container-fluid">
		<br />
		<br />
		<br />
		<h1>Yarn Transaction from Stock</h1>
		<br />
		<h4><asp:Label ID="lblYarnID" runat="server"></asp:Label></h4>
		<h4><asp:Label ID="lblYarnPurchaceWeight" runat="server"></asp:Label></h4>
		<h4><asp:Label ID="lblYarnPurchaseCartons" runat="server"></asp:Label></h4>
		<h4><asp:Label ID="lblYarnCurrentWeight" runat="server"></asp:Label></h4>
		<h4><asp:Label ID="lblYarnCurrentCartons" runat="server"></asp:Label></h4>
		<h4><asp:Label ID="lblerrYexists" runat="server" ForeColor="Red"></asp:Label></h4>
		<h4><asp:Label ID="lblerrother" runat="server" ForeColor="Red"></asp:Label></h4>
		
		
		<br />
			<div class="row">
				<label for="ddltranstype">Transaction</label>
					<asp:DropDownList ID="ddltranstype" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
						OnSelectedIndexChanged="ddltranstype_SelectedIndexChanged" AppendDataBoundItems="True">
						<asp:ListItem Text="--Select Transaction Type--" Value=""></asp:ListItem>
					</asp:DropDownList>
			</div>
			<br />
		<div class="row">
			<div class="col-sm-4">
				<label for="txteYdyelot">Enter Yarn Dyelot</label>
				<asp:TextBox runat="server" ID="txteYdyelot" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
		</div>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<asp:LinkButton runat="server" ID="btnView" CssClass="btn btn-default btn-lg" Enabled="False">
                    <span class="glyphicon glyphicon-eye-open" aria-hidden="true"></span>
                    View Dyelot
				</asp:LinkButton>
			</div>
			<hr />
			<br />
			<div class="row">
				<div class="col-sm-4">
					<label for="ddleYcolour">Yarn Colour</label>
					<asp:DropDownList ID="ddleYcolour" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
						OnSelectedIndexChanged="ddleYcolour_SelectedIndexChanged" AppendDataBoundItems="True" Enabled="False">
						<asp:ListItem Text="--Select Yarn Colour--" Value=""></asp:ListItem>
					</asp:DropDownList>
				</div>
				<div class="col-sm-4">
					<label for="txteYweight">Transaction Yarn Weight</label>
					<asp:TextBox runat="server" ID="txteYweight" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" TextMode="Number" >0</asp:TextBox>
				</div>
				<div class="col-sm-4">
					<label for="txteYcartons">Transaction Yarn Cartons</label>
					<asp:TextBox runat="server" ID="txteYcartons" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" TextMode="Number" >0</asp:TextBox>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-sm-4">
					<asp:LinkButton runat="server" ID="btnEdit" CssClass="btn btn-default btn-lg" Enabled="False">
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
		</div>
</asp:Content>
