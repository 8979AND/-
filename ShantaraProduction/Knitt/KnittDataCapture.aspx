<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="KnittDataCapture.aspx.vb" Inherits="ShantaraProduction.KnittDataCapture" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container-fluid">
		<h1>Knitt Data Capture</h1>
		<br />
		<h3>><asp:Label ID="lblBundleNo" runat="server" Text="BundleNo: "></asp:Label></h3>
		<br />
		<div class="row">
				<asp:LinkButton runat="server" ID="btnStart" CssClass="btn btn-default">
                    <span class="glyphicon glyphicon-play" aria-hidden="true"></span>
                    Start
				</asp:LinkButton>
		</div>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<label for="txtorderNo">Order Number</label>
                <asp:TextBox runat="server" ID="txtorderNo" cssClass="form-control" style="height:34px; width:100%; max-width:none" Enabled="False" AutoPostBack="True" Visible="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtBatchNo">Batch Number</label>
                <asp:TextBox runat="server" ID="txtBatchNo" cssClass="form-control" style="height:34px; width:100%; max-width:none" Enabled="False" Visible="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtProdcode">Product Code</label>
			    <asp:TextBox runat="server" ID="txtProdcode" cssClass="form-control" style="height:34px; width:100%; max-width:none" Enabled="False" Visible="False" />
			</div>			
			<div class="col-sm-4">
				<label for="txtProdDescr">Product Description</label>
                <asp:TextBox runat="server" ID="txtProdDescr" cssClass="form-control" style="height:34px; width:100%; max-width:none" Enabled="False" Visible="False" />
			</div>		
			<div class="col-sm-4">
				<label for="txtPToMake">Panels To Make</label>
				<asp:TextBox runat="server" ID="txtPToMake" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" Visible="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtPattern">Pattern Name</label>
				<asp:TextBox runat="server" ID="txtPattern" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" Visible="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtPatternDescr">Pattern Description</label>
				<asp:TextBox runat="server" ID="txtPatternDescr" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" Visible="False" />
			</div>			
			<div class="col-sm-4">
				<label for="txtSize">Size</label>
				<asp:TextBox runat="server" ID="txtSize" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" Visible="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtSInstruction">Special Instruction</label>
				<asp:TextBox runat="server" ID="txtSInstruction" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" Visible="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtComponent">Component</label>
				<asp:TextBox runat="server" ID="txtComponent" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" Visible="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtQPpanel">Quantity Per Panel</label>
				<asp:TextBox runat="server" ID="txtQPpanel" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" Visible="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtKwidth">Knitt Width</label>
				<asp:TextBox runat="server" ID="txtKwidth" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" Visible="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtkLength">Knitt Length</label>
				<asp:TextBox runat="server" ID="txtkLength" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" Visible="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtNeedles">Needles</label>
				<asp:TextBox runat="server" ID="txtNeedles" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" Visible="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtCycles">Cycles</label>
				<asp:TextBox runat="server" ID="txtCycles" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" Visible="False" />
			</div>
		</div>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<label for="txtYarnColour">Yarn Colour</label>
				<asp:TextBox runat="server" ID="txtYarnColour" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" Visible="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtYarnDyelot">Yarn Dyelot</label>
				<asp:TextBox runat="server" ID="txtYarnDyelot" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" Visible="False" />
			</div>
		</div>
		<br />
		<div class="row">
			<div id="displaygrdvprevpnls" runat="server">
				<asp:Label runat="server" AssociatedControlID="grdvprevpnls" Visible="false" ID="lblyarninvoice" CssClass="h2">Dyelots Captured for this Invoice</asp:Label>
				<asp:GridView ID="grdvprevpnls" runat="server" Visible="False" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
					<AlternatingRowStyle BackColor="White" />
					<EditRowStyle BackColor="#7C6F57" />
					<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
					<HeaderStyle BackColor="#03A5D1" Font-Bold="False" ForeColor="White" />
					<PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
					<RowStyle BackColor="#E3EAEB" />
					<SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
					<SortedAscendingCellStyle BackColor="#F8FAFA" />
					<SortedAscendingHeaderStyle BackColor="#246B61" />
					<SortedDescendingCellStyle BackColor="#D4DFE1" />
					<SortedDescendingHeaderStyle BackColor="#15524A" />
				</asp:GridView>
			</div>
		</div>
		<br />
		<hr style="height:1px;border:none;color:#333;background-color:#333;" />
		<h4>Capture</h4>
		<div class="row">
			<div class="col-sm-4">
				<asp:Label ID="lblerroperator" runat="server" BorderColor="Red" ForeColor="Red"></asp:Label>
				<label for="ddlOperator">Operator Name </label>
				<asp:DropDownList ID="ddlOperator" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
					OnSelectedIndexChanged="ddlOperator_SelectedIndexChanged" AppendDataBoundItems="True" Visible="False">
					<asp:ListItem Text="--Select Operator--" Value=""></asp:ListItem>
				</asp:DropDownList>
			</div>
			<div class="col-sm-4">
				<asp:Label ID="lblerrshift" runat="server" ForeColor="Red"></asp:Label>
				<label for="ddlShift">Shift </label>
				<asp:DropDownList ID="ddlShift" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
					OnSelectedIndexChanged="ddlShift_SelectedIndexChanged" AppendDataBoundItems="True" Visible="False">
					<asp:ListItem Text="--Select Shift--" Value=""></asp:ListItem>
					<asp:ListItem>Day</asp:ListItem>
					<asp:ListItem>Night</asp:ListItem>
				</asp:DropDownList>
			</div>
			<div class="col-sm-4">
				<label for="txtMachineNo">Machine Number</label>
				<asp:TextBox runat="server" ID="txtMachineNo" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Visible="False" TextMode="Number" />
			</div>
			<div class="col-sm-4">
				<asp:Label ID="lblerrpanels" runat="server" ForeColor="Red"></asp:Label>
				<label for="txtPanelsMade">Panels Made</label>
				<asp:TextBox runat="server" ID="txtPanelsMade" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Visible="False" TextMode="Number">0</asp:TextBox>
			</div>
		</div>
		<br />
		<div class="row">
			<asp:Label ID="lblerror1" runat="server" ForeColor="Red"></asp:Label>
			<asp:Label ID="lblerror2" runat="server" ForeColor="Red"></asp:Label>
		</div>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<asp:LinkButton runat="server" ID="BtnCaptureBundle" CssClass="btn btn-default btn-lg" Visible="False">
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
