Imports System.Data.OleDb
Public Class ApproveJrsyDiff
	Inherits System.Web.UI.Page
	Private cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		grdvMachineGroupAllocationPopulate()
	End Sub

	Private Sub grdvMachineGroupAllocationPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			grdvJDiff.Visible = True
			SQL = "SELECT DISTINCTROW CDH.BundleNo, SM.[Size Abbreviation] AS [Size], CDH.JrsysToCut, JD.ReasonOther, CDH.ActualJrsysCut
				   FROM (([CMT - CMTDetailsHeader] AS CDH
				   INNER JOIN [FG- Size Master] AS SM
						ON SM.SizeID = CDH.SizeID)
				   INNER JOIN [JerseyDifference] AS JD
						ON JD.BundleNo = CDH.BundleNo)
				   WHERE CDH.JrsyDiffUnprocessed=yes;"
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvJDiff.DataSource = Data
			grdvJDiff.DataBind()
		End Using
	End Sub

End Class