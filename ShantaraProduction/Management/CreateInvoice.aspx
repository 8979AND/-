<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CreateInvoice.aspx.vb" Inherits="ShantaraProduction.CreateInvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<br />
		<h1>Create Invoice</h1>
		<br />
	<div class="row">
				<div class="col-sm-4">
				<label for="ddlBatch">Batch No </label>
				<asp:DropDownList ID="ddlBatch" CssClass="form-control" data-provide ="typeahead" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
					 AppendDataBoundItems="True" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged">
					<asp:ListItem Text="--Select Unprocessed Batch--" Value=""></asp:ListItem>
				</asp:DropDownList>
			</div>
		</div>
		<br />
		<asp:Label runat="server"  AssociatedControlID="grdvBatch4Inv" Visible="True" ID="lblBatch4Inv" CssClass="h2">Production Orders</asp:Label>
	<asp:Label ID="lblerrBatch4Inv" runat="server" Text="" ForeColor="Red"></asp:Label>
	<div id="DisplaygrdvBatch4Inv" style="width: 675px; overflow: auto; height: 300px;" runat="server">
		<asp:GridView ID="grdvBatch4Inv" runat="server" autogeneratecolumns="False" CellPadding="5" ForeColor="#333333" GridLines="Vertical" HorizontalAlign="Center" CellSpacing="30" PageSize="5">
			<AlternatingRowStyle BackColor="White" />
			<Columns>
				<asp:BoundField DataField="BundleNo" HeaderText="BundleNo" />
				<asp:BoundField DataField="ProductCode" HeaderText="ProductCode" />
				<asp:BoundField DataField="ActualJrsysCut" HeaderText="Actual Jerseys Cut" />
				<asp:BoundField DataField="OrderNo" HeaderText="OrderNo" />
				<asp:BoundField DataField="EntityName" HeaderText="Customer" />
				<asp:BoundField DataField="BatchNo" HeaderText="BatchNo" />
				<asp:BoundField DataField="StyleNo" HeaderText="Style" />
				<asp:BoundField DataField="Size" HeaderText="Size" />
				<asp:BoundField DataField="JrsysToCut" HeaderText="Jerseys to cut" />
				
				<asp:TemplateField HeaderText="Jerseys Delivered" ItemStyle-Width="30">
					<ItemTemplate>
						<asp:TextBox runat="server" ID="txtJD" OnTextChanged="txtJD_TextChanged" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="True" AutoPostBack="True" Text='<%# Eval("JrsysDelivered") %>' />
					</ItemTemplate>

<ItemStyle Width="30px"></ItemStyle>
				</asp:TemplateField>

				<%--<asp:BoundField DataField="ProductID" HeaderText="ProductID" ItemStyle-Width="150" />--%>
				<asp:TemplateField HeaderText="Cost"></asp:TemplateField>
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
	<div class="col-sm-4">
				<label for="txtjerseycost">Jersey cost</label>
                <asp:TextBox runat="server" ID="txtjerseycost" cssClass="form-control" style="height:34px; width:100%; max-width:none" Enabled="False" AutoPostBack="True" />
			</div>
	<br />
	<div class="row">
			<asp:LinkButton runat="server" ID="btncreateINV" CssClass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span> Create Invoice
			</asp:LinkButton>
		</div>
	</asp:Content>
