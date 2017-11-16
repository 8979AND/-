<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CreateBatch.aspx.vb" Inherits="ShantaraProduction.CreateBatch" MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="container-fluid">
<h1>Create Batch</h1>
		<br />
<%--		<link rel="stylesheet" href='http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'
    media="screen" />
<script type="text/javascript" src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
<script type="text/javascript" src='http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
<script type="text/javascript" src="http://cdn.rawgit.com/bassjobsen/Bootstrap-3-Typeahead/master/bootstrap3-typeahead.min.js"></script>
<link rel="Stylesheet" href="https://twitter.github.io/typeahead.js/css/examples.css" />
		<script type="text/javascript">
			$(document).on('ready', function () {
				$('#txtProduct').typeahead({
					hint: true,
					highlight: true,
					minLength: 1
					, source: function (request, response) {
						$.ajax({
							url: '<%=ResolveUrl("~/Knitt/CreateBatch.aspx/Gettproduct") %>',
					data: "{ 'prefix': '" + request + "'}",
					dataType: "json",
					type: "POST",
					contentType: "application/json; charset=utf-8",
					success: function (data) {
						items = [];
						map = {};
						$.each(data.d, function (i, item) {
							var id = item.split('-')[1];
							var name = item.split('-')[0];
							map[name] = { id: id, name: name };
							items.push(name);
						});
						response(items);
						$(".dropdown-menu").css("height", "auto");
					},
					error: function (response) {
						alert(response.responseText);
					},
					failure: function (response) {
						alert(response.responseText);
					}
				});
			},
			updater: function (item) {
				$('[id*=hfProductId]').val(map[item].id);
				return item;
			}
				});
			});
		</script>--%>
		<div class="row">
				<div class="col-sm-4">
				<label for="ddlBProduct">Product </label>
				<asp:DropDownList ID="ddlBProduct" CssClass="form-control" data-provide ="typeahead" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
					 AppendDataBoundItems="True" OnSelectedIndexChanged="ddlBProduct_SelectedIndexChanged">
					<asp:ListItem Text="--Select Product--" Value=""></asp:ListItem>
				</asp:DropDownList>
				<asp:HiddenField ID="hfProductId" runat="server" />
			</div>
		</div>
		<br />
		<table class="table" style="width: 100%">
			<tr>
				<td>
					<asp:Label runat="server" AssociatedControlID="grdvProductionOrders" Visible="True" ID="lblProductionOrders" CssClass="h2">Production Orders</asp:Label>
					<asp:Label ID="lblerrPO" runat="server" Text="" ForeColor="Red"></asp:Label>
					<div id="DisplayProductionOrders" style="width: 675px; overflow: auto; height: 300px;" runat="server">
						<asp:GridView ID="grdvProductionOrders" runat="server"  CellPadding="5" ForeColor="#333333" GridLines="Vertical" HorizontalAlign="Center" CellSpacing="10" PageSize="15" >
							<AlternatingRowStyle BackColor="White" />
							<Columns>
								<asp:TemplateField>
									<ItemTemplate>
										<asp:CheckBox ID="chkRow" runat="server" AutoPostBack=True oncheckedchanged="chkRow_CheckedChanged"  />
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
				</td>
				<td>
					<div class="row">
						<asp:Label runat="server" AssociatedControlID="grdvisyarnavailable" Visible="True" ID="lblisyarnavailable" CssClass="h2">Yarn Available</asp:Label>
						<asp:Label ID="lblerrYA" runat="server" Text="" ForeColor="Red"></asp:Label>
						<div id="Displayisyarnavailable" style="width: 675px; overflow: auto; height: 300px;" runat="server">
							<asp:GridView ID="grdvisyarnavailable" runat="server" Style="column-width: auto;" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
								<AlternatingRowStyle BackColor="White" />
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<asp:CheckBox ID="chkRowy" runat="server" AutoPostBack="True" OnCheckedChanged="chkRowy_CheckedChanged" />
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
					<br />
					
				</td>
			</tr>
			<tr>
				<td>

				</td>
				<td>
					<div class="row">
						<asp:Label runat="server" AssociatedControlID="grdvisvariousdyelot" Visible="True" ID="lblisvariousdyelot" CssClass="h2">Various Dyelots</asp:Label>
						<asp:Label ID="lblerrvd" runat="server" Text="" ForeColor="Red"></asp:Label>
						<div id="Div2" style="width: 675px; overflow: auto; height: 300px;" runat="server">
							<asp:GridView ID="grdvisvariousdyelot" runat="server" Style="column-width: auto;" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
								<AlternatingRowStyle BackColor="White" />
								<Columns>
									<asp:TemplateField>
										<ItemTemplate>
											<asp:CheckBox ID="chkRowvd" runat="server" AutoPostBack="True" OnCheckedChanged="chkRowvd_CheckedChanged" />
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
				</td>
			</tr>
		</table>
		<br />
	<div class="row">
			<label for="txtYarnReq">Yarn Required</label>
			<asp:TextBox ID="txtYarnReq" runat="server" CssClass="form-control" TextMode="Number" Enabled="False"></asp:TextBox>
		<label for="txtOrderTot">Order Total</label>
			<asp:TextBox ID="txtOrderTot" runat="server" CssClass="form-control" TextMode="Number" Enabled="False"></asp:TextBox>
	</div>
		<br />
		<br />
		<div class="row">
			<div class="col-sm-4">
				<asp:LinkButton runat="server" ID="BtnCreateBatch" CssClass="btn btn-default btn-lg" Visible="True">
                    <span class="glyphicon glyphicon-send" aria-hidden="true"></span>
                    Create Batch
				</asp:LinkButton>
			</div>
			<div class="col-sm-4">
		<asp:LinkButton runat="server" ID="btnBack" CssClass="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-left" aria-hidden="true"></span>
                    Back
				</asp:LinkButton>
			</div>
		</div>	
	</div>
	<asp:Label runat="server" AssociatedControlID="grdvmachincomp" Visible="True" ID="Label2" CssClass="h2">for components of machineallocation</asp:Label>
					<div id="Div1" style="width: 675px; overflow: auto; height: 300px;" runat="server">
						<asp:GridView ID="grdvmachincomp" runat="server" Style="column-width: auto;" CellPadding="5" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CellSpacing="1" PageSize="15">
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
<%--	<script>
		$(#ddlBProduct).ajaxComplete

	</script>--%>
</asp:Content>
