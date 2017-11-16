Public Class CMTJob
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

	End Sub

	Protected Sub btnattachVN_Click(sender As Object, e As EventArgs) Handles btnattachVN.Click
		Session("JDescription") = "AttachVN"
		Response.Redirect("~/CMT/CMTOverveiw.aspx")
	End Sub

	Protected Sub btncutting_Click(sender As Object, e As EventArgs) Handles btncutting.Click
		Session("JDescription") = "Cutting"
		Response.Redirect("~/CMT/CMTOverveiw.aspx")
	End Sub

	Protected Sub btnDispatchs_Click(sender As Object, e As EventArgs) Handles btnDispatchs.Click
		Session("JDescription") = "Dispatch"
		Response.Redirect("~/CMT/CMTOverveiw.aspx")
	End Sub

	Protected Sub btnSideseam_Click(sender As Object, e As EventArgs) Handles btnSideseam.Click
		Session("JDescription") = "Side Seams"
		Response.Redirect("~/CMT/CMTOverveiw.aspx")
	End Sub

	Protected Sub btnPressing_Click(sender As Object, e As EventArgs) Handles btnPressing.Click
		Session("JDescription") = "Pressing"
		Response.Redirect("~/CMT/CMTOverveiw.aspx")
	End Sub
End Class