Public Class logout
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Session("Auth_Level") = 3
	End Sub

End Class