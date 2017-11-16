<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CMTBundles.aspx.vb" Inherits="ShantaraProduction.CMTBundles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container-fluid">
		<h1>CMT - Bundles</h1>
		<table class="table" style="width: 100%">
			<tr>
				<td>
					<div id="dispBundlesForCMT" runat="server">
						<asp:Label runat="server" AssociatedControlID="grdvBundlesForCMT" Visible="true" ID="Label1" CssClass="h2">Bundles To Do</asp:Label>
						<asp:GridView ID="grdvBundlesForCMT" runat="server" Visible="False" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
							<AlternatingRowStyle BackColor="White" />
							<Columns>
								<asp:HyperLinkField Text="Select"
									
									DataNavigateUrlFields="BundleNo"
									DataNavigateUrlFormatString="~/CMT/CMTDataCapture.aspx?ID={0}" />
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
				</td>
				<td>
					<div id="displayBundlesCMTDone" runat="server">
						<asp:Label runat="server" AssociatedControlID="grdvBundlesCMTDone" Visible="true" ID="lblOpenTickets" CssClass="h2">Bundles Done</asp:Label>
						<asp:GridView ID="grdvBundlesCMTDone" runat="server" Visible="False" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
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
				</td>
			</tr>
		</table>
	</div>
</asp:Content>
