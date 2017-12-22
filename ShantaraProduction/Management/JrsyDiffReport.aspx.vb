Imports System.Data.OleDb
Public Class JrsyDiffReport
	Inherits System.Web.UI.Page
	Private cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Session("Auth_Level") <> 1 Then
			Response.Redirect("~/Account/Lockout.aspx")
		End If
	End Sub

	Protected Sub rblJDPeriod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rblJDPeriod.SelectedIndexChanged
		Dim SQL As String
		Select Case rblJDPeriod.SelectedIndex
			Case 0
				SQL = "SELECT DISTINCTROW CDH.BundleNo, SM.[Size Abbreviation] AS [Size], CDH.JrsysToCut, JD.ReasonOther, CDH.ActualJrsysCut, JDRD.Description, JD.JDDate, (ED.EmployeeFirstName + ED.EmployeeLastName) AS [Employee]
				   FROM (((([CMT - CMTDetailsHeader] AS CDH
				   INNER JOIN [FG- Size Master] AS SM
						ON SM.SizeID = CDH.SizeID)
				   INNER JOIN [JerseyDifference] AS JD
						ON JD.BundleNo = CDH.BundleNo)
				   INNER JOIN [JrsyDiffReasonDef] AS JDRD
						ON JDRD.ReasonID = JD.ReasonID)
				   INNER JOIN [GN - EmployeeDetails] AS ED
						ON ED.EmployeeID = JD.EmployeeID)
				   WHERE CDate(Format(JD.JDDate,'mm/dd/yyyy')) = CDate(Format('" & DateTime.Now & "','mm/dd/yyyy')) 
				   ORDER BY JD.JDDate"
				Dim Adapter As New OleDbDataAdapter
				Dim Data As New DataTable
				Using con As New OleDbConnection(cnString)
					Dim cmd As New OleDbCommand()
					grdvJDReport.Visible = True
					con.Open()
					cmd.Connection = con
					cmd.CommandText = SQL

					Adapter.SelectCommand = cmd
					Adapter.Fill(Data)

					grdvJDReport.DataSource = Data
					grdvJDReport.DataBind()
				End Using

				BtnCustomperiod.Visible = False
				txtfrom.Visible = False
				txtto.Visible = False
				lblfrom.Visible = False
				lblto.Visible = False
				txtTotJD.Text = grdvJDReport.Rows.Count
			Case 1

				SQL = "Select DISTINCTROW CDH.BundleNo, SM.[Size Abbreviation] AS [Size], CDH.JrsysToCut, JD.ReasonOther, CDH.ActualJrsysCut, JDRD.Description, JD.JDDate, (ED.EmployeeFirstName + ED.EmployeeLastName) AS [Employee]
				   FROM (((([CMT - CMTDetailsHeader] AS CDH
				   INNER JOIN [FG- Size Master] AS SM
						ON SM.SizeID = CDH.SizeID)
				   INNER JOIN [JerseyDifference] AS JD
						ON JD.BundleNo = CDH.BundleNo)
				   INNER JOIN [JrsyDiffReasonDef] AS JDRD
						ON JDRD.ReasonID = JD.ReasonID)
				   INNER JOIN [GN - EmployeeDetails] AS ED
						ON ED.EmployeeID = JD.EmployeeID)
				   WHERE DAY(JD.JDDate) BETWEEN " & Date.Today.Day & " AND " & Date.Today.Day - 7 & "
				   Order by JD.JDDate"

				Dim Adapter As New OleDbDataAdapter
				Dim Data As New DataTable

				Using con As New OleDbConnection(cnString)
					Dim cmd As New OleDbCommand()
					grdvJDReport.Visible = True
					con.Open()
					cmd.Connection = con
					cmd.CommandText = SQL

					Adapter.SelectCommand = cmd
					Adapter.Fill(Data)

					grdvJDReport.DataSource = Data
					grdvJDReport.DataBind()
				End Using
				BtnCustomperiod.Visible = False
				txtfrom.Visible = False
				txtto.Visible = False
				lblfrom.Visible = False
				lblto.Visible = False
				txtTotJD.Text = grdvJDReport.Rows.Count
			Case 2
				SQL = "SELECT DISTINCTROW CDH.BundleNo, SM.[Size Abbreviation] AS [Size], CDH.JrsysToCut, JD.ReasonOther, CDH.ActualJrsysCut, JDRD.Description, JD.JDDate, (ED.EmployeeFirstName + ED.EmployeeLastName) AS [Employee]
				   FROM (((([CMT - CMTDetailsHeader] AS CDH
				   INNER JOIN [FG- Size Master] AS SM
						ON SM.SizeID = CDH.SizeID)
				   INNER JOIN [JerseyDifference] AS JD
						ON JD.BundleNo = CDH.BundleNo)
				   INNER JOIN [JrsyDiffReasonDef] AS JDRD
						ON JDRD.ReasonID = JD.ReasonID)
				   INNER JOIN [GN - EmployeeDetails] AS ED
						ON ED.EmployeeID = JD.EmployeeID)
				   WHERE MONTH(JD.JDDate) = " & Date.Today.Month & " AND YEAR(JD.JDDate) = " & Date.Today.Year & "
				   Order by JD.JDDate"
				Dim Adapter As New OleDbDataAdapter
				Dim Data As New DataTable
				Using con As New OleDbConnection(cnString)
					Dim cmd As New OleDbCommand()
					grdvJDReport.Visible = True
					con.Open()
					cmd.Connection = con
					cmd.CommandText = SQL

					Adapter.SelectCommand = cmd
					Adapter.Fill(Data)

					grdvJDReport.DataSource = Data
					grdvJDReport.DataBind()
				End Using
				BtnCustomperiod.Visible = False
				txtfrom.Visible = False
				txtto.Visible = False
				lblfrom.Visible = False
				lblto.Visible = False
				txtTotJD.Text = grdvJDReport.Rows.Count
			Case 3
				BtnCustomperiod.Visible = True
				txtfrom.Visible = True
				lblfrom.Visible = True
				lblto.Visible = True
				txtto.Visible = True
				txtto.Text = DateTime.Today.Date
				txtTotJD.Text = ""
				grdvJDReport.Visible = False
		End Select
	End Sub

	Protected Sub BtnCustomperiod_Click(sender As Object, e As EventArgs) Handles BtnCustomperiod.Click
		Dim sql As String
		sql = "Select DISTINCTROW CDH.BundleNo, SM.[Size Abbreviation] AS [Size], CDH.JrsysToCut, JD.ReasonOther, CDH.ActualJrsysCut, JDRD.Description, JD.JDDate, (ED.EmployeeFirstName + ED.EmployeeLastName) AS [Employee]
				   FROM (((([CMT - CMTDetailsHeader] AS CDH
				   INNER JOIN [FG- Size Master] AS SM
						ON SM.SizeID = CDH.SizeID)
				   INNER JOIN [JerseyDifference] AS JD
						ON JD.BundleNo = CDH.BundleNo)
				   INNER JOIN [JrsyDiffReasonDef] AS JDRD
						ON JDRD.ReasonID = JD.ReasonID)
				   INNER JOIN [GN - EmployeeDetails] AS ED
						ON ED.EmployeeID = JD.EmployeeID)
				   WHERE CDate(Format(JD.JDDate,'mm/dd/yyyy')) BETWEEN CDate(Format('" & txtfrom.Text & "','mm/dd/yyyy')) AND CDate(Format('" & txtto.Text & "','mm/dd/yyyy'))"

		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable

		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			grdvJDReport.Visible = True
			con.Open()
			cmd.Connection = con
			cmd.CommandText = Sql

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvJDReport.DataSource = Data
			grdvJDReport.DataBind()
		End Using
		txtTotJD.Text = grdvJDReport.Rows.Count
	End Sub
End Class