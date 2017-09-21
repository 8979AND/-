<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Recieve yarn.aspx.vb" Inherits="ShantaraProduction.Recieve_yarn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container-fluid">
		<h1>Recieve Yarn Stock</h1>
        <br />
		<div class="row">
			<div class="col-sm-4">
				<label for="ddlSupplier">Supplier </label>
<asp:DropDownList ID="ddlSupplier" CssClass="form-control" style="height:34px; width:100%; max-width:none" runat="server" AutoPostBack = "true"
             OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged">
<asp:ListItem Text = "--Select Supplier--" Value = ""></asp:ListItem>
</asp:DropDownList>			</div>
			
		</div>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<label for="txtdate">Purchase Date</label>
                <asp:TextBox runat="server" ID="txtdate" cssClass="form-control" style="height:34px; width:100%; max-width:none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtInvoice">Invoice Number</label>
                <asp:TextBox runat="server" ID="txtInvoice" cssClass="form-control" style="height:34px; width:100%; max-width:none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtYtype">Yarn Type</label>
                <asp:TextBox runat="server" ID="txtYtype" cssClass="form-control" style="height:34px; width:100%; max-width:none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtTtweight">Total Transaction weight </label>
                <asp:TextBox runat="server" ID="txtTtweight" cssClass="form-control" style="height:34px; width:100%; max-width:none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtTtcartons">Total Transaction Cartons </label>
                <asp:TextBox runat="server" ID="txtTtcartons" cssClass="form-control" style="height:34px; width:100%; max-width:none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtkgprice">Price per KG</label>
                <asp:TextBox runat="server" ID="txtkgprice" cssClass="form-control" style="height:34px; width:100%; max-width:none" Enabled="False" />
			</div>			
		</div>
		<br />
		<br />
		<h4>Capture</h4>
		<div class="row">
			<div class="col-sm-4">
				<label for="txtYdyelot">Yarn Dyelot</label>
				<asp:TextBox runat="server" ID="txtYdyelot" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="ddlYcolour">Yarn Colour</label>
				<asp:DropDownList ID="ddlYcolour" CssClass="form-control" runat="server" DataSourceID="sqlYcolour" DataTextField="YarnColour" DataValueField="YarnColour" Enabled="False"></asp:DropDownList>
				<asp:SqlDataSource ID="sqlYcolour" runat="server" ConnectionString="<%$ ConnectionStrings:ShantaraDBConnection %>" SelectCommand="SELECT [YarnColour] FROM [YN - Yarn Colour Defns]"></asp:SqlDataSource>
			</div>
			<div class="col-sm-4">
				<label for="txtYweight">Yarn Weight</label>
				<asp:TextBox runat="server" ID="txtYweight" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtYcartons">Yarn Cartons</label>
				<asp:TextBox runat="server" ID="txtYcartons" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtYCweight">Current Weight</label>
				<asp:TextBox runat="server" ID="txtYCweight" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>
			<div class="col-sm-4">
				<label for="txtYCcartons">Current Cartons</label>
				<asp:TextBox runat="server" ID="txtYCcartons" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" />
			</div>					
		</div>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<asp:LinkButton runat="server" ID="btnCapture" CssClass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-send" aria-hidden="true"></span>
                    Capture Dyelot
				</asp:LinkButton>
			</div>
		</div>
		<br />
		<br />
		<div class="row">
			<div id="displayInvoiceDyelots" runat="server">
                     <asp:Label runat="server" AssociatedControlID="grdvInvoiceDyelots" Visible="false" ID="lblMyTickets" CssClass="h2">Dyelots Captured for this Invoice</asp:Label>
                     <asp:GridView ID="grdvInvoiceDyelots" runat="server" Visible="False" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
                          <AlternatingRowStyle BackColor="White" />
                         <Columns>
                             <%--<asp:HyperLinkField Text="Select" 
                            DataNavigateUrlFields="Id"
                            DataNavigateUrlFormatString="~\Ticketing\TicketDetails.aspx?ID={0}" />--%>
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

 <script> 
	 {
		$("#ddlYcolour").chosen
	 }
	 	
	</script>
 
	
</asp:Content>
