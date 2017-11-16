Imports System.Data.OleDb
Imports System.Math
Public Class ProductionOrderIssue
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

	End Sub

	Private Sub BuildKnittingRecords(ByRef MaxBundleSz As Integer, ByRef compID As Integer, ByRef sizeID As Integer, ByRef PnlsToproduce As Integer, ByRef QtyPerPanel As Integer, ByRef KnittingOrderID As Integer)
		Dim bundlecount As Integer
		Dim bundlenum As String
		Dim PanelsToMake As Integer
		'tempnls = PanelsToProduce
		While PnlsToproduce > 10
			bundlecount += 1
			If bundlecount < 10 Then
				bundlenum = txtbatchno.Text & "-K0" & bundlecount
			Else
				bundlenum = txtbatchno.Text & "-K" & bundlecount
			End If

			If PnlsToproduce <= MaxBundleSz Then
				PanelsToMake = PnlsToproduce
				Exit While
			Else
				PanelsToMake = MaxBundleSz
				PnlsToproduce = PnlsToproduce - MaxBundleSz
				If PnlsToproduce < 10 Then
					PanelsToMake = PnlsToproduce + MaxBundleSz
					Exit While
				End If
			End If
			Dim cmdstring As String
			cmdstring = " INSERT INTO [KN - KnittingDetailsHeader] (BatchNo, BundleNo, ComponentID, SizeID, PanelsToMake, QtyPerPanel, KnittingOrderID) VALUES('" & txtbatchno.Text & "', '" & bundlenum & "', " & compID & ", " & sizeID & ", " & PanelsToMake & ", " & QtyPerPanel & ", " & KnittingOrderID & ");"
			Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;OLE DB Services=-4;Data Source=|DataDirectory|\Shantara Production IT.mdb")
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
			cmd.Connection.Close()
		End While
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
		For i = 0 To grdvProdOrderDetails.Rows.Count - 1
			componentName = grdvProdOrderDetails.Rows(i).Cells(7).Text
			MxBndleSz = grdvProdOrderDetails.Rows(i).Cells(8).Text
			knittOrderID = grdvProdOrderDetails.Rows(i).Cells(5).Text
			componentID = grdvProdOrderDetails.Rows(i).Cells(4).Text
			sizeID = grdvProdOrderDetails.Rows(i).Cells(6).Text
			qtyppnl = grdvProdOrderDetails.Rows(i).Cells(15).Text
			Select Case componentName
				Case "Sleeve", "Front", "Body", "Back"
					PnlsToProduce = grdvProdOrderDetails.Rows(i).Cells(16).Text
					BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID)
				Case "FrontRib34-42"
					'PnlsToProduce = 0
					'While componentName = "FrontRib34-42"
					PnlsToProduce += grdvProdOrderDetails.Rows(i).Cells(16).Text
					'End While
					BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID)
				Case "FrontRib44-50"
					'PnlsToProduce = 0
					'While componentName = "FrontRib44-50"
					PnlsToProduce += grdvProdOrderDetails.Rows(i).Cells(16).Text
					'End While
				Case "Collar22-32"
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
					BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID)
				Case "Collar34-46"
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
					BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID)
				Case "CollarS-4XL"
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
					'PnlsToProduce = 0
					'While componentName = "Armhole22-46"
					PnlsToProduce += grdvProdOrderDetails.Rows(i).Cells(16).Text
					'End While
					BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID)
				Case "ArmholeS-XL"
					'PnlsToProduce = 0
					'While componentName = "ArmholeS-XL"
					PnlsToProduce += grdvProdOrderDetails.Rows(i).Cells(16).Text
					'End While
					BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID)
				Case "Armhole2XL-4XL"
					'PnlsToProduce = 0
					'While componentName = "Armhole2XL-4XL"
					PnlsToProduce += grdvProdOrderDetails.Rows(i).Cells(16).Text
					'End While
					BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID)
				Case "Stolling"
					PnlsToProduce += (grdvProdOrderDetails.Rows(i).Cells(10).Text * (grdvProdOrderDetails.Rows(i).Cells(20).Text / 100))
				Case "Pocket"
					PocketsToMake += (grdvProdOrderDetails.Rows(i).Cells(10).Text / grdvProdOrderDetails.Rows(i).Cells(15).Text)
					PnlsToProduce = Round(PocketsToMake + 0.4, 0)
					BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID)
			End Select
		Next
	End Sub
	Private Sub grdvProdOrderDetailsPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;OLE DB Services=-4;Data Source=|DataDirectory|\Shantara Production IT.mdb")
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
			WHERE POH.BatchNo = '" & txtbatchno.Text & "'
			ORDER BY POH.BatchNo, PMA.ComponentID, POD.KnittingOrderID, POD.SizeID;"
		con.Open()
		cmd.Connection = con
		cmd.CommandText = SQL

		Adapter.SelectCommand = cmd
		Adapter.Fill(Data)

		grdvProdOrderDetails.DataSource = Data
		grdvProdOrderDetails.DataBind()
		cmd.Connection.Close()
	End Sub
	Protected Sub btnPrintTickets_Click(sender As Object, e As EventArgs) Handles btnPrintTickets.Click
		grdvProdOrderDetailsPopulate()
		knittingdetailsheader()
	End Sub

	Protected Sub Back(sender As Object, e As EventArgs) Handles btnBack.Click

	End Sub


	Private Sub knittdatareader()
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
				Dim componentName As String
				Dim PnlsToProduce As Integer
				Dim MxBndleSz As Integer
				Dim knittOrderID As Integer
				Dim PocketsToMake As Integer
				Dim componentID As Integer
				Dim sizeID As Integer
				Dim qtyppnl As Integer
				componentName = reader("ComponentName")
				MxBndleSz = reader("MaxKnitBundleSize")
				knittOrderID = reader("KnittingOrderID")
				componentID = reader("ComponentID")
				sizeID = reader("TotPnls")
				qtyppnl = reader("NoOfComponents")
				Select Case componentName
					Case "Sleeve", "Front", "Body", "Back"
						PnlsToProduce = reader("TotPnls")
						BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID)
					Case "FrontRib34-42"
						'PnlsToProduce = 0
						'While componentName = "FrontRib34-42"
						PnlsToProduce += reader("TotPnls")
						'End While
						BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID)
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
						BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID)
					Case "Collar34-46"
						'PnlsToProduce = 0
						'While componentName = "Collar34-46"
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
						BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID)
					Case "CollarS-4XL"
						'PnlsToProduce = 0
						'While componentName = "CollarS-4XL"
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
					Case "Armhole22-46"
						'PnlsToProduce = 0
						'While componentName = "Armhole22-46"
						PnlsToProduce += reader("TotPnls")
						'End While
						BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID)
					Case "ArmholeS-XL"
						'PnlsToProduce = 0
						'While componentName = "ArmholeS-XL"
						PnlsToProduce += reader("TotPnls")
						'End While
						BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID)
					Case "Armhole2XL-4XL"
						'PnlsToProduce = 0
						'While componentName = "Armhole2XL-4XL"
						PnlsToProduce += reader("TotPnls")
						'End While
						BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID)
					Case "Stolling"
						PnlsToProduce += (grdvProdOrderDetails.Rows(i).Cells(10).Text * (grdvProdOrderDetails.Rows(i).Cells(20).Text / 100))
					Case "Pocket"
						PocketsToMake += (reader("CompPerPnl") / reader("CompPerPnl")
						PnlsToProduce = Round(PocketsToMake + 0.4, 0)
						BuildKnittingRecords(MxBndleSz, componentID, sizeID, PnlsToProduce, qtyppnl, knittOrderID)
				End Select
			End While
		Else

		End If
		cmd.Connection.Close()
	End Sub
End Class