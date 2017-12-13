<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ApproveJrsyDiff.aspx.vb" Inherits="ShantaraProduction.ApproveJrsyDiff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container-fluid">
		<br />
		<h1>Approve Jersey Difference</h1>
		<br />
		<asp:SqlDataSource ID="ReasonDataSource" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=&quot;|DataDirectory|\Shantara Production IT.mdb&quot;" ProviderName="System.Data.OleDb" SelectCommand="SELECT [ReasonID], [Description], [JDiffTypeID] FROM [JrsyDiffReasonDef] WHERE ([JDiffTypeID] = ?)">
			<SelectParameters>
				<asp:QueryStringParameter DefaultValue="1" Name="JDiffTypeID" QueryStringField="1" Type="Int32" />
			</SelectParameters>
		</asp:SqlDataSource>
		<asp:Label runat="server" AssociatedControlID="grdvJDiff" Visible="True" ID="lblBatch4Inv" CssClass="h2">Production Orders</asp:Label>
		<asp:Label ID="lblerrJDiff" runat="server" Text="" ForeColor="Red"></asp:Label>
		<div id="DisplaygrdvJDiff" style="width: 675px; overflow: auto; height: 300px;" runat="server">
			<asp:GridView ID="grdvJDiff" runat="server" AutoGenerateColumns="False" CellPadding="5" ForeColor="#333333" GridLines="Vertical" HorizontalAlign="Center" CellSpacing="30" PageSize="5">
				<AlternatingRowStyle BackColor="White" />
				<Columns>
					<asp:BoundField DataField="BundleNo" HeaderText="BundleNo" />
<%--					<asp:BoundField DataField="ProductCode" HeaderText="ProductCode" />--%>
					<asp:BoundField DataField="Size" HeaderText="Size" />
					<asp:BoundField DataField="JrsysToCut" HeaderText="Jerseys to cut" />
					<asp:TemplateField HeaderText="Reason" ItemStyle-Width="30">
						<ItemTemplate>
							<asp:DropDownList ID="ddlreason" CssClass="form-control" Style="height: 34px; width: 100%; max-width: 150px" runat="server" AutoPostBack="true"
								AppendDataBoundItems="True" DataSourceID="ReasonDataSource" DataTextField="Description" DataValueField="ReasonID">
								<asp:ListItem Text="--Select Reason--" Value=""></asp:ListItem>
							</asp:DropDownList>
						</ItemTemplate>
						<ItemStyle Width="45px"></ItemStyle>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Other" ItemStyle-Width="30">
						<ItemTemplate>
							<asp:TextBox runat="server" ID="txtOther" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="True" AutoPostBack="True" Text='<%# Eval("ReasonOther") %>' />
						</ItemTemplate>
						<ItemStyle Width="30px"></ItemStyle>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Actual Jerseys Cut" ItemStyle-Width="30">
						<ItemTemplate>
							<asp:TextBox runat="server" ID="txtAJC" CssClass="form-control" Style="height: 34px; width: 100%; max-width: none" Enabled="True" AutoPostBack="True" Text='<%# Eval("ActualJrsysCut") %>' />
						</ItemTemplate>
						<ItemStyle Width="30px"></ItemStyle>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Other" ItemStyle-Width="30">
						<ItemTemplate>
							<asp:LinkButton runat="server" ID="btnAccept" CssClass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span> Accept/changed
							</asp:LinkButton>
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
	</div>
</asp:Content>
