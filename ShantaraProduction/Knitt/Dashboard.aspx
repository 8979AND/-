<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Dashboard.aspx.vb" Inherits="ShantaraProduction.Dashboard2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h1>Knitt Production Dashboard</h1>
	<br />
	<h2>Orders to Be Produced</h2>
	<br />
	<p>Date Recieved/ /Customer/ /gtProduct/ /Description/ /Quantity/ /Deadline</p>
	<asp:GridView ID="grdvInvoiceDyelots" runat="server" Visible="False" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
		<AlternatingRowStyle BackColor="White" />
		<Columns>
			<%--<asp:HyperLinkField Text="Select"
				DataNavigateUrlFields="YarnID"
				DataNavigateUrlFormatString="~\Management\Edit_Yarn_Invoice.aspx?ID={0}" />--%>
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
	<h2>Orders In Progress</h2>
	<br />
	<p>Date started/ /recieved to start Delay/ /Product&nbsp;&nbsp;&nbsp;&nbsp; / /Component/ /total Quantity/ /Quantity Remaining/ /Machine/ /Days left before deadline</p>
	<p>12/07/2017/ /6 days&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;/ /1852 Navy / /Body&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; / / 50&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; / / 10 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; / /cms5&nbsp;&nbsp;&nbsp;&nbsp; / /3 days</p>
	<asp:GridView ID="GridView1" runat="server" Visible="False" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
					<AlternatingRowStyle BackColor="White" />
					<Columns>
						<%--<asp:HyperLinkField Text="Select"
							DataNavigateUrlFields="YarnID"
							DataNavigateUrlFormatString="~\Management\Edit_Yarn_Invoice.aspx?ID={0}" />--%>
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
	<h2>Orders waiting for Check Store collection</h2>
		<br />
	<asp:GridView ID="GridView2" runat="server" Visible="False" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
					<AlternatingRowStyle BackColor="White" />
					<Columns>
						<%--<asp:HyperLinkField Text="Select"
							DataNavigateUrlFields="YarnID"
							DataNavigateUrlFormatString="~\Management\Edit_Yarn_Invoice.aspx?ID={0}" />--%>
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
</asp:Content>
