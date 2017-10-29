Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Globalization
Public Class Adjust_Yarn_Stock
	Inherits System.Web.UI.Page
	Private SupplierID As Integer = 0
	Private YarnID As Integer = 0
	Private CurrentCartons As Integer = 0
	Private NewCartons As Integer = 0
	Private CartonDiff As Integer = 0
	Private YarnTransactionID As Integer = 0
	Private CurrentWeight As Double
	Private NewWeight As Double
	Private WeightDiff As Double
	Private DocNo As String
	Private ALNU As Integer ' adjustment Last number used
	Private locale As String
	Private culture As CultureInfo
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		getColour()
		getTransactiontype()
	End Sub

	Private Sub getTransactiontype()
		Dim strQuery As String = "SELECT TransactionTypeID, TransactionType FROM [YN - Yarn Transaction Type]"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Deepak Vallabh\Documents\shantara\ShantaraProduction\ShantaraProduction\App_Data\Shantara Production IT.mdb")
		'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New OleDbCommand()
		'Dim cmd As New SqlCommand()
		If IsPostBack = False Then
			ddltranstype.AppendDataBoundItems = True
			cmd.CommandType = CommandType.Text
			cmd.CommandText = strQuery
			cmd.Connection = con
			Try
				con.Open()
				ddltranstype.DataSource = cmd.ExecuteReader()
				ddltranstype.DataTextField = "TransactionType"
				ddltranstype.DataValueField = "TransactionTypeID"
				ddltranstype.DataBind()
			Catch ex As Exception
				Throw ex
			Finally
				con.Close()
				cmd.Dispose()
				con.Dispose()
			End Try
		End If
	End Sub

	Private Sub getColour()
		Dim strQuery As String = "SELECT YarnColourID, YarnColour from [YN - Yarn Colour Defns]"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Deepak Vallabh\Documents\shantara\ShantaraProduction\ShantaraProduction\App_Data\Shantara Production IT.mdb")
		'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New OleDbCommand()
		'Dim cmd As New SqlCommand()
		If IsPostBack = False Then
			ddleYcolour.AppendDataBoundItems = True
			cmd.CommandType = CommandType.Text
			cmd.CommandText = strQuery
			cmd.Connection = con
			Try
				con.Open()
				ddleYcolour.DataSource = cmd.ExecuteReader()
				ddleYcolour.DataTextField = "YarnColour"
				ddleYcolour.DataValueField = "YarnColourID"
				ddleYcolour.DataBind()
			Catch ex As Exception
				Throw ex
			Finally
				con.Close()
				cmd.Dispose()
				con.Dispose()
			End Try
		End If
	End Sub
	Private Sub dispDyelot()

		'YarnID = CInt(Request.QueryString("ID").ToString())

		Dim cmdstring As String = "SELECT YM.YarnID, YM.YarnDyelot, YM.YarnColourID, EM.EntityName, YM.YarnPurchaceWeight, YM.YarnSupplier, YM.YarnPurchaseCartons, YM.CurrentWeight, YM.CurrentCartons
        FROM [YN - Yarn Master] YM INNER JOIN [GN - EntityMaster] EM
        On EM.EntityID = YM.YarnSupplier
        WHERE YM.YarnDyelot = '" & txteYdyelot.Text & "';"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Deepak Vallabh\Documents\shantara\ShantaraProduction\ShantaraProduction\App_Data\Shantara Production IT.mdb")
		'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New OleDbCommand(cmdstring)
		'Dim cmd As New SqlCommand(cmdstring)
		Dim reader As OleDbDataReader
		'Dim reader As SqlDataReader
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()

		reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
		If reader.HasRows = True Then
			While reader.Read
				Session("YarnID") = reader("YarnID")
				lblYarnID.Text = "YarnID: " & Session("YarnID")
				lblYarnPurchaceWeight.Text = "Yarn Purchace Weight: " & reader("YarnPurchaceWeight")
				lblYarnPurchaseCartons.Text = "Yarn Purchase Cartons: " & reader("YarnPurchaseCartons")
				ddleYcolour.SelectedValue = reader("YarnColourID")
				Session("CurrentWeight") = reader("CurrentWeight")
				Session("CurrentCartons") = reader("CurrentCartons")
				Session("SupplierID") = reader("YarnSupplier")
			End While
		Else
			MsgBox("Dyelot entered incorrectly Or does Not exist")
		End If
		lblYarnCurrentCartons.Text = "Yarn Current Cartons: " & Session("CurrentCartons")
		lblYarnCurrentWeight.Text = "Yarn Current Weight: " & Replace(Session("CurrentWeight"), ",", ".")
	End Sub

	Private Sub Newyarndocnumber()
		'"SELECT YTH.TransactionTypeID, YTT.RangePrefix, YTT.LastNumberUsed
		'      FROM [YN - YarnTransactionHeader] YTH JOIN [YN - Yarn Transaction Type] YTT
		'      On YTT.TransactionTypeID = YTH.TransactionTypeID
		'      WHERE YTH.EntityID = 5 AND YTT.TransactionTypeID = 7;"
		Dim cmdstring As String = "SELECT YTT.RangePrefix, YTT.LastNumberUsed
        FROM [YN - Yarn Transaction Type] YTT
        WHERE YTT.TransactionTypeID = " & ddltranstype.SelectedValue & ";"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Deepak Vallabh\Documents\shantara\ShantaraProduction\ShantaraProduction\App_Data\Shantara Production IT.mdb")
		'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New OleDbCommand(cmdstring)
		'Dim cmd As New SqlCommand(cmdstring)
		Dim reader As OleDbDataReader
		'Dim reader As SqlDataReader
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()

		reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
		If reader.HasRows = True Then
			While reader.Read
				ALNU = reader("LastNumberUsed") + 1
				DocNo = reader("RangePrefix") & CStr(ALNU)
			End While
		Else
			MsgBox("problem with new doc number")
		End If
	End Sub

	Private Sub AdjustDyelotUpdate()
		'YarnID = CInt(Request.QueryString("ID").ToString())

		'If CDbl(txteYweight.Text) = h Then
		'	w = CDbl(txteYweight.Text) / 1000
		'Else
		'	w = txteYweight.Text
		'End If
		'REPLACE('" & NewWeight & "',',','.') ,
		Dim cmdstring As String = "UPDATE [YN - Yarn Master] 
								   SET YarnColourID=" & ddleYcolour.SelectedValue & " ,CurrentWeight= '" & NewWeight & "' ,CurrentCartons=" & NewCartons & " 
								   WHERE YarnDyelot='" & txteYdyelot.Text & "'"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Deepak Vallabh\Documents\shantara\ShantaraProduction\ShantaraProduction\App_Data\Shantara Production IT.mdb")
		'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New OleDbCommand(cmdstring)
		'Dim cmd As New SqlCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub

	Private Sub UpdateAdjustLastNumberUsed()
		Dim cmdstring As String = "UPDATE [YN - Yarn Transaction Type] SET LastNumberUsed = " & ALNU & " WHERE TransactionTypeID = " & ddltranstype.SelectedValue
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Deepak Vallabh\Documents\shantara\ShantaraProduction\ShantaraProduction\App_Data\Shantara Production IT.mdb")
		'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New OleDbCommand(cmdstring)
		'Dim cmd As New SqlCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub

	Private Sub AdjustDBAuditTrailLines()
		'Dim WeightDiffs As String
		'WeightDiffs = Replace(CStr(WeightDiff), ",", ".")
		',  REPLACE('" & CStr(WeightDiff) & "',',','.') ,
		Dim cmdstring As String = "INSERT INTO [YN - YarnTransactionLines] (YarnTransactionID, YarnID, TransactionWeight, TransactionCartons, Processed) " &
		"VALUES (" & YarnTransactionID & ", " & Session("YarnID") & ",'" & CStr(WeightDiff) & "' ," & CartonDiff & " ,1);"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Deepak Vallabh\Documents\shantara\ShantaraProduction\ShantaraProduction\App_Data\Shantara Production IT.mdb")
		'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New OleDbCommand(cmdstring)
		'Dim cmd As New SqlCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub

	Private Sub GetYarnTransactionID()
		Dim cmdstring As String = "SELECT YTH.YarnTransactionID
        FROM [YN - YarnTransactionHeader] YTH
        WHERE YTH.YarnDocumentNo = '" & DocNo & "';"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Deepak Vallabh\Documents\shantara\ShantaraProduction\ShantaraProduction\App_Data\Shantara Production IT.mdb")
		'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New OleDbCommand(cmdstring)
		'Dim cmd As New SqlCommand(cmdstring)
		Dim reader As OleDbDataReader
		'Dim reader As SqlDataReader
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()

		reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
		If reader.HasRows = True Then
			While reader.Read
				YarnTransactionID = reader("YarnTransactionID")
			End While
		Else
			MsgBox("Transaction ID does not match")
		End If
	End Sub

	Private Sub AdjustDBAuditTrail()
		Dim cmdstring As String = "INSERT INTO [YN - YarnTransactionHeader] (TransactionTypeID, TransactionDate, EntityID, YarnDocumentNo, Processed) " &
		"VALUES (" & ddltranstype.SelectedValue & ", '" & DateTime.Now & "' ,5 ,'" & DocNo & "' ,1);"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Deepak Vallabh\Documents\shantara\ShantaraProduction\ShantaraProduction\App_Data\Shantara Production IT.mdb")
		'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New OleDbCommand(cmdstring)
		'Dim cmd As New SqlCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub

	Protected Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
		dispDyelot()
		Newyarndocnumber()
	End Sub

	Protected Sub ddleYcolour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddleYcolour.SelectedIndexChanged
		'Do Not Delete
	End Sub
	Private Sub selectwc()
		If Request.UserLanguages.Length = 0 Then Exit Sub
		locale = Request.UserLanguages(0)
		If String.IsNullOrEmpty(locale) Then Exit Sub

		' Instantiate CultureInfo object for the user's locale
		culture = New CultureInfo(locale)

		' Convert user input from a string to a number
		'Try
		WeightDiff = Replace(txteYweight.Text, ".", ",")
		'Catch ex As FormatException
		'Exit Sub
		'Catch ex As Exception
		'	Exit Sub
		'End Try
		'Double.TryParse(txteYweight.Text, Session("WeightDiff"))
		Select Case ddltranstype.SelectedValue
			Case 1, 5
				'Session("WeightDiff") = CDbl(txteYweight.Text)
				NewWeight = Session("CurrentWeight") + WeightDiff
				CartonDiff = txteYcartons.Text
				NewCartons = Session("CurrentCartons") + CartonDiff

		' The following is the only Case clause that evaluates to True.
			Case 2, 3, 4, 6, 7, 8
				WeightDiff = 0 - WeightDiff
				NewWeight = Session("CurrentWeight") + WeightDiff
				CartonDiff = 0 - txteYcartons.Text
				NewCartons = Session("CurrentCartons") + CartonDiff

			Case Else
				MsgBox("transaction type out of range")
		End Select
	End Sub


	Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
		selectwc()
		Newyarndocnumber()
		AdjustDBAuditTrail()
		GetYarnTransactionID()
		AdjustDBAuditTrailLines()
		UpdateAdjustLastNumberUsed()
		AdjustDyelotUpdate()
		MsgBox("Adjustment Captured")
	End Sub

	Protected Sub Back(sender As Object, e As EventArgs) Handles btnBack.Click

	End Sub

	Protected Sub ddltranstype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddltranstype.SelectedIndexChanged
		txteYdyelot.Enabled = True
		btnView.Enabled = True
		ddleYcolour.Enabled = True
		txteYweight.Enabled = True
		txteYcartons.Enabled = True
		btnEdit.Enabled = True
	End Sub
End Class