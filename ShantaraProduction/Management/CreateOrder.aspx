<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CreateOrder.aspx.vb" Inherits="ShantaraProduction.CreateOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container-fluid">
		<h1>Create New Order</h1>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<label for="ddlCustomer">Customer </label>
				<asp:DropDownList ID="ddlCustomer" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
					OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged" AppendDataBoundItems="True">
					<asp:ListItem Text="--Select Customer--" Value=""></asp:ListItem>
				</asp:DropDownList>
			</div>
			<div class="col-sm-4">
				<label for="txtorderdate">Date Created(dd/mm/yyyy)</label>
				<asp:TextBox runat="server" ID="txtorderdate" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" AutoPostBack="True" TextMode="DateTime" />
			</div>
			<div class="col-sm-4">
				<label for="txtduedate">Required by date(dd/mm/yyyy)</label>
				<asp:TextBox runat="server" ID="txtduedate" type="Date" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" AutoPostBack="True" TextMode="DateTime" />
			</div>
			<div class="col-sm-4">
				<asp:Label ID="lblerrorderno" runat="server" Text="" ForeColor="Red"></asp:Label>
				<label for="txtOrderNo">Order Number</label>
				<asp:TextBox runat="server" ID="txtOrderNo" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" AutoPostBack="True" />
			</div>
			<div class="col-sm-4">
				<div >
				<asp:Label ID="lblerrSI" runat="server" Text="" ForeColor="Red"></asp:Label>
				<label for="ddlSI">Special Instructions</label>
				<asp:DropDownList ID="ddlSI" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
					Enabled="False" AppendDataBoundItems="True">
					<asp:ListItem Text="--Select Special Instructions--" Value=""></asp:ListItem>
				</asp:DropDownList>
				</div>
			</div>
			<div class="col-sm-4">
				<asp:Label ID="lblerrCMTSI" runat="server" Text="" ForeColor="Red"></asp:Label>
				<label for="ddlCMTSI">CMT Special Instructions</label>
				<asp:DropDownList ID="ddlCMTSI" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
					Enabled="False" AppendDataBoundItems="True">
					<asp:ListItem Text="--Select CMT Special Instructions--" Value=""></asp:ListItem>
				</asp:DropDownList>
			</div>
			<div class="col-sm-4">
				<asp:Label ID="lblerrprod" runat="server" Text="" ForeColor="Red"></asp:Label>
				<label for="ddlProduct">Product</label>
				<asp:DropDownList ID="ddlProduct" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true" AppendDataBoundItems="True" Enabled="False">
					<asp:ListItem Text="--Select Product--" Value=""></asp:ListItem>
				</asp:DropDownList>
			</div>
		</div>
		<br />
		<hr style="height: 1px; border: none; color: #333; background-color: #333;" />
		<div class="row">
			<div class="col-sm-4">
				<asp:Label ID="lblerrqty" runat="server" ForeColor="Red"></asp:Label>
				<label for="txtQuantity">Quatity</label>
				<asp:TextBox runat="server" ID="txtQuantity" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" AutoPostBack="True" TextMode="Number" >0</asp:TextBox>
			</div>
			<div class="col-sm-4">
				<label for="txtOrderQtyBalance">Order Quantity Balance</label>
				<asp:TextBox runat="server" ID="txtOrderQtyBalance" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" AutoPostBack="True" Text="0" TextMode="Number" />
			</div>
			<div class="col-sm-4">
				<asp:Label ID="lblerrsize" runat="server" Text="" ForeColor="Red"></asp:Label>
				<label for="ddlSize">Size</label>
				<asp:DropDownList ID="ddlSize" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="False"
					Enabled="False" AppendDataBoundItems="True">
					<asp:ListItem Text="--Select Size--" Value=""></asp:ListItem>
				</asp:DropDownList>
			</div>
		</div>
			<div class="row">
				<div class="col-sm-4">
					<asp:Label ID="lblerrother" runat="server" Text="" ForeColor="Red"></asp:Label>
					<asp:LinkButton runat="server" ID="btnCreate" CssClass="btn btn-default btn-lg" Enabled="True" Visible="False">
                    <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>
                    Capture Product
					</asp:LinkButton>
				</div>
			</div>
			<br />
			<div class="row">
				<div id="displayOrderProducts" runat="server">
					<asp:Label runat="server" AssociatedControlID="grdvOrderProducts" Visible="false" ID="lblyarninvoice" CssClass="h2">Dyelots Captured for this Invoice</asp:Label>
					<asp:GridView ID="grdvOrderProducts" runat="server" Visible="False" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
						<AlternatingRowStyle BackColor="White" />
						<Columns>
							<asp:HyperLinkField Text="Select"
								DataNavigateUrlFields="KnittingOrderID"
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
				</div>
			</div>
	</div>
<%--	<script type="text/javascript">
		$(function () {
			$('#ddlSI').typeahead();
		});
	</script>--%>
</asp:Content>
