<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ProductionOrderIssue.aspx.vb" Inherits="ShantaraProduction.ProductionOrderIssue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<br />
	<div class="row">
		<div class="col-sm-4">
			<label for="txtbatchno">BatchNo</label>
		<asp:TextBox ID="txtbatchno" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
		</div>
	</div>
	<br />
	<asp:SqlDataSource ID="MachineGroupDataSource" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=&quot;|DataDirectory|\Shantara Production IT.mdb&quot;;OLE DB Services=-4" ProviderName="System.Data.OleDb" SelectCommand="SELECT [MachineNumber] FROM [KN - Knitting Machine Data]"></asp:SqlDataSource>
	<br />
	<asp:Label runat="server" AssociatedControlID="grdvMachineGroupAllocation" Visible="True" ID="lblMachineGroupAllocation" CssClass="h2">Production Orders</asp:Label>
	<asp:Label ID="lblerrMGA" runat="server" Text="" ForeColor="Red"></asp:Label>
	<div id="DisplayMachineGroupAllocation" style="width: 675px; overflow: auto; height: 300px;" runat="server">
		<asp:GridView ID="grdvMachineGroupAllocation" runat="server" CellPadding="5" ForeColor="#333333" GridLines="Vertical" HorizontalAlign="Center" CellSpacing="10" PageSize="15">
			<AlternatingRowStyle BackColor="White" />
			<Columns>
				<asp:TemplateField HeaderText="Machine number">
					<ItemTemplate>
						<asp:DropDownList ID="ddlMGA" CssClass="form-control" Style="height: 34px; width: 100%; max-width: 150px" runat="server" AutoPostBack="true"
							AppendDataBoundItems="True" DataSourceID="MachineGroupDataSource" DataTextField="MachineNumber" DataValueField="MachineNumber">
							<asp:ListItem Text="--Select Machine Number--" Value=""></asp:ListItem>
						</asp:DropDownList>
					</ItemTemplate>
					<ControlStyle BackColor="#FFCC66" ForeColor="Black" />
					<HeaderStyle ForeColor="White" />
				</asp:TemplateField>
				<%--<asp:BoundField DataField="ProductID" HeaderText="ProductID" ItemStyle-Width="150" />--%>
			</Columns>
			<EditRowStyle BackColor="#7C6F57" />
			<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
			<HeaderStyle BackColor="#6699ff" Font-Bold="False" ForeColor="White" />
			<PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
			<RowStyle BackColor="#E3EAEB" />
			<SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
			<SortedAscendingCellStyle BackColor="#F8FAFA" />
			<SortedAscendingHeaderStyle BackColor="#246B61" />
			<SortedDescendingCellStyle BackColor="#D4DFE1" />
			<SortedDescendingHeaderStyle BackColor="#15524A" />
		</asp:GridView>
	</div>

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
