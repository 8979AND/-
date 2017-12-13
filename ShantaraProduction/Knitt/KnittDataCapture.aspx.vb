Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class KnittDataCapture
	Inherits System.Web.UI.Page
	Private BundleNo As String
	Shared Pmadeday As Integer
	Shared Pmadenight As Integer
	Private Result As String
	Shared Startdate As String
	Private compID As Integer
	Private cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"


	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Not IsPostBack Then
			getOperator()
			lblerror1.Visible = False
			lblerror2.Visible = False
		End If
		BundleNo = Request.QueryString("ID").ToString()
	End Sub

	'	Private Sub CheckMachineAllocation()
	'		Dim cmdstring = "WITH POSqry AS (
	'SELECT DISTINCT [KN - ProductionOrderHeader].BatchNo, 
	'				[KN - ProductionOrderHeader].ProductID, 
	'				[KN - ProductionOrderDetails].ProductionQty, 
	'				[KN - ProductionMachineAllocation].ComponentID, 
	'				[KN - ProductionOrderDetails].KnittingOrderID, 
	'				[KN - ProductionOrderDetails].SizeID, 
	'				[FG - Component Master].ComponentName, 
	'				([ProductionQty]*[NoOfComponents]) AS CompTot, 
	'				[FG - Style Size Comp Def Details].PanelDependency, 
	'				[FG - Pattern Component Details].KnitCombination, 
	'				[KN - ProductionMachineAllocation].MachineNumber,
	'				[KN - Knitting Machine Data].SettlingAllowance,
	'				[KN - Knitting Machine Data].MaxKnitWidth,
	'				[KN - Knitting Machine Data].CombinedComponents,
	'				[KN - Knitting Machine Data].ForceOneCompPerPnl,
	'				IIf([ForceOneCompPerPnl]=1,1,IIf([PanelDependency]='None',0,IIf([PanelDependency]='Width',([MaxKnitWidth]-[SettlingAllowance])/[ComponentWidth],([MaxKnitWidth]-[SettlingAllowance])/[ComponentLength]))) AS CompPerPnl, 
	'				[FG - Style Size Comp Def Details].ComponentWidth,
	'				[FG - Style Size Comp Def Details].ComponentLength,
	'				[KN - ProductionOrderHeader].TicketsPrinted, 
	'				[FG - End Product Codes].NoCMTReq, 
	'				[FG - End Product Codes].StyleID, 
	'				[FG - Component Master].SplitAcrossSizes,
	'				[FG - Style Size Comp Def Details].NoOfComponents
	'FROM [KN - Knitting Machine Data] 
	'INNER JOIN [KN - ProductionOrderHeader] 
	'INNER JOIN [FG - End Product Codes] 
	'	ON [KN - ProductionOrderHeader].ProductID = [FG - End Product Codes].ProductID 
	'INNER JOIN [KN - ProductionOrderDetails]
	'INNER JOIN [KN - ProductionMachineAllocation] 
	'INNER JOIN [FG - Style Size Comp Def Details] 
	'	ON [KN - ProductionMachineAllocation].ComponentID = [FG - Style Size Comp Def Details].ComponentID 
	'	ON [KN - ProductionOrderDetails].SizeID = [FG - Style Size Comp Def Details].SizeID 
	'	ON [KN - ProductionOrderHeader].BatchNo = [KN - ProductionOrderDetails].BatchNo 
	'		AND [KN - ProductionOrderHeader].BatchNo = [KN - ProductionMachineAllocation].BatchNo 
	'		AND [FG - End Product Codes].StyleID = [FG - Style Size Comp Def Details].StyleID 
	'INNER JOIN [FG - Pattern Component Details] ON [FG - End Product Codes].PatternID = [FG - Pattern Component Details].PatternID 
	'INNER JOIN [FG - Component Master] 
	'	ON [FG - Component Master].ComponentID = [FG - Style Size Comp Def Details].ComponentID 
	'		AND [KN - ProductionMachineAllocation].ComponentID = [FG - Component Master].ComponentID
	'	ON [KN - Knitting Machine Data].MachineNumber = [KN - ProductionMachineAllocation].MachineNumber 
	'INNER JOIN [KN - ProductionYarnAllocation] 
	'	ON [KN - ProductionOrderHeader].BatchNo = [KN - ProductionYarnAllocation].BatchNo
	')
	'SELECT DISTINCT BatchNo, 
	'				ProductID, 
	'				ComponentID, 
	'				KnitCombination, 
	'				MachineNumber, 
	'				NoOfComponents
	'FROM POSqry
	'ORDER BY BatchNo, ComponentID;"
	'		Dim con As New OleDbConnection("Provider=Microsoft.OLEDB.12.0;OLE DB Services=-4;Data Source=C:\Users\Deepak Vallabh\Documents\shantara\ShantaraProduction\ShantaraProduction\App_Data\Shantara Production IT.mdb")
	'		'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
	'		Dim cmd As New OleDbCommand(cmdstring)
	'		'Dim cmd As New SqlCommand(cmdstring)
	'		Dim reader As OleDbDataReader
	'		'Dim reader As SqlDataReader
	'		cmd.CommandType = CommandType.Text
	'		cmd.Connection = con
	'		cmd.Connection.Open()
	'		cmd.ExecuteNonQuery()

	'		reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
	'		If reader.HasRows = True Then
	'			While reader.Read()
	'				Session.Add("MachineNo", reader("MachineNumber"))
	'			End While
	'			If Session("MachineNo") = 0 Then
	'				MsgBox("Machine Numbers not allocated to all Components")
	'			Else
	'				MsgBox("Machines allocated")
	'			End If

	'		End If

	'	End Sub
	Private Sub Startdatedtime()
		Dim cmdstring As String
		cmdstring = "UPDATE [KN - KnittingDetailsHeader]
					 SET DateStarted ='" & DateTime.Now &
					"' WHERE BundleNo = '" & BundleNo & "'"
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand(cmdstring)
			'Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub

	Private Sub GetknittDatadb()
		Dim cmdstring = "SELECT KDH.BatchNo, 
								KDH.PanelsToMake, 
								KDH.BundleNo, 
								KDH.PanelsMadeDay, 
								KDH.PanelsMadeNight,
								KDH.QtyPerPanel,
								KDH.DateStarted,
								KDH.ComponentID,
								KO.OrderNo, 
								EPC.ProductCode, 
								EPC.ProdDescription, 
								PM.PatternName, 
								PM.Description, 
								(SM.[Size Abbreviation]) AS [Size], 
								CM.ComponentName, 							
								(SIM.SpecialInstructionDetail) AS [Special Instructions],
								PMA.MachineNumber, 
							    SSCDD.ComponentWidth, 
								SSCDD.ComponentLength, 					 
								YM.YarnDyelot,
								YCD.YarnColour
        FROM ((((((((((([KN - KnittingDetailsHeader] AS KDH 
		INNER JOIN [KN - KnittingOrder] AS KO
			On KDH.KnittingOrderID = KO.KnittingOrderID )
		INNER JOIN [FG - Style Size Comp Def Details] AS SSCDD
			ON  SSCDD.SizeID = KDH.SizeID)
		INNER JOIN [KN - ProductionMachineAllocation] AS PMA
			ON (PMA.ComponentID = SSCDD.ComponentID) AND (KDH.BatchNo = PMA.BatchNo))
		INNER JOIN [FG - Component Master] AS CM 
			ON KDH.ComponentID = CM.ComponentID)
		INNER JOIN [FG- Size Master] AS SM
			ON KDH.SizeID = SM.SizeID)
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [FG - Pattern Master] AS PM
			ON EPC.PatternID = PM.PatternID)
		INNER JOIN [KN -Special Instructions Master] AS SIM
			ON KO.SpecialInstructionID = SIM.SpecialInstructionID)
		INNER JOIN [KN - ProductionYarnAllocation] AS PYA
			ON KDH.BatchNo = PYA.BatchNo)
		INNER JOIN [YN - Yarn Master] AS YM 
			ON PYA.YarnID = YM.YarnID)
		INNER JOIN [YN - Yarn Colour Defns] AS YCD
			ON YM.YarnColourID = YCD.YarnColourID)
		WHERE KDH.BundleNo = '" & BundleNo & "';"
		Using con As New OleDbConnection(cnString)
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
					txtorderNo.Text = reader("OrderNo")
					lblBundleNo.Text = "BundleNo: " & reader("BundleNo")
					txtBatchNo.Text = reader("BatchNo")
					txtProdcode.Text = reader("ProductCode")
					If reader.IsDBNull(10) Then
						txtProdDescr.Text = ""
					Else
						txtProdDescr.Text = reader("ProdDescription")
					End If
					txtPToMake.Text = reader("PanelsToMake")
					txtPattern.Text = reader("PatternName")
					txtPatternDescr.Text = reader("Description")
					txtSize.Text = reader("Size")
					txtSInstruction.Text = reader("Special Instructions")
					txtComponent.Text = reader("ComponentName")
					Session("compID") = reader("ComponentID")
					txtQPpanel.Text = reader("QtyPerPanel")
					txtMachineNo.Text = reader("MachineNumber")
					txtKwidth.Text = reader("ComponentWidth")
					txtkLength.Text = reader("ComponentLength")
					'txtNeedles.Text = reader("")
					'txtCycles.Text = reader("")
					txtYarnColour.Text = reader("YarnColour")
					txtYarnDyelot.Text = reader("YarnDyelot")
					Pmadeday = reader("PanelsMadeDay")
					Pmadenight = reader("PanelsMadeNight")
					If reader.IsDBNull(6) Then
						Startdate = ""
					Else
						Startdate = reader("DateStarted")
					End If
				End While
			Else
				lblerror1.Text = "problem with reading info from database into boxes"
			End If
		End Using
	End Sub



	Protected Sub ddlOperator_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlOperator.SelectedIndexChanged
		'.visible
	End Sub

	Protected Sub ddlShift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlShift.SelectedIndexChanged

	End Sub

	Private Sub getOperator()
		Dim strQuery As String = "SELECT EmployeeID, (EmployeeFirstName + ' ' + EmployeeLastName) AS [FullName] from [GN - EmployeeDetails] WHERE JobDescription = 'MC-Operator'"
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand()
			'Dim cmd As New SqlCommand()
			If IsPostBack = False Then
				ddlOperator.AppendDataBoundItems = True
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strQuery
				cmd.Connection = con
				Try
					con.Open()
					ddlOperator.DataSource = cmd.ExecuteReader()
					ddlOperator.DataTextField = "FullName"
					ddlOperator.DataValueField = "EmployeeID"
					ddlOperator.DataBind()
				Catch ex As Exception
					Throw ex
				End Try
			End If
		End Using
	End Sub
	Private Sub KnittBundleCompleteCheck()
		Dim pmadecurrent As String
		pmadecurrent = txtPanelsMade.Text
		Dim cmdstring = "SELECT KDH.BatchNo, PanelsMadeDay, PanelsMadeNight, PanelsToMake
						 FROM [KN - KnittingDetailsHeader] AS KDH
						 WHERE KDH.BundleNo ='" & BundleNo & "'"
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand(cmdstring)
			'Dim cmd As New SqlCommand(cmdstring)
			Dim reader As OleDbDataReader
			'Dim reader As SqlDataReader
			Dim totalPMade As Integer
			Dim PanelsToMake As Integer

			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
			reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
			If reader.HasRows = True Then
				While reader.Read
					totalPMade = reader("PanelsMadeDay") + reader("PanelsMadeNight")
					PanelsToMake = reader("PanelsToMake")
				End While
				If ((totalPMade + CInt(pmadecurrent)) >= PanelsToMake) And ((totalPMade + CInt(pmadecurrent)) <= (PanelsToMake + 8)) Then
					Result = 1 'bundle complete
					'MsgBox("Bundle complete")
				ElseIf (totalPMade + CInt(pmadecurrent)) < PanelsToMake Then
					Result = 2 'bundle incomplete
					'MsgBox("Bundle Incomplete")
				Else
					Result = 3
					lblerror1.Visible = True
					lblerror1.Text = "Please check number of bundles entered"
				End If
			Else
				Result = 3
				lblerror2.Visible = True
				lblerror2.Text = "error with Sub KnittBundleCompleteCheck()"
			End If
		End Using
	End Sub
	Private Sub grdvprevpnlsPopulate()
		Dim Adapter As New OleDbDataAdapter
		'Dim Adapter As New SqlDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand()
			'Dim cmd As New SqlCommand()
			grdvprevpnls.Visible = True
			SQL = "SELECT kdh.BundleNo, kdh.PanelsMadeDay, kdh.PanelsMadeNight, (kdh.PanelsToMake - (kdh.PanelsMadeDay + kdh.PanelsMadeNight)) AS [panels outstanding]
        FROM [KN - KnittingDetailsHeader] AS kdh
		WHERE kdh.BundleNo = '" & BundleNo & "';"

			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvprevpnls.DataSource = Data
			grdvprevpnls.DataBind()
		End Using
	End Sub

	Private Sub Machineupdate()
		Dim cmdstring As String
		cmdstring = "UPDATE [KN - ProductionMachineAllocation]
					 SET MachineNumber =" & txtMachineNo.Text &
					" WHERE (BatchNo = '" & txtBatchNo.Text & "') AND (ComponentID = " & Session("compID") & ")"
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand(cmdstring)
			'Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub

	Private Sub kdcUpdateRecord()
		Dim pmadecurrent As String
		pmadecurrent = txtPanelsMade.Text
		Dim cmdstring As String
		If ddlShift.SelectedIndex = 1 Then
			If Result = 1 Then
				If Pmadeday = 0 Then
					cmdstring = "UPDATE [KN - KnittingDetailsHeader]
						     SET OperatorDay =" & ddlOperator.SelectedValue & ", PanelsMadeDay =" & txtPanelsMade.Text & ", DateCompleted ='" & DateTime.Now & "', KnittComplete = yes, MachineNo =" & txtMachineNo.Text &
								" WHERE BundleNo = '" & BundleNo & "'"
				Else
					If CInt(pmadecurrent) > Pmadeday Then
						cmdstring = "UPDATE [KN - KnittingDetailsHeader]
						     SET OperatorDay =" & ddlOperator.SelectedValue & ",PanelsMadeDay =" & (Pmadeday + CInt(txtPanelsMade.Text)) & ", DateCompleted ='" & DateTime.Now & "', KnittComplete = yes, MachineNo =" & txtMachineNo.Text &
							" WHERE BundleNo = '" & BundleNo & "'"
					Else
						cmdstring = "UPDATE [KN - KnittingDetailsHeader]
						     SET PanelsMadeDay =" & (Pmadeday + CInt(txtPanelsMade.Text)) & ", DateCompleted ='" & DateTime.Now & "', KnittComplete = yes, MachineNo =" & txtMachineNo.Text &
							" WHERE BundleNo = '" & BundleNo & "'"
					End If
				End If
			ElseIf Result = 2 Then
				If Pmadeday = 0 Then
					cmdstring = "UPDATE [KN - KnittingDetailsHeader]
						     SET OperatorDay =" & ddlOperator.SelectedValue & ", PanelsMadeDay =" & CInt(txtPanelsMade.Text) & ", KnittComplete = no, MachineNo =" & txtMachineNo.Text &
								" WHERE BundleNo = '" & BundleNo & "'"
				Else
					If CInt(pmadecurrent) > Pmadeday Then
						cmdstring = "UPDATE [KN - KnittingDetailsHeader]
						     SET OperatorDay =" & ddlOperator.SelectedValue & ", PanelsMadeDay =" & (Pmadeday + CInt(txtPanelsMade.Text)) & ", KnittComplete = no, MachineNo =" & txtMachineNo.Text &
							" WHERE BundleNo = '" & BundleNo & "'"
					Else
						cmdstring = "UPDATE [KN - KnittingDetailsHeader]
						     SET PanelsMadeDay =" & (Pmadeday + CInt(txtPanelsMade.Text)) & ", KnittComplete = no, MachineNo =" & txtMachineNo.Text &
							" WHERE BundleNo = '" & BundleNo & "'"
					End If

				End If
			ElseIf Result = 3 Then
				Exit Sub
			End If

		ElseIf ddlShift.SelectedIndex = 2 Then
			If Result = 1 Then
				If Pmadenight = 0 Then
					cmdstring = "UPDATE [KN - KnittingDetailsHeader]
							 SET OperatorNight =" & ddlOperator.SelectedValue & ", PanelsMadeNight =" & CInt(txtPanelsMade.Text) & ", DateCompleted ='" & DateTime.Now & "', KnittComplete = yes, MachineNo =" & txtMachineNo.Text &
							" WHERE BundleNo = '" & BundleNo & "'"
				Else
					If CInt(pmadecurrent) > Pmadenight Then
						cmdstring = "UPDATE [KN - KnittingDetailsHeader]
							 SET OperatorNight =" & ddlOperator.SelectedValue & ",PanelsMadeNight =" & (Pmadenight + CInt(txtPanelsMade.Text)) & ", DateCompleted ='" & DateTime.Now & "', KnittComplete = yes, MachineNo =" & txtMachineNo.Text &
							" WHERE BundleNo = '" & BundleNo & "'"
					Else
						cmdstring = "UPDATE [KN - KnittingDetailsHeader]
							 SET PanelsMadeNight =" & (Pmadenight + CInt(txtPanelsMade.Text)) & ", DateCompleted ='" & DateTime.Now & "', KnittComplete = yes, MachineNo =" & txtMachineNo.Text &
							" WHERE BundleNo = '" & BundleNo & "'"
					End If
				End If
			ElseIf Result = 2 Then
				If Pmadenight = 0 Then
					cmdstring = "UPDATE [KN - KnittingDetailsHeader]
							 SET OperatorNight =" & ddlOperator.SelectedValue & ", PanelsMadeNight =" & CInt(txtPanelsMade.Text) & ", KnittComplete = no, MachineNo =" & txtMachineNo.Text &
							" WHERE BundleNo = '" & BundleNo & "'"
				Else
					If CInt(pmadecurrent) > Pmadenight Then
						cmdstring = "UPDATE [KN - KnittingDetailsHeader]
							 SET OperatorNight =" & ddlOperator.SelectedValue & ", PanelsMadeNight =" & (Pmadenight + CInt(txtPanelsMade.Text)) & ", KnittComplete = no, MachineNo =" & txtMachineNo.Text &
							" WHERE BundleNo = '" & BundleNo & "'"
					Else
						cmdstring = "UPDATE [KN - KnittingDetailsHeader]
							 SET PanelsMadeNight =" & (Pmadenight + CInt(txtPanelsMade.Text)) & ", KnittComplete = no, MachineNo =" & txtMachineNo.Text &
							" WHERE BundleNo = '" & BundleNo & "'"
					End If
				End If
			ElseIf Result = 3 Then
				Exit Sub
			End If
		End If
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand(cmdstring)
			'Dim cmd As New SqlCommand(cmdstring)
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
		Session("pagechange") = 1

	End Sub

	Public Sub UpdateKnittbatchComplete()
		Dim cmdstring As String = "UPDATE [KN - ProductionOrderHeader] SET KnittBatchComplete = yes WHERE BatchNo =  '" & txtBatchNo.Text & "'"
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
	Public Sub KnittbatchCompleteCheck()
		BundleNo = Request.QueryString("ID").ToString()
		Dim cmdstring = "SELECT POD.BatchNo, KDH.BundleNo, KDH.KnittComplete, POH.KnittBatchComplete
		FROM ((([KN - ProductionOrderDetails] AS POD 
		INNER JOIN [KN - KnittingOrder] AS KO
			On POD.KnittingOrderID = KO.KnittingOrderID )
		INNER JOIN [KN - ProductionOrderHeader] AS POH
			ON POD.BatchNo = POH.BatchNo)
		INNER JOIN [KN - KnittingDetailsHeader] AS KDH
			ON POD.BatchNo = KDH.BatchNo)
		WHERE (KDH.KnittComplete = no) AND (POH.KnittBatchComplete = no) AND (KDH.BatchNo = '" & txtBatchNo.Text & "')"
		Using con As New OleDbConnection(cnString)
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
			If Result = 1 Then
				If reader.HasRows = False Then
					UpdateKnittbatchComplete()
					Response.Redirect("~\Knitt\DisplayBatches.aspx")
				Else
					Response.Redirect("~\Knitt\DisplayBatchBundles.aspx?ID=" & txtBatchNo.Text)
				End If
			ElseIf Result = 2 Then
				Response.Redirect("~\Knitt\DisplayBatchBundles.aspx?ID=" & txtBatchNo.Text)
			ElseIf Result = 3 Then
				Exit Sub
			End If
		End Using
	End Sub

	Protected Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
		txtorderNo.Visible = True
		txtBatchNo.Visible = True
		txtProdcode.Visible = True
		txtProdDescr.Visible = True
		txtPToMake.Visible = True
		txtPattern.Visible = True
		txtPatternDescr.Visible = True
		txtSize.Visible = True
		txtSInstruction.Visible = True
		txtComponent.Visible = True
		txtQPpanel.Visible = True
		txtKwidth.Visible = True
		txtkLength.Visible = True
		txtNeedles.Visible = True
		txtCycles.Visible = True
		txtYarnColour.Visible = True
		txtYarnDyelot.Visible = True
		ddlShift.Visible = True
		ddlOperator.Visible = True
		txtMachineNo.Visible = True
		txtPanelsMade.Visible = True
		BtnCaptureBundle.Visible = True
		GetknittDatadb()
		If Startdate = "" Then
			Startdatedtime()
		End If
		grdvprevpnlsPopulate()
		'KnittBundleCompleteCheck()
		'UpdateAllRecordscompletes()
	End Sub



	Protected Sub BtnCaptureBundle_Click(sender As Object, e As EventArgs) Handles BtnCaptureBundle.Click
		lblerror1.Visible = False
		lblerror2.Visible = False
		If ddlOperator.SelectedIndex <> 0 Then
			lblerroperator.Visible = False
			If ddlShift.SelectedIndex <> 0 Then
				lblerrshift.Visible = False
				If txtPanelsMade.Text <> "0" Then
					lblerrpanels.Visible = False
					KnittBundleCompleteCheck()
					If Result = 1 Or Result = 2 Then
						Machineupdate()
						kdcUpdateRecord()
						KnittbatchCompleteCheck()
					Else
						Exit Sub
					End If
				Else
					lblerrpanels.Visible = True
					lblerrpanels.Text = "Please enter an appropriate value for Panels Made"
					txtPanelsMade.Focus()
					Exit Sub
				End If
			Else
				lblerrshift.Visible = True
				lblerrshift.Text = "Please Select Shift"
				ddlShift.Focus()
				Exit Sub
			End If
		Else
			lblerroperator.Visible = True
			lblerroperator.Text = "Please Select Operator"
			ddlOperator.Focus()
			Exit Sub
		End If

	End Sub

	Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
		Response.Redirect("~/Knitt/DisplayBatchBundles.aspx?ID=" & Session("BatchNo"))
	End Sub

	Protected Sub txtMachineNo_TextChanged(sender As Object, e As EventArgs) Handles txtMachineNo.TextChanged

	End Sub
End Class