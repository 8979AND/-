Imports System.Web
Imports System.Web.UI
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports Owin
Imports System.Data.SqlClient


Partial Public Class Login
    Inherits Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'RegisterHyperLink.NavigateUrl = "Register"
        ' Enable this once you have account confirmation enabled for password reset functionality
        ' ForgotPasswordHyperLink.NavigateUrl = "Forgot"
        'OpenAuthLogin.ReturnUrl = Request.QueryString("ReturnUrl")
        'Dim returnUrl = HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
        'If Not [String].IsNullOrEmpty(returnUrl) Then
        ' RegisterHyperLink.NavigateUrl += "?ReturnUrl=" & returnUrl
        ' End If
    End Sub
    Protected Sub initAdmin()
        ' Dim con As SqlConnection
        Dim cmd As SqlCommand
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())

        Dim cmdstring As String
        cmdstring = "INSERT INTO Users (Username,Password,Auth_Level,FName,LName,Cellnumber) VALUES ('Admin@shantara.co.za','" & Encrypt.GenerateHash("password") & "',1,'Admin','Admin',1234567890)"
        cmd = New SqlCommand(cmdstring)
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        cmd.Connection.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub LogIn(sender As Object, e As EventArgs)
        'initAdmin()

        If IsValid Then
            Dim TempUsername As String = Email.Text
            Dim TempPassword As String = Password.Text

            'Dim Connection As SqlConnection
            Dim Command As SqlCommand
            Dim Reader As SqlDataReader

            Dim connection As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())
            Dim CommandString As String

            CommandString = "SELECT * FROM Users WHERE Username ='" & TempUsername & "';"

            Command = New SqlCommand(CommandString)
            Command.CommandType = CommandType.Text
            Command.Connection = connection

            Command.Connection.Open()

            Command.ExecuteNonQuery()

            Reader = Command.ExecuteReader(CommandBehavior.CloseConnection)

            If Reader.HasRows = True Then
                Do While Reader.Read()
                    Dim q As String = Encrypt.GenerateHash(TempPassword)
                    If Not (Encrypt.GenerateHash(TempPassword)) = Reader("Password") Then
                        FailureText.Text = "Username and password combination is incorrect"
                        ErrorMessage.Visible = True
                        Exit Sub
                    End If
                    'Dim FirstNameCookies As New HttpCookie("FirstNameCookies", Reader("FirstName"))
                    'Dim LastNameCookies As New HttpCookie("LastNameCookies", Reader("LastName"))
                    'Dim UserIDCookies As New HttpCookie("UserIDCookies", Reader("UserID"))
                    'Response.Cookies.Add(FirstNameCookies)
                    'Response.Cookies.Add(LastNameCookies)
                    'Response.Cookies.Add(UserIDCookies)

                    Session.Add("Username", Reader("Username"))
                    Session.Add("Auth_Level", Reader("Auth_Level"))
                    Session.Add("Id", Reader("Id"))

                    If Session("Auth_Level") = 1 Then
                        Response.Redirect("~/AdminControl/Dashboard.aspx")
                    ElseIf Session("Auth_Level") = 2 Then
                        Response.Redirect("/Management/Dashboard.aspx")
                    ElseIf Session("Auth_Level") = 3 Then
                        Response.Redirect("~/Knitt/Dashboard.aspx")
                    ElseIf Session("Auth_Level") = 3 Then
                        Response.Redirect("~/CMT/Dashboard.aspx")
                    End If

                Loop

            Else
                FailureText.Text = "User Not Registered"
                ErrorMessage.Visible = True
                TempUsername = ""
                TempPassword = ""

            End If

            '' Validate the user password
            'Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            'Dim signinManager = Context.GetOwinContext().GetUserManager(Of ApplicationSignInManager)()

            '' This doen't count login failures towards account lockout
            '' To enable password failures to trigger lockout, change to shouldLockout := True
            'Dim result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout := False)

            'Select Case result
            '    Case SignInStatus.Success
            '        IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)
            '        Exit Select
            '    Case SignInStatus.LockedOut
            '        Response.Redirect("/Account/Lockout")
            '        Exit Select
            '    Case SignInStatus.RequiresVerification
            '        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
            '                                        Request.QueryString("ReturnUrl"),
            '                                        RememberMe.Checked),
            '                          True)
            '        Exit Select
            '    Case Else
            '        FailureText.Text = "Invalid login attempt"
            '        ErrorMessage.Visible = True
            '        Exit Select
            'End Select
        End If
    End Sub
End Class
