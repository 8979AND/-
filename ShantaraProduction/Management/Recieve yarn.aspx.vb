Imports System.Data.SqlClient

Public Class Recieve_yarn
	Inherits System.Web.UI.Page


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
			'		testsessionforgridview()

		End If
	End Sub

	Private Sub getSupplier()
		Dim strQuery As String = "SELECT DISTINCT EntityID, EntityName from [GN - EntityMaster] WHERE EntityTypeID = 1"
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New SqlCommand()

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
			Finally

				con.Close()

				con.Dispose()

			End Try
		End If
	End Sub

	Private Sub getColour()


		Dim strQuery As String = "SELECT YarnColourID, YarnColour from [YN - Yarn Colour Defns]"
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New SqlCommand()
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
			Finally
				con.Close()
				cmd.Dispose()
				con.Dispose()
			End Try
		End If
	End Sub

	Private Sub getYtype()

		Dim strQuery As String = "SELECT DISTINCT YarnTypeID, YarnType from [YN - Yarn Type] "
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New SqlCommand()
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
				con.Close()
				'	cmd.Dispose()
				con.Dispose()

			End Try
		End If
	End Sub

	Protected Sub ddlSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSupplier.SelectedIndexChanged
		txtdate.Enabled = True
		txtInvoice.Enabled = True
		ddlYtype.Enabled = True
		txtkgprice.Enabled = True
	End Sub
	Private Sub InvoiceDBPopulate()
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())

		Dim cmdstring As String = "INSERT INTO [YN - Yarn Master] (YarnDyelot, YarnColourID, YarnTypeID, YarnSupplier, SupplierInvoiceNo, YarnPurchaceWeight, YarnPurchaseCartons, YarnKgPrice, YarnPurchaseDate, CurrentWeight, CurrentCartons) " &
		"VALUES ('" & txtYdyelot.Text & "', " & ddlYcolour.SelectedValue & ", " & ddlYtype.SelectedValue & ", " & ddlSupplier.SelectedValue & ", '" & txtInvoice.Text & "', " & txtYweight.Text & ", " & txtYcartons.Text & ", " & txtkgprice.Text & ", '" & txtdate.Text & "', " & txtYweight.Text & ", " & txtYcartons.Text & ");"
		'SELECT CAST(scope_identity() AS int);"
		Dim cmd As New SqlCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		'Dim TicketID As Int32 = 0
		'TicketID = Convert.ToInt32(cmd.ExecuteScalar())
		'Dim notification As New CustomerComms
		'notification.NotifyNewTicket(TicketID)

		cmd.Connection.Close()
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
		Session("Invoice_number") = txtInvoice.Text
		SQL = "SELECT YM.YarnID, YM.YarnDyelot, YC.YarnColour, YM.YarnPurchaceWeight, YM.YarnPurchaseCartons
        FROM [YN - Yarn Master] YM JOIN [YN - Yarn Colour Defns] YC
        On YM.YarnColourID = YC.YarnColourID 
		WHERE YM.SupplierInvoiceNo = '" & Session("Invoice_number") & "';"


		'	cmd.Parameters.AddWithValue("@invoice", )
		con.Open()
		cmd.Connection = con
		cmd.CommandText = SQL

		Adapter.SelectCommand = cmd
		Adapter.Fill(Data)

		grdvInvoiceDyelots.DataSource = Data
		grdvInvoiceDyelots.DataBind()

	End Sub
	Private Sub testsessionforgridview()
		Dim Command As SqlCommand
		Dim Reader As SqlDataReader

		Dim connection As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim CommandString As String

		CommandString = "SELECT YM.YarnID, YM.YarnDyelot, YM.SupplierInvoiceNo, YC.YarnColour, YM.YarnPurchaceWeight, YM.YarnPurchaseCartons
        FROM [YN - Yarn Master] YM JOIN [YN - Yarn Colour Defns] YC
        On YM.YarnColourID = YC.YarnColourID;"

		Command = New SqlCommand(CommandString)
		Command.CommandType = CommandType.Text
		Command.Connection = connection

		Command.Connection.Open()

		Command.ExecuteNonQuery()

		Reader = Command.ExecuteReader(CommandBehavior.CloseConnection)

		If Reader.HasRows = True Then
			While Reader.Read()
				Session.Add("Invoice_number", Reader("SupplierInvoiceNo"))
			End While
		End If
	End Sub

	Private Sub InvoiceDBAuditTrail()
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())

		Dim cmdstring As String = "INSERT INTO [YN - YarnTransactionHeader] (TransactionTypeID, TransactionDate, EntityID, YarnDocumentNo, Processed) " &
		"VALUES (1, '" & DateTime.Now & "', " & ddlSupplier.SelectedValue & ", '" & txtInvoice.Text & "', 1);"
		Dim cmd As New SqlCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub

	Protected Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
		Session("YI_date") = txtdate.Text
		Session("YI_price") = txtkgprice.Text
		Session("YI_Supplier") = ddlSupplier.SelectedItem.Text
		Session("YI_Ytype") = ddlYtype.SelectedItem.Text

		Session("editYarn") = 0
		InvoiceDBPopulate()
		grdvInvoiceDyelotsPopulate()
		ddlYcolour.ClearSelection()
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
		MsgBox("invoice Captured")
		btnyarninvcaptur.Enabled = False
	End Sub

	Protected Sub Back(sender As Object, e As EventArgs) Handles btnBack.Click

	End Sub
End Class




