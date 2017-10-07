﻿Imports System.Data.SqlClient

Public Class Edit_Yarn_Stock
	Inherits System.Web.UI.Page

	Private YarnID As Integer
	Private w, h As Decimal
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


		getColour()
		Readdyelotfromdb()
		'	h = CDbl(txteYweight.Text)
	End Sub
	Private Sub Readdyelotfromdb()
		If Not Page.IsPostBack Then
			'If Session("Auth_Level") = 3 Then
			YarnID = CInt(Request.QueryString("ID").ToString())

			Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmdstring = "SELECT YM.YarnID, YM.YarnDyelot, YC.YarnColourID, YC.YarnColour, YM.YarnPurchaceWeight, YM.YarnPurchaseCartons
        FROM [YN - Yarn Master] YM JOIN [YN - Yarn Colour Defns] YC
        On YM.YarnColourID = YC.YarnColourID 
        WHERE YM.YarnID = '" & YarnID & "';"
			Dim cmd As New SqlCommand(cmdstring)
			Dim reader As SqlDataReader
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
			reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
			While reader.Read
				lblYarn.Text = "YarnID: " & reader("YarnID")
				txteYdyelot.Text = reader("YarnDyelot")
				ddleYcolour.SelectedValue = reader("YarnColourID")
				txteYweight.Text = reader("YarnPurchaceWeight")
				txteYcartons.Text = reader("YarnPurchaseCartons")
			End While
		End If
		'End If
	End Sub

	Private Sub getColour()
		Dim strQuery As String = "SELECT YarnColourID, YarnColour from [YN - Yarn Colour Defns]"
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New SqlCommand()
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

	Private Sub InvoiceDyelotUpdate()
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		YarnID = CInt(Request.QueryString("ID").ToString())

		'If CDbl(txteYweight.Text) = h Then
		'	w = CDbl(txteYweight.Text) / 1000
		'Else
		'	w = txteYweight.Text
		'End If
		Dim cmdstring As String = "UPDATE [YN - Yarn Master] SET YarnDyelot='" & txteYdyelot.Text & "',YarnColourID=" & ddleYcolour.SelectedValue & ",YarnPurchaceWeight=" & txteYweight.Text & ",YarnPurchaseCartons=" & txteYcartons.Text & ",CurrentWeight=" & txteYweight.Text & ",CurrentCartons=" & txteYcartons.Text & " WHERE YarnID=" & YarnID
		Dim cmd As New SqlCommand(cmdstring)
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
		Dim d As String
	End Sub
End Class