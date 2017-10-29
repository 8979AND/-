Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class DisplayBatchs
	Inherits System.Web.UI.Page
	Private BatchNo As String
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		grdvbatchprodnBundlePopulate()
	End Sub

	Private Sub grdvbatchprodnBundlePopulate()
		Dim Adapter As New OleDbDataAdapter
		'Dim Adapter As New SqlDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb")
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
		WHERE (kdh.BatchNo = '" & Session("BatchNo") & "') AND (kdh.KnittComplete = 0);"

		con.Open()
		cmd.Connection = con
		cmd.CommandText = SQL

		Adapter.SelectCommand = cmd
		Adapter.Fill(Data)

		grdvbatchprodnBundle.DataSource = Data
		grdvbatchprodnBundle.DataBind()

	End Sub

End Class