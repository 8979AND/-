Imports System.Data.OleDb
Public Class BundleOverview
	Inherits System.Web.UI.Page
	Private cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		grdvBundlesToCheckPopulate()
		grdvBundlesCheckedPopulate()
	End Sub

	Private Sub grdvBundlesToCheckPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			grdvBundlesToCheck.Visible = True
			Session("BatchNo") = Request.QueryString("ID").ToString()
			SQL = "SELECT kdh.BatchNo, kdh.BundleNo, (sm.[Size Abbreviation]) AS [Size], (cm.ComponentName) AS [Component], kdh.PanelsToMake, (SIM.SpecialInstructionDetail) AS [Special Instructions]
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
		WHERE (kdh.BatchNo = @BatchNo) AND (kdh.KnittComplete = yes) AND (kdh.Checkcomplete = no);"
			cmd.Parameters.AddWithValue("@BatchNo", Session("BatchNo"))
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvBundlesToCheck.DataSource = Data
			grdvBundlesToCheck.DataBind()
		End Using
	End Sub

	Private Sub grdvBundlesCheckedPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			grdvBundlesChecked.Visible = True
			SQL = "SELECT kdh.BatchNo, kdh.BundleNo, (sm.[Size Abbreviation]) AS [Size], (cm.ComponentName) AS [Component], kdh.PanelsToMake
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
		WHERE (kdh.BatchNo = @BatchNo) AND (kdh.KnittComplete = yes) AND (kdh.Checkcomplete = yes);"
			cmd.Parameters.AddWithValue("@BatchNo", Session("BatchNo"))
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvBundlesChecked.DataSource = Data
			grdvBundlesChecked.DataBind()
		End Using
	End Sub



End Class