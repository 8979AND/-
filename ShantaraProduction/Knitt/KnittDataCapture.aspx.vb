Imports System.Data.SqlClient

Public Class KnittDataCapture
	Inherits System.Web.UI.Page
	Private BundleNo As String
	Private Pmadeday As Integer
	Private Pmadenight As Integer

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		GetknittDatadb()
		getOperator()
	End Sub

	Private Sub CheckMachineAllocation()
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmdstring = "WITH POSqry AS (
SELECT DISTINCT [KN - ProductionOrderHeader].BatchNo, 
				[KN - ProductionOrderHeader].ProductID, 
				[KN - ProductionOrderDetails].ProductionQty, 
				[KN - ProductionMachineAllocation].ComponentID, 
				[KN - ProductionOrderDetails].KnittingOrderID, 
				[KN - ProductionOrderDetails].SizeID, 
				[FG - Component Master].ComponentName, 
				([ProductionQty]*[NoOfComponents]) AS CompTot, 
				[FG - Style Size Comp Def Details].PanelDependency, 
				[FG - Pattern Component Details].KnitCombination, 
				[KN - ProductionMachineAllocation].MachineNumber,
				[KN - Knitting Machine Data].SettlingAllowance,
				[KN - Knitting Machine Data].MaxKnitWidth,
				[KN - Knitting Machine Data].CombinedComponents,
				[KN - Knitting Machine Data].ForceOneCompPerPnl,
				IIf([ForceOneCompPerPnl]=1,1,IIf([PanelDependency]='None',0,IIf([PanelDependency]='Width',([MaxKnitWidth]-[SettlingAllowance])/[ComponentWidth],([MaxKnitWidth]-[SettlingAllowance])/[ComponentLength]))) AS CompPerPnl, 
				[FG - Style Size Comp Def Details].ComponentWidth,
				[FG - Style Size Comp Def Details].ComponentLength,
				[KN - ProductionOrderHeader].TicketsPrinted, 
				[FG - End Product Codes].NoCMTReq, 
				[FG - End Product Codes].StyleID, 
				[FG - Component Master].SplitAcrossSizes,
				[FG - Style Size Comp Def Details].NoOfComponents
FROM [KN - Knitting Machine Data] 
INNER JOIN [KN - ProductionOrderHeader] 
INNER JOIN [FG - End Product Codes] 
	ON [KN - ProductionOrderHeader].ProductID = [FG - End Product Codes].ProductID 
INNER JOIN [KN - ProductionOrderDetails]
INNER JOIN [KN - ProductionMachineAllocation] 
INNER JOIN [FG - Style Size Comp Def Details] 
	ON [KN - ProductionMachineAllocation].ComponentID = [FG - Style Size Comp Def Details].ComponentID 
	ON [KN - ProductionOrderDetails].SizeID = [FG - Style Size Comp Def Details].SizeID 
	ON [KN - ProductionOrderHeader].BatchNo = [KN - ProductionOrderDetails].BatchNo 
		AND [KN - ProductionOrderHeader].BatchNo = [KN - ProductionMachineAllocation].BatchNo 
		AND [FG - End Product Codes].StyleID = [FG - Style Size Comp Def Details].StyleID 
INNER JOIN [FG - Pattern Component Details] ON [FG - End Product Codes].PatternID = [FG - Pattern Component Details].PatternID 
INNER JOIN [FG - Component Master] 
	ON [FG - Component Master].ComponentID = [FG - Style Size Comp Def Details].ComponentID 
		AND [KN - ProductionMachineAllocation].ComponentID = [FG - Component Master].ComponentID
	ON [KN - Knitting Machine Data].MachineNumber = [KN - ProductionMachineAllocation].MachineNumber 
INNER JOIN [KN - ProductionYarnAllocation] 
	ON [KN - ProductionOrderHeader].BatchNo = [KN - ProductionYarnAllocation].BatchNo
)
SELECT DISTINCT BatchNo, 
				ProductID, 
				ComponentID, 
				KnitCombination, 
				MachineNumber, 
				NoOfComponents
FROM POSqry
ORDER BY BatchNo, ComponentID;"
		Dim cmd As New SqlCommand(cmdstring)
		Dim reader As SqlDataReader
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()

		reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
		If reader.HasRows = True Then
			While reader.Read()
				Session.Add("MachineNo", reader("MachineNumber"))
			End While
			If Session("MachineNo") = 0 Then
				MsgBox("Machine Numbers not allocated to all Components")
			Else
				MsgBox("Machines allocated")
			End If

		End If

	End Sub
	Private Sub Startdatedtime()
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmdstring As String
		cmdstring = "UPDATE [KN - KnittingDetailsHeader]
					 SET DateStarted ='" & DateTime.Now &
					"' WHERE BundleNo = '" & BundleNo & "'"
		Dim cmd As New SqlCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub

	Private Sub GetknittDatadb()
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		BundleNo = Request.QueryString("ID").ToString()
		Dim cmdstring = "SELECT KDH.BatchNo, KDH.PanelsToMake, KDH.BundleNo, KDH.PanelsMadeDay, KDH.PanelsMadeNight, KO.OrderNo, EPC.ProductCode, EPC.ProdDescription, 
						  PM.PatternName, PM.Description, SM.Size, CM.ComponentName, 
						 (SIM.SpecialInstructionDetail) AS [Special Instructions], PMA.MachineNumber, 
						 SSCDD.ComponentWidth, SSCDD.ComponentLength, KDH.QtyPerPanel, YM.YarnDyelot,
						 YCD.YarnColour
        FROM [KN - KnittingDetailsHeader] KDH INNER JOIN [KN - KnittingOrder] KO
			On KDH.KnittingOrderID = KO.KnittingOrderID 
		INNER JOIN [KN - ProductionMachineAllocation] PMA
		INNER JOIN [FG - Style Size Comp Def Details] SSCDD
			ON PMA.ComponentID = SSCDD.ComponentID 
			ON KDH.SizeID = SSCDD.SizeID  
		AND KDH.BatchNo = PMA.BatchNo
		INNER JOIN [FG - Component Master] CM 
			ON KDH.ComponentID = CM.ComponentID
		INNER JOIN [FG- Size Master] SM
			ON KDH.SizeID = SM.SizeID
		INNER JOIN [FG - End Product Codes] EPC
			ON KO.ProductID = EPC.ProductID
		INNER JOIN [FG - Pattern Master] PM
			ON EPC.PatternID = PM.PatternID
		INNER JOIN [KN -Special Instructions Master] SIM
			ON KO.SpecialInstructionID = SIM.SpecialInstructionID
		INNER JOIN [KN - ProductionYarnAllocation] PYA
			ON KDH.BatchNo = PYA.BatchNo
		INNER JOIN [YN - Yarn Master] YM 
			ON PYA.YarnID = YM.YarnID
		INNER JOIN [YN - Yarn Colour Defns] YCD
			ON YM.YarnColourID = YCD.YarnColourID
		WHERE KDH.BundleNo = '" & BundleNo & "';"
		Dim cmd As New SqlCommand(cmdstring)
		Dim reader As SqlDataReader
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
				txtProdDescr.Text = reader("ProdDescription")
				txtPToMake.Text = reader("PanelsToMake")
				txtPattern.Text = reader("PatternName")
				txtPatternDescr.Text = reader("Description")
				txtSize.Text = reader("Size")
				txtSInstruction.Text = reader("Special Instructions")
				txtComponent.Text = reader("ComponentName")
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

			End While
		Else
			MsgBox("db not accesible")
		End If

	End Sub



	Protected Sub ddlOperator_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlOperator.SelectedIndexChanged
		'.visible
	End Sub

	Protected Sub ddlShift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlShift.SelectedIndexChanged

	End Sub

	Private Sub getOperator()
		Dim strQuery As String = "SELECT EmployeeID, (EmployeeFirstName + ' ' + EmployeeLastName) AS [FullName] from [GN - EmployeeDetails] WHERE JobDescription = 'MC-Operator'"
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New SqlCommand()
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
			Finally
				con.Close()
				cmd.Dispose()
				con.Dispose()
			End Try
		End If
	End Sub

	Private Sub kdcUpdateRecord()
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmdstring As String
		Dim result As String = MsgBox("Is This Bundle complete", MsgBoxStyle.YesNoCancel, "Bundle Check")
		If ddlShift.SelectedIndex = 1 Then
			If result = vbYes Then
				If Pmadeday = 0 Then
					cmdstring = "UPDATE [KN - KnittingDetailsHeader]
						     SET OperatorDay =" & ddlOperator.SelectedValue & ", PanelsMadeDay =" & txtPanelsMade.Text & ", DateCompleted ='" & DateTime.Now & "', BundleComplete = 1" &
								" WHERE BundleNo = '" & BundleNo & "'"
				Else
					cmdstring = "UPDATE [KN - KnittingDetailsHeader]
						     SET PanelsMadeDay =" & (Pmadeday + txtPanelsMade.Text) & ", DateCompleted ='" & DateTime.Now & "', BundleComplete = 1" &
							" WHERE BundleNo = '" & BundleNo & "'"
				End If
			ElseIf result = vbNo Then
				If Pmadeday = 0 Then
					cmdstring = "UPDATE [KN - KnittingDetailsHeader]
						     SET OperatorDay =" & ddlOperator.SelectedValue & ", PanelsMadeDay =" & txtPanelsMade.Text & ", BundleComplete = 0" &
								" WHERE BundleNo = '" & BundleNo & "'"
				Else
					cmdstring = "UPDATE [KN - KnittingDetailsHeader]
						     SET PanelsMadeDay =" & (Pmadeday + txtPanelsMade.Text) & ", BundleComplete = 0" &
							" WHERE BundleNo = '" & BundleNo & "'"
				End If
			ElseIf result = vbCancel Then
				Exit Sub
			End If

		ElseIf ddlShift.SelectedIndex = 2 Then
			If result = vbYes Then
				If Pmadenight = 0 Then
					cmdstring = "UPDATE [KN - KnittingDetailsHeader]
							 SET OperatorNight =" & ddlOperator.SelectedValue & ", PanelsMadeNight =" & txtPanelsMade.Text & ", DateCompleted ='" & DateTime.Now & "', BundleComplete = 1" &
							" WHERE BundleNo = '" & BundleNo & "'"
				Else
					cmdstring = "UPDATE [KN - KnittingDetailsHeader]
							 SET PanelsMadeNight =" & (Pmadenight + txtPanelsMade.Text) & ", DateCompleted ='" & DateTime.Now & "', BundleComplete = 1" &
							" WHERE BundleNo = '" & BundleNo & "'"
				End If
			ElseIf result = vbNo Then
				If Pmadenight = 0 Then
					cmdstring = "UPDATE [KN - KnittingDetailsHeader]
							 SET OperatorNight =" & ddlOperator.SelectedValue & ", PanelsMadeNight =" & txtPanelsMade.Text & ", BundleComplete = 0" &
							" WHERE BundleNo = '" & BundleNo & "'"
				Else
					cmdstring = "UPDATE [KN - KnittingDetailsHeader]
							 SET PanelsMadeNight =" & (Pmadenight + txtPanelsMade.Text) & ", BundleComplete = 0" &
							" WHERE BundleNo = '" & BundleNo & "'"
				End If
			ElseIf result = vbCancel Then
				Exit Sub
			End If
		End If

		Dim cmd As New SqlCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
		Session("pagechange") = 1
		'Session("BatchNo") = txtBatchNo.Text
		Response.Redirect("~\Knitt\DisplayBatchBundles.aspx?ID=" & txtBatchNo.Text)

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
		txtMachineNo.Visible = True
		txtKwidth.Visible = True
		txtkLength.Visible = True
		txtNeedles.Visible = True
		txtCycles.Visible = True
		txtYarnColour.Visible = True
		txtYarnDyelot.Visible = True
		ddlShift.Visible = True
		ddlOperator.Visible = True
		txtPanelsMade.Visible = True
		BtnCaptureBundle.Visible = True
		Startdatedtime()
	End Sub

	Protected Sub BtnCaptureBundle_Click(sender As Object, e As EventArgs) Handles BtnCaptureBundle.Click
		kdcUpdateRecord()
	End Sub
End Class