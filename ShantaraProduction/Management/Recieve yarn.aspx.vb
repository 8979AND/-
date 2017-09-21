Imports System.Data.SqlClient

Public Class Recieve_yarn
	Inherits System.Web.UI.Page


	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		'If Not IsPostBack Then
		getSupplier()

		'End If
	End Sub

	Private Sub getSupplier()
		ddlSupplier.AppendDataBoundItems = True
		Dim strQuery As String = "SELECT DISTINCT EntityID, EntityName from [GN - EntityMaster] WHERE EntityTypeID = 1"
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New SqlCommand()
		cmd.CommandType = CommandType.Text
		cmd.CommandText = strQuery
		cmd.Connection = con
		Try
			con.Open()
			ddlSupplier.DataSource = cmd.ExecuteReader()
			ddlSupplier.DataTextField = "EntityName"
			ddlSupplier.DataValueField = "EntityID"
			ddlSupplier.DataBind()
		Catch ex As Exception
			Throw ex
		Finally
			con.Close()
			con.Dispose()
		End Try
	End Sub

	Protected Sub ddlSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSupplier.SelectedIndexChanged
		txtdate.Enabled = True
		txtInvoice.Enabled = True
		txtYtype.Enabled = True
		txtTtweight.Enabled = True
		txtTtcartons.Enabled = True
		txtkgprice.Enabled = True
		txtYdyelot.Enabled = True
		ddlYcolour.Enabled = True
		txtYweight.Enabled = True
		txtYcartons.Enabled = True
	End Sub
	Private Sub grdvInvoiceDBPopulate()

	End Sub
	Private Sub grdvInvoiceDyelotsPopulate()
		Dim cmd As New SqlCommand
		Dim Adapter As New SqlDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())

		grdvInvoiceDyelots.Visible = True
		'btnBack.Visible = False
		'btnAddUser.Visible = True		
		SQL = "SELECT YM.YarnID, YM.YarnDyelot, YC.YarnColour, YM.YarnPurchaceWeight, YM.YarnPurchaseCartons, YM.CurrentWeight, YM.CurrentCartons
        FROM [YN - Yarn Master] YM JOIN [YN - Yarn Colour Defns] YC
        On YM.YarnColourID = YC.YarnColourID 
        WHERE YM.SupplierInvoiceNo = 'NV180000119'"
		con.Open()
		cmd.Connection = con
		cmd.CommandText = Sql

		Adapter.SelectCommand = cmd
		Adapter.Fill(Data)

		grdvInvoiceDyelots.DataSource = Data
		grdvInvoiceDyelots.DataBind()

	End Sub

	Protected Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
		grdvInvoiceDyelotsPopulate()
	End Sub
End Class




