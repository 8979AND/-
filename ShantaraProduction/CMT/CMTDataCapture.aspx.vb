Imports System.Data.OleDb
Public Class CMTDataCapture
	Inherits System.Web.UI.Page

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
		WHERE CDH.BundleNo = '" & Session("BundleNo") & "';"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;OLE DB Services=-4;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		Dim cmd As New OleDbCommand(cmdstring)
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
					txtProdDescr.Text = reader("ProdDescription")
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
		Else
			txtAJCutD.Visible = True
			lblajc.Visible = True
			txtJtoCut.Visible = False
			lblj2c.Visible = False
			txtactualJcut.Visible = False
			lblajce.Visible = False
		End If
		lblOperation.Text = Session("FullName") & " - " & Session("JDescription")
		cmd.Connection.Close()
	End Sub
	Private Sub Updatecuttcaptured()
		Dim cmdstring As String
		cmdstring = "UPDATE [CMT - CMTDetailsHeader]
							 SET CutDataCaptured = yes, 
								 ActualJrsysCut = " & txtactualJcut.Text &
							 " WHERE BundleNo = '" & Session("BundleNo") & "'"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;OLE DB Services=-4;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		Dim cmd As New OleDbCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub
	Private Sub UpdatewhereJdesc()
		Dim cmdstring As String
		Select Case Session("JDescription")
			Case "Cutting"
				cmdstring = "UPDATE [CMT - CMTDetailsOperations]
							 SET CutterID =" & Session("EmployeeID") &
							", CutDate ='" & DateTime.Now &
							"' WHERE BundleNo = '" & Session("BundleNo") & "'"
				Updatecuttcaptured()
			Case "AttachVN"
				cmdstring = "UPDATE [CMT - CMTDetailsOperations]
							 SET AttachVID =" & Session("EmployeeID") &
							", AttachVDate ='" & DateTime.Now &
							"' WHERE BundleNo = '" & Session("BundleNo") & "'"
			Case "Side Seams"
				cmdstring = "UPDATE [CMT - CMTDetailsOperations]
							 SET SideSeamsID =" & Session("EmployeeID") &
							", SideSeamsDate ='" & DateTime.Now &
							"' WHERE BundleNo = '" & Session("BundleNo") & "'"
			Case "Pressing"
				cmdstring = "UPDATE [CMT - CMTDetailsOperations]
							 SET PressID =" & Session("EmployeeID") &
							", PressDate ='" & DateTime.Now &
							"' WHERE BundleNo = '" & Session("BundleNo") & "'"
			Case "Dispatch"
				cmdstring = "UPDATE [CMT - CMTDetailsOperations]
							 SET DispatcherID =" & Session("EmployeeID") &
							", DispatchDate ='" & DateTime.Now &
							"' WHERE BundleNo = '" & Session("BundleNo") & "'"
		End Select
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;OLE DB Services=-4;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		Dim cmd As New OleDbCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub

	Public Sub CMTbatchCompleteCheck()
		Dim cmdstring As String
		Select Case Session("JDescription")
			Case "Cutting"
				cmdstring = "SELECT CDH.BatchNo
							  FROM ([CMT - CMTDetailsOperations] AS CDO
							 INNER JOIN [CMT - CMTDetailsHeader] AS CDH
								ON CDO.BundleNo = CDH.BundleNo)
							 WHERE (CDO.CutDate IS NULL) AND (CDH.BatchNo = '" & txtBatchNo.Text & "')"
			Case "AttachVN"
				cmdstring = "SELECT CDH.BatchNo
							 FROM ([CMT - CMTDetailsOperations] AS CDO
							 INNER JOIN [CMT - CMTDetailsHeader] AS CDH
								ON CDO.BundleNo = CDH.BundleNo)
							 WHERE (CDO.AttachVDate IS NULL) AND (CDH.BatchNo = '" & txtBatchNo.Text & "') AND (CDH.CutDataCaptured = yes)"
			Case "Side Seams"
				cmdstring = "SELECT CDH.BatchNo
							 FROM ([CMT - CMTDetailsOperations] AS CDO
							 INNER JOIN [CMT - CMTDetailsHeader] AS CDH
								ON CDO.BundleNo = CDH.BundleNo)
							 WHERE (CDO.SideSeamsDate IS NULL) AND (CDH.BatchNo = '" & txtBatchNo.Text & "') AND (CDH.CutDataCaptured = yes)"
			Case "Pressing"
				cmdstring = "SELECT CDH.BatchNo
							 FROM ([CMT - CMTDetailsOperations] AS CDO
							 INNER JOIN [CMT - CMTDetailsHeader] AS CDH
								ON CDO.BundleNo = CDH.BundleNo)
							 WHERE (CDO.PressDate IS NULL) AND (CDH.BatchNo = '" & txtBatchNo.Text & "') AND (CDH.CutDataCaptured = yes)"
			Case "Dispatch"
				cmdstring = "SELECT CDH.BatchNo
							 FROM ([CMT - CMTDetailsOperations] AS CDO
							 INNER JOIN [CMT - CMTDetailsHeader] AS CDH
								ON CDO.BundleNo = CDH.BundleNo)
							 WHERE (CDO.DispatchDate IS NULL) AND (CDH.BatchNo = '" & txtBatchNo.Text & "') AND (CDH.CutDataCaptured = yes)"
		End Select
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;OLE DB Services=-4;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		Dim cmd As New OleDbCommand(cmdstring)
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
		cmd.Connection.Close()
	End Sub
	Private Sub UpdateCMTBundleCompleteview()
		Dim cmdstring As String
		cmdstring = "UPDATE [CMT - CMTDetailsHeader]
							 SET Bundlecompleteview = yes
							 WHERE BundleNo = '" & Session("BundleNo") & "'"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;OLE DB Services=-4;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		Dim cmd As New OleDbCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub
	Public Sub CMTbundleCompleteviewCheck()
		Dim cmdstring As String
		cmdstring = "SELECT BundleNo
					 FROM [CMT - CMTDetailsOperations] 
					 WHERE (CutDate IS NOT NULL) AND (AttachVDate IS NOT NULL) AND (SideSeamsDate IS NOT NULL) AND (PressDate IS NOT NULL) AND (DispatchDate IS NOT NULL) AND (BundleNo = '" & Session("BundleNo") & "')"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;OLE DB Services=-4;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		Dim cmd As New OleDbCommand(cmdstring)
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
		cmd.Connection.Close()
	End Sub

	Protected Sub BtnCaptureBundle_Click(sender As Object, e As EventArgs) Handles BtnCaptureBundle.Click
		If Session("JDescription") = "Cutting" Then
			If lblajce.Text <> "0" Then
				lblerrajce.Visible = False
				UpdatewhereJdesc()
				CMTbundleCompleteviewCheck()
			Else
				lblerrajce.Visible = True
				lblerrajce.Text = "please enter Valid number of jerseys"
			End If
		Else
			UpdatewhereJdesc()
			CMTbundleCompleteviewCheck()
		End If


	End Sub
End Class