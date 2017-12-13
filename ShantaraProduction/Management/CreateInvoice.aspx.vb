Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports GemBox.Spreadsheet
Public Class CreateInvoice
	Inherits System.Web.UI.Page
	Private cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"
	Private ILNU As Integer
	Private InvoiceNumber As String
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		getBatchno()
	End Sub

	Private Sub getBatchno()
		Dim strQuery As String = "SELECT DISTINCT BatchNo
FROM [CMT - CMTDetailsHeader]
WHERE BundleComplete = no"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()

			If IsPostBack = False Then
				ddlBatch.AppendDataBoundItems = True
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strQuery
				cmd.Connection = con
				Try
					con.Open()
					ddlBatch.DataSource = cmd.ExecuteReader()
					ddlBatch.DataTextField = "BatchNo"
					ddlBatch.DataValueField = "BatchNo"
					ddlBatch.DataBind()
				Catch ex As Exception
					Throw ex
				End Try
			End If
		End Using
	End Sub

	Private Sub getJerseysDelivered()
		Dim strQuery As String = "SELECT DISTINCT JrsysDelivered
FROM [CMT - CMTDetailsHeader]
WHERE BundleComplete = no"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()

			If IsPostBack = False Then
				ddlBatch.AppendDataBoundItems = True
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strQuery
				cmd.Connection = con
				Try
					con.Open()
					ddlBatch.DataSource = cmd.ExecuteReader()
					ddlBatch.DataTextField = "BatchNo"
					ddlBatch.DataValueField = "BatchNo"
					ddlBatch.DataBind()
				Catch ex As Exception
					Throw ex
				End Try
			End If
		End Using
	End Sub

	Private Sub grdvBatch4InvPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			grdvBatch4Inv.Visible = True
			SQL = "SELECT DISTINCTROW KO.OrderNo, CDH.JrsysDelivered, S.StyleNo, CDH.BatchNo, CDH.BundleNo, EPC.ProductCode, SM.[Size Abbreviation] AS [Size], CDH.JrsysToCut, CDH.ActualJrsysCut, EM.EntityName
				   FROM (((((((([CMT - CMTDetailsHeader] AS CDH
				   INNER JOIN [KN - ProductionOrderHeader] AS POH
						ON CDH.BatchNo = POH.BatchNo)
				   INNER JOIN [KN - ProductionOrderDetails] AS POD
						ON POH.BatchNo = POD.BatchNo)
				   INNER JOIN [KN - KnittingOrder] AS KO
						ON POD.KnittingOrderID = KO.KnittingOrderID)
				   INNER JOIN [FG - End Product Codes] AS EPC
						ON KO.ProductID = EPC.ProductID)
				   INNER JOIN [GN - EntityMaster] AS EM
						ON KO.EntityID = EM.EntityID)
				   INNER JOIN [FG- Size Master] AS SM
						ON SM.SizeID = CDH.SizeID)
				   INNER JOIN [FG - Style Size Comp Def Details] AS SSCDD
						ON EPC.StyleID = SSCDD.StyleID)
				   INNER JOIN [FG - Style] AS S
						ON SSCDD.StyleID = S.StyleID)
				   WHERE CDH.BatchNo= '" & ddlBatch.SelectedValue & "'"
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvBatch4Inv.DataSource = Data
			grdvBatch4Inv.DataBind()
		End Using
		Dim cost As Double
		For i As Integer = 0 To grdvBatch4Inv.Rows.Count - 1
			grdvBatch4Inv.Rows(i).Cells(10).Text = CalcItemMaterialCost(ddlBatch.SelectedValue, grdvBatch4Inv.Rows(i).Cells(7).Text)
		Next
	End Sub



	Private Sub UpdateJrysDel()
		For i As Integer = 0 To grdvBatch4Inv.Rows.Count - 1
			Dim txtJrysdel As TextBox = DirectCast(grdvBatch4Inv.Rows(i).Cells(0).FindControl("txtJD"), TextBox)
			Dim cmdstring As String
			cmdstring = " UPDATE [CMT - CMTDetailsHeader]
						  SET JrsysDelivered = " & txtJrysdel.Text &
							"WHERE BundleNo ='" & grdvBatch4Inv.Rows(i).Cells(0).Text & "'"
			Using con As New OleDbConnection(cnString)
				Dim cmd As New OleDbCommand(cmdstring)
				cmd.CommandType = CommandType.Text
				cmd.Connection = con
				cmd.Connection.Open()
				cmd.ExecuteNonQuery()
			End Using
		Next
	End Sub

	Protected Sub txtJD_TextChanged(sender As Object, e As EventArgs)
		UpdateJrysDel()
	End Sub

	Private Sub NewInvNo()
		Dim cmdstring = "SELECT RangePrefix, LastNumberUsed
        FROM [Parm - Prefix And Number Table]
        WHERE RangePrefix = 'ID'"
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
					ILNU = reader("LastNumberUsed") + 1
					InvoiceNumber = reader("RangePrefix") & CStr(ILNU)
				End While
			End If
		End Using
	End Sub
	Private Sub InsertInvHeader()
		Dim cmdstring As String = "INSERT INTO [INV - Header] ([Invoice Number], CustomerID, InvoiceDate, Printed) " &
		"VALUES ('" & InvoiceNumber & "',13 ,'" & DateTime.Now & "' ,yes);"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub

	Private Function CalcItemMaterialCost(BatchNo As String, Size As String) As Double
		Dim KnitWeight As Double = 0
		Dim YarnPrice As Double = 0
		Dim NrJrsys As Double = 0
		Dim TotNrJrsys As Double = 0
		Dim AllocWgt As Double = 0
		Dim AvgAllocWgt As Double = 0
		Dim AllocComps As Boolean
		Dim AltSize As String
		Dim SizeFound As Boolean
		Dim NrJrsysAlt As Double = 0
		CalcItemMaterialCost = 0

		'Get total weight of knitting for particular batch and size
		SizeFound = False
		AltSize = "None"
		Do While SizeFound = False
			'checkexist
			Dim cmdstring_tw = "SELECT [KN - KnittingDetailsHeader].BatchNo, 
							  [FG- Size Master].[Size Abbreviation], 
							  [FG - Component Master].SplitAcrossSizes,
							  Sum([KN - KnittingDetailsWeights].BundleWeight) AS SumOfBundleWeight 
				       FROM ([FG- Size Master] 
					   INNER JOIN ([FG - Component Master] 
				       INNER JOIN [KN - KnittingDetailsHeader] 
						  ON [FG - Component Master].ComponentID = [KN - KnittingDetailsHeader].ComponentID) 
						  ON [FG- Size Master].SizeID = [KN - KnittingDetailsHeader].SizeID) 
					   INNER JOIN [KN - KnittingDetailsWeights] 
						  ON [KN - KnittingDetailsHeader].BundleNo = [KN - KnittingDetailsWeights].BundleNo 
					   GROUP BY [KN - KnittingDetailsHeader].BatchNo, [FG- Size Master].[Size Abbreviation], [FG - Component Master].SplitAcrossSizes 
					   HAVING ((([KN - KnittingDetailsHeader].BatchNo)='" & BatchNo & "') 
							AND (([FG- Size Master].[Size Abbreviation])='" & Size & "') 
							AND (([FG - Component Master].SplitAcrossSizes)=False));"
			Using con_tw As New OleDbConnection(cnString)
				Dim cmd_tw As New OleDbCommand(cmdstring_tw)
				Dim reader_tw As OleDbDataReader
				cmd_tw.CommandType = CommandType.Text
				cmd_tw.Connection = con_tw
				cmd_tw.Connection.Open()
				cmd_tw.ExecuteNonQuery()

				reader_tw = cmd_tw.ExecuteReader(CommandBehavior.CloseConnection)
				While reader_tw.Read
					If reader_tw.HasRows = False Then
						'get total weight with Altsize
						AltSize = InputBox("Please enter the size from which the panels were cut. Enter size in the format 'Sizexx' or 'SML, MED, LRG, etc'")
						Dim cmdstring_twAltS = "SELECT [KN - KnittingDetailsHeader].BatchNo, 
								   [FG- Size Master].[Size Abbreviation], 
							       [FG - Component Master].SplitAcrossSizes,
							       Sum([KN - KnittingDetailsWeights].BundleWeight) AS SumOfBundleWeight 
				       FROM ([FG- Size Master] 
					   INNER JOIN ([FG - Component Master] 
				       INNER JOIN [KN - KnittingDetailsHeader] 
						  ON [FG - Component Master].ComponentID = [KN - KnittingDetailsHeader].ComponentID) 
						  ON [FG- Size Master].SizeID = [KN - KnittingDetailsHeader].SizeID) 
					   INNER JOIN [KN - KnittingDetailsWeights] 
						  ON [KN - KnittingDetailsHeader].BundleNo = [KN - KnittingDetailsWeights].BundleNo 
					   GROUP BY [KN - KnittingDetailsHeader].BatchNo, [FG- Size Master].[Size Abbreviation], [FG - Component Master].SplitAcrossSizes 
					   HAVING ((([KN - KnittingDetailsHeader].BatchNo)='" & BatchNo & "') 
							AND (([FG- Size Master].[Size Abbreviation])='" & AltSize & "') 
							AND (([FG - Component Master].SplitAcrossSizes)=False));"
						Using con_alts As New OleDbConnection(cnString)
							Dim cmd_twalts As New OleDbCommand(cmdstring_twAltS)
							Dim reader_twAltS As OleDbDataReader
							cmd_twalts.CommandType = CommandType.Text
							cmd_twalts.Connection = con_alts
							cmd_twalts.Connection.Open()
							cmd_twalts.ExecuteNonQuery()

							reader_twAltS = cmd_twalts.ExecuteReader(CommandBehavior.CloseConnection)
							If reader_twAltS.HasRows = True Then
								While reader_twAltS.Read
									KnitWeight = reader_twAltS("SumOfBundleWeight")
								End While
								SizeFound = True
							End If
						End Using
					Else
						'get total weight with size
						Dim cmdstring_twS = "SELECT [KN - KnittingDetailsHeader].BatchNo, 
								   [FG- Size Master].[Size Abbreviation], 
							       [FG - Component Master].SplitAcrossSizes,
							       Sum([KN - KnittingDetailsWeights].BundleWeight) AS SumOfBundleWeight 
				       FROM ([FG- Size Master] 
					   INNER JOIN ([FG - Component Master] 
				       INNER JOIN [KN - KnittingDetailsHeader] 
						  ON [FG - Component Master].ComponentID = [KN - KnittingDetailsHeader].ComponentID) 
						  ON [FG- Size Master].SizeID = [KN - KnittingDetailsHeader].SizeID) 
					   INNER JOIN [KN - KnittingDetailsWeights] 
						  ON [KN - KnittingDetailsHeader].BundleNo = [KN - KnittingDetailsWeights].BundleNo 
					   GROUP BY [KN - KnittingDetailsHeader].BatchNo, [FG- Size Master].[Size Abbreviation], [FG - Component Master].SplitAcrossSizes 
					   HAVING ((([KN - KnittingDetailsHeader].BatchNo)='" & BatchNo & "') 
							AND (([FG- Size Master].[Size Abbreviation])='" & Size & "') 
							AND (([FG - Component Master].SplitAcrossSizes)=False));"
						Using con_tws As New OleDbConnection(cnString)
							Dim cmd_tws As New OleDbCommand(cmdstring_twS)
							Dim reader_twS As OleDbDataReader
							cmd_tws.CommandType = CommandType.Text
							cmd_tws.Connection = con_tws
							cmd_tws.Connection.Open()
							cmd_tws.ExecuteNonQuery()

							reader_twS = cmd_tws.ExecuteReader(CommandBehavior.CloseConnection)
							While reader_twS.Read
								KnitWeight = reader_twS("SumOfBundleWeight")
							End While
						End Using
						SizeFound = True
					End If
				End While
			End Using
		Loop

		'Get yarn price of ground colour allocated to batch
		'What happens when there is more than one yarn allocated for the same batch for the ground colour?
		'Is it always one end product code per batch?
		Dim cmdstring_ypgc = "SELECT [KN - ProductionYarnAllocation].BatchNo, 
								   [KN - ProductionYarnAllocation].YarnKGPrice, 
								   [FG - End Product Colours].ColourNumber, 
								   [FG - End Product Colours].ColourPercentage 
						    FROM [KN - ProductionYarnAllocation] 
							INNER JOIN ([KN - ProductionOrderHeader] 
							INNER JOIN [FG - End Product Colours] 
								ON [KN - ProductionOrderHeader].ProductID = [FG - End Product Colours].ProductID) 
								ON ([KN - ProductionOrderHeader].BatchNo = [KN - ProductionYarnAllocation].BatchNo) 
									AND ([KN - ProductionYarnAllocation].YarnColourID = [FG - End Product Colours].YarnColourID) 
							WHERE ((([KN - ProductionYarnAllocation].BatchNo)='" & BatchNo & "') 
									AND (([FG - End Product Colours].ColourNumber)='G'));"
		Using con_ypgc As New OleDbConnection(cnString)
			Dim cmd_ypgc As New OleDbCommand(cmdstring_ypgc)
			Dim reader_ypgc As OleDbDataReader
			cmd_ypgc.CommandType = CommandType.Text
			cmd_ypgc.Connection = con_ypgc
			cmd_ypgc.Connection.Open()
			cmd_ypgc.ExecuteNonQuery()

			reader_ypgc = cmd_ypgc.ExecuteReader(CommandBehavior.CloseConnection)
			While reader_ypgc.Read
				YarnPrice = reader_ypgc("YarnKGPrice")
			End While
		End Using

		'Get number of jerseys cut (or "to cut" if not already cut) for batch and size

		'Which flag to use to determine whether to use actual or "to cut" numbers?
		'Bundle Complete or Cut Data Captured?
		Dim strQuery_NJ As String
		If AltSize = "None" Then
			strQuery_NJ = "SELECT [CMT - CMTDetailsHeader].BatchNo, 
								  [CMT - CMTDetailsHeader].BundleNo, 
								  [FG- Size Master].[Size Abbreviation],
								  [CMT - CMTDetailsHeader].BundleComplete, 
								  [CMT - CMTDetailsHeader].CutDataCaptured, 
								  [CMT - CMTDetailsHeader].JrsysToCut,
								  [CMT - CMTDetailsHeader].ActualJrsysCut 
							FROM [CMT - CMTDetailsHeader] 
							INNER JOIN [FG- Size Master] 
								ON [CMT - CMTDetailsHeader].SizeID = [FG- Size Master].SizeID 
							WHERE ((([CMT - CMTDetailsHeader].BatchNo)='" & BatchNo & "') 
								AND (([FG- Size Master].[Size Abbreviation])='" & Size & "'));"
		Else
			strQuery_NJ = "SELECT [CMT - CMTDetailsHeader].BatchNo, 
								  [CMT - CMTDetailsHeader].BundleNo, 
								  ([FG- Size Master].[Size Abbreviation]) AS [Size],
								  [CMT - CMTDetailsHeader].BundleComplete, 
								  [CMT - CMTDetailsHeader].CutDataCaptured, 
								  [CMT - CMTDetailsHeader].JrsysToCut, 
								  [CMT - CMTDetailsHeader].ActualJrsysCut 
							FROM [CMT - CMTDetailsHeader] 
							INNER JOIN [FG- Size Master] 
								ON [CMT - CMTDetailsHeader].SizeID = [FG- Size Master].SizeID 
							WHERE ((([CMT - CMTDetailsHeader].BatchNo)='" & BatchNo & "') 
								AND (([FG- Size Master].[Size Abbreviation])='" & AltSize & "'));"
		End If
		Using con_NJ As New OleDbConnection(cnString)
			Dim cmd_NJ As New OleDbCommand(strQuery_NJ)
			Dim reader_NJ As OleDbDataReader
			cmd_NJ.CommandType = CommandType.Text
			cmd_NJ.Connection = con_NJ
			cmd_NJ.Connection.Open()
			cmd_NJ.ExecuteNonQuery()

			reader_NJ = cmd_NJ.ExecuteReader(CommandBehavior.CloseConnection)
			If reader_NJ.HasRows = True Then
				Do While reader_NJ.Read
					If AltSize = "None" Then
						If reader_NJ("CutDataCaptured") = False Then
							NrJrsys = NrJrsys + reader_NJ("JrsysToCut")
						Else
							NrJrsys = NrJrsys + reader_NJ("ActualJrsysCut")
						End If
					Else
						If reader_NJ("CutDataCaptured") = False Then
							NrJrsysAlt = NrJrsysAlt + reader_NJ("(JrsysToCut")
						Else
							NrJrsysAlt = NrJrsysAlt + reader_NJ("ActualJrsysCut")
						End If
					End If
				Loop
				NrJrsys = NrJrsys + NrJrsysAlt
			End If
		End Using


		'Get total number of jerseys cut (or "to cut" if not already cut)
		'in batch across all sizes4

		Dim strQuery_TotNJ = "SELECT [CMT - CMTDetailsHeader].BatchNo, 
								   [CMT - CMTDetailsHeader].BundleNo, 
								   [CMT - CMTDetailsHeader].BundleComplete, 
								   [CMT - CMTDetailsHeader].CutDataCaptured, 
								   [CMT - CMTDetailsHeader].JrsysToCut, 
								   [CMT - CMTDetailsHeader].ActualJrsysCut 
							FROM [CMT - CMTDetailsHeader] 
							WHERE ((([CMT - CMTDetailsHeader].BatchNo)='" & BatchNo & "'));"
		Using con_TotNJ As New OleDbConnection(cnString)
			Dim cmd_TotNJ As New OleDbCommand(strQuery_TotNJ)
			Dim reader_TotNJ As OleDbDataReader
			cmd_TotNJ.CommandType = CommandType.Text
			cmd_TotNJ.Connection = con_TotNJ
			cmd_TotNJ.Connection.Open()
			cmd_TotNJ.ExecuteNonQuery()

			reader_TotNJ = cmd_TotNJ.ExecuteReader(CommandBehavior.CloseConnection)
			If reader_TotNJ.HasRows = True Then
				Do While reader_TotNJ.Read
					If reader_TotNJ("CutDataCaptured") = False Then
						TotNrJrsys = TotNrJrsys + reader_TotNJ("JrsysToCut")
					Else
						TotNrJrsys = TotNrJrsys + reader_TotNJ("ActualJrsysCut")
					End If
				Loop
			End If
		End Using


		'Get total weight of "split across sizes" components for batch

		Dim strQuery_SAS = "SELECT [KN - KnittingDetailsHeader].BatchNo, 
								   [FG - Component Master].SplitAcrossSizes, 
								   Sum([KN - KnittingDetailsWeights].BundleWeight) AS SumOfBundleWeight 
							FROM ([FG- Size Master] 
							INNER JOIN ([FG - Component Master] 
							INNER JOIN [KN - KnittingDetailsHeader] 
								ON [FG - Component Master].ComponentID = [KN - KnittingDetailsHeader].ComponentID) 
								ON [FG- Size Master].SizeID = [KN - KnittingDetailsHeader].SizeID) 
							INNER JOIN [KN - KnittingDetailsWeights] 
								ON [KN - KnittingDetailsHeader].BundleNo = [KN - KnittingDetailsWeights].BundleNo 
							GROUP BY [KN - KnittingDetailsHeader].BatchNo, [FG - Component Master].SplitAcrossSizes 
							HAVING ((([KN - KnittingDetailsHeader].BatchNo)='" & BatchNo & "') 
								And (([FG - Component Master].SplitAcrossSizes)=True));"
		Using con_SAS As New OleDbConnection(cnString)
			Dim cmd_SAS As New OleDbCommand(strQuery_SAS)
			Dim reader_SAS As OleDbDataReader
			cmd_SAS.CommandType = CommandType.Text
			cmd_SAS.Connection = con_SAS
			cmd_SAS.Connection.Open()
			cmd_SAS.ExecuteNonQuery()
			reader_SAS = cmd_SAS.ExecuteReader(CommandBehavior.CloseConnection)
			AllocComps = True
			If reader_SAS.HasRows = False Then
				AllocComps = False
				AllocWgt = 0
			Else
				While reader_SAS.Read
					If AllocComps = True Then
						AllocWgt = reader_SAS("SumOfBundleWeight")
					End If
				End While
			End If
		End Using


		'Will all batches always have components that are split across sizes?

		If TotNrJrsys = 0 Then
			MsgBox("Could not calculate average weight of 'split across sizes components'. Something is wrong.", vbOKOnly)
		Else
			AvgAllocWgt = AllocWgt / TotNrJrsys
		End If

		'Allocate "split across sizes" components to knitweight

		KnitWeight = KnitWeight + (AvgAllocWgt * NrJrsys)
		'Calculate final cost

		Return ((KnitWeight * YarnPrice) / NrJrsys)

	End Function

	Private Sub InsertInvDetails()
		For i As Integer = 0 To grdvBatch4Inv.Rows.Count - 1
			Dim txtJrysdel As TextBox = DirectCast(grdvBatch4Inv.Rows(i).Cells(0).FindControl("txtJD"), TextBox)
			Dim cmdstring As String
			cmdstring = "INSERT INTO [INV - Details] ([Invoice Number], ItemUniqueCode, ItemCategory01, ItemCategory02, ItemCategory03, ItemCategory04, ItemCategory05, ItemCategory06, ItemCategory07, ItemCategory08, ItemAmountOrdered, ItemAmountDel, ItemUnitPrice) " &
		"VALUES (" & InvoiceNumber & ", '" & grdvBatch4Inv.Rows(i).Cells(0).Text & ",'CMT Invoice Number', '" & grdvBatch4Inv.Rows(i).Cells(1).Text & "', '" & grdvBatch4Inv.Rows(i).Cells(2).Text & ", '" & grdvBatch4Inv.Rows(i).Cells(3).Text &
				 ", '" & grdvBatch4Inv.Rows(i).Cells(4).Text & ", '" & grdvBatch4Inv.Rows(i).Cells(5).Text & ", '" & grdvBatch4Inv.Rows(i).Cells(6).Text & ", '" & grdvBatch4Inv.Rows(i).Cells(7).Text & ", '" & grdvBatch4Inv.Rows(i).Cells(8).Text &
				 ", '" & grdvBatch4Inv.Rows(i).Cells(9).Text & ", '" & grdvBatch4Inv.Rows(i).Cells(10).Text & ", " & CalcItemMaterialCost(grdvBatch4Inv.Rows(i).Cells(10).Text, grdvBatch4Inv.Rows(i).Cells(6).Text) & ");"
			'Cell(
			Using con As New OleDbConnection(cnString)
				Dim cmd As New OleDbCommand(cmdstring)
				cmd.CommandType = CommandType.Text
				cmd.Connection = con
				cmd.Connection.Open()
				cmd.ExecuteNonQuery()
			End Using
		Next
	End Sub



	Private Sub updatecmtbundlecomplete()

	End Sub

	Protected Sub ddlBatch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBatch.SelectedIndexChanged
		grdvBatch4InvPopulate()
		PastelCSV()
	End Sub

	Private Sub PastelCSV()
		Dim SQL As String
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim sb As New StringBuilder
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			SQL = "SELECT DISTINCTROW KO.OrderNo, CDH.JrsysDelivered, S.StyleNo, CDH.BatchNo, CDH.BundleNo, EPC.ProductCode, SM.[Size Abbreviation] AS [Size], CDH.JrsysToCut, CDH.ActualJrsysCut, EM.EntityName
				   FROM (((((((([CMT - CMTDetailsHeader] AS CDH
				   INNER JOIN [KN - ProductionOrderHeader] AS POH
						ON CDH.BatchNo = POH.BatchNo)
				   INNER JOIN [KN - ProductionOrderDetails] AS POD
						ON POH.BatchNo = POD.BatchNo)
				   INNER JOIN [KN - KnittingOrder] AS KO
						ON POD.KnittingOrderID = KO.KnittingOrderID)
				   INNER JOIN [FG - End Product Codes] AS EPC
						ON KO.ProductID = EPC.ProductID)
				   INNER JOIN [GN - EntityMaster] AS EM
						ON KO.EntityID = EM.EntityID)
				   INNER JOIN [FG- Size Master] AS SM
						ON SM.SizeID = CDH.SizeID)
				   INNER JOIN [FG - Style Size Comp Def Details] AS SSCDD
						ON EPC.StyleID = SSCDD.StyleID)
				   INNER JOIN [FG - Style] AS S
						ON SSCDD.StyleID = S.StyleID)
				   WHERE CDH.BatchNo= '" & ddlBatch.SelectedValue & "'"
			cmd.Connection = con
			cmd.CommandText = SQL
			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			For Each dr As DataRow In Data.Rows
				'sb.AppendFormat("{0},{1}", dr(0), dr(1))
				sb.Append(dr(0) & ",")
				sb.Append(dr(1) & ",")
				sb.Append(dr(2) & ",")
				sb.Append(dr(3) & ",")
				sb.Append(dr(4).ToString & ",")
				sb.Append(dr(5).ToString & ",")
				sb.Append(dr(6).ToString & ",")
				sb.Append(dr(7).ToString & ",")
				sb.Append("\r\n")
			Next
		End Using
		SetLicense("")
		'Dim excelFile = New ExcelFile()
		Dim file As New StreamWriter("C:\Users\Deepak Vallabh\Documents\shantara\ShantaraProduction\ShantaraProduction\Exported\Pmastel.csv", True)
		file.WriteLine(sb.ToString)
		file.Close()
	End Sub
	Public Shared Sub SetLicense(serialKey As String)

	End Sub

	Protected Sub btncreateINV_Click(sender As Object, e As EventArgs) Handles btncreateINV.Click
		txtjerseycost.Text = CalcItemMaterialCost(ddlBatch.SelectedValue, "28")
	End Sub
End Class