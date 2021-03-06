﻿Imports System.Data.OleDb
Public Class CMTBundles
	Inherits System.Web.UI.Page
	Private cnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Shantara Production IT.mdb;OLE DB Services=-4"
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		grdvBundlesForCMTPopulate()
		grdvBundlesCMTDonePopulate()
	End Sub

	Private Sub grdvBundlesForCMTPopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			grdvBundlesForCMT.Visible = True
			Session("BatchNo") = Request.QueryString("ID").ToString()
			Select Case Session("JDescription")
				Case "Cutting"
					SQL = "SELECT CDH.BatchNo, CDH.BundleNo, (SM.[Size Abbreviation]) AS [Size], CDH.JrsysToCut, (CSIM.CMTSpecialInstructionDetail) AS [CMT Special Instructions]
        FROM ((((([CMT - CMTDetailsHeader] AS CDH
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID )
		INNER JOIN [FG- Size Master] AS SM
			ON  SM.SizeID = CDH.SizeID )
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (CDH.BatchNo = @BatchNo) AND (CDH.CutDataCaptured = no) AND (CDH.Bundlecompleteview = no);"
				Case "AttachVN"
					SQL = "SELECT CDH.BatchNo, CDH.BundleNo, (SM.[Size Abbreviation]) AS [Size], CDH.JrsysToCut, (CSIM.CMTSpecialInstructionDetail) AS [CMT Special Instructions]
        FROM ((((([CMT - CMTDetailsHeader] AS CDH
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID )
		INNER JOIN [FG- Size Master] AS SM
			ON  SM.SizeID = CDH.SizeID )
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (CDH.BatchNo = @BatchNo) AND (CDH.CutDataCaptured = yes) AND (CDO.AttachVDate IS NULL) AND (CDH.Bundlecompleteview = no) AND (JrsyDiffUnprocessed = no);"
				Case "Side Seams"
					SQL = "SELECT CDH.BatchNo, CDH.BundleNo, (SM.[Size Abbreviation]) AS [Size], CDH.JrsysToCut, (CSIM.CMTSpecialInstructionDetail) AS [CMT Special Instructions]
        FROM ((((([CMT - CMTDetailsHeader] AS CDH
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID )
		INNER JOIN [FG- Size Master] AS SM
			ON  SM.SizeID = CDH.SizeID )
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (CDH.BatchNo = @BatchNo) AND (CDH.CutDataCaptured = yes) AND (CDO.SideSeamsDate IS NULL) AND (CDH.Bundlecompleteview = no) AND (JrsyDiffUnprocessed = no);"
				Case "Pressing"
					SQL = "SELECT CDH.BatchNo, CDH.BundleNo, (SM.[Size Abbreviation]) AS [Size], CDH.JrsysToCut, (CSIM.CMTSpecialInstructionDetail) AS [CMT Special Instructions]
        FROM ((((([CMT - CMTDetailsHeader] AS CDH
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID )
		INNER JOIN [FG- Size Master] AS SM
			ON  SM.SizeID = CDH.SizeID )
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (CDH.BatchNo = @BatchNo) AND (CDH.CutDataCaptured = yes) AND (CDO.PressDate IS NULL) AND (CDH.Bundlecompleteview = no) AND (JrsyDiffUnprocessed = no);"
				Case "Dispatch"
					SQL = "SELECT CDH.BatchNo, CDH.BundleNo, (SM.[Size Abbreviation]) AS [Size], CDH.JrsysToCut, (CSIM.CMTSpecialInstructionDetail) AS [CMT Special Instructions]
        FROM ((((([CMT - CMTDetailsHeader] AS CDH
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID )
		INNER JOIN [FG- Size Master] AS SM
			ON  SM.SizeID = CDH.SizeID )
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (CDH.BatchNo = @BatchNo) AND (CDH.CutDataCaptured = yes) AND (CDO.DispatchDate IS NULL) AND (CDH.Bundlecompleteview = no) AND (JrsyDiffUnprocessed = no);"
			End Select
			cmd.Parameters.AddWithValue("@BatchNo", Session("BatchNo"))
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvBundlesForCMT.DataSource = Data
			grdvBundlesForCMT.DataBind()
		End Using
	End Sub

	Private Sub grdvBundlesCMTDonePopulate()
		Dim Adapter As New OleDbDataAdapter
		Dim Data As New DataTable
		Dim SQL As String
		Using con As New OleDbConnection(cnString)
			Dim cmd As New OleDbCommand()
			grdvBundlesCMTDone.Visible = True
			Session("BatchNo") = Request.QueryString("ID").ToString()
			Select Case Session("JDescription")
				Case "Cutting"
					SQL = "SELECT CDH.BatchNo, CDH.BundleNo, (SM.[Size Abbreviation]) AS [Size], CDH.JrsysToCut, (CSIM.CMTSpecialInstructionDetail) AS [CMT Special Instructions], CDO.CutDate
        FROM ((((([CMT - CMTDetailsHeader] AS CDH
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID )
		INNER JOIN [FG- Size Master] AS SM
			ON  SM.SizeID = CDH.SizeID )
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (CDH.BatchNo = @BatchNo) AND (CDH.CutDataCaptured = yes);"
				Case "AttachVN"
					SQL = "SELECT CDH.BatchNo, CDH.BundleNo, (SM.[Size Abbreviation]) AS [Size], CDH.JrsysToCut, (CSIM.CMTSpecialInstructionDetail) AS [CMT Special Instructions], CDO.AttachVDate
        FROM ((((([CMT - CMTDetailsHeader] AS CDH
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID )
		INNER JOIN [FG- Size Master] AS SM
			ON  SM.SizeID = CDH.SizeID )
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (CDH.BatchNo = @BatchNo) AND (CDH.CutDataCaptured = yes) AND (CDO.AttachVDate IS NOT NULL);"
				Case "Side Seams"
					SQL = "SELECT CDH.BatchNo, CDH.BundleNo, (SM.[Size Abbreviation]) AS [Size], CDH.JrsysToCut, (CSIM.CMTSpecialInstructionDetail) AS [CMT Special Instructions], CDO.AttachVDate
        FROM ((((([CMT - CMTDetailsHeader] AS CDH
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID )
		INNER JOIN [FG- Size Master] AS SM
			ON  SM.SizeID = CDH.SizeID )
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (CDH.BatchNo = @BatchNo) AND (CDH.CutDataCaptured = yes) AND (CDO.SideSeamsDate IS NOT NULL);"
				Case "Pressing"
					SQL = "SELECT CDH.BatchNo, CDH.BundleNo, (SM.[Size Abbreviation]) AS [Size], CDH.JrsysToCut, (CSIM.CMTSpecialInstructionDetail) AS [CMT Special Instructions], CDO.PressDate
        FROM ((((([CMT - CMTDetailsHeader] AS CDH
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID )
		INNER JOIN [FG- Size Master] AS SM
			ON  SM.SizeID = CDH.SizeID )
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (CDH.BatchNo = @BatchNo) AND (CDH.CutDataCaptured = yes) AND (CDO.PressDate IS NOT NULL);"
				Case "Dispatch"
					SQL = "SELECT CDH.BatchNo, CDH.BundleNo, (SM.[Size Abbreviation]) AS [Size], CDH.JrsysToCut, (CSIM.CMTSpecialInstructionDetail) AS [CMT Special Instructions], CDO.DispatchDate
        FROM ((((([CMT - CMTDetailsHeader] AS CDH
		INNER JOIN [KN - KnittingOrder] AS KO
			On CDH.KnittingOrderID = KO.KnittingOrderID )
		INNER JOIN [FG- Size Master] AS SM
			ON  SM.SizeID = CDH.SizeID )
		INNER JOIN [FG - End Product Codes] AS EPC
			ON KO.ProductID = EPC.ProductID)
		INNER JOIN [KN - CMT Special Instruction Master] AS CSIM
			ON KO.CMTSpecialInstructionID = CSIM.SpecialInstructionID)
		INNER JOIN [CMT - CMTDetailsOperations] AS CDO
			ON CDH.BundleNo = CDO.BundleNo)
		WHERE (CDH.BatchNo = @BatchNo) AND (CDH.CutDataCaptured = yes) AND (CDO.DispatchDate IS NOT NULL);"
			End Select
			cmd.Parameters.AddWithValue("@BatchNo", Session("BatchNo"))
			con.Open()
			cmd.Connection = con
			cmd.CommandText = SQL

			Adapter.SelectCommand = cmd
			Adapter.Fill(Data)

			grdvBundlesCMTDone.DataSource = Data
			grdvBundlesCMTDone.DataBind()
		End Using
	End Sub

	Protected Sub Back(sender As Object, e As EventArgs) Handles btnBack.Click
		Response.Redirect("~/CMT/CMTOverveiw.aspx")
	End Sub
End Class