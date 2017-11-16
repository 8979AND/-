Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class Edit_Yarn_Invoice
	Inherits System.Web.UI.Page

	Private YarnID As Integer
	Private w, h As Decimal
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		getColour()
		Readdyelotfromdb()
	End Sub

	Private Sub Readdyelotfromdb()
		If Not Page.IsPostBack Then
			'If Session("Auth_Level") = 3 Then
			YarnID = CInt(Request.QueryString("ID").ToString())
			Dim cmdstring As String
			cmdstring = "SELECT YM.YarnID, YM.YarnDyelot, YC.YarnColourID, YC.YarnColour, YM.YarnPurchaceWeight, YM.YarnPurchaseCartons
        FROM ([YN - Yarn Master] AS YM 
		INNER JOIN [YN - Yarn Colour Defns] AS YC
			On YM.YarnColourID = YC.YarnColourID) 
        WHERE YM.YarnID = " & YarnID & ";"
			Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4")
			Dim cmd As New OleDbCommand(cmdstring)
			Dim reader As OleDbDataReader
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
			reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
			While reader.Read
				lblYarn.Text = "YarnID: " & reader("YarnID")
				txteYdyelot.Text = reader("YarnDyelot")
				ddleYcolour.SelectedValue = reader("YarnColourID")
				txteYweight.Text = Replace(reader("YarnPurchaceWeight"), ".", ",")
				txteYcartons.Text = reader("YarnPurchaseCartons")
			End While
			con.Close()
			cmd.Dispose()
			con.Dispose()
		End If
	End Sub

	Private Sub getColour()
		Dim strQuery As String = "SELECT YarnColourID, YarnColour from [YN - Yarn Colour Defns]"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4")
		Dim cmd As New OleDbCommand()
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
				cmd.Connection.Close()
			End Try
		End If
	End Sub

	Private Sub InvoiceDyelotUpdate()
		YarnID = CInt(Request.QueryString("ID").ToString())
		Dim cmdstring As String = "UPDATE [YN - Yarn Master] SET YarnDyelot='" & txteYdyelot.Text & "',YarnColourID=" & ddleYcolour.SelectedValue & ",YarnPurchaceWeight='" & txteYweight.Text & "',YarnPurchaseCartons=" & txteYcartons.Text & ",CurrentWeight='" & txteYweight.Text & "',CurrentCartons=" & txteYcartons.Text & " WHERE YarnID=" & YarnID
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4")
		Dim cmd As New OleDbCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub

	Protected Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
		'If Session("Auth_Level") = 1 Or Session("Auth_Level") = 2 Then
		InvoiceDyelotUpdate()
		Session("editYarn") = 1
		Response.Redirect("~/Management/Recieve yarn.aspx")
		'Else
		'Response.Redirect("~/Management/Dashboard.aspx")
		'End If
	End Sub

	Protected Sub Back(sender As Object, e As EventArgs) Handles btnBack.Click
		Session("editYarn") = 1
		Response.Redirect("~/Management/Recieve yarn.aspx")
	End Sub

	Protected Sub ddleYcolour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddleYcolour.SelectedIndexChanged
		'do not delete
	End Sub
End Class