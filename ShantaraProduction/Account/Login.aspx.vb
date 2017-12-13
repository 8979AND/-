Imports System.Web
Imports System.Web.UI
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports Owin
Imports System.Data.OleDb


Partial Public Class Login
	Inherits Page
	Private cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"
	Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
		'RegisterHyperLink.NavigateUrl = "Register"
		' Enable this once you have account confirmation enabled for password reset functionality
		' ForgotPasswordHyperLink.NavigateUrl = "Forgot"
		'OpenAuthLogin.ReturnUrl = Request.QueryString("ReturnUrl")
		'Dim returnUrl = HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
		'If Not [String].IsNullOrEmpty(returnUrl) Then
		' RegisterHyperLink.NavigateUrl += "?ReturnUrl=" & returnUrl
		' End If
		getUsername()
		'initAdmin()
	End Sub
	Protected Sub initAdmin()
		Dim cmdstring As String = "UPDATE [GN - EmployeeDetails]
								   SET [Password] ='" & Encrypt.GenerateHash("Shantara01") &
								   "' WHERE EmployeeID = 100;"
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

	Private Sub getUsername() 'The auth_level filter is just for now while the staff log in isnt implemented
		Dim strQuery As String = "SELECT EmployeeID, (EmployeeFirstName+EmployeeLastName) AS [Username] 
								  FROM [GN - EmployeeDetails]
								  WHERE (Auth_LevelID = 1) OR (Auth_LevelID = 2)
								  ORDER BY EmployeeFirstName ASC"
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()

			If IsPostBack = False Then
				ddlUsername.AppendDataBoundItems = True
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strQuery
				cmd.Connection = con
				Try
					con.Open()
					ddlUsername.DataSource = cmd.ExecuteReader()
					ddlUsername.DataTextField = "Username"
					ddlUsername.DataValueField = "EmployeeID"
					ddlUsername.DataBind()
				Catch ex As Exception
					Throw ex
				End Try
			End If
		End Using
	End Sub
	Protected Sub LogIn(sender As Object, e As EventArgs)
		'initAdmin()
		'If IsValid Then
		Dim tempEmployerID As String = ddlUsername.SelectedValue
			Dim TempPassword As String = Password.Text
			Dim cmdstring = "SELECT EmployeeID, (EmployeeFirstName+EmployeeLastName) AS [Username], Password, Auth_LevelID
							 FROM [GN - EmployeeDetails] 
							 WHERE EmployeeID =" & tempEmployerID & ";"
			Using con As New OleDbConnection(cnString)
				'Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
				Dim cmd As New OleDbCommand(cmdstring)
				'Dim cmd As New SqlCommand(cmdstring)
				Dim reader As OleDbDataReader
				'Dim reader As SqlDataReader
				cmd.CommandType = CommandType.Text
				cmd.Connection = con
				cmd.Connection.Open()
				cmd.ExecuteNonQuery()

				reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
				If reader.HasRows = True Then
					While reader.Read
						Dim q As String = Encrypt.GenerateHash(TempPassword)
						If Not (Encrypt.GenerateHash(TempPassword)) = reader("Password") Then
							FailureText.Text = "Username and password combination is incorrect"
							ErrorMessage.Visible = True
							Exit Sub
						End If
						Session.Add("Username", reader("Username"))
						Session.Add("Auth_Level", reader("Auth_LevelID"))
						'Session.Add("EmployeeLogInID", reader("EmployeeID"))

						If Session("Auth_Level") = 1 Then
							Response.Redirect("~/Management/Adjust_Yarn_Stock.aspx")
						ElseIf Session("Auth_Level") = 2 Then
							Response.Redirect("~/CMT/CMTJob.aspx")
						ElseIf Session("Auth_Level") = 3 Then
							Response.Redirect("~/Knitt/DisplayBatches.aspx")
						End If
					End While
				Else
					FailureText.Text = "User Not Registered"
					ErrorMessage.Visible = True
					tempEmployerID = 0
					TempPassword = ""
				End If
			End Using
		'End If
	End Sub
End Class
