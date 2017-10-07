Imports System.Data.SqlClient
Public Class CreateBatch
	Inherits System.Web.UI.Page
	Private BLNU As Integer
	Private BatchNo As String
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		getProduct()
	End Sub
	Private Sub getProduct()
		Dim strQuery As String = "SELECT ProductID, ProductCode from [FG - End Product Codes] "
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
		Dim cmd As New SqlCommand()

		If IsPostBack = False Then
			ddlBProduct.AppendDataBoundItems = True
			cmd.CommandType = CommandType.Text
			cmd.CommandText = strQuery
			cmd.Connection = con
			Try
				con.Open()

				ddlBProduct.DataSource = cmd.ExecuteReader()
				ddlBProduct.DataTextField = "ProductCode"
				ddlBProduct.DataValueField = "ProductID"
				ddlBProduct.DataBind()
			Catch ex As Exception
				Throw ex
			Finally

				con.Close()

				con.Dispose()

			End Try
		End If
	End Sub

	Private Sub NewBatchNo()

		'YarnID = CInt(Request.QueryString("ID").ToString())

		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())

		'"SELECT YTH.TransactionTypeID, YTT.RangePrefix, YTT.LastNumberUsed
		'      FROM [YN - YarnTransactionHeader] YTH JOIN [YN - Yarn Transaction Type] YTT
		'      On YTT.TransactionTypeID = YTH.TransactionTypeID
		'      WHERE YTH.EntityID = 5 AND YTT.TransactionTypeID = 7;"

		Dim cmdstring = "SELECT YNCF.yarnColourAbbreviation, YNCF.LastBatchNo
        FROM [YN - Yarn Colour Defns] YNCF INNER JOIN [FG - End Product Colours] FGPC ON YNCF.YarnColourID = FGPC.YarnColourID
        WHERE (FGPC.ColourNumber = 'G') AND (FGPC.ProductID = " & ddlBProduct.SelectedValue & ");"
		Dim cmd As New SqlCommand(cmdstring)
		Dim reader As SqlDataReader
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()

		reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
		If reader.HasRows = True Then
			While reader.Read
				BLNU = reader("LastBatchNo") + 1
				BatchNo = reader("yarnColourAbbreviation") & CStr(BLNU)
			End While
		Else
			MsgBox("batchNo not working")
		End If
	End Sub

	Private Sub grdvProductionOrdersPopulate()
		Dim cmd As New SqlCommand
		Dim Adapter As New SqlDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())

		grdvProductionOrders.Visible = True
		'btnBack.Visible = False
		'btnAddUser.Visible = True	
		Session("Batch_Product") = ddlBProduct.SelectedValue
		SQL = "SELECT KNKO.OrderNo, KNKO.ReqByDate, GNEM.EntityName
        FROM [KN - KnittingOrder] KNKO INNER JOIN [GN - EntityMaster] GNEM ON KNKO.EntityID = GNEM.EntityID 
		WHERE KNKO.ProductID = '" & Session("Batch_Product") & "';"

		con.Open()
		cmd.Connection = con
		cmd.CommandText = SQL

		Adapter.SelectCommand = cmd
		Adapter.Fill(Data)

		grdvProductionOrders.DataSource = Data
		grdvProductionOrders.DataBind()

	End Sub

	Protected Sub ddlBProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBProduct.SelectedIndexChanged
		grdvProductionOrdersPopulate()
	End Sub
End Class