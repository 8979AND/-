<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CreateBatch.aspx.vb" Inherits="ShantaraProduction.CreateBatch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container-fluid">
<h1>Create Ticket</h1>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<label for="ddlBProduct">Product </label>
				<asp:DropDownList ID="ddlBProduct" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
					 AppendDataBoundItems="True" OnSelectedIndexChanged="ddlBProduct_SelectedIndexChanged">
					<asp:ListItem Text="--Select Product--" Value=""></asp:ListItem>
				</asp:DropDownList>
			</div>
		</div>
		<br />
		<div class="row">
			<div id="DisplayProductionOrders" runat="server">
				<asp:Label runat="server" AssociatedControlID="grdvProductionOrders" Visible="True" ID="lblProductionOrders" CssClass="h2">Production Orders</asp:Label>
				<asp:GridView ID="grdvProductionOrders" runat="server" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
					<AlternatingRowStyle BackColor="White" />
					<Columns>
						<asp:TemplateField>
							<ItemTemplate>
								<asp:CheckBox ID="chkRow" runat="server" />
							</ItemTemplate>
						</asp:TemplateField>
						<%--<asp:BoundField DataField="ProductID" HeaderText="ProductID" ItemStyle-Width="150" />--%>
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
