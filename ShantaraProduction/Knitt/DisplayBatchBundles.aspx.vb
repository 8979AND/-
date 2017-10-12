Imports System.Data.SqlClient
Public Class DisplayBatchs
	Inherits System.Web.UI.Page
	Private BatchNo As String
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		grdvbatchprodnBundlePopulate()
	End Sub

	Private Sub grdvbatchprodnBundlePopulate()
		Dim cmd As New SqlCommand
		Dim Adapter As New SqlDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		grdvbatchprodnBundle.Visible = True
		Session("BatchNo") = Request.QueryString("ID").ToString()
		SQL = "SELECT KDH.BatchNo, KDH.BundleNo, SM.Size, CM.ComponentName, KDH.PanelsToMake, (SIM.SpecialInstructionDetail) AS [Special Instructions]
        FROM [KN - KnittingDetailsHeader] KDH INNER JOIN [KN - KnittingOrder] KO
			On KDH.KnittingOrderID = KO.KnittingOrderID 
		INNER JOIN [FG - Component Master] CM 
			ON KDH.ComponentID = CM.ComponentID
		INNER JOIN [FG- Size Master] SM
			ON KDH.SizeID = SM.SizeID
		INNER JOIN [FG - End Product Codes] EPC
			ON KO.ProductID = EPC.ProductID
		INNER JOIN [KN -Special Instructions Master] SIM
			ON KO.SpecialInstructionID = SIM.SpecialInstructionID
		WHERE KDH.BatchNo = '" & Session("BatchNo") & "' AND BundleComplete = 0;"

		con.Open()
		cmd.Connection = con
		cmd.CommandText = SQL

		Adapter.SelectCommand = cmd
		Adapter.Fill(Data)

		grdvbatchprodnBundle.DataSource = Data
		grdvbatchprodnBundle.DataBind()

	End Sub

End Class