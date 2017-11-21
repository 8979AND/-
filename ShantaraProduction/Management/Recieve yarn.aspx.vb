Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class Recieve_yarn
	Inherits System.Web.UI.Page
	Private cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not IsPostBack Then
			getSupplier()
			getYtype()
			getColour()
			If Session("editYarn") = 1 Then
				txtInvoice.Text = Session("Invoice_number")
				txtdate.Text = Session("YI_date")
				txtkgprice.Text = Session("YI_price")
				ddlSupplier.SelectedItem.Text = Session("YI_Supplier")
				ddlYtype.SelectedItem.Text = Session("YI_Ytype")
				grdvInvoiceDyelotsPopulate()
				txtYdyelot.Enabled = True
				ddlYcolour.Enabled = True
				txtYweight.Enabled = True
				txtYcartons.Enabled = True
			Else

			End If
			Session("editYarn") = 0
			txtdate.Text = DateTime.Now.Date
		End If

	End Sub

	Private Sub getSupplier()
		Dim strQuery As String = "SELECT DISTINCT EntityID, EntityName from [GN - EntityMaster] WHERE EntityTypeID = 1"
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand()
			'Dim cmd As New SqlCommand()

			If IsPostBack = False Then
				ddlSupplier.AppendDataBoundItems = True
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
				End Try
			End If
		End Using
	End Sub

	Private Sub getColour()


		Dim strQuery As String = "SELECT YarnColourID, YarnColour from [YN - Yarn Colour Defns]"
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand()
			'Dim cmd As New SqlCommand()
			If IsPostBack = False Then
				ddlYcolour.AppendDataBoundItems = True
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strQuery
				cmd.Connection = con
				Try
					con.Open()
					ddlYcolour.DataSource = cmd.ExecuteReader()
					ddlYcolour.DataTextField = "YarnColour"
					ddlYcolour.DataValueField = "YarnColourID"
					ddlYcolour.DataBind()
				Catch ex As Exception
					Throw ex
				End Try
			End If
		End Using
	End Sub

	Private Sub getYtype()

		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand()
			'Dim cmd As New SqlCommand()		
			Dim strQuery As String = "SELECT DISTINCT YarnTypeID, YarnType from [YN - Yarn Type] "

			If IsPostBack = False Then
				ddlYtype.AppendDataBoundItems = True
				'	ddlYtype.Items.Clear()
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strQuery
				cmd.Connection = con
				Try
					con.Open()
					ddlYtype.DataSource = cmd.ExecuteReader()
					ddlYtype.DataTextField = "YarnType"
					ddlYtype.DataValueField = "YarnTypeID"
					ddlYtype.DataBind()
				Catch ex As Exception
					Throw ex
				Finally
				End Try
			End If
		End Using
	End Sub

	Protected Sub ddlSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSupplier.SelectedIndexChanged
		txtdate.Enabled = True
		txtInvoice.Enabled = True
		ddlYtype.Enabled = True
		txtkgprice.Enabled = True
	End Sub
	Private Sub InvoiceDBPopulate()
		Dim cmdstring As String = "INSERT INTO [YN - Yarn Master] (YarnDyelot, YarnColourID, YarnTypeID, YarnSupplier, SupplierInvoiceNo, YarnPurchaceWeight, YarnPurchaseCartons, YarnKgPrice, YarnPurchaseDate, CurrentWeight, CurrentCartons) " &
		"VALUES ('" & txtYdyelot.Text & "', " & ddlYcolour.SelectedValue & ", " & ddlYtype.SelectedValue & ", " & ddlSupplier.SelectedValue & ", '" & txtInvoice.Text & "', " & txtYweight.Text & ", " & txtYcartons.Text & ", " & txtkgprice.Text & ", '" & txtdate.Text & "', " & txtYweight.Text & ", " & txtYcartons.Text & ");"
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand(cmdstring)
			'Dim cmd As New SqlCommand(cmdstring)	
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub
	Private Sub grdvInvoiceDyelotsPopulate()
		Dim Adapter As New OleDbDataAdapter
		'Dim Adapter As New SqlDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand()
			'Dim cmd As New SqlCommand()
			grdvInvoiceDyelots.Visible = True
			Session("Invoice_number") = txtInvoice.Text
			SQL = "SELECT [YN - Yarn Master].YarnID, [YN - Yarn Master].YarnDyelot, [YN - Yarn Colour Defns].YarnColour, [YN - Yarn Master].YarnPurchaceWeight, [YN - Yarn Master].YarnPurchaseCartons 
			   FROM ([YN - Yarn Master] 
			   INNER JOIN [YN - Yarn Colour Defns] 
					On [YN - Yarn Master].YarnColourID = [YN - Yarn Colour Defns].YarnColourID)
			   WHERE [YN - Yarn Master].SupplierInvoiceNo = '" & Session("Invoice_number") & "'"

			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvInvoiceDyelots.DataSource = Data
			grdvInvoiceDyelots.DataBind()
		End Using
	End Sub

	Private Sub InvoiceDBAuditTrail()
		Dim cmdstring As String = "INSERT INTO [YN - YarnTransactionHeader] (TransactionTypeID, TransactionDate, EntityID, YarnDocumentNo, Processed) " &
		"VALUES (1, '" & DateTime.Now & "', " & ddlSupplier.SelectedValue & ", '" & txtInvoice.Text & "', 1);"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub

	Public Sub grdvInvoiceSummaryPopulate()
		Dim Adapter As New OleDbDataAdapter
		'Dim Adapter As New SqlDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand()
			'Dim cmd As New SqlCommand()	
			grdvInvoiceSummary.Visible = True
			'btnBack.Visible = False
			'btnAddUser.Visible = True	
			Session("Invoice_number") = txtInvoice.Text
			', (YM.YarnKgPrice*YM.YarnPurchaceWeight) AS [Total Price(R)]
			SQL = "SELECT YM.SupplierInvoiceNo, SUM(YM.YarnPurchaceWeight) AS [Total Weight], SUM(YM.YarnPurchaseCartons) AS [Total Cartons]
        FROM [YN - Yarn Master] AS YM
		WHERE YM.SupplierInvoiceNo = '" & Session("Invoice_number") & "'
		GROUP BY YM.SupplierInvoiceNo
		ORDER BY YM.SupplierInvoiceNo, SUM(YM.YarnPurchaceWeight), SUM(YM.YarnPurchaseCartons)"
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvInvoiceSummary.DataSource = Data
			grdvInvoiceSummary.DataBind()
		End Using
	End Sub

	Protected Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
		Session("YI_date") = txtdate.Text
		Session("YI_price") = txtkgprice.Text
		Session("YI_Supplier") = ddlSupplier.SelectedItem.Text
		Session("YI_Ytype") = ddlYtype.SelectedItem.Text
		InvoiceDBPopulate()
		grdvInvoiceDyelotsPopulate()
		ddlYcolour.ClearSelection()
		txtYdyelot.Text = ""
		txtYweight.Text = ""
		txtYcartons.Text = ""
	End Sub

	Protected Sub txtkgprice_TextChanged(sender As Object, e As EventArgs) Handles txtkgprice.TextChanged


	End Sub

	Protected Sub ddlYtype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlYtype.SelectedIndexChanged
		If txtkgprice.Enabled = True Then
			txtYdyelot.Enabled = True
			ddlYcolour.Enabled = True
			txtYweight.Enabled = True
			txtYcartons.Enabled = True
		End If
	End Sub

	Protected Sub ddlYcolour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlYcolour.SelectedIndexChanged
		Dim donothing As String
	End Sub

	Protected Sub btnyarninvcaptur_Click(sender As Object, e As EventArgs) Handles btnyarninvcaptur.Click
		InvoiceDBAuditTrail()
		grdvInvoiceSummaryPopulate()
		btnyarninvcaptur.Enabled = False
	End Sub

	Protected Sub Back(sender As Object, e As EventArgs) Handles btnBack.Click

	End Sub
End Class




