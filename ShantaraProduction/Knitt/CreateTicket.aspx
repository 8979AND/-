<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CreateTicket.aspx.vb" Inherits="ShantaraProduction.CreateTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container-fluid">
		<h1>Create Ticket</h1>
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
				<label for="txtCTBatchNo">Quatity</label>
				<asp:TextBox runat="server" ID="txtCTBatchNo" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" AutoPostBack="True" />
			</div>
			<div class="col-sm-4">
				<label for="txtCTorderdate">Date Created(yyyy/mm/dd)</label>
				<asp:TextBox runat="server" ID="txtCTorderdate" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" AutoPostBack="True" />
			</div>
			<div class="col-sm-4">
				<label for="txtCTduedate">Required by date(yyyy/mm/dd)</label>
				<asp:TextBox runat="server" ID="txtCTduedate" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" AutoPostBack="True" />
			</div>
			<div class="col-sm-4">
				<label for="txtCTProduct">Product</label>
				<asp:TextBox runat="server" ID="txtCTProduct" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" AutoPostBack="True" />
			</div>
			<div class="col-sm-4">
				<label for="txtCTSize">Size</label>
				<asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" AutoPostBack="True" />
			</div>
			<div class="col-sm-4">
				<label for="txtCTQuantity">Quatity</label>
				<asp:TextBox runat="server" ID="txtCTQuantity" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" AutoPostBack="True" />
			</div>
		</div>
		<div class="row">
			<label for="ddlMachine">Yarn Colour</label>
			<asp:DropDownList ID="ddlMachine" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
				OnSelectedIndexChanged="ddlMachine_SelectedIndexChanged" Enabled="False" AppendDataBoundItems="True">
				<asp:ListItem Text="--Select Yarn Colour--" Value=""></asp:ListItem>
			</asp:DropDownList>
		</div>
		<br />
		<div class="row">
			<div id="displayInvoiceDyelots" runat="server">
				<asp:Label runat="server" AssociatedControlID="grdvInvoiceDyelots" Visible="false" ID="lblyarninvoice" CssClass="h2">Dyelots Captured for this Invoice</asp:Label>
				<asp:GridView ID="grdvInvoiceDyelots" runat="server" Visible="False" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
					<AlternatingRowStyle BackColor="White" />
					<Columns>
						<asp:HyperLinkField Text="Select"
							DataNavigateUrlFields="YarnID"
							DataNavigateUrlFormatString="~\Management\Edit_Yarn_Invoice.aspx?ID={0}" />
					</Columns>
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
			<div class="row">
				<div class="col-sm-4">
					<asp:LinkButton runat="server" ID="btnCreate" CssClass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>
                    Capture Product
					</asp:LinkButton>
				</div>
			</div>
		</div>
	</div>
		
			
</asp:Content>
