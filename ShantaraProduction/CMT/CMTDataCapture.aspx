<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CMTDataCapture.aspx.vb" Inherits="ShantaraProduction.CMTDataCapture" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container-fluid">
		<h1>CMT Data Capture</h1>
		<br />
		<h3>><asp:Label ID="lblBundleNo" runat="server" Text="BundleNo: "></asp:Label></h3>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<label for="txtorderNo">Order Number</label>
				<asp:TextBox runat="server" ID="txtorderNo" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" AutoPostBack="True" />
			</div>
			<div class="col-sm-4">
				<label for="txtBatchNo">Batch Number</label>
				<asp:TextBox runat="server" ID="txtBatchNo" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtProdcode">Product Code</label>
				<asp:TextBox runat="server" ID="txtProdcode" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtProdDescr">Product Description</label>
				<asp:TextBox runat="server" ID="txtProdDescr" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<asp:Label ID="lblj2c" runat="server" Text="Jerseys To Cut" Font-Bold="True"></asp:Label>
				<asp:TextBox runat="server" ID="txtJtoCut" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<asp:Label ID="lblajc" runat="server" Text="Actual Jerserys Cut" Font-Bold="True"></asp:Label>
				<asp:TextBox runat="server" ID="txtAJCutD" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtSize">Size</label>
				<asp:TextBox runat="server" ID="txtSize" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
		</div>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<label for="txtYarnColour">Main Colour</label>
				<asp:TextBox runat="server" ID="txtYarnColour" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtCSIM">CMT Special Instructions</label>
				<asp:TextBox runat="server" ID="txtCSIM" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
		</div>
		<br />
		<hr style="height: 1px; border: none; color: #333; background-color: #333;" />
		<h4>Capture</h4>
		<br />
		<div class="row">
					<h3>><asp:Label ID="lblOperation" runat="server" Text="BundleNo: "></asp:Label></h3>
		</div>
		<div class="row">
			<div class="col-sm-4">
				<asp:Label ID="lblajce" runat="server" Text="Actual Jerseys Cut" Font-Bold="True"></asp:Label>
				<asp:TextBox runat="server" ID="txtactualJcut" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" />
			</div>
		</div>
		<br />
		<div class="row">
			<asp:LinkButton runat="server" ID="BtnCaptureBundle" CssClass="btn btn-default btn-lg" Visible="True">
                    <span class="glyphicon glyphicon-send" aria-hidden="true"></span>
                    Capture Bundle
			</asp:LinkButton>
		</div>
		

	</div>

</asp:Content>
