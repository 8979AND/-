Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class DisplayBatchs
	Inherits System.Web.UI.Page
	Private BatchNo As String
	Private cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		grdvbatchprodnBundlePopulate()
		grdvprodnBundlesCheckedPopulate()
	End Sub

	Private Sub grdvbatchprodnBundlePopulate()
		Dim Adapter As New OleDbDataAdapter
		'Dim Adapter As New SqlDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand()
			'Dim cmd As New SqlCommand()
			grdvbatchprodnBundle.Visible = True
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
		WHERE (kdh.BatchNo = '" & Session("BatchNo") & "') AND (kdh.KnittComplete = no);"

			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvbatchprodnBundle.DataSource = Data
			grdvbatchprodnBundle.DataBind()
		End Using
	End Sub

	Private Sub grdvprodnBundlesCheckedPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			grdvprodnBundlesChecked.Visible = True
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
		WHERE (kdh.BatchNo = '" & Session("BatchNo") & "') AND (kdh.KnittComplete = yes);"
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvprodnBundlesChecked.DataSource = Data
			grdvprodnBundlesChecked.DataBind()
		End Using
	End Sub

	Protected Sub Back(sender As Object, e As EventArgs) Handles btnBack.Click
		Response.Redirect("~/Knitt/DisplayBatches.aspx")
	End Sub
End Class