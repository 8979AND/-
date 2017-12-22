Imports System.Data.OleDb
Public Class ApproveJrsyDiff
	Inherits System.Web.UI.Page
	Private cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"
	Private JDLNU As Integer
	Private JrsydiffID As String
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not Page.IsPostBack Then
			If Session("Auth_Level") = 1 Then
				grdvJDiffPopulate()
			ElseIf Session("Auth_Level") = 2 Then
				grdvJDiffPopulate()
			Else
				Response.Redirect("~/Account/Lockout.aspx")
			End If
		End If
	End Sub

	Private Sub grdvJDiffPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			grdvJDiff.Visible = True
			SQL = "SELECT DISTINCTROW CDH.BundleNo, SM.[Size Abbreviation] AS [Size], CDH.JrsysToCut, JD.ReasonOther, CDH.ActualJrsysCut, JD.ReasonID
				   FROM (([CMT - CMTDetailsHeader] AS CDH
				   INNER JOIN [FG- Size Master] AS SM
						ON SM.SizeID = CDH.SizeID)
				   INNER JOIN [JerseyDifference] AS JD
						ON JD.BundleNo = CDH.BundleNo)
				   WHERE CDH.JrsyDiffUnprocessed=yes;"
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvJDiff.DataSource = Data
			grdvJDiff.DataBind()
		End Using
	End Sub

	Private Sub NewJrsydiffID()
		Dim cmdstring As String
		cmdstring = "SELECT Prefix, LastNumberUsed
        FROM [JerseyDiffTypeDef]
        WHERE JDiffTypeID = 1;"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			Dim reader As OleDbDataReader
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
			reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
			If reader.HasRows = True Then
				While reader.Read
					JDLNU = reader("LastNumberUsed") + 1
					JrsydiffID = reader("Prefix") & CStr(JDLNU)
				End While
			Else
				lblerrJDiff.Text = "problem with new JrsydiffID"
			End If
		End Using
	End Sub

	Private Sub UpdateJDiffLastNumberUsed()
		Dim cmdstring As String = "UPDATE [JerseyDiffTypeDef] SET LastNumberUsed = " & JDLNU & " WHERE JDiffTypeID = 1;"
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand(cmdstring)
			'Dim cmd As New SqlCommand(cmdstring)
			cmd.Parameters.AddWithValue("@JDiffTypeID", Session("JDiffTypeID"))
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub

	Protected Sub grdvJDiff_SelectedIndexChanged(sender As Object, e As EventArgs)
		NewJrsydiffID()
		Dim bundleno As String = grdvJDiff.SelectedRow.Cells(0).Text
		Dim ddlRsn As DropDownList = DirectCast(grdvJDiff.SelectedRow.FindControl("ddlreason"), DropDownList)
		Dim txtothr As TextBox = DirectCast(grdvJDiff.SelectedRow.FindControl("txtOther"), TextBox)
		Dim txtActualJC As TextBox = DirectCast(grdvJDiff.SelectedRow.FindControl("txtAJC"), TextBox)

		Dim RID As Integer
		Dim Rother As String
		Dim AJC As Integer
		Dim J2C As Integer
		Dim cmdstringr As String = "SELECT CDH.BundleNo, JD.ReasonOther, CDH.ActualJrsysCut, JD.ReasonID, CDH.JrsysToCut
				   FROM ([CMT - CMTDetailsHeader] AS CDH
				   INNER JOIN [JerseyDifference] AS JD
						ON JD.BundleNo = CDH.BundleNo)
				   WHERE CDH.BundleNo = '" & bundleno & "';"
		Using conn As New OleDbConnection(cnString)
			Dim cmdd As New OleDbCommand(cmdstringr)
			Dim reader As OleDbDataReader
			cmdd.CommandType = CommandType.Text
			cmdd.Connection = conn
			cmdd.Connection.Open()
			cmdd.ExecuteNonQuery()
			reader = cmdd.ExecuteReader(CommandBehavior.CloseConnection)
			If reader.HasRows = True Then
				While reader.Read
					RID = reader("ReasonID")
					If reader.IsDBNull(1) Then
						Rother = " "
					Else
						Rother = reader(1)

					End If
					AJC = reader("ActualJrsysCut")
					J2C = reader("JrsysToCut")
				End While
			Else
				lblerrJDiff.Text = "problem with fetching data"
			End If
		End Using
		If ddlRsn.SelectedValue <> RID Or txtothr.Text <> Rother Or txtActualJC.Text <> AJC Then
			lblerrJDiff.Visible = False
			Dim cmdstringii As String
			Dim JerseyDiffQty As Integer
			JerseyDiffQty = txtActualJC.Text - J2C
			If ddlRsn.SelectedValue = 5 Then
				If txtothr.Text = "" Then
					lblerrJDiff.Visible = True
					lblerrJDiff.Text = "please add reason to other box"
					Exit Sub
				End If
				cmdstringii = "INSERT INTO [JerseyDifference] (JrsydiffID, JDiffTypeID, JerseyDiffQty, ReasonID, ReasonOther, EmployeeID, JDDate, BundleNo) " &
			"VALUES ('" & JrsydiffID & "' ,1 ," & JerseyDiffQty & " ," & ddlRsn.SelectedValue & ",'" & txtothr.Text & "' ," & Session("EmployeeLogInID") & " ,'" & DateTime.Now & "', '" & bundleno & "');"
			Else

				cmdstringii = "INSERT INTO [JerseyDifference] (JrsydiffID, JDiffTypeID, JerseyDiffQty, ReasonID, EmployeeID, JDDate, BundleNo) " &
			"VALUES ('" & JrsydiffID & "' ,1 ," & JerseyDiffQty & " ," & ddlRsn.SelectedValue & " ," & Session("EmployeeLogInID") & " ,'" & DateTime.Now & "', '" & bundleno & "');"
			End If
			Using conii As New OleDbConnection(cnString)
				Dim cmdii As New OleDbCommand(cmdstringii)
				cmdii.CommandType = CommandType.Text
				cmdii.Connection = conii
				cmdii.Connection.Open()
				cmdii.ExecuteNonQuery()
			End Using
		End If
		UpdateJDiffLastNumberUsed()
		Dim cmdstring As String
		cmdstring = " UPDATE [CMT - CMTDetailsHeader] 
						  SET JrsyDiffUnprocessed = no 
						  WHERE (BundleNo ='" & bundleno & "');"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
		grdvJDiffPopulate()
		'Accessing TemplateField Column controls
		'Dim reason As String = TryCast(GridView1.SelectedRow.FindControl("lblCountry"), Label).Text

		'lblValues.Text = "<b>Name:</b> " & name & " <b>Country:</b> " & country
	End Sub
	'Protected Sub btnAccept_Click(sender As Object, e As EventArgs)
	'	Updatemachineallocation()
	'	grdvJDiffPopulate()
	'End Sub
End Class