Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
Public Class DisplayBatchBundles
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		grdvbatchprodnPopulate()
	End Sub

	Private Sub grdvbatchprodnPopulate()
		Dim Adapter As New OleDbDataAdapter
		'Dim Adapter As New SqlDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New OleDbCommand()
		'Dim cmd As New SqlCommand()
		grdvbatchprodn.Visible = True
		SQL = "SELECT [KN - ProductionOrderDetails].BatchNo, 
					  [GN - EntityMaster].EntityName, 
					  [FG - End Product Codes].ProductCode,
					  SUM([KN - ProductionOrderDetails].ProductionQty) AS [Batch Total Panels],
					  [KN -Special Instructions Master].SpecialInstructionDetail,
					  [KN - ProductionOrderHeader].KnittBatchComplete 
		      FROM (((((([KN - ProductionOrderDetails] 
		INNER JOIN [KN - KnittingOrder]		
			ON  [KN - ProductionOrderDetails].KnittingOrderID = [KN - KnittingOrder].KnittingOrderID)
		INNER JOIN [GN - EntityMaster] 
			ON [GN - EntityMaster].EntityID = [KN - KnittingOrder].EntityID)
		INNER JOIN [KN -Special Instructions Master] 
			ON [KN -Special Instructions Master].SpecialInstructionID = [KN - KnittingOrder].SpecialInstructionID)
		INNER JOIN [KN - ProductionOrderHeader] 
			ON [KN - ProductionOrderHeader].BatchNo = [KN - ProductionOrderDetails].BatchNo)
		INNER JOIN [FG - End Product Codes] 
			ON [FG - End Product Codes].ProductID = [KN - ProductionOrderHeader].ProductID)
		INNER JOIN [KN - KnittingDetailsHeader] 
			ON [KN - KnittingDetailsHeader].BatchNo = [KN - ProductionOrderDetails].BatchNo)
		WHERE [KN - ProductionOrderHeader].KnittBatchComplete = no
		GROUP BY [KN - ProductionOrderDetails].BatchNo, [GN - EntityMaster].EntityName, [FG - End Product Codes].ProductCode, [KN -Special Instructions Master].SpecialInstructionDetail, [KN - ProductionOrderHeader].KnittBatchComplete
		ORDER BY [KN - ProductionOrderDetails].BatchNo, [GN - EntityMaster].EntityName;"
		con.Open()
		cmd.Connection = con
		cmd.CommandText = SQL

		Adapter.SelectCommand = cmd
		Adapter.Fill(Data)

		grdvbatchprodn.DataSource = Data
		grdvbatchprodn.DataBind()

	End Sub



End Class