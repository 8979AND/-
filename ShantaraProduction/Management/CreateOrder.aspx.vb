Imports System.Data.OleDb
Public Class CreateOrder
	Inherits System.Web.UI.Page

	Shared OLNU As Integer
	Shared KOD As Integer
	Shared ODocNo As String
	Private cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("Auth_Level") <> 1 Then
			Response.Redirect("~/Account/Lockout.aspx")
		End If
		getCustomer()
		getProduct()
		getSize()
		getSI()
		getCMTSI()
	End Sub

	Private Sub getCustomer()
		Dim strQuery As String = "SELECT EntityID, EntityName FROM [GN - EntityMaster] WHERE (((EntityTypeID)=2)) ORDER BY EntityName;"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			If IsPostBack = False Then
				ddlCustomer.AppendDataBoundItems = True
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strQuery
				cmd.Connection = con
				Try
					con.Open()
					ddlCustomer.DataSource = cmd.ExecuteReader()
					ddlCustomer.DataTextField = "EntityName"
					ddlCustomer.DataValueField = "EntityID"
					ddlCustomer.DataBind()
				Catch ex As Exception
					Throw ex
				End Try
			End If
		End Using
	End Sub

	Private Sub getProduct()
		Dim strQuery As String = "SELECT ProductID, ProductID & ' - ' + ProductCode & ' - ' & ProdDescription AS [Prod] 
								  FROM [FG - End Product Codes] 
								  ORDER BY ProductID;"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			If IsPostBack = False Then
				ddlProduct.AppendDataBoundItems = True
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strQuery
				cmd.Connection = con
				Try
					con.Open()
					ddlProduct.DataSource = cmd.ExecuteReader()
					ddlProduct.DataTextField = "Prod"
					ddlProduct.DataValueField = "ProductID"
					ddlProduct.DataBind()
				Catch ex As Exception
					Throw ex
				End Try
			End If
		End Using
	End Sub

	Private Sub getSize()
		Dim strQuery As String = "SELECT SizeID, ([Size Abbreviation]) AS [Sizze] FROM [FG- Size Master];"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			If IsPostBack = False Then
				ddlSize.AppendDataBoundItems = True
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strQuery
				cmd.Connection = con
				Try
					con.Open()
					ddlSize.DataSource = cmd.ExecuteReader()
					ddlSize.DataTextField = "Sizze"
					ddlSize.DataValueField = "SizeID"
					ddlSize.DataBind()
				Catch ex As Exception
					Throw ex
				End Try
			End If
		End Using
	End Sub

	Private Sub getSI()
		Dim strQuery As String = "SELECT SpecialInstructionID, SpecialInstructionDetail FROM [KN -Special Instructions Master] ORDER BY SpecialInstructionDetail;"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			If IsPostBack = False Then
				ddlSI.AppendDataBoundItems = True
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strQuery
				cmd.Connection = con
				Try
					con.Open()
					ddlSI.DataSource = cmd.ExecuteReader()
					ddlSI.DataTextField = "SpecialInstructionDetail"
					ddlSI.DataValueField = "SpecialInstructionID"
					ddlSI.DataBind()
				Catch ex As Exception
					Throw ex
				End Try
			End If
		End Using
	End Sub

	Private Sub NewOrdernumber()
		Dim cmdstring As String = "SELECT EM.[Entity Abbreviation], EM.LastNumUsed
        FROM [GN - EntityMaster] AS EM
        WHERE EM.EntityID = " & ddlCustomer.SelectedValue & ";"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			Dim reader As OleDbDataReader
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()

			reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
			If reader.HasRows = True Then
				While reader.Read
					OLNU = reader("LastNumUsed") + 1
					ODocNo = reader("Entity Abbreviation") & CStr(OLNU)
				End While
				txtOrderNo.Text = ODocNo
			Else
				lblerrorderno.Text = "problem with new Order Number, Please check Table [GN - EntityMaster] in Database"
				Exit Sub
			End If
		End Using
	End Sub

	Private Sub getCMTSI()
		Dim strQuery As String = "SELECT SpecialInstructionID, CMTSpecialInstructionDetail FROM [KN - CMT Special Instruction Master] ORDER BY CMTSpecialInstructionDetail;"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			If IsPostBack = False Then
				ddlCMTSI.AppendDataBoundItems = True
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strQuery
				cmd.Connection = con
				Try
					con.Open()
					ddlCMTSI.DataSource = cmd.ExecuteReader()
					ddlCMTSI.DataTextField = "CMTSpecialInstructionDetail"
					ddlCMTSI.DataValueField = "SpecialInstructionID"
					ddlCMTSI.DataBind()
				Catch ex As Exception
					Throw ex
				End Try
			End If
		End Using

	End Sub

	Private Sub Insertknittingorderrecord()
		Dim cmdstring As String
		cmdstring = " INSERT INTO [KN - KnittingOrder] (OrderNo, EntityID, ProductID, OrderDate, ReqByDate, SpecialInstructionID, CMTSpecialInstructionID) VALUES ('" &
						txtOrderNo.Text &
						"', " & ddlCustomer.SelectedValue &
						", " & ddlProduct.SelectedValue &
						", '" & txtorderdate.Text &
						"', '" & txtduedate.Text &
						"', " & ddlSI.SelectedValue &
						", " & ddlCMTSI.SelectedValue &
						");"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub

	Private Sub getknittingorderID()
		Dim cmdstring As String = "SELECT KnittingOrderID
        FROM [KN - KnittingOrder]
        WHERE OrderNo = '" & txtOrderNo.Text & "';"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			Dim reader As OleDbDataReader
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()

			reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
			If reader.HasRows = True Then
				While reader.Read
					KOD = reader("KnittingOrderID")
				End While
			Else
				lblerrother.Text = "problem with KnittOrderID, Please check Table [KN - KnittingOrder] in Database"
				Exit Sub
			End If
		End Using
	End Sub

	Private Sub InsertKnittingOrderSzQtyDetailsrecord()
		Dim cmdstring As String
		cmdstring = " INSERT INTO [KN - KnittingOrderSzQtyDetails] (KnittingOrderID, SizeID, OrderQty, OrderQtyBalance) VALUES (" &
					KOD &
					", " & ddlSize.SelectedValue &
					", " & txtQuantity.Text &
					", " & txtOrderQtyBalance.Text &
					");"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand(cmdstring)
			cmd.CommandType = CommandType.Text
			cmd.Connection = con
			cmd.Connection.Open()
			cmd.ExecuteNonQuery()
		End Using
	End Sub

	Private Sub grdvOrderProductsPopulate()
		Dim Adapter As New OleDbDataAdapter
		'Dim Adapter As New SqlDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
			Dim cmd As New OleDbCommand()
			'Dim cmd As New SqlCommand()
			grdvOrderProducts.Visible = True
			SQL = "SELECT KO.KnittingOrderID, KO.OrderNo, EPC.ProductCode, EPC.ProdDescription, (SM.[Size Abbreviation]) AS [Size], KOSQD.OrderQty, KOSQD.OrderQtyBalance, KO.OrderDate 
		FROM ((([KN - KnittingOrder] AS KO
		INNER JOIN [KN - KnittingOrderSzQtyDetails] AS KOSQD
			ON KO.KnittingOrderID = KOSQD.KnittingOrderID)
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [FG- Size Master] AS SM
			ON KOSQD.SizeID = SM.SizeID)
		WHERE KO.[EntityID] =" & ddlCustomer.SelectedValue & " AND CDate(Format(KO.[OrderDate],'mm/dd/yyyy')) = CDate(Format('" & DateTime.Now & "','mm/dd/yyyy'))"
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvOrderProducts.DataSource = Data
			grdvOrderProducts.DataBind()
		End Using
	End Sub

	Private Sub UpdateOrderLastNumberUsed()
		Dim cmdstring As String = "UPDATE  [GN - EntityMaster] SET LastNumUsed = " & OLNU & " WHERE EntityID = " & ddlCustomer.SelectedValue & ";"
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

	Protected Sub ddlCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCustomer.SelectedIndexChanged
		txtorderdate.Text = DateTime.Today
		txtduedate.Text = DateTime.Today.AddDays(7)
		txtduedate.Enabled = True
		txtorderdate.Enabled = True
		ddlProduct.ClearSelection()
		ddlProduct.Enabled = True
		ddlSize.Enabled = True
		ddlSI.Enabled = True
		ddlCMTSI.Enabled = True
		txtQuantity.Enabled = True
		txtOrderQtyBalance.Enabled = True
		btnCreate.Visible = True
	End Sub

	Protected Sub txtduedate_TextChanged(sender As Object, e As EventArgs) Handles txtduedate.TextChanged

	End Sub

	Protected Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
		If ddlProduct.SelectedIndex <> 0 Then
			If txtQuantity.Text <> "0" Or txtQuantity Is Nothing Or txtOrderQtyBalance Is Nothing Then
				If ddlSize.SelectedIndex <> 0 Then
					getknittingorderID()
					'UpdateOrderLastNumberUsed()
					InsertKnittingOrderSzQtyDetailsrecord()
					grdvOrderProductsPopulate()
					ddlSize.ClearSelection()
					txtQuantity.Text = ""
					txtOrderQtyBalance.Text = ""
					lblerrsize.Visible = False
					lblerrqty.Visible = False
				Else
					lblerrsize.Text = "please select Size"
					lblerrsize.Visible = True
					ddlSize.Focus()
				End If
			Else
				lblerrqty.Text = "please select valid Quantity"
				lblerrqty.Visible = True
				txtQuantity.Focus()
			End If
		Else

		End If

	End Sub

	'Private Sub checkknittingorderexists()
	'	Dim cmdstring As String = "SELECT KnittingOrderID
	'       FROM [KN - KnittingOrder]
	'       WHERE OrderNo = '" & txtOrderNo.Text & "';"
	'	Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4")
	'	Dim cmd As New OleDbCommand(cmdstring)
	'	Dim reader As OleDbDataReader
	'	cmd.CommandType = CommandType.Text
	'	cmd.Connection = con
	'	cmd.Connection.Open()
	'	cmd.ExecuteNonQuery()

	'	reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
	'	If reader.HasRows = False Then

	'	Else
	'		lblerrother.Text = "problem with KnittOrderID, Please check Table [KN - KnittingOrder] in Database"
	'		Exit Sub
	'	End If
	'	End Using
	'End Sub

	Protected Sub ddlProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProduct.SelectedIndexChanged
		If ddlSI.SelectedIndex <> 0 Then
			If ddlCMTSI.SelectedIndex <> 0 Then
				NewOrdernumber()
				UpdateOrderLastNumberUsed()
				Insertknittingorderrecord()
			Else
				lblerrCMTSI.Visible = True
				lblerrCMTSI.Text = "Please select option or None"
				ddlCMTSI.Focus()
			End If
		Else
			lblerrSI.Visible = True
			lblerrSI.Text = "Please select option or None"
			ddlSI.Focus()
		End If


	End Sub

	Protected Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
		txtOrderQtyBalance.Text = txtQuantity.Text
		lblerrqty.Visible = False
	End Sub

	Protected Sub ddlSI_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSI.SelectedIndexChanged
		lblerrSI.Visible = False
	End Sub

	Protected Sub ddlCMTSI_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCMTSI.SelectedIndexChanged
		lblerrCMTSI.Visible = False
	End Sub
End Class