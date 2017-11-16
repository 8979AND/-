Imports System.Data.OleDb
Public Class CMTOverveiw
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		getCMTOperator()
		UpdatenullCMTspecialinstructions()
		'updatecmtBundleComplete()
		batcheck()

	End Sub

	Private Sub batcheck()
		Dim sql As String
		Select Case Session("JDescription")
			Case "Cutting"
				Sql = "SELECT CDH.BatchNo, EM.EntityName, EPC.ProductCode, SUM(CDH.JrsysToCut) AS [Total Jerseys To Cut], CSIM.CMTSpecialInstructionDetail
        FROM (((((([CMT - CMTDetailsHeader] AS CDH 
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID)
		INNER JOIN [GN - EntityMaster] AS EM 
			ON KO.EntityID = EM.EntityID)
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [KN - ProductionOrderHeader] AS POH
			ON CDH.BatchNo = POH.BatchNo)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (POH.BatchComplete = yes) AND (CDH.CutDataCaptured = no) AND (CDO.CutDate IS NULL) AND (CDH.Bundlecompleteview = no) 
		GROUP BY CDH.BatchNo, EM.EntityName, EPC.ProductCode, CSIM.CMTSpecialInstructionDetail
		ORDER BY CDH.BatchNo, EM.EntityName;"
			Case "AttachVN"
				Sql = "SELECT CDH.BatchNo, EM.EntityName, EPC.ProductCode, SUM(CDH.JrsysToCut) AS [Total Jerseys To Cut], CSIM.CMTSpecialInstructionDetail
        FROM (((((([CMT - CMTDetailsHeader] AS CDH 
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID)
		INNER JOIN [GN - EntityMaster] AS EM 
			ON KO.EntityID = EM.EntityID)
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [KN - ProductionOrderHeader] AS POH
			ON CDH.BatchNo = POH.BatchNo)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (POH.BatchComplete = yes) AND (CDH.CutDataCaptured = yes) AND (CDO.AttachVDate IS NULL) AND (CDH.Bundlecompleteview = no) 
		GROUP BY CDH.BatchNo, EM.EntityName, EPC.ProductCode, CSIM.CMTSpecialInstructionDetail
		ORDER BY CDH.BatchNo, EM.EntityName;"
			Case "Side Seams"
				Sql = "SELECT CDH.BatchNo, EM.EntityName, EPC.ProductCode, SUM(CDH.JrsysToCut) AS [Total Jerseys To Cut], CSIM.CMTSpecialInstructionDetail
        FROM (((((([CMT - CMTDetailsHeader] AS CDH 
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID)
		INNER JOIN [GN - EntityMaster] AS EM 
			ON KO.EntityID = EM.EntityID)
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [KN - ProductionOrderHeader] AS POH
			ON CDH.BatchNo = POH.BatchNo)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (POH.BatchComplete = yes) AND (CDH.CutDataCaptured = yes) AND (CDO.SideSeamsDate IS NULL) AND (CDH.Bundlecompleteview = no) 
		GROUP BY CDH.BatchNo, EM.EntityName, EPC.ProductCode, CSIM.CMTSpecialInstructionDetail
		ORDER BY CDH.BatchNo, EM.EntityName;"
			Case "Pressing"
				Sql = "SELECT CDH.BatchNo, EM.EntityName, EPC.ProductCode, SUM(CDH.JrsysToCut) AS [Total Jerseys To Cut], CSIM.CMTSpecialInstructionDetail
        FROM (((((([CMT - CMTDetailsHeader] AS CDH 
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID)
		INNER JOIN [GN - EntityMaster] AS EM 
			ON KO.EntityID = EM.EntityID)
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [KN - ProductionOrderHeader] AS POH
			ON CDH.BatchNo = POH.BatchNo)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (POH.BatchComplete = yes) AND (CDH.CutDataCaptured = yes) AND (CDO.PressDate IS NULL) AND (CDH.Bundlecompleteview = no) 
		GROUP BY CDH.BatchNo, EM.EntityName, EPC.ProductCode, CSIM.CMTSpecialInstructionDetail
		ORDER BY CDH.BatchNo, EM.EntityName;"
			Case "Dispatch"
				Sql = "SELECT CDH.BatchNo, EM.EntityName, EPC.ProductCode, SUM(CDH.JrsysToCut) AS [Total Jerseys To Cut], CSIM.CMTSpecialInstructionDetail
        FROM (((((([CMT - CMTDetailsHeader] AS CDH 
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID)
		INNER JOIN [GN - EntityMaster] AS EM 
			ON KO.EntityID = EM.EntityID)
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [KN - ProductionOrderHeader] AS POH
			ON CDH.BatchNo = POH.BatchNo)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (POH.BatchComplete = yes) AND (CDH.CutDataCaptured = yes) AND (CDO.DispatchDate IS NULL) AND (CDH.Bundlecompleteview = no) 
		GROUP BY CDH.BatchNo, EM.EntityName, EPC.ProductCode, CSIM.CMTSpecialInstructionDetail
		ORDER BY CDH.BatchNo, EM.EntityName;"
		End Select
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4")
		Dim cmd As New OleDbCommand(sql)
		Dim reader As OleDbDataReader
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()

		reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
		If reader.HasRows = True Then
			Select Case Session("JDescription")
				Case "Cutting"
					LblJDisc.Text = "Cutting"
				Case "AttachVN"
					LblJDisc.Text = "Attach V-Neck"
				Case "Side Seams"
					LblJDisc.Text = "Side Seams"
				Case "Pressing"
					LblJDisc.Text = "Pressing"
				Case "Dispatch"
					LblJDisc.Text = "Dispatch"
			End Select
		Else
			ddlCMTStaff.Visible = False
			Select Case Session("JDescription")
				Case "Cutting"
					LblJDisc.Text = "No Batches/bundles for Cutting"
				Case "AttachVN"
					LblJDisc.Text = "No Batches/bundles for Attach V-Neck"
				Case "Side Seams"
					LblJDisc.Text = "No Batches/bundles for Side Seams"
				Case "Pressing"
					LblJDisc.Text = "No Batches/bundles for Pressing"
				Case "Dispatch"
					LblJDisc.Text = "No Batches/bundles for Dispatch"
			End Select
		End If
		cmd.Connection.Close()
	End Sub

	Private Sub getCMTOperator()
		Dim strQuery As String = "SELECT EmployeeID, (EmployeeFirstName + ' ' + EmployeeLastName) AS [FullName] from [GN - EmployeeDetails] WHERE Department = 'CMT' ORDER BY EmployeeFirstName"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4")
		Dim cmd As New OleDbCommand()
		If IsPostBack = False Then
			ddlCMTStaff.AppendDataBoundItems = True
			cmd.CommandType = CommandType.Text
			cmd.CommandText = strQuery
			cmd.Connection = con
			Try
				con.Open()
				ddlCMTStaff.DataSource = cmd.ExecuteReader()
				ddlCMTStaff.DataTextField = "FullName"
				ddlCMTStaff.DataValueField = "EmployeeID"
				ddlCMTStaff.DataBind()
			Catch ex As Exception
				Throw ex
			Finally
				cmd.Connection.Close()
			End Try
		End If
	End Sub



	Private Sub getCMTStaffDetails()
		Dim cmdstring = "SELECT EmployeeID, (EmployeeFirstName + ' ' + EmployeeLastName) AS [FullName], JobDescription FROM [GN - EmployeeDetails] WHERE EmployeeID = " & ddlCMTStaff.SelectedValue
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4")
		Dim cmd As New OleDbCommand(cmdstring)
		Dim reader As OleDbDataReader
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()

		reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
		If reader.HasRows = True Then
			While reader.Read
				Session("EmployeeID") = reader("EmployeeID")
				Session("FullName") = reader("FullName")
				'Session("JDescription") = reader("JobDescription")
				'LblJDisc.Text = "Job Discription: " & Session("JDescription")
			End While
		Else
			LblJDisc.Text = "problem with displaying info from database into boxes"
		End If
		cmd.Connection.Close()
	End Sub

	Private Sub grdvCMTbatchesPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4")
		Dim cmd As New OleDbCommand()
		grdvCMTbatches.Visible = True
		Select Case Session("JDescription")
			Case "Cutting"
				SQL = "SELECT CDH.BatchNo, EM.EntityName, EPC.ProductCode, SUM(CDH.JrsysToCut) AS [Total Jerseys To Cut], CSIM.CMTSpecialInstructionDetail
        FROM (((((([CMT - CMTDetailsHeader] AS CDH 
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID)
		INNER JOIN [GN - EntityMaster] AS EM 
			ON KO.EntityID = EM.EntityID)
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [KN - ProductionOrderHeader] AS POH
			ON CDH.BatchNo = POH.BatchNo)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (POH.BatchComplete = yes) AND (CDH.CutDataCaptured = no) AND (CDO.CutDate IS NULL) AND (CDH.Bundlecompleteview = no) 
		GROUP BY CDH.BatchNo, EM.EntityName, EPC.ProductCode, CSIM.CMTSpecialInstructionDetail
		ORDER BY CDH.BatchNo, EM.EntityName;"
			Case "AttachVN"
				SQL = "SELECT CDH.BatchNo, EM.EntityName, EPC.ProductCode, SUM(CDH.JrsysToCut) AS [Total Jerseys To Cut], CSIM.CMTSpecialInstructionDetail
        FROM (((((([CMT - CMTDetailsHeader] AS CDH 
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID)
		INNER JOIN [GN - EntityMaster] AS EM 
			ON KO.EntityID = EM.EntityID)
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [KN - ProductionOrderHeader] AS POH
			ON CDH.BatchNo = POH.BatchNo)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (POH.BatchComplete = yes) AND (CDH.CutDataCaptured = yes) AND (CDO.AttachVDate IS NULL) AND (CDH.Bundlecompleteview = no) 
		GROUP BY CDH.BatchNo, EM.EntityName, EPC.ProductCode, CSIM.CMTSpecialInstructionDetail
		ORDER BY CDH.BatchNo, EM.EntityName;"
			Case "Side Seams"
				SQL = "SELECT CDH.BatchNo, EM.EntityName, EPC.ProductCode, SUM(CDH.JrsysToCut) AS [Total Jerseys To Cut], CSIM.CMTSpecialInstructionDetail
        FROM (((((([CMT - CMTDetailsHeader] AS CDH 
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID)
		INNER JOIN [GN - EntityMaster] AS EM 
			ON KO.EntityID = EM.EntityID)
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [KN - ProductionOrderHeader] AS POH
			ON CDH.BatchNo = POH.BatchNo)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (POH.BatchComplete = yes) AND (CDH.CutDataCaptured = yes) AND (CDO.SideSeamsDate IS NULL) AND (CDH.Bundlecompleteview = no) 
		GROUP BY CDH.BatchNo, EM.EntityName, EPC.ProductCode, CSIM.CMTSpecialInstructionDetail
		ORDER BY CDH.BatchNo, EM.EntityName;"
			Case "Pressing"
				SQL = "SELECT CDH.BatchNo, EM.EntityName, EPC.ProductCode, SUM(CDH.JrsysToCut) AS [Total Jerseys To Cut], CSIM.CMTSpecialInstructionDetail
        FROM (((((([CMT - CMTDetailsHeader] AS CDH 
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID)
		INNER JOIN [GN - EntityMaster] AS EM 
			ON KO.EntityID = EM.EntityID)
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [KN - ProductionOrderHeader] AS POH
			ON CDH.BatchNo = POH.BatchNo)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (POH.BatchComplete = yes) AND (CDH.CutDataCaptured = yes) AND (CDO.PressDate IS NULL) AND (CDH.Bundlecompleteview = no) 
		GROUP BY CDH.BatchNo, EM.EntityName, EPC.ProductCode, CSIM.CMTSpecialInstructionDetail
		ORDER BY CDH.BatchNo, EM.EntityName;"
			Case "Dispatch"
				SQL = "SELECT CDH.BatchNo, EM.EntityName, EPC.ProductCode, SUM(CDH.JrsysToCut) AS [Total Jerseys To Cut], CSIM.CMTSpecialInstructionDetail
        FROM (((((([CMT - CMTDetailsHeader] AS CDH 
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID)
		INNER JOIN [GN - EntityMaster] AS EM 
			ON KO.EntityID = EM.EntityID)
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [KN - ProductionOrderHeader] AS POH
			ON CDH.BatchNo = POH.BatchNo)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (POH.BatchComplete = yes) AND (CDH.CutDataCaptured = yes) AND (CDO.DispatchDate IS NULL) AND (CDH.Bundlecompleteview = no) 
		GROUP BY CDH.BatchNo, EM.EntityName, EPC.ProductCode, CSIM.CMTSpecialInstructionDetail
		ORDER BY CDH.BatchNo, EM.EntityName;"
		End Select

		con.Open()
		cmd.Connection = con
		cmd.CommandText = SQL

		Adapter.SelectCommand = cmd
		Adapter.Fill(Data)

		grdvCMTbatches.DataSource = Data
		grdvCMTbatches.DataBind()
		cmd.Connection.Close()
	End Sub
	Private Sub updatecmtBundleComplete()
		Dim cmdstring As String
		cmdstring = "UPDATE [CMT - CMTDetailsHeader]
							 SET Bundlecompleteview = yes"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4")
		Dim cmd As New OleDbCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub
	Protected Sub ddlCMTStaff_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCMTStaff.SelectedIndexChanged
		If ddlCMTStaff.SelectedIndex = 0 Then
			LblJDisc.Text = "Please select your name"
		Else
			getCMTStaffDetails()
			grdvCMTbatchesPopulate()
		End If



	End Sub

	Private Sub UpdatenullCMTspecialinstructions()
		Dim cmdstring As String = "UPDATE [KN - KnittingOrder] SET CMTSpecialInstructionID = 415 WHERE CMTSpecialInstructionID IS NULL"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4")
		Dim cmd As New OleDbCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub


	Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
		Response.Redirect("~/CMT/CMTJob.aspx")
	End Sub
End Class