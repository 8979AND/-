Imports System.Data.OleDb
Imports System.Math
Imports System.Data
Imports System.IO
Public Class ProductionOrderIssue
	Inherits System.Web.UI.Page
	Private cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"

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

	Private Sub Insertmachineallocation()
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

	Private Sub BuildKnittingRecords(ByVal MaxBundleSz As Integer, ByVal compID As Integer, ByVal sizeID As Integer, ByVal PnlsToproduce As Integer, ByVal QtyPerPanel As Integer, ByVal KnittingOrderID As Integer, ByVal bundlenum As Integer)
		Dim pnls2prod As Integer
		Dim bundleNo As String
		Dim PanelsToMake As Integer
		'tempnls = PanelsToProduce
		pnls2prod = PnlsToproduce
		For i = 0 To grdvProdOrderDetails.Rows.Count - 1
			Do Until pnls2prod < 10

				If bundlenum < 10 Then
					bundleNo = txtbatchno.Text & "-K0" & bundlenum
				Else
					bundleNo = txtbatchno.Text & "-K" & bundlenum
				End If
				bundlenum += 1
				If pnls2prod <= MaxBundleSz Then
					PanelsToMake = pnls2prod
					Exit Do
				Else
					PanelsToMake = MaxBundleSz
					pnls2prod = pnls2prod - MaxBundleSz
					If pnls2prod < 10 Then
						PanelsToMake = pnls2prod + MaxBundleSz
						Exit Do
					End If
				End If
				Dim cmdstring As String
				cmdstring = " INSERT INTO [KN - KnittingDetailsHeader] (BatchNo, BundleNo, ComponentID, SizeID, PanelsToMake, QtyPerPanel, KnittingOrderID) VALUES('" & txtbatchno.Text & "', '" & bundleNo & "', " & compID & ", " & sizeID & ", " & PanelsToMake & ", " & QtyPerPanel & ", " & KnittingOrderID & ");"
				Using con As New OleDbConnection(cnString)
					Dim cmd As New OleDbCommand(cmdstring)
					cmd.CommandType = CommandType.Text
					cmd.Connection = con
					cmd.Connection.Open()
					cmd.ExecuteNonQuery()
				End Using
			Loop
			bundlenum += 1
		Next

	End Sub

	Private Sub knittingdetailsheader()
		Dim componentName As String
		Dim PnlsToProduce As Integer
		Dim MxBndleSz As Integer
		Dim knittOrderID As Integer
		Dim PocketsToMake As Integer
		Dim componentID As Integer
		Dim sizeID As Integer
		Dim qtyppnl As Integer
		Dim bundleNo As Integer
		bundleNo = 1
		For i = 0 To grdvProdOrderDetails.Rows.Count - 1
			componentName = grdvProdOrderDetails.Rows(i).Cells(7).Text
			knittOrderID = grdvProdOrderDetails.Rows(i).Cells(5).Text
			componentID = grdvProdOrderDetails.Rows(i).Cells(4).Text
			sizeID = grdvProdOrderDetails.Rows(i).Cells(6).Text
			If grdvProdOrderDetails.Rows(i).Cells(15).Text = "&nbsp;" Then
				qtyppnl = 1
			Else
				qtyppnl = grdvProdOrderDetails.Rows(i).Cells(15).Text
			End If
			Select Case componentName
				Case "Sleeve", "Front", "Body", "Back"
					MxBndleSz = 36
					PnlsToProduce = grdvProdOrderDetails.Rows(i).Cells(16).Text
					BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
				Case "FrontRib34-42"
					MxBndleSz = 150
					'PnlsToProduce = 0
					'While componentName = "FrontRib34-42"
					PnlsToProduce += grdvProdOrderDetails.Rows(i).Cells(16).Text
					'End While
					BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
				Case "FrontRib44-50"
					MxBndleSz = 150
					'PnlsToProduce = 0
					'While componentName = "FrontRib44-50"
					PnlsToProduce += grdvProdOrderDetails.Rows(i).Cells(16).Text
					'End While
				Case "Collar22-32"
					MxBndleSz = 200
					'PnlsToProduce = 0
					'While componentName = "Collar22-32"
					PnlsToProduce += grdvProdOrderDetails.Rows(i).Cells(16).Text
					'End While
					Select Case PnlsToProduce
						Case 50 To 100
							PnlsToProduce = PnlsToProduce + 1
						Case 101 To 250
							PnlsToProduce = PnlsToProduce + 2
						Case Is > 250
							PnlsToProduce = PnlsToProduce + 3
					End Select
					BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
				Case "Collar34-46"
					MxBndleSz = 200
					'PnlsToProduce = 0
					'While componentName = "Collar34-46"
					PnlsToProduce += grdvProdOrderDetails.Rows(i).Cells(16).Text
					'End While
					Select Case PnlsToProduce
						Case 50 To 100
							PnlsToProduce = PnlsToProduce + 1
						Case 101 To 250
							PnlsToProduce = PnlsToProduce + 2
						Case Is > 250
							PnlsToProduce = PnlsToProduce + 3
					End Select
					BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
				Case "CollarS-4XL"
					MxBndleSz = 200
					'PnlsToProduce = 0
					'While componentName = "CollarS-4XL"
					PnlsToProduce += grdvProdOrderDetails.Rows(i).Cells(16).Text
					'End While
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
					'PnlsToProduce = 0
					'While componentName = "Armhole22-46"
					PnlsToProduce += grdvProdOrderDetails.Rows(i).Cells(16).Text
					'End While
					BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
				Case "ArmholeS-XL"
					MxBndleSz = 150
					'PnlsToProduce = 0
					'While componentName = "ArmholeS-XL"
					PnlsToProduce += grdvProdOrderDetails.Rows(i).Cells(16).Text
					'End While
					BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
				Case "Armhole2XL-4XL"
					MxBndleSz = 150
					'PnlsToProduce = 0
					'While componentName = "Armhole2XL-4XL"
					PnlsToProduce += grdvProdOrderDetails.Rows(i).Cells(16).Text
					'End While
					BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
				Case "Stolling"
					MxBndleSz = 30
					PnlsToProduce += (grdvProdOrderDetails.Rows(i).Cells(10).Text * (grdvProdOrderDetails.Rows(i).Cells(20).Text / 100))
				Case "Pocket"
					MxBndleSz = 100
					PocketsToMake += (grdvProdOrderDetails.Rows(i).Cells(10).Text / grdvProdOrderDetails.Rows(i).Cells(15).Text)
					PnlsToProduce = Round(PocketsToMake + 0.4, 0)
					BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
			End Select
		Next
	End Sub
	Private Sub grdvProdOrderDetailsPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			grdvProdOrderDetails.Visible = True
			SQL = "SELECT DISTINCTROW POH.BatchNo, 
								  POH.ProductID, 
								  POH.TicketsPrinted,
								  POD.ProductionQty, 
								  PMA.ComponentID, 
								  POD.KnittingOrderID, 
								  POD.SizeID, 
								  CM.ComponentName,
								  CM.MaxKnitBundleSize,
								  CM.SplitAcrossSizes,
								  [ProductionQty]* [NoOfComponents] As CompTot,
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
		Insertmachineallocation()
		grdvProdOrderDetailsPopulate()
		knittingdetailsheader()
		'knittdatareader()

	End Sub

	Protected Sub Back(sender As Object, e As EventArgs) Handles btnBack.Click

	End Sub


	Private Sub knittdatareader() 'still need to test
		Dim cmdstring As String = "SELECT DISTINCTROW POH.BatchNo, 
								  POH.ProductID, 
								  POH.TicketsPrinted,
								  POD.ProductionQty, 
								  PMA.ComponentID, 
								  POD.KnittingOrderID, 
								  POD.SizeID, 
								  CM.ComponentName,
								  CM.MaxKnitBundleSize,
								  CM.SplitAcrossSizes,
								  [ProductionQty]* [NoOfComponents] As CompTot,
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
			WHERE POH.BatchNo = '" & txtbatchno.Text & "'
			ORDER BY POH.BatchNo, PMA.ComponentID, POD.KnittingOrderID, POD.SizeID;"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			Dim reader As OleDbDataReader
			Dim componentName As String
			Dim PnlsToProduce As Integer
			Dim MxBndleSz As Integer
			Dim knittOrderID As Integer
			Dim PocketsToMake As Integer
			Dim componentID As Integer
			Dim qtyppnl As Integer
			Dim sizeID As Integer
			Dim bundleNo As Integer
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()

			reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
			bundleNo = 1
			If reader.HasRows = True Then
				While reader.Read
					componentName = reader("ComponentName")
					MxBndleSz = reader("MaxKnitBundleSize")
					knittOrderID = reader("KnittingOrderID")
					componentID = Val(reader("ComponentID"))
					sizeID = reader("sizeID")
					If reader.IsDBNull(15) Then
						qtyppnl = 1
					Else
						qtyppnl = Val(reader("CompPerPnl"))
					End If
					Select Case componentName
						Case "Sleeve"
							PnlsToProduce = Val(reader("TotPnls"))
							BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
						Case "Front"
							PnlsToProduce = Val(reader("TotPnls"))
							BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
						Case "Body"
							PnlsToProduce = Val(reader("TotPnls"))
							BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
						Case "Back"
							PnlsToProduce = Val(reader("TotPnls"))
							BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
						Case "FrontRib34-42"
							'PnlsToProduce = 0
							'While componentName = "FrontRib34-42"
							PnlsToProduce += reader("TotPnls")
							'End While
							BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
						Case "FrontRib44-50"
							'PnlsToProduce = 0
							'While componentName = "FrontRib44-50"
							PnlsToProduce += reader("TotPnls")
					'End While
						Case "Collar22-32"
							'PnlsToProduce = 0
							'While componentName = "Collar22-32"
							PnlsToProduce += reader("TotPnls")
							'End While
							Select Case PnlsToProduce
								Case 50 To 100
									PnlsToProduce = PnlsToProduce + 1
								Case 101 To 250
									PnlsToProduce = PnlsToProduce + 2
								Case Is > 250
									PnlsToProduce = PnlsToProduce + 3
							End Select
							BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
						Case "Collar34-46"
							'PnlsToProduce = 0
							'While componentName = "Collar34-46"
							PnlsToProduce += Val(reader("TotPnls"))
							'End While
							Select Case PnlsToProduce
								Case 50 To 100
									PnlsToProduce = PnlsToProduce + 1
								Case 101 To 250
									PnlsToProduce = PnlsToProduce + 2
								Case Is > 250
									PnlsToProduce = PnlsToProduce + 3
							End Select
							BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
						Case "CollarS-4XL"
							'PnlsToProduce = 0
							'While componentName = "CollarS-4XL"
							PnlsToProduce += Val(reader("TotPnls"))
							'End While
							Select Case PnlsToProduce
								Case 50 To 100
									PnlsToProduce = PnlsToProduce + 1
								Case 101 To 250
									PnlsToProduce = PnlsToProduce + 2
								Case Is > 250
									PnlsToProduce = PnlsToProduce + 3
							End Select
						Case "Armhole22-46"
							'PnlsToProduce = 0
							'While componentName = "Armhole22-46"
							PnlsToProduce += Val(reader("TotPnls"))
							'End While
							BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
						Case "ArmholeS-XL"
							'PnlsToProduce = 0
							'While componentName = "ArmholeS-XL"
							PnlsToProduce += Val(reader("TotPnls"))
							'End While
							BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
						Case "Armhole2XL-4XL"
							'PnlsToProduce = 0
							'While componentName = "Armhole2XL-4XL"
							PnlsToProduce += Val(reader("TotPnls"))
							'End While
							BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
						Case "Stolling"
							PnlsToProduce += Val((reader("CompTot") * reader("ComponentLength")))
						Case "Pocket"
							PocketsToMake += Val((reader("CompTot") / reader("CompPerPnl")))
							PnlsToProduce = Round(PocketsToMake + 0.4, 0)
							BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID, bundleNo)
					End Select
				End While
			Else

			End If
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

End Class