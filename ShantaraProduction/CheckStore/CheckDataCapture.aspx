<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CheckDataCapture.aspx.vb" Inherits="ShantaraProduction.CheckDataCapture" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container-fluid">
		<br />
		<br />
		<br />
		<h1>Check Data Capture</h1>
		<br />
		<h3><asp:Label ID="lblBundleNo" runat="server" Text="BundleNo: "></asp:Label></h3>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<label for="txtorderNo">Order Number</label>
                <asp:TextBox runat="server" ID="txtorderNo" cssClass="form-control" style="height:34px; width:100%; max-width:none" Enabled="False" AutoPostBack="True" />
			</div>
			<div class="col-sm-4">
				<label for="txtBatchNo">Batch Number</label>
                <asp:TextBox runat="server" ID="txtBatchNo" cssClass="form-control" style="height:34px; width:100%; max-width:none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtProdcode">Product Code</label>
			    <asp:TextBox runat="server" ID="txtProdcode" cssClass="form-control" style="height:34px; width:100%; max-width:none" Enabled="False" />
			</div>			
			<div class="col-sm-4">
				<label for="txtProdDescr">Product Description</label>
                <asp:TextBox runat="server" ID="txtProdDescr" cssClass="form-control" style="height:34px; width:100%; max-width:none" Enabled="False" />
			</div>		
			<div class="col-sm-4">
				<label for="txtPToMake">Panels To Make</label>
				<asp:TextBox runat="server" ID="txtPToMake" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtPMade">Panels Made</label>
				<asp:TextBox runat="server" ID="txtPMade" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtSize">Size</label>
				<asp:TextBox runat="server" ID="txtSize" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtComponent">Component</label>
				<asp:TextBox runat="server" ID="txtComponent" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtQPpanel">Quantity Per Panel</label>
				<asp:TextBox runat="server" ID="txtQPpanel" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtKwidth">Knitt Width</label>
				<asp:TextBox runat="server" ID="txtKwidth" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtkLength">Knitt Length</label>
				<asp:TextBox runat="server" ID="txtkLength" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
		</div>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<label for="txtYarnColour">Yarn Colour</label>
				<asp:TextBox runat="server" ID="txtYarnColour" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
		</div>
		<br />
		<hr style="height:1px;border:none;color:#333;background-color:#333;" />
		<h4>Capture</h4>

		<div class="row">
			<asp:Label ID="lblerrother" runat="server" ForeColor="Red"></asp:Label>
			<div class="col-sm-4">
				<asp:Label ID="lblerrchecker" runat="server" ForeColor="Red"></asp:Label>
				<label for="ddlChecker">Checker Name </label>
				<asp:DropDownList ID="ddlChecker" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
					 AppendDataBoundItems="True">
					<asp:ListItem Text="--Select Checker--" Value=""></asp:ListItem>
				</asp:DropDownList>
			</div>
			<div class="col-sm-4">
				<asp:Label ID="lblerrfault" runat="server" ForeColor="Red"></asp:Label>
				<label for="ddlFault">Is there any faults? </label>
				<asp:DropDownList ID="ddlFault" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
					AppendDataBoundItems="True">
					<asp:ListItem Text="--Select Yes/No--" Value=""></asp:ListItem>
					<asp:ListItem>Yes</asp:ListItem>
					<asp:ListItem>No</asp:ListItem>
				</asp:DropDownList>
			</div>
		</div>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<label for="txtFHoles">Fault Holes</label>
				<asp:TextBox runat="server" ID="txtFHoles" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" >0</asp:TextBox>
			</div>
			<div class="col-sm-4">
				<label for="txtFNeedleStripe">Fault Needle Stripe</label>
				<asp:TextBox runat="server" ID="txtFNeedleStripe" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" >0</asp:TextBox>
			</div>
			<div class="col-sm-4">
				<label for="txtFWidth">Fault Width</label>
				<asp:TextBox runat="server" ID="txtFWidth" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" >0</asp:TextBox>
			</div>
			<div class="col-sm-4">
				<label for="txtFLength">Fault Length</label>
				<asp:TextBox runat="server" ID="txtFLength" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" >0</asp:TextBox>
			</div>
			<div class="col-sm-4">
				<label for="txtFDropStitch">Fault Drop Stitch</label>
				<asp:TextBox runat="server" ID="txtFDropStitch" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" >0</asp:TextBox>
			</div>
			<div class="col-sm-4">
				<label for="txtFYarn">Fault Yarn</label>
				<asp:TextBox runat="server" ID="txtFYarn" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" >0</asp:TextBox>
			</div>
				<div class="col-sm-4">
				<label for="txtFPressoff">Fault Press-off</label>
				<asp:TextBox runat="server" ID="txtFPressoff" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" >0</asp:TextBox>
			</div>
			<div class="col-sm-4">
				<label for="txtFQty">Fault Quantity</label>
				<asp:TextBox runat="server" ID="txtFQty" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" >0</asp:TextBox>
			</div>
			<div class="col-sm-4">
				<label for="txtFaultCollars">Fault Collars</label>
				<asp:TextBox runat="server" ID="txtFaultCollars" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" >0</asp:TextBox>
			</div>
			<div class="col-sm-4">
				<label for="txtFOthers">Fault Others</label>
				<asp:TextBox runat="server" ID="txtFOthers" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" >0</asp:TextBox>
			</div>
		</div>
		<br />
		<br />
		<div class="row">
			<div class="col-sm-4">
				<asp:Label ID="lblerrBweight" runat="server" ForeColor="Red"></asp:Label>
				<label for="txtBundleWeight">Bundle Weight</label>
				<asp:TextBox runat="server" ID="txtBundleWeight" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" TextMode="Number" >0</asp:TextBox>
			</div>
			<div class="col-sm-4">
				<label for="txtBundleWasteWeight">Bundle Waste Weight</label>
				<asp:TextBox runat="server" ID="txtBundleWasteWeight" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" TextMode="Number">0</asp:TextBox>
			</div>
			<div class="col-sm-4">
				<label for="txtBundleFaultWeight">Bundle Fault Weight</label>
				<asp:TextBox runat="server" ID="txtBundleFaultWeight" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" TextMode="Number">0</asp:TextBox>
			</div>
		</div>
		<br />
		<br />
		<div class="row">
			<div class="col-sm-4">
				<asp:LinkButton runat="server" ID="BtnCaptureBundle" CssClass="btn btn-default btn-lg" Visible="True">
                    <span class="glyphicon glyphicon-send" aria-hidden="true"></span>
                    Capture Bundle
				</asp:LinkButton>
			</div>
			<div class="col-sm-4">
		<asp:LinkButton runat="server" ID="btnBack" CssClass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-send" aria-hidden="true"></span>
                    Back
				</asp:LinkButton>
			</div>
		</div>	
	</div>
</asp:Content>
