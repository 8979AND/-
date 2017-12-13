<%@ Page Title="" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"  CodeBehind="CheckOverview.aspx.vb" Inherits="ShantaraProduction.DisplayJerseyoverview"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container-fluid">
		<br />
		<br />
		<br />
		<h1>Check store - Batches</h1>
		<table class="table" style="width: 100%">
			<tr>
				<td>
					<div id="disprecievedjersey" runat="server">
						<asp:Label runat="server" AssociatedControlID="grdvFromKnitt" Visible="true" ID="Label1" CssClass="h2">To be checked</asp:Label>
						<asp:GridView ID="grdvFromKnitt" runat="server" Visible="False" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
							<AlternatingRowStyle BackColor="White" />
							<Columns>
								<asp:HyperLinkField Text="Select"
									DataNavigateUrlFields="BatchNo"
									DataNavigateUrlFormatString="~\CheckStore\CheckBundles.aspx?ID={0}" />
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
					<div id="displayreadyforcmt" runat="server">
						<asp:Label runat="server" AssociatedControlID="grdvReadyForCMT" Visible="true" ID="lblOpenTickets" CssClass="h2">Ready for CMT</asp:Label>
						<asp:GridView ID="grdvReadyForCMT" runat="server" Visible="False" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
							<AlternatingRowStyle BackColor="White" />
							<EditRowStyle BackColor="#995c00" />
							<FooterStyle BackColor="#800000" Font-Bold="True" ForeColor="White" />
							<HeaderStyle BackColor="#cc0000" Font-Bold="False" ForeColor="White" />
							<PagerStyle BackColor="#b30047" ForeColor="White" HorizontalAlign="Center" />
							<RowStyle BackColor="#ffe6e6" />
							<SelectedRowStyle BackColor="#ffff99" Font-Bold="True" ForeColor="#333333" />
							<SortedAscendingCellStyle BackColor="#ffb3b3" />
							<SortedAscendingHeaderStyle BackColor="#246B61" />
							<SortedDescendingCellStyle BackColor="#D4DFE1" />
							<SortedDescendingHeaderStyle BackColor="#15524A" />
						</asp:GridView>
					</div>
					<br />
					<asp:LinkButton runat="server" ID="btnSend" CssClass="btn btn-default">
                    <span class="glyphicon glyphicon-play" aria-hidden="true"></span>
                    Send to CMT
				</asp:LinkButton>
				</td>
			</tr>
		</table>
	</div>
</asp:Content>
