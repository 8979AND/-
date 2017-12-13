Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
Public Class DisplayBatchBundles
	Inherits System.Web.UI.Page
	Private cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Updatenullspecialinstructions()
		'UpdateAllRecordscompletes()
		'UpdateAlbundlelRecordsincomplete()
		grdvbatchprodnPopulate()
	End Sub

	Private Sub grdvbatchprodnPopulate()
		Dim Adapter As New OleDbDataAdapter
		'Dim Adapter As New SqlDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand()
			'Dim cmd As New SqlCommand()
			grdvbatchprodn.Visible = True
			SQL = "SELECT DISTINCT [KN - ProductionOrderDetails].BatchNo, 
					  [GN - EntityMaster].EntityName, 
					  [FG - End Product Codes].ProductCode,
					  [KN -Special Instructions Master].SpecialInstructionDetail,
					  [KN - ProductionOrderHeader].DateIssued 
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
			  ORDER BY [KN - ProductionOrderDetails].BatchNo, [KN - ProductionOrderHeader].DateIssued, [GN - EntityMaster].EntityName;"
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvbatchprodn.DataSource = Data
			grdvbatchprodn.DataBind()
		End Using
	End Sub

	Private Sub Updatenullspecialinstructions()
		Dim cmdstring As String = "UPDATE [KN - KnittingOrder] SET SpecialInstructionID = 43 WHERE SpecialInstructionID IS NULL"
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand(cmdstring)
			'Dim cmd As New SqlCommand(cmdstring)
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub

	Private Sub UpdateAllRecordscompletes()
		Dim cmdstring As String
		cmdstring = "UPDATE [KN - ProductionOrderHeader]
					 SET BatchComplete = no"
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand(cmdstring)
			'Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub

	Private Sub UpdateAlbundlelRecordsincomplete()
		Dim cmdstring As String
		cmdstring = "UPDATE [KN - KnittingDetailsHeader]
					 SET KnittComplete = no, Checkcomplete = no"
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand(cmdstring)
			'Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub
End Class