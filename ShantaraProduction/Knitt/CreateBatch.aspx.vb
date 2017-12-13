Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Web.Services
Imports System.Configuration
Public Class CreateBatch
	Inherits System.Web.UI.Page
	Private BLNU As Integer
	Private BatchNo As String
	Private cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"


	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		getProduct()
	End Sub
	'	<System.Web.Services.WebMethod()>
	'	Public Shared Function GettProduct(prefix As String) As String()
	'		Dim products As New List(Of String)()
	'		Using conn As New OleDbConnection()
	'			conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"
	'			Using cmd As New OleDbCommand()
	'				cmd.CommandText = "SELECT DISTINCT KO.ProductID, EPC.ProductCode, EPC.ProdDescription 
	'FROM [FG - End Product Codes] AS EPC
	'INNER JOIN [KN - KnittingOrder] AS KO
	'	ON EPC.ProductID = KO.ProductID 
	'WHERE (((KO.KnittingIssued)=False) AND (ProductCode like @SearchText + '%')) 
	'ORDER BY EPC.ProductCode; "
	'				cmd.Parameters.AddWithValue("@SearchText", prefix)
	'				cmd.Connection = conn
	'				conn.Open()
	'				Using sdr As OleDbDataReader = cmd.ExecuteReader()
	'					While sdr.Read()
	'						products.Add(String.Format("{0}-{1}", sdr("ContactName"), sdr("CustomerId")))
	'					End While
	'				End Using
	'				conn.Close()
	'			End Using
	'		End Using
	'		Return products.ToArray()
	'	End Function

	Private Sub getProduct()
		Dim strQuery As String = "SELECT DISTINCT KO.ProductID, EPC.ProductCode, EPC.ProdDescription 
FROM [FG - End Product Codes] AS EPC
INNER JOIN [KN - KnittingOrder] AS KO
	ON EPC.ProductID = KO.ProductID 
WHERE (((KO.KnittingIssued)=False)) 
ORDER BY EPC.ProductCode; "
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()

			If IsPostBack = False Then
				ddlBProduct.AppendDataBoundItems = True
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strQuery
				cmd.Connection = con
				Try
					con.Open()
					ddlBProduct.DataSource = cmd.ExecuteReader()
					ddlBProduct.DataTextField = "ProductCode"
					ddlBProduct.DataValueField = "ProductID"
					ddlBProduct.DataBind()
				Catch ex As Exception
					Throw ex
				End Try
			End If
		End Using
	End Sub

	'SQL = "SELECT DISTINCT POH.BatchNo, SSCDD.ComponentID, COUNT(SSCDD.ComponentID) AS [RCOUNT]
	'		FROM(
	'				SELECT last(5)
	'				FROM ([KN - ProductionOrderHeader] AS POH
	'				INNER Join [FG - End Product Codes] AS EPC
	'					On POH.ProductID = EPC.ProductID)
	'				INNER Join([KN - ProductionOrderDetails] AS POD
	'				INNER Join [FG - Style Size Comp Def Details]  AS SSCDD
	'					On POD.SizeID = SSCDD.SizeID) 
	'					On (POH.BatchNo = POD.BatchNo) 
	'						And (EPC.StyleID = SSCDD.StyleID)
	'				WHERE POH.BatchNo = 'BRN493'
	'	) AS temptable2
	'	WHERE RCOUNT = 2;"


	Private Sub grdvProductionOrdersPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			grdvProductionOrders.Visible = True
			'btnBack.Visible = False
			'btnAddUser.Visible = True	
			Session("Batch_Product") = ddlBProduct.SelectedValue
			SQL = "SELECT DISTINCT KO.KnittingOrderID, KO.OrderNo, KO.ReqByDate, EM.EntityName, SM.[Size Abbreviation] AS [Size], KOSQD.OrderQtyBalance, KOSQD.OnProductionOrder, SM.SizeID
			   FROM (([GN - EntityMaster] AS EM
			   INNER JOIN [KN - KnittingOrder] AS KO
				  ON EM.EntityID = KO.EntityID)
			   INNER JOIN [FG - End Product Master] AS EPM
				  ON EPM.ProductID = KO.ProductID)
			   INNER JOIN ([FG- Size Master] AS SM
			   INNER JOIN [KN - KnittingOrderSzQtyDetails] AS KOSQD
				  ON SM.SizeID = KOSQD.SizeID) 
				  ON KO.KnittingOrderID = KOSQD.KnittingOrderID
			   WHERE (KO.KnittingIssued=False) And (KO.ProductID=" & Session("Batch_Product") & ") AND (KOSQD.OrderQtyBalance>0)
			   ORDER BY KO.OrderNo;"
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvProductionOrders.DataSource = Data
			grdvProductionOrders.DataBind()
			'For r As Integer = 0 To grdvProductionOrders.Rows.Count - 1
			'	grdvProductionOrders.Rows(r).Cells(8).Visible = False
			'Next
		End Using
	End Sub

	Private Sub grdvisyarnavailablePopulate() 'query needs to be changed when moving to new db(not access)
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			grdvisyarnavailable.Visible = True
			'btnBack.Visible = False
			'btnAddUser.Visible = True	
			SQL = "SELECT DISTINCT D15.YarnID, D15.YarnDyelot, D15.YarnColourID, D15.YarnColour, D15.CurrentWeight, D15.YarnType, D15.EntityName, D15.YarnPurchaseDate, D15.YarnPurchaceWeight, D15.SupplierInvoiceNo, D15.YarnKgPrice
FROM  ([KN - Union of Dyelots Greater and Less than 15kg] AS D15
INNER JOIN [FG - End Product Colours] AS EPC
	ON EPC.YarnColourID = D15.YarnColourID)
WHERE ((D15.CurrentWeight>=" & txtYarnReq.Text & "*(EPC.ColourPercentage/100)) 
	AND ((EPC.ColourPercentage)>0)
	AND (EPC.ProductID = " & Session("Batch_Product") & ")) 
ORDER BY D15.CurrentWeight;"
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvisyarnavailable.DataSource = Data
			grdvisyarnavailable.DataBind()
		End Using
	End Sub

	Private Function yarnreq(size As Integer) As Double
		Dim yrn As Double
		Dim cmdstring = "SELECT EPM.YarnRequired
						 FROM ([FG - End Product Master] AS EPM
						 INNER JOIN [FG- Size Master] AS SM
							ON SM.SizeID = EPM.SizeID)
						 WHERE (EPM.ProductID = " & Session("Batch_Product") & ") AND (SM.[Size Abbreviation] = '" & size & "')"
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
					yrn = reader("YarnRequired")
				End While
			Else
				MsgBox("problem with displaying info from database into boxes")
			End If
			Return yrn
		End Using
	End Function

	Private Sub machalocationtbl()

		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			grdvmachincomp.Visible = True
			'Session("Batch_Product") = ddlBProduct.SelectedValue
			SQL = "SELECT DISTINCT POH.BatchNo, SSCDD.ComponentID
						FROM ([KN - ProductionOrderHeader] AS POH
						INNER Join [FG - End Product Codes] AS EPC
							On POH.ProductID = EPC.ProductID)
						INNER Join([KN - ProductionOrderDetails] AS POD
						INNER Join [FG - Style Size Comp Def Details]  AS SSCDD
							On POD.SizeID = SSCDD.SizeID) 
							On (POH.BatchNo = POD.BatchNo) 
								And (EPC.StyleID = SSCDD.StyleID)
						WHERE POH.BatchNo = '" & BatchNo & "'"
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvmachincomp.DataSource = Data
			grdvmachincomp.DataBind()
			For r As Integer = 0 To grdvProductionOrders.Rows.Count - 1
				grdvProductionOrders.Rows(r).Cells(8).Visible = False
			Next
		End Using
	End Sub

	Protected Sub chkRow_CheckedChanged(sender As Object, e As EventArgs)
		'Dim chk As CheckBox = DirectCast(sender, CheckBox)
		'Dim gr As GridViewRow = DirectCast(chk.Parent.Parent, GridViewRow)
		Dim qty As Double
		Dim otot As Integer
		Dim counter As Integer = 0
		For i As Integer = 0 To grdvProductionOrders.Rows.Count - 1
			Dim chk As CheckBox = DirectCast(grdvProductionOrders.Rows(i).Cells(0).FindControl("chkRow"), CheckBox)
			If chk.Checked Then
				counter += 1
				If counter > 0 Then
					qty += ((grdvProductionOrders.Rows(i).Cells(6).Text) * yarnreq(grdvProductionOrders.Rows(i).Cells(5).Text))
					txtYarnReq.Text = Replace(qty, ",", ".")
					otot += grdvProductionOrders.Rows(i).Cells(6).Text
					txtOrderTot.Text = otot
					grdvisyarnavailablePopulate()
				Else
					grdvisyarnavailable.Visible = False
				End If

			End If
		Next
	End Sub

	Private Sub NewBatchNo()
		Dim cmdstring = "SELECT YNCF.yarnColourAbbreviation, YNCF.LastBatchNo
        FROM [YN - Yarn Colour Defns] AS YNCF 
		INNER JOIN [FG - End Product Colours] AS FGPC 
			ON YNCF.YarnColourID = FGPC.YarnColourID
        WHERE (FGPC.ColourNumber = 'G') AND (FGPC.ProductID = " & ddlBProduct.SelectedValue & ");"
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
					BLNU = reader("LastBatchNo") + 1
					BatchNo = reader("yarnColourAbbreviation") & CStr(BLNU)
				End While
			Else
				MsgBox("batchNo not working")
			End If
		End Using
	End Sub

	Private Sub updatebatchno()
		Dim cmdstring As String = "UPDATE ([YN - Yarn Colour Defns] AS YNCF 
								   INNER JOIN [FG - End Product Colours] AS FGPC 
										ON YNCF.YarnColourID = FGPC.YarnColourID)
								   SET YNCF.LastBatchNo = " & BLNU &
								   " WHERE (FGPC.ColourNumber = 'G') AND (FGPC.ProductID = " & ddlBProduct.SelectedValue & ");"
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand(cmdstring)
			'Dim cmd As New SqlCommand(cmdstring)
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
		'MsgBox("batch Updated")
	End Sub

	Private Sub InsertProductionOrderHeaderRecord()
		Dim cmdstring As String
		cmdstring = " INSERT INTO [KN - ProductionOrderHeader] (BatchNo, ProductID, DateIssued) VALUES ('" &
					BatchNo &
					"', " & ddlBProduct.SelectedValue &
					", '" & DateTime.Now &
					"');"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
		'MsgBox("orderheader")
	End Sub

	Private Sub InsertProductionOrderDetailsRecord()
		For i As Integer = 0 To grdvProductionOrders.Rows.Count - 1
			Dim chk As CheckBox = DirectCast(grdvProductionOrders.Rows(i).Cells(0).FindControl("chkRow"), CheckBox)
			If chk.Checked Then
				Dim cmdstring As String
				cmdstring = " INSERT INTO [KN - ProductionOrderDetails] (BatchNo, SizeID, KnittingOrderID, ProductionQty) VALUES ('" &
							BatchNo &
							"', " & grdvProductionOrders.Rows(i).Cells(8).Text &
							", " & grdvProductionOrders.Rows(i).Cells(1).Text &
							", " & grdvProductionOrders.Rows(i).Cells(6).Text &
							");"
				Using con As New OleDbConnection(cnString)
					Dim cmd As New OleDbCommand(cmdstring)
					cmd.CommandType = CommandType.Text
					cmd.Connection = con
					cmd.Connection.Open()
					cmd.ExecuteNonQuery()
				End Using
			End If
		Next
		'MsgBox("orderdetails")
	End Sub

	Private Sub machineallocation()
		For c As Integer = 0 To grdvmachincomp.Rows.Count - 1
			Dim cmdstring As String
			cmdstring = " INSERT INTO [KN - ProductionMachineAllocation] (BatchNo, ComponentID) VALUES('" & grdvmachincomp.Rows(c).Cells(0).Text & "', " & grdvmachincomp.Rows(c).Cells(1).Text & ");"
			Using con As New OleDbConnection(cnString)
				Dim cmd As New OleDbCommand(cmdstring)
				cmd.CommandType = CommandType.Text
				cmd.Connection = con
				cmd.Connection.Open()
				cmd.ExecuteNonQuery()
			End Using
		Next
		'MsgBox("MACHINE ALLOCTION PER COMP")
	End Sub

	Private Sub yarnallocation()
		For i As Integer = 0 To grdvisyarnavailable.Rows.Count - 1
			Dim chk As CheckBox = DirectCast(grdvisyarnavailable.Rows(i).Cells(0).FindControl("chkRowy"), CheckBox)
			If chk.Checked Then
				Dim cmdstring As String
				If grdvisyarnavailable.Rows(i).Cells(1).Text = "Dummy" Then
					For u As Integer = 0 To grdvisvariousdyelot.Rows.Count - 1
						Dim chkk As CheckBox = DirectCast(grdvisvariousdyelot.Rows(u).Cells(0).FindControl("chkRowvd"), CheckBox)
						If chkk.Checked Then
							cmdstring = " INSERT INTO [KN - ProductionYarnAllocation] (BatchNo, YarnColourID, yarnID, CombinedDyelot, YarnRequired, YarnKgPrice) VALUES ('" &
							BatchNo &
							"', " & grdvisyarnavailable.Rows(i).Cells(3).Text &
							", " & grdvisvariousdyelot.Rows(u).Cells(1).Text &
							", " & txtYarnReq.Text &
							", true" &
							", VAL(Replace('" & grdvisyarnavailable.Rows(i).Cells(11).Text & "',',','.'))" &
							");"
						End If
					Next
				Else
					cmdstring = " INSERT INTO [KN - ProductionYarnAllocation] (BatchNo, YarnColourID, yarnID, YarnRequired, YarnKgPrice) VALUES ('" &
							BatchNo &
							"', " & grdvisyarnavailable.Rows(i).Cells(3).Text &
							", " & grdvisyarnavailable.Rows(i).Cells(1).Text &
							", " & txtYarnReq.Text &
							", VAL(Replace('" & grdvisyarnavailable.Rows(i).Cells(11).Text & "',',','.'))" &
							");"
				End If
				Using con As New OleDbConnection(cnString)
					Dim cmd As New OleDbCommand(cmdstring)
					cmd.CommandType = CommandType.Text
					cmd.Connection = con
					cmd.Connection.Open()
					cmd.ExecuteNonQuery()
				End Using
			End If
		Next
		'MsgBox("yarn allocated")
	End Sub

	Protected Sub ddlBProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBProduct.SelectedIndexChanged
		grdvisyarnavailable.Visible = False
		grdvisvariousdyelot.Visible = False
		grdvProductionOrders.Visible = False
		grdvProductionOrdersPopulate()
	End Sub


	Protected Sub chkRowy_CheckedChanged(sender As Object, e As EventArgs)
		Dim counter As Integer
		Dim i As Integer
		For i = 0 To grdvisyarnavailable.Rows.Count - 1
			Dim chk As CheckBox = DirectCast(grdvisyarnavailable.Rows(i).Cells(0).FindControl("chkRowy"), CheckBox)
			If chk.Checked Then
				counter = counter + 1
				If counter > 1 Then
					lblerrvd.Visible = True
					lblerrYA.Text = "too many checked"
					chk.Checked = False
				Else
					lblerrYA.Visible = False
					If grdvisyarnavailable.Rows(i).Cells(1).Text = "Dummy" Then
						grdvisvariousdyelotPopulate()
					End If
				End If
			End If
		Next
	End Sub

	Private Sub grdvisvariousdyelotPopulate() 'query needs to be changed when moving to new db(not access)
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			grdvisvariousdyelot.Visible = True
			Dim i As Integer
			For i = 0 To grdvisyarnavailable.Rows.Count - 1
				Dim chk As CheckBox = DirectCast(grdvisyarnavailable.Rows(i).Cells(0).FindControl("chkRowy"), CheckBox)
				If chk.Checked Then
					'sql statement from stored query not table
					SQL = "SELECT Dless15.[YarnID], Dless15.[YarnDyelot], Dless15.[YarnColourID], Dless15.[YarnColour], Dless15.[YarnTypeID], 
					  Dless15.[YarnType], Dless15.[EntityName], Dless15.[SupplierInvoiceNo], Dless15.[YarnPurchaceWeight], 
					  Dless15.[YarnPurchaseCartons], Dless15.[YarnPurchaseDate], Dless15.[YarnSupplier], Dless15.[CurrentCartons] 
			   FROM [KN - Dyelots Less than 15kg] AS Dless15
			   Where ([YarnColourID] = " & grdvisyarnavailable.Rows(i).Cells(3).Text &
						" AND [YarnType] = '" & grdvisyarnavailable.Rows(i).Cells(6).Text &
						"' AND [EntityName] ='" & grdvisyarnavailable.Rows(i).Cells(7).Text &
						"' And [SupplierInvoiceNo] = '" & grdvisyarnavailable.Rows(i).Cells(10).Text & "');"
					'Else
					'	grdvisvariousdyelot.Visible = False
				End If
			Next

			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvisvariousdyelot.DataSource = Data
			grdvisvariousdyelot.DataBind()
		End Using
	End Sub

	Protected Sub chkRowvd_CheckedChanged(sender As Object, e As EventArgs)
		Dim counter As Integer
		For u As Integer = 0 To grdvisvariousdyelot.Rows.Count - 1
			Dim chk As CheckBox = DirectCast(grdvisvariousdyelot.Rows(u).Cells(0).FindControl("chkRowvd"), CheckBox)
			If chk.Checked Then
				counter = counter + 1
				If counter > 1 Then
					lblerrvd.Visible = True
					lblerrvd.Text = "too many checked"
					chk.Checked = False
				Else
					lblerrvd.Visible = False
				End If
			End If
		Next
	End Sub

	Protected Sub BtnCreateBatch_Click(sender As Object, e As EventArgs) Handles BtnCreateBatch.Click
		'For i As Integer = 0 To grdvProductionOrders.Rows.Count - 1
		'	Dim chkPO As CheckBox = DirectCast(grdvProductionOrders.Rows(i).Cells(0).FindControl("chkRow"), CheckBox)
		'	If chkPO.Checked Then
		'		lblerrPO.Visible = False
		'		lblerrYA.Visible = False
		'		Dim j As Integer
		'		For j = 0 To grdvisyarnavailable.Rows.Count - 1
		'			Dim chkya As CheckBox = DirectCast(grdvisyarnavailable.Rows(j).Cells(0).FindControl("chkRowy"), CheckBox)
		'			If chkya.Checked Then
		'				lblerrYA.Visible = False
		'				If grdvisyarnavailable.Rows(j).Cells(1).Text = "Dummy" Then
		'					For u As Integer = 0 To grdvisvariousdyelot.Rows.Count - 1
		'						Dim chkvd As CheckBox = DirectCast(grdvisvariousdyelot.Rows(u).Cells(0).FindControl("chkRowvd"), CheckBox)
		'						If chkvd.Checked Then
		'							lblerrvd.Visible = False
		'							lblerrYA.Visible = False
		'							lblerrPO.Visible = False
		'						Else
		'							lblerrvd.Visible = True
		'							lblerrvd.Text = "Please select an Yarn"
		'							Exit Sub
		'						End If
		'					Next
		'				Else
		'					lblerrvd.Visible = False
		'					lblerrYA.Visible = False
		'					lblerrPO.Visible = False
		'				End If
		'			Else
		'				lblerrYA.Visible = True
		'				lblerrYA.Text = "Please select an Yarn"
		'				Exit Sub
		'			End If
		'		Next
		'	Else
		'		lblerrPO.Visible = True
		'		lblerrPO.Text = "Please select an Order"
		'		Exit Sub
		'	End If
		'Next
		NewBatchNo()
		InsertProductionOrderHeaderRecord()
		InsertProductionOrderDetailsRecord()
		machalocationtbl()
		machineallocation()
		yarnallocation()
		updatebatchno()
	End Sub


End Class