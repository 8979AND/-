Imports System.Data.OleDb
Public Class BundleOverview
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		grdvBundlesToCheckPopulate()
		grdvBundlesCheckedPopulate()
	End Sub

	Private Sub grdvBundlesToCheckPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb")
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
		WHERE (kdh.BatchNo = '" & Session("BatchNo") & "') AND (kdh.KnittComplete = yes) AND (kdh.Checkcomplete = no);"

		con.Open()
		cmd.Connection = con
		cmd.CommandText = SQL

		Adapter.SelectCommand = cmd
		Adapter.Fill(Data)

		grdvBundlesToCheck.DataSource = Data
		grdvBundlesToCheck.DataBind()
		cmd.Connection.Close()
	End Sub

	Private Sub grdvBundlesCheckedPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb")
		Dim cmd As New OleDbCommand()
		grdvBundlesChecked.Visible = True
		Session("BatchNo") = Request.QueryString("ID").ToString()
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
		WHERE (kdh.BatchNo = '" & Session("BatchNo") & "') AND (kdh.KnittComplete = yes) AND (kdh.Checkcomplete = yes);"

		con.Open()
		cmd.Connection = con
		cmd.CommandText = SQL

		Adapter.SelectCommand = cmd
		Adapter.Fill(Data)

		grdvBundlesChecked.DataSource = Data
		grdvBundlesChecked.DataBind()
		cmd.Connection.Close()
	End Sub



End Class