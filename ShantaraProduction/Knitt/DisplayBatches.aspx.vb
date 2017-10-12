Imports System.Data.SqlClient
Public Class DisplayBatchBundles
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		grdvbatchprodnPopulate()
	End Sub

	Private Sub grdvbatchprodnPopulate()
		Dim cmd As New SqlCommand
		Dim Adapter As New SqlDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		grdvbatchprodn.Visible = True
		SQL = "SELECT POD.BatchNo, EM.EntityName, EPC.ProductCode, SUM(POD.ProductionQty) AS [Batch Total Panels], SIM.SpecialInstructionDetail, POH.BatchComplete
        FROM [KN - ProductionOrderDetails] POD INNER JOIN [KN - KnittingOrder] KO
			On POD.KnittingOrderID = KO.KnittingOrderID 
		INNER JOIN [GN - EntityMaster] EM 
			ON KO.EntityID = EM.EntityID
		INNER JOIN [FG - End Product Codes] EPC
			ON KO.ProductID = EPC.ProductID
		INNER JOIN [KN -Special Instructions Master] SIM
			ON KO.SpecialInstructionID = SIM.SpecialInstructionID
		INNER JOIN [KN - ProductionOrderHeader] POH
			ON POD.BatchNo = POH.BatchNo
		INNER JOIN [KN - KnittingDetailsHeader] KDH
			ON POD.BatchNo = KDH.BatchNo
		WHERE KDH.BundleComplete = 0 	
		GROUP BY POD.BatchNo, EntityName, EPC.ProductCode, SIM.SpecialInstructionDetail, POH.BatchComplete
		ORDER BY POD.BatchNo, EM.EntityName;"
		con.Open()
		cmd.Connection = con
		cmd.CommandText = SQL

		Adapter.SelectCommand = cmd
		Adapter.Fill(Data)

		grdvbatchprodn.DataSource = Data
		grdvbatchprodn.DataBind()

	End Sub

End Class