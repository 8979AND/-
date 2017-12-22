Imports System.Data.OleDb
Imports System.Math
Imports System.Data
Imports System.IO
Public Class ProductionOrderIssue
	Inherits System.Web.UI.Page
	Private cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"
	Shared componentName As String
	Shared PnlsToProduce As Integer
	Shared MxBndleSz As Integer
	Shared knittOrderID As Integer
	Shared PocketsToMake As Integer
	Shared componentID As Integer
	Shared sizeID As Integer
	Shared qtyppnl As Integer
	Shared bundleNo As String
	Shared pnls2prod As Integer
	Shared bundlenum As Integer
	Shared PanelsToMake As Integer
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

	End Sub

	Private Sub grdvMachineGroupAllocationPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			grdvMachineGroupAllocation.Visible = True
			'btnBack.Visible = False
			'btnAddUser.Visible = True	
			SQL = "SELECT BatchNo, ComponentID
			   FROM [KN - ProductionMachineAllocation]
			   WHERE BatchNo='" & txtbatchno.Text & "';"
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvMachineGroupAllocation.DataSource = Data
			grdvMachineGroupAllocation.DataBind()
		End Using
	End Sub

	Private Sub Updatemachineallocation()
		For i As Integer = 0 To grdvMachineGroupAllocation.Rows.Count - 1
			Dim ddl As DropDownList = DirectCast(grdvMachineGroupAllocation.Rows(i).Cells(0).FindControl("ddlMGA"), DropDownList)
			If ddl.SelectedIndex = 0 Then
				lblerrMGA.Visible = True
				lblerrMGA.Text = "please select machine number"
				Exit Sub
			Else
				Dim cmdstring As String
				cmdstring = " UPDATE [KN - ProductionMachineAllocation] 
						  SET MachineNumber = " & ddl.SelectedValue &
							" WHERE (BatchNo ='" & grdvMachineGroupAllocation.Rows(i).Cells(1).Text & "') AND (ComponentID =" & grdvMachineGroupAllocation.Rows(i).Cells(2).Text & ");"
				Using con As New OleDbConnection(cnString)
					Dim cmd As New OleDbCommand(cmdstring)
					cmd.CommandType = CommandType.Text
					cmd.Connection = con
					cmd.Connection.Open()
					cmd.ExecuteNonQuery()
				End Using
				lblerrMGA.Visible = False
			End If
		Next
	End Sub

	Private Sub BuildKnittingRecords(ByRef MaxBundleSz As Integer, ByRef compID As Integer, ByRef sizeID As Integer, ByRef PnlsToproduce As Integer, ByRef QtyPerPanel As Integer, ByRef KnittingOrderID As Integer, ByRef bundlenum As Integer)
		pnls2prod = PnlsToproduce
		Dim cmdstring As String
		'For Each i As GridViewRow In grdvProdOrderDetails.Rows
		Do Until pnls2prod = 0
			If bundlenum < 10 Then
				bundleNo = txtbatchno.Text & "-K0" & bundlenum
			Else
				bundleNo = txtbatchno.Text & "-K" & bundlenum
			End If
			bundlenum += 1
			If pnls2prod <= MaxBundleSz Then
				PanelsToMake = pnls2prod
				cmdstring = " INSERT INTO [KN - KnittingDetailsHeader] (BatchNo, BundleNo, ComponentID, SizeID, PanelsToMake, QtyPerPanel, KnittingOrderID) VALUES('" & txtbatchno.Text & "', '" & bundleNo & "', " & compID & ", " & sizeID & ", " & PanelsToMake & ", " & QtyPerPanel & ", " & KnittingOrderID & ");"
				Using con As New OleDbConnection(cnString)
					Dim cmd As New OleDbCommand(cmdstring)
					cmd.CommandType = CommandType.Text
					cmd.Connection = con
					cmd.Connection.Open()
					cmd.ExecuteNonQuery()
				End Using
				Exit Do
			Else
				PanelsToMake = MaxBundleSz
				pnls2prod = pnls2prod - MaxBundleSz

				If pnls2prod < 10 Then
					PanelsToMake = pnls2prod + MaxBundleSz
					pnls2prod = 0

					cmdstring = " INSERT INTO [KN - KnittingDetailsHeader] (BatchNo, BundleNo, ComponentID, SizeID, PanelsToMake, QtyPerPanel, KnittingOrderID) VALUES('" & txtbatchno.Text & "', '" & bundleNo & "', " & compID & ", " & sizeID & ", " & PanelsToMake & ", " & QtyPerPanel & ", " & KnittingOrderID & ");"
					'					Using con As New OleDbConnection(cnString)
					'					Dim cmd As New OleDbCommand(cmdstring)
					'					cmd.CommandType = CommandType.Text
					'					cmd.Connection = con
					'					cmd.Connection.Open()
					'					cmd.ExecuteNonQuery()
					'					End Using
					'					Exit Do
				End If


				cmdstring = " INSERT INTO [KN - KnittingDetailsHeader] (BatchNo, BundleNo, ComponentID, SizeID, PanelsToMake, QtyPerPanel, KnittingOrderID) VALUES('" & txtbatchno.Text & "', '" & bundleNo & "', " & compID & ", " & sizeID & ", " & PanelsToMake & ", " & QtyPerPanel & ", " & KnittingOrderID & ");"
				Using con As New OleDbConnection(cnString)
					Dim cmd As New OleDbCommand(cmdstring)
					cmd.CommandType = CommandType.Text
					cmd.Connection = con
					cmd.Connection.Open()
					cmd.ExecuteNonQuery()
				End Using
			End If

		Loop

		'bundlenum += 1
		'Next

	End Sub

	Private Sub grdvProdOrderDetailsPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			grdvProdOrderDetails.Visible = True
			SQL = "Select DISTINCTROW POH.BatchNo, 
								  POH.ProductID,
								  POH.TicketsPrinted,
								  POD.ProductionQty,
								  PMA.ComponentID,
								  POD.KnittingOrderID,
								  POD.SizeID,
								  CM.ComponentName,
								  CM.MaxKnitBundleSize,
								  CM.SplitAcrossSizes,
								  [ProductionQty] * [NoOfComponents] As CompTot,
								  SSCDD.PanelDependency,
								  PCD.KnitCombination,
								  PMA.MachineNumber,
								  KMD.ForceOneCompPerPnl,
								  IIf([ForceOneCompPerPnl] = True, 1, IIf([PanelDependency] = 'None', 0, IIf([PanelDependency] = 'Width', Fix(([MaxKnitWidth] - [SettlingAllowance]) / [ComponentWidth]), Fix(([MaxKnitWidth] - [SettlingAllowance]) / [ComponentLength])))) As CompPerPnl,
								  Round((([CompTot] / [CompPerPnl]) + 0.4), 0) As TotPnls, 
								  EPC.NoCMTReq,
								  EPC.StyleID,
								  SSCDD.NoOfComponents,
								  SSCDD.ComponentLength
			FROM([KN - Knitting Machine Data] AS KMD
			INNER Join(((([KN - ProductionOrderHeader] AS POH
			INNER Join [FG - End Product Codes] AS EPC
				On POH.ProductID = EPC.ProductID) 
			INNER Join([KN - ProductionOrderDetails] AS POD
			INNER Join([KN - ProductionMachineAllocation] AS PMA 
			INNER Join [FG - Style Size Comp Def Details] AS SSCDD
				On PMA.ComponentID = SSCDD.ComponentID) 
				On POD.SizeID = SSCDD.SizeID) 
				On (POH.BatchNo = POD.BatchNo) 
					And (POH.BatchNo = PMA.BatchNo) 
					And (EPC.StyleID = SSCDD.StyleID)) 
			INNER Join [FG - Pattern Component Details] AS PCD
				On EPC.PatternID = PCD.PatternID) 
			INNER Join [FG - Component Master] AS CM
				On (CM.ComponentID = SSCDD.ComponentID) 
					And (PMA.ComponentID = CM.ComponentID)) 
				On KMD.MachineNumber = PMA.MachineNumber) 
			INNER Join [KN - ProductionYarnAllocation] AS PYA
				On POH.BatchNo = PYA.BatchNo
			WHERE POH.BatchNo = '" & txtbatchno.Text &
			"' ORDER BY POH.BatchNo, PMA.ComponentID, POD.KnittingOrderID, POD.SizeID;"
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvProdOrderDetails.DataSource = Data
			grdvProdOrderDetails.DataBind()
		End Using
	End Sub
	Protected Sub btnPrintTickets_Click(sender As Object, e As EventArgs) Handles btnPrintTickets.Click
		bundlenum = 1
		'Updatemachineallocation()
		grdvProdOrderDetailsPopulate()
		'UpdateOrdQtyBal()
		'knittingdetailsheaderdataset()
		'knittdatareader()
		BuildCMTRecords()
	End Sub

	Protected Sub Back(sender As Object, e As EventArgs) Handles btnBack.Click
	End Sub

	Private Sub knittingdetailsheaderdataset()
		bundlenum = 1
		Dim SQL As String
		Dim Adapter As New OleDbDataAdapter
		Dim dt As New DataTable
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			SQL = "Select DISTINCTROW POH.BatchNo, 
								  POH.ProductID,
								  POD.ProductionQty,
								  PMA.ComponentID,
								  POD.KnittingOrderID,
								  POD.SizeID,
								  CM.ComponentName,
								  CM.SplitAcrossSizes,
								  [ProductionQty] * [NoOfComponents] As CompTot,
								  PMA.MachineNumber,
								  IIf([ForceOneCompPerPnl] = True, 1, IIf([PanelDependency] = 'None', 0, IIf([PanelDependency] = 'Width', Fix(([MaxKnitWidth] - [SettlingAllowance]) / [ComponentWidth]), Fix(([MaxKnitWidth] - [SettlingAllowance]) / [ComponentLength])))) As CompPerPnl,
								  Round((([CompTot] / [CompPerPnl]) + 0.4), 0) As TotPnls, 
								  EPC.StyleID,
								  SSCDD.ComponentLength
			FROM([KN - Knitting Machine Data] AS KMD
			INNER Join(((([KN - ProductionOrderHeader] AS POH
			INNER Join [FG - End Product Codes] AS EPC
				On POH.ProductID = EPC.ProductID) 
			INNER Join([KN - ProductionOrderDetails] AS POD
			INNER Join([KN - ProductionMachineAllocation] AS PMA 
			INNER Join [FG - Style Size Comp Def Details] AS SSCDD
				On PMA.ComponentID = SSCDD.ComponentID) 
				On POD.SizeID = SSCDD.SizeID) 
				On (POH.BatchNo = POD.BatchNo) 
					And (POH.BatchNo = PMA.BatchNo) 
					And (EPC.StyleID = SSCDD.StyleID)) 
			INNER Join [FG - Pattern Component Details] AS PCD
				On EPC.PatternID = PCD.PatternID) 
			INNER Join [FG - Component Master] AS CM
				On (CM.ComponentID = SSCDD.ComponentID) 
					And (PMA.ComponentID = CM.ComponentID)) 
				On KMD.MachineNumber = PMA.MachineNumber) 
			INNER Join [KN - ProductionYarnAllocation] AS PYA
				On POH.BatchNo = PYA.BatchNo
			WHERE POH.BatchNo = '" & txtbatchno.Text &
			"' ORDER BY POH.BatchNo, PMA.ComponentID, POD.KnittingOrderID, POD.SizeID;"
			cmd.Connection = con
			cmd.CommandText = SQL
			Adapter.SelectCommand = cmd
			Adapter.Fill(dt)
			Dim dr As Integer = 0
			'For dr As Integer = 0 To dt.Rows.Count - 1
			Do While dr < dt.Rows.Count
				componentName = dt(dr)(6)
				knittOrderID = dt(dr)(4)
				componentID = dt(dr)(3)
				sizeID = dt(dr)(5)
				qtyppnl = dt(dr)(10)
				Select Case componentName
					Case "Sleeve", "Front", "Body", "Back"
						MxBndleSz = 36
						PnlsToProduce = dt(dr)(11)
						BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundlenum)
					Case "FrontRib34-42"
						MxBndleSz = 150
						PnlsToProduce = 0
						'Do Until componentName <> "FrontRib34-42" Or dr = dt.Rows.Count - 1
						PnlsToProduce += dt(dr)(11)
						'Loop
						BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundlenum)
					Case "FrontRib44-50"
						MxBndleSz = 150
						'PnlsToProduce = 0
						'Do Until componentName <> "FrontRib44-50" Or dr = dt.Rows.Count - 1
						PnlsToProduce += dt(dr)(11)
						'Loop
					Case "Collar22-32"
						MxBndleSz = 200
						PnlsToProduce = 0
						Dim tempknittOrderID = knittOrderID
						Do While componentName = "Collar22-32" And dr < dt.Rows.Count And knittOrderID = tempknittOrderID


							'If componentName <> "Collar22-32" Or dr = dt.Rows.Count - 1 Then
							'	Exit Do
							'End If
							PnlsToProduce += dt(dr)(11)
							dr += 1
							If dr < dt.Rows.Count Then
								componentName = dt(dr)(6)
								tempknittOrderID = dt(dr)(4)
							End If
						Loop
						dr = dr - 1
						Select Case PnlsToProduce
							Case 50 To 100
								PnlsToProduce = PnlsToProduce + 1
							Case 101 To 250
								PnlsToProduce = PnlsToProduce + 2
							Case Is > 250
								PnlsToProduce = PnlsToProduce + 3
						End Select
						BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundlenum)
					Case "Collar34-46"
						MxBndleSz = 200
						PnlsToProduce = 0
						'Do Until componentName <> "Collar34-46" Or dr = dt.Rows.Count - 1
						PnlsToProduce += dt(dr)(11)
						'Loop
						Select Case PnlsToProduce
							Case 50 To 100
								PnlsToProduce = PnlsToProduce + 1
							Case 101 To 250
								PnlsToProduce = PnlsToProduce + 2
							Case Is > 250
								PnlsToProduce = PnlsToProduce + 3
						End Select
						BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundlenum)
					Case "CollarS-4XL"
						MxBndleSz = 200
						PnlsToProduce = 0
						'Do Until componentName <> "CollarS-4XL" Or dr = dt.Rows.Count - 1
						PnlsToProduce += dt(dr)(11)
						'Loop
						Select Case PnlsToProduce
							Case 50 To 100
								PnlsToProduce = PnlsToProduce + 1
							Case 101 To 250
								PnlsToProduce = PnlsToProduce + 2
							Case Is > 250
								PnlsToProduce = PnlsToProduce + 3
						End Select
					Case "Armhole22-46"
						MxBndleSz = 150
						PnlsToProduce = 0
						'Do Until componentName <> "Armhole22-46" Or dr = dt.Rows.Count - 1
						PnlsToProduce += dt(dr)(11)
						'Loop
						BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundlenum)
					Case "ArmholeS-XL"
						MxBndleSz = 150
						PnlsToProduce = 0
						'Do Until componentName <> "ArmholeS-XL" Or dr = dt.Rows.Count - 1
						PnlsToProduce += dt(dr)(11)
						'Loop
						BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundlenum)
					Case "Armhole2XL-4XL"
						MxBndleSz = 150
						PnlsToProduce = 0
						'Do Until componentName <> "Armhole2XL-4XL" Or dr = dt.Rows.Count - 1
						PnlsToProduce += dt(dr)(11)
						'Loop
						BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundlenum)
					Case "Stolling"
						MxBndleSz = 30
						PnlsToProduce += (dt(dr)(8) * (dt(dr)(13) / 100))
					Case "Pocket"
						MxBndleSz = 100
						PocketsToMake += (dt(dr)(8) / qtyppnl)
						PnlsToProduce = Round(PocketsToMake + 0.4, 0)
						BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundlenum)
				End Select
				dr += 1
			Loop
			'Next
		End Using
	End Sub

	Protected Sub txtbatchno_TextChanged(sender As Object, e As EventArgs) Handles txtbatchno.TextChanged
		grdvMachineGroupAllocationPopulate()
	End Sub

	Private Sub UpdateOrdQtyBal()
		Dim cmdstring As String
		cmdstring = "UPDATE [KN - KnittingOrderSzQtyDetails] AS KOSQD
					 INNER JOIN [KN - ProductionOrderDetails] AS POD
						On (KOSQD.SizeID = POD.SizeID) 
							And (KOSQD.KnittingOrderID = POD.KnittingOrderID) 
					 Set KOSQD.OrderQtyBalance = [OrderQtyBalance]-[ProductionQty], KOSQD.OnProductionOrder = True 
					 WHERE POD.BatchNo = '" & txtbatchno.Text & "';"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub

	Private Sub UpdateKnittingIssued()
		Dim cmdstring As String
		cmdstring = "UPDATE [KN - KnittingOrder] 
					 SET KnittingIssued = True 
					 WHERE ((([KN - KnittingOrder].KnittingOrderID) 
					 In (SELECT [KnittingOrderID] 
						 FROM [KN - CheckOutstandingKnittingOrdersByBatch] 
						 WHERE [SumOfOrderQtyBalance] <= 0)));"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub

	Private Sub UpdateTicketsPrinted()
		Dim cmdstring As String
		cmdstring = "UPDATE [KN - ProductionOrderHeader] 
					 SET [KN - ProductionOrderHeader].TicketsPrinted = True 
					 WHERE [KN - ProductionOrderHeader].BatchNo='" & txtbatchno.Text & "';"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub
	'summary
	Dim cmdstring As String = "SELECT DISTINCTROW POH.BatchNo, 
												  POH.ProductID, 
												  POD.ProductionQty, 
												  PMA.ComponentID,
												  POD.KnittingOrderID,
												  POD.SizeID, 
												  CM.ComponentName,
												  [ProductionQty]*[NoOfComponents] AS CompTot, 
												  SSCDD.PanelDependency, 
												  PCD.KnitCombination, 
												  PMA.MachineNumber, 
												  KMD.ForceOneCompPerPnl, 
												  IIf([ForceOneCompPerPnl]=True,1,IIf([PanelDependency]='None',0,IIf([PanelDependency]='Width',Fix(([MaxKnitWidth]-[SettlingAllowance])/[ComponentWidth]),Fix(([MaxKnitWidth]-[SettlingAllowance])/[ComponentLength])))) AS CompPerPnl, 
												  SSCDD.ComponentWidth, 
												  SSCDD.ComponentLength,  
												  Round((([CompTot]/[CompPerPnl])+0.4),0) AS TotPnls,
												  POH.TicketsPrinted, 
												  EPC.NoCMTReq, 
												  EPC.StyleID,
												  CM.SplitAcrossSizes, 
												  SSCDD.NoOfComponents
							  FROM ([KN - Knitting Machine Data] AS KMD
							  INNER JOIN (((([KN - ProductionOrderHeader] AS POH
							  INNER JOIN [FG - End Product Codes] AS EPC
								  ON POH.ProductID = EPC.ProductID) 
							  INNER JOIN ([KN - ProductionOrderDetails] AS POD
							  INNER JOIN ([KN - ProductionMachineAllocation] AS PMA
							  INNER JOIN [FG - Style Size Comp Def Details] AS SSCDD
								  ON PMA.ComponentID = SSCDD.ComponentID) 
								  ON POD.SizeID = SSCDD.SizeID) 
								  ON (POH.BatchNo = POD.BatchNo) 
									 AND (POH.BatchNo = PMA.BatchNo) 
									 AND (EPC.StyleID = SSCDD.StyleID)) 
							  INNER JOIN [FG - Pattern Component Details] AS PCD
								  ON EPC.PatternID = PCD.PatternID) 
							  INNER JOIN [FG - Component Master] AS CM
								  ON (CM.ComponentID = SSCDD.ComponentID) 
									 AND (PMA.ComponentID = CM.ComponentID)) 
								  ON KMD.MachineNumber = PMA.MachineNumber) 
							  INNER JOIN [KN - ProductionYarnAllocation] AS PYA
								  ON POH.BatchNo = PYA.BatchNo
							  ORDER BY POH.BatchNo, PMA.ComponentID, POD.KnittingOrderID, POD.SizeID;"
	' summary part 1
	Dim cmdstrin As String = "SELECT POH.BatchNo, 
									 POH.ProductID,
									 POD.SizeID, 
									 POD.ProductionQty, 
									 PMA.ComponentID, 
									 CM.ComponentName, 
									 [ProductionQty]*[NoOfComponents] AS CompTot, 
									 SSCDD.PanelDependency, 
									 PCD.KnitCombination, 
								     PMA.MachineNumber, 
									 IIf([PanelDependency]='None',0,IIf([PanelDependency]='Width',Fix(([MaxKnitWidth]-[SettlingAllowance])/[ComponentWidth]),Fix(([MaxKnitWidth]-[SettlingAllowance])/[ComponentLength]))) AS CompPerPnl, 
								     SSCDD.ComponentWidth, 
									 SSCDD.ComponentLength,
								     Round((([CompTot]/[CompPerPnl])+0.4),0) AS TotPnls 
							FROM ([KN - Knitting Machine Data] AS KMD
							INNER JOIN (((([KN - ProductionOrderHeader] AS POH
							INNER JOIN [FG - End Product Codes] AS EPC
								ON [KN - ProductionOrderHeader].ProductID = [FG - End Product Codes].ProductID) 
							INNER JOIN ([KN - ProductionOrderDetails] AS POD
							INNER JOIN ([KN - ProductionMachineAllocation] AS PMA
							INNER JOIN [FG - Style Size Comp Def Details] AS SSCDD
								ON [KN - ProductionMachineAllocation].ComponentID = [FG - Style Size Comp Def Details].ComponentID) 
								ON [KN - ProductionOrderDetails].SizeID = [FG - Style Size Comp Def Details].SizeID) 
								ON ([KN - ProductionOrderHeader].BatchNo = [KN - ProductionOrderDetails].BatchNo) 
									AND ([KN - ProductionOrderHeader].BatchNo = [KN - ProductionMachineAllocation].BatchNo)	
									AND ([FG - End Product Codes].StyleID = [FG - Style Size Comp Def Details].StyleID)) 
							INNER JOIN [FG - Pattern Component Details] AS PCD
								ON [FG - End Product Codes].PatternID = [FG - Pattern Component Details].PatternID) 
							INNER JOIN [FG - Component Master] AS CM
								ON ([FG - Component Master].ComponentID = [FG - Style Size Comp Def Details].ComponentID) 
									AND ([KN - ProductionMachineAllocation].ComponentID = [FG - Component Master].ComponentID)) 
								ON KMD.MachineNumber = PMA.MachineNumber)
							INNER JOIN [KN - ProductionYarnAllocation] AS PYA
								ON POH.BatchNo = PYA.BatchNo;"

	Private Sub BuildCMTRecords()
		Dim CMTBndlNum As Integer
		Dim cmtBundleNo As String
		Dim MaxJrsyBndlSz As Integer
		Dim JrsysToMake As Integer
		Dim JrsysToCut As Integer
		Dim BatchNo As String
		Dim sizeID As Integer
		Dim knittingOrdID As Integer
		Dim SQL As String
		Dim Adapter As New OleDbDataAdapter
		Dim dt As New DataTable
		Dim cmdstring As String
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			SQL = " SELECT [KN - ProductionOrderDetails].* " &
							 " FROM [KN - ProductionOrderHeader] 
							   INNER JOIN [KN - ProductionOrderDetails] 
								  ON [KN - ProductionOrderHeader].BatchNo = [KN - ProductionOrderDetails].BatchNo 
							   WHERE ((([KN - ProductionOrderDetails].BatchNo) = '" & txtbatchno.Text & "')); "
			cmd.Connection = con
			cmd.CommandText = SQL
			Adapter.SelectCommand = cmd
			Adapter.Fill(dt)
			MaxJrsyBndlSz = 30
			CMTBndlNum = 1
			For dr As Integer = 0 To dt.Rows.Count - 1
				JrsysToMake = dt(dr)(3)
				Do Until JrsysToMake = 0
					BatchNo = txtbatchno.Text
					sizeID = dt(dr)(1)
					knittingOrdID = dt(dr)(2)
					If CMTBndlNum < 10 Then
						cmtBundleNo = txtbatchno.Text & "-C0" & CMTBndlNum
						'cmtBundleNo = txtbatchno.Text & "-C0" & CMTBndlNum
					Else
						cmtBundleNo = txtbatchno.Text & "-C" & CMTBndlNum
						'cmtBundleNo = txtbatchno.Text & "-C" & CMTBndlNum
					End If
					CMTBndlNum += 1
					If JrsysToMake < MaxJrsyBndlSz Then
						JrsysToCut = JrsysToMake
						cmdstring = " INSERT INTO [CMT - CMTDetailsHeader] (BatchNo, BundleNo, SizeID, JrsysToCut, KnittingOrderID) VALUES('" & txtbatchno.Text & "', '" & cmtBundleNo & "', " & sizeID & ", " & JrsysToCut & ", " & knittingOrdID & ");"
						Using conn As New OleDbConnection(cnString)
							Dim cmdd As New OleDbCommand(cmdstring)
							cmdd.CommandType = CommandType.Text
							cmdd.Connection = conn
							cmdd.Connection.Open()
							cmdd.ExecuteNonQuery()
						End Using
						cmdstring = " INSERT INTO [CMT - CMTDetailsOperations] (BundleNo) VALUES('" & cmtBundleNo & "');"
						Using connn As New OleDbConnection(cnString)
							Dim cmdd As New OleDbCommand(cmdstring)
							cmdd.CommandType = CommandType.Text
							cmdd.Connection = connn
							cmdd.Connection.Open()
							cmdd.ExecuteNonQuery()
						End Using
						Exit Do
					Else
						JrsysToCut = MaxJrsyBndlSz
						JrsysToMake = JrsysToMake - MaxJrsyBndlSz
						If JrsysToMake < 10 Then
							JrsysToCut = JrsysToMake + MaxJrsyBndlSz
							JrsysToMake = 0
							'cmdstring = " INSERT INTO [CMT - CMTDetailsHeader] (BatchNo, BundleNo, SizeID, JrsysToCut, KnittingOrderID) VALUES('" & txtbatchno.Text & "', '" & cmtBundleNo & "', " & sizeID & ", " & JrsysToCut & ", " & knittingOrdID & ");"
							'Using conn As New OleDbConnection(cnString)
							'	Dim cmdd As New OleDbCommand(cmdstring)
							'	cmdd.CommandType = CommandType.Text
							'	cmdd.Connection = con
							'	cmdd.Connection.Open()
							'	cmdd.ExecuteNonQuery()
							'End Using
							'cmdstring = " INSERT INTO [CMT - CMTDetailsOperations] (BundleNo) VALUES('" & cmtBundleNo & "');"
							'Using conn As New OleDbConnection(cnString)
							'	Dim cmdd As New OleDbCommand(cmdstring)
							'	cmdd.CommandType = CommandType.Text
							'	cmdd.Connection = con
							'	cmdd.Connection.Open()
							'	cmdd.ExecuteNonQuery()
							'End Using
							'Exit Do
						End If
						cmdstring = " INSERT INTO [CMT - CMTDetailsHeader] (BatchNo, BundleNo, SizeID, JrsysToCut, KnittingOrderID) VALUES('" & txtbatchno.Text & "', '" & cmtBundleNo & "', " & sizeID & ", " & JrsysToCut & ", " & knittingOrdID & ");"
						Using conn As New OleDbConnection(cnString)
							Dim cmdd As New OleDbCommand(cmdstring)
							cmdd.CommandType = CommandType.Text
							cmdd.Connection = conn
							cmdd.Connection.Open()
							cmdd.ExecuteNonQuery()
						End Using
						cmdstring = " INSERT INTO [CMT - CMTDetailsOperations] (BundleNo) VALUES('" & cmtBundleNo & "');"
						Using conn As New OleDbConnection(cnString)
							Dim cmdd As New OleDbCommand(cmdstring)
							cmdd.CommandType = CommandType.Text
							cmdd.Connection = conn
							cmdd.Connection.Open()
							cmdd.ExecuteNonQuery()
						End Using
					End If
					'CMTBndlNum = CMTBndlNum + 1
				Loop
				'CMTBndlNum = CMTBndlNum + 1
			Next
		End Using
	End Sub

End Class