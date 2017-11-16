Imports System.Data.OleDb
Imports ZXing.Common
Imports ZXing
Imports ZXing.QrCode
Public Class DisplayJerseyoverview
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		grdvFromKnittPopulate()
		'testinnerjoinUpdate()
		grdvReadyForCMTPopulate()
	End Sub

	Private Sub grdvFromKnittPopulate()
		Dim barcodeWriter As New BarcodeWriter
		barcodeWriter.Format = BarcodeFormat.QR_CODE
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;OLE DB Services=-4;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		Dim cmd As New OleDbCommand()
		grdvFromKnitt.Visible = True
		SQL = "SELECT POD.BatchNo, EM.EntityName, EPC.ProductCode, SUM(POD.ProductionQty) AS [Batch Total Panels], SIM.SpecialInstructionDetail, POH.KnittBatchComplete
        FROM (((((([KN - ProductionOrderDetails] AS POD 
		INNER JOIN [KN - KnittingOrder] AS KO
			On POD.KnittingOrderID = KO.KnittingOrderID)
		INNER JOIN [GN - EntityMaster] AS EM 
			ON KO.EntityID = EM.EntityID)
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN -Special Instructions Master] AS SIM
			ON KO.SpecialInstructionID = SIM.SpecialInstructionID)
		INNER JOIN [KN - ProductionOrderHeader] AS POH
			ON POD.BatchNo = POH.BatchNo)
		INNER JOIN [KN - KnittingDetailsHeader] AS KDH
			ON POD.BatchNo = KDH.BatchNo)
		WHERE KDH.KnittComplete = yes AND KDH.Checkcomplete = no
		GROUP BY POD.BatchNo, EM.EntityName, EPC.ProductCode, SIM.SpecialInstructionDetail, POH.KnittBatchComplete
		ORDER BY POD.BatchNo, EM.EntityName;"
		con.Open()
		cmd.Connection = con
		cmd.CommandText = SQL

		Adapter.SelectCommand = cmd
		Adapter.Fill(Data)

		grdvFromKnitt.DataSource = Data
		grdvFromKnitt.DataBind()
		cmd.Connection.Close()
	End Sub

	Private Sub grdvReadyForCMTPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;OLE DB Services=-4;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		Dim cmd As New OleDbCommand()
		grdvReadyForCMT.Visible = True
		SQL = "SELECT POD.BatchNo, EM.EntityName, EPC.ProductCode, SUM(POD.ProductionQty) AS [Batch Total Panels]
        FROM ((((([KN - ProductionOrderDetails] AS POD 
		INNER JOIN [KN - KnittingOrder] AS KO
			On POD.KnittingOrderID = KO.KnittingOrderID)
		INNER JOIN [GN - EntityMaster] AS EM 
			ON KO.EntityID = EM.EntityID)
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - ProductionOrderHeader] AS POH
			ON POD.BatchNo = POH.BatchNo)
		INNER JOIN [KN - KnittingDetailsHeader] AS KDH
			ON POD.BatchNo = KDH.BatchNo)
		WHERE (KDH.Checkcomplete = yes) AND (POH.CheckBatchComplete = yes) AND (POH.BatchComplete = no)
		GROUP BY POD.BatchNo, EM.EntityName, EPC.ProductCode
		ORDER BY POD.BatchNo, EM.EntityName;"
		con.Open()
		cmd.Connection = con
		cmd.CommandText = SQL

		Adapter.SelectCommand = cmd
		Adapter.Fill(Data)

		grdvReadyForCMT.DataSource = Data
		grdvReadyForCMT.DataBind()
		cmd.Connection.Close()
	End Sub

	Public Sub UpdatebatchComplete()
		Dim cmdstring As String = "UPDATE ([KN - ProductionOrderHeader] AS POH 
								   INNER JOIN [CMT - CMTDetailsHeader] AS CDH 
										ON POH.BatchNo = CDH.BatchNo) 
								   SET POH.BatchComplete = yes 
								   WHERE POH.CheckBatchComplete = yes AND CDH.CutDataCaptured = no"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;OLE DB Services=-4;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New OleDbCommand(cmdstring)
		'Dim cmd As New SqlCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub

	Public Sub testinnerjoinUpdate()
		Dim cmdstring As String = "UPDATE ([KN - ProductionOrderDetails] AS POD 
								   INNER JOIN [KN - KnittingDetailsHeader] AS KDH
										ON POD.BatchNo = KDH.BatchNo)
								   SET POD.ProductionQty = 600 
								   WHERE KDH.BundleComplete = yes AND KDH.KnittComplete = yes AND KDH.Checkcomplete = yes"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;OLE DB Services=-4;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New OleDbCommand(cmdstring)
		'Dim cmd As New SqlCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub

	Private Sub cdcInsertcmtoperation()
		Dim cmdstring As String
		cmdstring = " INSERT INTO [CMT - CMTDetailsOperations] (BundleNo) 
						SELECT BundleNo
						FROM ([CMT - CMTDetailsHeader]
						INNER JOIN [KN - ProductionOrderHeader]
							ON [KN - ProductionOrderHeader].BatchNo = [CMT - CMTDetailsHeader].BatchNo) 
						WHERE [KN - ProductionOrderHeader].BatchComplete = no AND [KN - ProductionOrderHeader].CheckBatchComplete = yes  AND [CMT - CMTDetailsHeader].CutDataCaptured = no AND [KN - ProductionOrderHeader].BatchNo = [CMT - CMTDetailsHeader].BatchNo"
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;OLE DB Services=-4;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		Dim cmd As New OleDbCommand(cmdstring)
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()
		cmd.Connection.Close()
	End Sub

	Protected Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
		'cdcInsertcmtoperation()
		UpdatebatchComplete()
		grdvReadyForCMTPopulate()
	End Sub

End Class