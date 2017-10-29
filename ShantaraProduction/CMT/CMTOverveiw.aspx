<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CMTOverveiw.aspx.vb" Inherits="ShantaraProduction.CMTOverveiw" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
		<div class="container-fluid">
		<h1>CMT Batches</h1>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<label for="ddlCMTStaff">Your Name </label>
				<asp:DropDownList ID="ddlCMTStaff" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
					OnSelectedIndexChanged="ddlCMTStaff_SelectedIndexChanged" AppendDataBoundItems="True">
					<asp:ListItem Text="--Select Your Name--" Value=""></asp:ListItem>
				</asp:DropDownList>
			</div>
		</div>
		<br />
		<div class="row">	
			<h2><asp:Label ID="LblJDisc" runat="server" Text=""></asp:Label></h2>
		</div>
			<br />
		<div class="row">
			<div id="displayCMTbatches" runat="server">
				<asp:Label runat="server" AssociatedControlID="grdvCMTbatches" Visible="false" ID="lblgrdbatch" CssClass="h2">Dyelots Captured for this Invoice</asp:Label>
				<asp:GridView ID="grdvCMTbatches" runat="server" Visible="False" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
					<AlternatingRowStyle BackColor="White" />
					<Columns>
						<asp:HyperLinkField Text="Select"
							DataNavigateUrlFields="BatchNo"
							DataNavigateUrlFormatString="~/CMT/CMTBundles.aspx?ID={0}" />
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
