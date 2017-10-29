Imports System.Data.OleDb
Public Class CMTOverveiw
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		getCMTOperator()
	End Sub

	Private Sub getCMTOperator()
		Dim strQuery As String = "SELECT EmployeeID, (EmployeeFirstName + ' ' + EmployeeLastName) AS [FullName] from [GN - EmployeeDetails] WHERE Department = 'CMT' ORDER BY EmployeeFirstName"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb")
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
				con.Close()
				cmd.Dispose()
				con.Dispose()
			End Try
		End If
	End Sub

	Private Sub getCMTStaffDetails()
		Dim cmdstring = "SELECT EmployeeID, (EmployeeFirstName + ' ' + EmployeeLastName) AS [FullName], JobDescription FROM [GN - EmployeeDetails] WHERE EmployeeID = " & ddlCMTStaff.SelectedValue
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb")
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
				Session("JDescription") = reader("JobDescription")
				LblJDisc.Text = "Job Discription: " & Session("JDescription")
			End While
		Else
			MsgBox("problem with displaying info from database into boxes")
		End If
	End Sub

	Private Sub grdvCMTbatchesPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb")
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
		WHERE (POH.BatchComplete = yes) AND (CDH.CutDataCaptured = no) AND (CDO.CutDate IS NULL) AND (CDH.BundleComplete = no) 
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
		WHERE (POH.BatchComplete = yes) AND (CDH.CutDataCaptured = yes) AND (CDO.AttachVDate IS NULL) AND (CDH.BundleComplete = no) 
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
		WHERE (POH.BatchComplete = yes) AND (CDH.CutDataCaptured = yes) AND (CDO.PressDate IS NULL) AND (CDH.BundleComplete = no) 
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
		WHERE (POH.BatchComplete = yes) AND (CDH.CutDataCaptured = yes) AND (CDO.DispatchDate IS NULL) AND (CDH.BundleComplete = no) 
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

	End Sub
	Private Sub updatecmtBundleComplete()
		Dim cmdstring As String
		cmdstring = "UPDATE [CMT - CMTDetailsHeader]
							 SET BundleComplete = yes"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		Dim cmd As New OleDbCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub
	Protected Sub ddlCMTStaff_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCMTStaff.SelectedIndexChanged
		getCMTStaffDetails()
		Select Case Session("JDescription")
			Case "Cutting", "AttachVN", "Pressing", "Dispatch"
				'updatecmtBundleComplete()
				grdvCMTbatchesPopulate()
			Case Else
				LblJDisc.Text = Session("FullName") & " does not need to use this system"
				grdvCMTbatches.Visible = False
		End Select

	End Sub
End Class