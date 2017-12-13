Imports System.Data.OleDb
Public Class CMTDataCapture
	Inherits System.Web.UI.Page
	Private cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"
	Private JrsydiffID As String
	Private JDLNU As Integer
	Private JDiffTypeID As Integer
	Shared ActualJrsysCut As Integer
	Shared JrsysToCut As Integer
	Private jerseytxt As Integer
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		GetCMTDatadb()
	End Sub

	Private Sub GetCMTDatadb()
		Session("BundleNo") = Request.QueryString("ID").ToString()
		Dim cmdstring = "SELECT CDH.BatchNo,
								CDH.BundleNo,
								CDH.JrsysToCut,
								CDH.ActualJrsysCut,
								KO.OrderNo, 
								EPC.ProductCode, 
								EPC.ProdDescription, 
								(SM.[Size Abbreviation]) AS [Size], 												 
								YCD.YarnColour,
								CSIM.CMTSpecialInstructionDetail
        FROM ((((((([CMT - CMTDetailsHeader] AS CDH
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID )
		INNER JOIN [FG- Size Master] AS SM
			ON CDH.SizeID = SM.SizeID)
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - ProductionYarnAllocation] AS PYA
			ON CDH.BatchNo = PYA.BatchNo)
		INNER JOIN [YN - Yarn Master] AS YM 
			ON PYA.YarnID = YM.YarnID)
		INNER JOIN [YN - Yarn Colour Defns] AS YCD
			ON YM.YarnColourID = YCD.YarnColourID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		WHERE CDH.BundleNo = @BundleNo;"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.Parameters.AddWithValue("@BundleNo", Session("BundleNo"))
			Dim reader As OleDbDataReader
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()

			reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
			If reader.HasRows = True Then
				While reader.Read
					txtorderNo.Text = reader("OrderNo")
					lblBundleNo.Text = "BundleNo: " & reader("BundleNo")
					txtBatchNo.Text = reader("BatchNo")
					txtJtoCut.Text = reader("JrsysToCut")
					If reader.IsDBNull(3) Then
						txtAJCutD.Text = "0"
					Else
						txtAJCutD.Text = reader(3)
					End If

					txtProdcode.Text = reader("ProductCode")
					If reader.IsDBNull(6) Then
						txtProdDescr.Text = ""
					Else
						txtProdDescr.Text = reader(6)
					End If
					txtSize.Text = reader("Size")
					txtCSIM.Text = reader("CMTSpecialInstructionDetail")
					txtYarnColour.Text = reader("YarnColour")
				End While
			Else
				MsgBox("problem with displaying info from database into boxes")
			End If
			If Session("JDescription") = "Cutting" Then
				txtAJCutD.Visible = False
				lblajc.Visible = False
				txtJtoCut.Visible = True
				lblj2c.Visible = True
				txtactualJcut.Visible = True
				lblajce.Visible = True
				lblajce.Text = "Actual Jerseys Cut"
			ElseIf Session("JDescription") = "Dispatch" Then
				txtAJCutD.Visible = False
				lblajc.Visible = False
				txtJtoCut.Visible = True
				lblj2c.Visible = True
				lblajce.Text = "Jerseys Delivered"
				txtactualJcut.Visible = True
				lblajce.Visible = True
			Else
				txtAJCutD.Visible = True
				lblajc.Visible = True
				txtJtoCut.Visible = False
				lblj2c.Visible = False
				txtactualJcut.Visible = False
				lblajce.Visible = False
			End If
			lblOperation.Text = Session("FullName") & " - " & Session("JDescription")
		End Using
	End Sub
	Private Sub Updatecuttcaptured()
		Dim cmdstring As String
		cmdstring = "UPDATE [CMT - CMTDetailsHeader]
							 SET CutDataCaptured = yes, 
								 ActualJrsysCut = " & txtactualJcut.Text &
							 " WHERE BundleNo = @BundleNo"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.Parameters.AddWithValue("@BundleNo", Session("BundleNo"))
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub

	Private Sub Updatedeliverycaptured()
		Dim cmdstring As String
		cmdstring = "UPDATE [CMT - CMTDetailsHeader]
							 SET CutDataCaptured = yes, 
								 JrsysDelivered = " & txtactualJcut.Text &
							  "WHERE BundleNo = @BundleNo"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.Parameters.AddWithValue("@BundleNo", Session("BundleNo"))
			'cmd.Parameters.AddWithValue("@ActualJcut", txtactualJcut.Text)
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub

	Private Sub UpdatewhereJdesc()
		Dim cmdstring As String
		Select Case Session("JDescription")
			Case "Cutting"
				cmdstring = "UPDATE [CMT - CMTDetailsOperations]
							 SET CutterID = " & Session("EmployeeID") &
							", CutDate ='" & DateTime.Now &
							"' WHERE BundleNo = @BundleNo"
				Updatecuttcaptured()
			Case "AttachVN"
				cmdstring = "UPDATE [CMT - CMTDetailsOperations]
							 SET AttachVID = " & Session("EmployeeID") &
							", AttachVDate ='" & DateTime.Now &
							"' WHERE BundleNo = @BundleNo"
			Case "Side Seams"
				cmdstring = "UPDATE [CMT - CMTDetailsOperations]
							 SET SideSeamsID = " & Session("EmployeeID") &
							" , SideSeamsDate ='" & DateTime.Now &
							"' WHERE BundleNo = @BundleNo"
			Case "Pressing"
				cmdstring = "UPDATE [CMT - CMTDetailsOperations]
							 SET PressID = " & Session("EmployeeID") &
							", PressDate ='" & DateTime.Now &
							"' WHERE BundleNo = @BundleNo"
			Case "Dispatch"
				cmdstring = "UPDATE [CMT - CMTDetailsOperations]
							 SET DispatcherID = " & Session("EmployeeID") &
							" , DispatchDate ='" & DateTime.Now &
							"' WHERE BundleNo = @BundleNo"
				Updatedeliverycaptured()
		End Select
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.Parameters.AddWithValue("@BundleNo", Session("BundleNo"))
			'cmd.Parameters.AddWithValue("@EmployeeID", Session("EmployeeID"))
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub

	Public Sub CMTbatchCompleteCheck()
		Dim cmdstring As String
		Select Case Session("JDescription")
			Case "Cutting"
				cmdstring = "SELECT CDH.BatchNo
							  FROM ([CMT - CMTDetailsOperations] AS CDO
							 INNER JOIN [CMT - CMTDetailsHeader] AS CDH
								ON CDO.BundleNo = CDH.BundleNo)
							 WHERE (CDO.CutDate IS NULL) AND (CDH.BatchNo = @BatchNo)"
			Case "AttachVN"
				cmdstring = "SELECT CDH.BatchNo
							 FROM ([CMT - CMTDetailsOperations] AS CDO
							 INNER JOIN [CMT - CMTDetailsHeader] AS CDH
								ON CDO.BundleNo = CDH.BundleNo)
							 WHERE (CDO.AttachVDate IS NULL) AND (CDH.BatchNo = @BatchNo) AND (CDH.CutDataCaptured = yes)"
			Case "Side Seams"
				cmdstring = "SELECT CDH.BatchNo
							 FROM ([CMT - CMTDetailsOperations] AS CDO
							 INNER JOIN [CMT - CMTDetailsHeader] AS CDH
								ON CDO.BundleNo = CDH.BundleNo)
							 WHERE (CDO.SideSeamsDate IS NULL) AND (CDH.BatchNo = @BatchNo) AND (CDH.CutDataCaptured = yes)"
			Case "Pressing"
				cmdstring = "SELECT CDH.BatchNo
							 FROM ([CMT - CMTDetailsOperations] AS CDO
							 INNER JOIN [CMT - CMTDetailsHeader] AS CDH
								ON CDO.BundleNo = CDH.BundleNo)
							 WHERE (CDO.PressDate IS NULL) AND (CDH.BatchNo = @BatchNo) AND (CDH.CutDataCaptured = yes)"
			Case "Dispatch"
				cmdstring = "SELECT CDH.BatchNo
							 FROM ([CMT - CMTDetailsOperations] AS CDO
							 INNER JOIN [CMT - CMTDetailsHeader] AS CDH
								ON CDO.BundleNo = CDH.BundleNo)
							 WHERE (CDO.DispatchDate IS NULL) AND (CDH.BatchNo = @BatchNo) AND (CDH.CutDataCaptured = yes)"
		End Select
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.Parameters.AddWithValue("@BatchNo", txtBatchNo.Text)
			Dim reader As OleDbDataReader
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()

			reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
			If reader.HasRows = False Then
				Response.Redirect("~/CMT/CMTJob.aspx")
			Else
				Response.Redirect("~/CMT/CMTBundles.aspx?ID=" & txtBatchNo.Text)
			End If
		End Using
	End Sub
	Private Sub UpdateCMTBundleCompleteview()
		Dim cmdstring As String
		cmdstring = "UPDATE [CMT - CMTDetailsHeader]
							 SET Bundlecompleteview = yes
							 WHERE BundleNo = @BundleNo"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.Parameters.AddWithValue("@BundleNo", Session("BundleNo"))
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub
	Public Sub CMTbundleCompleteviewCheck()
		Dim cmdstring As String
		cmdstring = "SELECT BundleNo
					 FROM [CMT - CMTDetailsOperations] 
					 WHERE (CutDate IS NOT NULL) AND (AttachVDate IS NOT NULL) AND (SideSeamsDate IS NOT NULL) AND (PressDate IS NOT NULL) AND (DispatchDate IS NOT NULL) AND (BundleNo = @BundleNo)"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.Parameters.AddWithValue("@BundleNo", Session("BundleNo"))
			Dim reader As OleDbDataReader
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()

			reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
			If reader.HasRows = True Then
				'MsgBox("cmt bundle complete")
				UpdateCMTBundleCompleteview()
				CMTbatchCompleteCheck()
			Else
				CMTbatchCompleteCheck()
			End If
		End Using
	End Sub

	Protected Sub BtnCaptureBundle_Click(sender As Object, e As EventArgs) Handles BtnCaptureBundle.Click
		'jerseytxt = CInt(txtactualJcut.Text)
		getJersey()
		If Session("JDescription") = "Cutting" Then
			If txtactualJcut.Text <> "0" Or txtactualJcut.Text.Length <> 0 Then
				If CInt(txtactualJcut.Text) <> JrsysToCut Then
					RBLJD.Visible = True
					lblerrJDmsg.Visible = True
					lblerrJDmsg.Text = "Jerseys to be cut is not equal to actual Jerseys cut. Please Select Reason"
				Else
					RBLJD.Visible = False
					lblerrJDmsg.Visible = False
					lblerrajce.Visible = False
					UpdatewhereJdesc()
					CMTbundleCompleteviewCheck()
					'MsgBox("something wrong")
				End If
			Else
				lblerrajce.Visible = True
				lblerrajce.Text = "please enter Valid number of jerseys"
				'Exit Sub
			End If
		ElseIf Session("JDescription") = "Dispatch" Then
			If txtactualJcut.Text <> "0" Or txtactualJcut.Text.Length <> 0 Then
				If CInt(txtactualJcut.Text) <> ActualJrsysCut Then
					RBLJD.Visible = True
					lblerrJDmsg.Visible = True
					lblerrJDmsg.Text = "Jerseys Delivered in not equal to Jerseys cut. Please Select Reason"
				Else
					RBLJD.Visible = False
					lblerrJDmsg.Visible = False
					lblerrajce.Visible = False
					UpdatewhereJdesc()
					CMTbundleCompleteviewCheck()
					'MsgBox("something wrong")
				End If
			Else
				lblerrajce.Visible = True
				lblerrajce.Text = "please enter Valid number of jerseys"
				'Exit Sub
			End If
		Else
			UpdatewhereJdesc()
			CMTbundleCompleteviewCheck()
		End If
	End Sub

	Private Sub getReason()
		Dim strQuery As String = "SELECT ReasonID, Description FROM JrsyDiffReasonDef WHERE JDiffTypeID = @JDiffTypeID"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			cmd.Parameters.AddWithValue("@JDiffTypeID", Session("JDiffTypeID"))
			ddlReason.AppendDataBoundItems = True
			cmd.CommandType = CommandType.Text
			cmd.CommandText = strQuery
			cmd.Connection = con
			Try
				con.Open()
				ddlReason.DataSource = cmd.ExecuteReader()
				ddlReason.DataTextField = "Description"
				ddlReason.DataValueField = "ReasonID"
				ddlReason.DataBind()
			Catch ex As Exception
				Throw ex
			End Try
		End Using
	End Sub
	Private Sub NewJrsydiffID()
		Dim cmdstring As String
		cmdstring = "SELECT Prefix, LastNumberUsed
        FROM [JerseyDiffTypeDef]
        WHERE JDiffTypeID = @JDiffTypeID;"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.Parameters.AddWithValue("@JDiffTypeID", Session("JDiffTypeID"))
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
				lblerrother.Text = "problem with new JrsydiffID"
			End If
		End Using
	End Sub

	Private Sub UpdateJDiffLastNumberUsed()
		Dim cmdstring As String = "UPDATE [JerseyDiffTypeDef] SET LastNumberUsed = " & JDLNU & " WHERE JDiffTypeID = JDiffTypeID;"
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

	Private Sub evalJDiffTypeID()
		If Session("JDescription") = "Cutting" Then
			If RBLJD.SelectedValue = 1 Then
				Session("JDiffTypeID") = 3
			ElseIf RBLJD.SelectedValue = 2 Then
				Session("JDiffTypeID") = 1
			End If
		ElseIf Session("JDescription") = "Dispatch" Then
			If RBLJD.SelectedValue = 1 Then
				Session("JDiffTypeID") = 3
			ElseIf RBLJD.SelectedValue = 2 Then
				Session("JDiffTypeID") = 2
			End If
		End If
	End Sub

	Private Sub getJersey()
		Dim cmdstring As String
		cmdstring = "SELECT ActualJrsysCut, JrsysToCut
        FROM [CMT - CMTDetailsHeader]
        WHERE BundleNo = @BundleNo"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.Parameters.AddWithValue("@BundleNo", Session("BundleNo"))
			Dim reader As OleDbDataReader
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
			reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
			If reader.HasRows = True Then
				While reader.Read
					If reader.IsDBNull(0) Then
						ActualJrsysCut = 0
					Else
						ActualJrsysCut = reader(0)
					End If

					If reader.IsDBNull(1) Then
						JrsysToCut = 0
					Else
						JrsysToCut = reader(1)
					End If
				End While
			Else
				lblerrother.Text = "problem with new JrsydiffID"
			End If
		End Using
	End Sub

	Private Sub InsertJerseyDifference()
		Dim cmdstring As String
		Dim JerseyDiffQty As Integer
		If Session("JDescription") = "Cutting" Then
			JerseyDiffQty = CInt(txtactualJcut.Text) - JrsysToCut
		ElseIf Session("JDescription") = "Dispatch" Then
			JerseyDiffQty = CInt(txtactualJcut.Text) - ActualJrsysCut
		End If
		If RBLJD.SelectedValue = 1 Then
			cmdstring = "INSERT INTO [JerseyDifference] (JrsydiffID, JDiffTypeID, JerseyDiffQty, ReasonID, EmployeeID, JDDate, BundleNo) " &
			"VALUES ('" & JrsydiffID & "' ," & Session("JDiffTypeID") & ",0 ,7 ," & Session("EmployeeID") & " ,'" & DateTime.Now & "', '" & Session("BundleNo") & "');"
		ElseIf RBLJD.SelectedValue = 2 Then
			If ddlReason.SelectedValue = 5 Then
				cmdstring = "INSERT INTO [JerseyDifference] (JrsydiffID, JDiffTypeID, JerseyDiffQty, ReasonID, ReasonOther, EmployeeID, JDDate, BundleNo) " &
			"VALUES ('" & JrsydiffID & "' ," & Session("JDiffTypeID") & "," & JerseyDiffQty & " ," & ddlReason.SelectedValue & ",'" & txtotherR.Text & "' ," & Session("EmployeeID") & " ,'" & DateTime.Now & "', '" & Session("BundleNo") & "');"
			Else
				cmdstring = "INSERT INTO [JerseyDifference] (JrsydiffID, JDiffTypeID, JerseyDiffQty, ReasonID, EmployeeID, JDDate, BundleNo) " &
			"VALUES ('" & JrsydiffID & "' ," & Session("JDiffTypeID") & " ," & JerseyDiffQty & " ," & ddlReason.SelectedValue & " ," & Session("EmployeeID") & " ,'" & DateTime.Now & "', '" & Session("BundleNo") & "');"
			End If
		End If
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub

	Protected Sub RBLJD_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RBLJD.SelectedIndexChanged
		evalJDiffTypeID()
		getReason()
		If RBLJD.SelectedValue = 1 Then
			txtactualJcut.Enabled = True
			lblerrajce.Visible = True
			lblerrajce.Text = "please put correct amount then click Button"
			ddlReason.Visible = False
			BtnCaptureBundle.Visible = True
			btnjrsyadj.Visible = False
			lblerrJDmsg.Visible = False
			RBLJD.Visible = False
			lblother.Visible = False
			txtotherR.Visible = False
			NewJrsydiffID()
			InsertJerseyDifference()
			UpdateJDiffLastNumberUsed()
		ElseIf RBLJD.SelectedValue = 2 Then
			lblerrajce.Visible = False
			txtactualJcut.Enabled = False
			BtnCaptureBundle.Visible = False
			ddlReason.Visible = True
			btnjrsyadj.Visible = False
		End If
	End Sub

	Protected Sub ddlReason_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlReason.SelectedIndexChanged
		btnjrsyadj.Visible = True
		If ddlReason.SelectedValue = 5 Then
			txtotherR.Visible = True
			lblother.Visible = True
			lblother.Text = "Please give a reason"
		Else
			If ddlReason.SelectedIndex = 0 Then
				btnjrsyadj.Visible = False
			Else
				btnjrsyadj.Visible = True
			End If
			lblother.Visible = False
			txtotherR.Visible = False
		End If

	End Sub

	Protected Sub btnjrsyadj_Click(sender As Object, e As EventArgs) Handles btnjrsyadj.Click
		If ddlReason.SelectedValue = 5 Then
			If txtotherR.Text.Length <> 0 Then
				NewJrsydiffID()
				InsertJerseyDifference()
				UpdateJDiffLastNumberUsed()
				UpdatewhereJdesc()
				CMTbundleCompleteviewCheck()
			End If
		Else
			NewJrsydiffID()
			InsertJerseyDifference()
			UpdateJDiffLastNumberUsed()
			UpdatewhereJdesc()
			CMTbundleCompleteviewCheck()
		End If


	End Sub


End Class