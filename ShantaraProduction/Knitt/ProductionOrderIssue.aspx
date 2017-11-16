<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ProductionOrderIssue.aspx.vb" Inherits="ShantaraProduction.ProductionOrderIssue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<label for="txtbatchno">BatchNo</label>
			<asp:TextBox ID="txtbatchno" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
	<br />
	<div id="dispProdOrderDetails" runat="server">
						<asp:Label runat="server" AssociatedControlID="grdvProdOrderDetails" Visible="true" ID="lblProdOrderDetails" CssClass="h2">Production Order Details</asp:Label>
						<asp:GridView ID="grdvProdOrderDetails" runat="server" Visible="False" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
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
	
	<div class="row">
			<div class="col-sm-4">
				<asp:LinkButton runat="server" ID="btnPrintTickets" CssClass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-send" aria-hidden="true"></span>
                    Print Tickets
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
</asp:Content>
