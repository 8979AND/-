﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="DisplayBatchBundles.aspx.vb" Inherits="ShantaraProduction.DisplayBatchs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container-fluid">
		<h1>Batch Bundles for Production</h1>
		<br />
		<div class="row">
			<div id="displaybatchprodnBundle" runat="server">
				<asp:Label runat="server" AssociatedControlID="grdvbatchprodnBundle" Visible="false" ID="lblyarninvoice" CssClass="h2">Dyelots Captured for this Invoice</asp:Label>
				<asp:GridView ID="grdvbatchprodnBundle" runat="server" Visible="False" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
					<AlternatingRowStyle BackColor="White" />
					<Columns>
						<asp:HyperLinkField Text="Select"
							DataNavigateUrlFields="BundleNo"
							DataNavigateUrlFormatString="~\Knitt\KnittDataCapture.aspx?ID={0}" />
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
		</div>
	</div>
</asp:Content>
