Imports System.Data.OleDb
Public Class CheckDataCapture
	Inherits System.Web.UI.Page
	'Shared BundleNo As String
	Shared totPanelsmade As Integer
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		GetCheckDatadb()
		getChecker()
		checkiffault()
	End Sub

	Private Sub GetCheckDatadb()
		Session("BundleNo") = Request.QueryString("ID").ToString()
		Dim cmdstring = "SELECT KDH.BatchNo, 
								KDH.PanelsToMake, 
								KDH.BundleNo, 
								KDH.PanelsMadeDay, 
								KDH.PanelsMadeNight,
								KDH.QtyPerPanel,
								KO.OrderNo, 
								EPC.ProductCode, 
								EPC.ProdDescription, 
								(SM.[Size Abbreviation]) AS [Size], 
								CM.ComponentName, 							
							    SSCDD.ComponentWidth, 
								SSCDD.ComponentLength, 					 
								YCD.YarnColour
        FROM (((((((([KN - KnittingDetailsHeader] AS KDH 
		INNER JOIN [KN - KnittingOrder] AS KO
			On KDH.KnittingOrderID = KO.KnittingOrderID )
		INNER JOIN [FG - Style Size Comp Def Details] AS SSCDD
			ON  SSCDD.SizeID = KDH.SizeID)
		INNER JOIN [FG - Component Master] AS CM 
			ON KDH.ComponentID = CM.ComponentID)
		INNER JOIN [FG- Size Master] AS SM
			ON KDH.SizeID = SM.SizeID)
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - ProductionYarnAllocation] AS PYA
			ON KDH.BatchNo = PYA.BatchNo)
		INNER JOIN [YN - Yarn Master] AS YM 
			ON PYA.YarnID = YM.YarnID)
		INNER JOIN [YN - Yarn Colour Defns] AS YCD
			ON YM.YarnColourID = YCD.YarnColourID)
		WHERE KDH.BundleNo = '" & Session("BundleNo") & "';"
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
				txtorderNo.Text = reader("OrderNo")
				lblBundleNo.Text = "BundleNo: " & reader("BundleNo")
				txtBatchNo.Text = reader("BatchNo")
				txtProdcode.Text = reader("ProductCode")
				If reader.IsDBNull(8) Then
					txtProdDescr.Text = ""
				Else
					txtProdDescr.Text = reader("ProdDescription")
				End If

				txtPToMake.Text = reader("PanelsToMake")
				txtSize.Text = reader("Size")
				txtComponent.Text = reader("ComponentName")
				txtQPpanel.Text = reader("QtyPerPanel")
				txtKwidth.Text = reader("ComponentWidth")
				txtkLength.Text = reader("ComponentLength")
				txtYarnColour.Text = reader("YarnColour")
				txtPMade.Text = reader("PanelsMadeDay") + reader("PanelsMadeNight")
			End While
		Else
			MsgBox("problem with displaying info from database into boxes")
		End If

	End Sub

	Private Sub getChecker()
		Dim strQuery As String = "SELECT EmployeeID, (EmployeeFirstName + ' ' + EmployeeLastName) AS [FullName] from [GN - EmployeeDetails] WHERE JobDescription = 'KnitChecker'"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		Dim cmd As New OleDbCommand()
		If IsPostBack = False Then
			ddlChecker.AppendDataBoundItems = True
			cmd.CommandType = CommandType.Text
			cmd.CommandText = strQuery
			cmd.Connection = con
			Try
				con.Open()
				ddlChecker.DataSource = cmd.ExecuteReader()
				ddlChecker.DataTextField = "FullName"
				ddlChecker.DataValueField = "EmployeeID"
				ddlChecker.DataBind()
			Catch ex As Exception
				Throw ex
			Finally
				con.Close()
				cmd.Dispose()
				con.Dispose()
			End Try
		End If
	End Sub
	Private Sub checkiffault()
		If ddlFault.SelectedIndex = 1 Then
			txtFHoles.Enabled = True
			txtFNeedleStripe.Enabled = True
			txtFWidth.Enabled = True
			txtFLength.Enabled = True
			txtFDropStitch.Enabled = True
			txtFYarn.Enabled = True
			txtFPressoff.Enabled = True
			txtFQty.Enabled = True
			txtFaultCollars.Enabled = True
			txtFOthers.Enabled = True
		ElseIf ddlFault.SelectedIndex = 2 Then
			txtFHoles.Enabled = False
			txtFNeedleStripe.Enabled = False
			txtFWidth.Enabled = False
			txtFLength.Enabled = False
			txtFDropStitch.Enabled = False
			txtFYarn.Enabled = False
			txtFPressoff.Enabled = False
			txtFQty.Enabled = False
			txtFaultCollars.Enabled = False
			txtFOthers.Enabled = False
		End If
	End Sub
	Private Sub cdcInsertfaultrecord()
		Dim cmdstring As String
		'"', FaultPress-Off ='" & txtFPressoff.Text &
		cmdstring = "INSERT INTO [KN - KnittingDetailsFaults] (BundleNo, FaultHoles, FaultNeedleStripe, FaultWidth, FaultLength, FaultDropStitch, FaultYarn, [FaultPress-Off], FaultQty, FaultCollars, FaultOther) VALUES ('" & Session("BundleNo") &
						"', " & txtFHoles.Text &
						", " & txtFNeedleStripe.Text &
						", " & txtFWidth.Text &
						", " & txtFLength.Text &
						", " & txtFDropStitch.Text &
						", " & txtFYarn.Text &
						", " & txtFPressoff.Text &
						", " & txtFQty.Text &
						", " & txtFaultCollars.Text &
						", " & txtFOthers.Text & ");"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		Dim cmd As New OleDbCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub

	Private Sub cdcUpdateweightrecord()
		Dim cmdstring As String
		cmdstring = " UPDATE [KN - KnittingDetailsWeights]
					  SET BundleWeight =" & txtBundleWeight.Text &
						", BundleWasteWeight =" & txtBundleWasteWeight.Text &
						", BundleFaultWeight =" & txtBundleFaultWeight.Text &
					" WHERE BundleNo = '" & Session("BundleNo") & "'"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		Dim cmd As New OleDbCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub

	Private Sub cdcUpdateheaderrecord()
		Dim cmdstring As String
		cmdstring = " UPDATE [KN - KnittingDetailsHeader]
					  SET Checker =" & ddlChecker.SelectedValue &
						", DateChecked ='" & DateTime.Now &
						"', Checkcomplete = yes 
						 WHERE BundleNo = '" & Session("BundleNo") & "'"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		Dim cmd As New OleDbCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub
	Public Sub UpdateCheckbatchComplete()
		Dim cmdstring As String = "UPDATE [KN - ProductionOrderHeader] SET CheckBatchComplete = yes WHERE BatchNo =  '" & txtBatchNo.Text & "'"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New OleDbCommand(cmdstring)
		'Dim cmd As New SqlCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub

	Public Sub CheckbatchCompleteCheck()
		Dim cmdstring = "SELECT POD.BatchNo, KDH.BundleNo, KDH.Checkcomplete, POH.CheckBatchComplete
		FROM ((([KN - ProductionOrderDetails] POD 
		INNER JOIN [KN - KnittingOrder] KO
			On POD.KnittingOrderID = KO.KnittingOrderID )
		INNER JOIN [KN - ProductionOrderHeader] POH
			ON POD.BatchNo = POH.BatchNo)
		INNER JOIN [KN - KnittingDetailsHeader] KDH
			ON POD.BatchNo = KDH.BatchNo)
		WHERE (KDH.Checkcomplete = no) AND (POH.CheckBatchComplete = no) AND (KDH.BatchNo = '" & txtBatchNo.Text & "')"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb")
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
		If reader.HasRows = False Then
			MsgBox("check batch complete")
			UpdateCheckbatchComplete()
			Response.Redirect("~\CheckStore\CheckOverview.aspx")
		Else
			KnittbatchCompleteCheck()
		End If
	End Sub

	Public Sub KnittbatchCompleteCheck()
		Dim cmdstring = "SELECT kdh.BatchNo, kdh.BundleNo, (sm.[Size Abbreviation]) AS [Size], (cm.ComponentName) AS [Component], kdh.PanelsToMake, (SIM.SpecialInstructionDetail) AS [Special Instructions]
        FROM ((((([KN - KnittingDetailsHeader] AS kdh
		INNER JOIN [KN - KnittingOrder] AS ko
			On kdh.KnittingOrderID = ko.KnittingOrderID )
		INNER JOIN [FG - Component Master] AS cm
			ON  cm.ComponentID = kdh.ComponentID)
		INNER JOIN [FG- Size Master] AS sm
			ON  sm.SizeID = kdh.SizeID )
		INNER JOIN [FG - End Product Codes] AS epc
			ON ko.ProductID = epc.ProductID)
		INNER JOIN [KN -Special Instructions Master] AS SIM
			ON ko.SpecialInstructionID = SIM.SpecialInstructionID)
		WHERE (kdh.BatchNo = '" & Session("BatchNo") & "') AND (kdh.KnittComplete = yes) AND (kdh.Checkcomplete = no);"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb")
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
		If reader.HasRows = False Then
			MsgBox("no more checks but outstandng bundles(batch incomplete)")
			Response.Redirect("~\CheckStore\CheckOverview.aspx")
		Else
			Response.Redirect("~\CheckStore\CheckBundles.aspx?ID=" & txtBatchNo.Text)
		End If
	End Sub

	Protected Sub BtnCaptureBundle_Click(sender As Object, e As EventArgs) Handles BtnCaptureBundle.Click
		If ddlFault.SelectedIndex = 1 Then
			cdcInsertfaultrecord()
		End If
		cdcUpdateweightrecord()
		cdcUpdateheaderrecord()
		CheckbatchCompleteCheck()
	End Sub
End Class