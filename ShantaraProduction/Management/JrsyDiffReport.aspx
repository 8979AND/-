<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="JrsyDiffReport.aspx.vb" Inherits="ShantaraProduction.JrsyDiffReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container-fluid">
		<br />
		<br />
		<br />
		<br />
		<h1>Approve Jersey Difference</h1>
		<br />
		<div class="row">
			<div class="col-sm-4">
				<asp:RadioButtonList ID="rblJDPeriod" runat="server" AutoPostBack="true" Visible="True" AppendDataBoundItems="True">
			<asp:ListItem Text="Today" Value="1"></asp:ListItem>
			<asp:ListItem Text="Past 7 days" Value="2"></asp:ListItem>
			<asp:ListItem Text="This month" Value="3"></asp:ListItem>
			<asp:ListItem Text="Custom" Value="4"></asp:ListItem>
			</asp:RadioButtonList>
			</div>
			<div class="col-sm-4">
				<asp:Label ID="lbltotJD" runat="server" Text="Total Jersy Difference logs" Visible="True"></asp:Label>
				<asp:TextBox runat="server" ID="txtTotJD" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="False" TextMode="Number" Visible="True" />

			</div>
		</div>
		
		<div class="row">
			<div class="col-sm-4">
				<asp:Label ID="lblFrom" runat="server" Text="From Date" Visible="False"></asp:Label>
				<asp:TextBox runat="server" ID="txtfrom" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="True" AutoPostBack="True" TextMode="Date" Visible="False" />
			</div>
			<div class="col-sm-4">
				<asp:Label ID="lblto" runat="server" Text="To Date" Visible="False"></asp:Label>
				<asp:TextBox runat="server" ID="txtto" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="True" TextMode="Date" Visible="False" />
			</div>
			<div class="col-sm-4">
				<asp:LinkButton runat="server" ID="BtnCustomperiod" CssClass="btn btn-default btn-lg" Visible="False">
                    <span class="glyphicon glyphicon-hourglass" aria-hidden="true"></span>
                    Enter
			</asp:LinkButton>
			</div>		
		</div>
		<br />
		<asp:GridView ID="grdvJDReport" runat="server" AutoPostBack="true"  AutoGenerateColumns="False" CellPadding="5" ForeColor="#333333" GridLines="Vertical" HorizontalAlign="Center" CellSpacing="30" PageSize="5">
				<AlternatingRowStyle BackColor="White" />
				<Columns>
					<asp:BoundField DataField="BundleNo" HeaderText="BundleNo" />
					<asp:BoundField DataField="Size" HeaderText="Size" />
					<asp:BoundField DataField="JrsysToCut" HeaderText="Jerseys to cut" />
					<asp:BoundField DataField="Description" HeaderText="Reason" />
					<asp:BoundField DataField="ReasonOther" HeaderText="Reason for Other" />
					<asp:BoundField DataField="ActualJrsysCut" HeaderText="Actual Jerseys Cut" />
					<asp:BoundField DataField="Employee" HeaderText="Employee" />
					<asp:BoundField DataField="JDDate" HeaderText="Date" />
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
</asp:Content>
