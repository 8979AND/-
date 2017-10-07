Imports System.Data.SqlClient

Public Class KnittDataCapture
	Inherits System.Web.UI.Page

	'Private dbs As Database
	'Private strProdnOrdSummary As String
	'Private rsPOS As Recordset
	Private ComponentType As String
	'Private varBookmark As Variant
	Private BundleNum As Integer
	Private PnlsToProduce As Integer
	Private MaxBundleSz As Integer
	Private EndOfRecordset As Boolean
	Private PocketsToMake As Single
	Private strCheckKnittingIssued As String
	'Private rsCKI As Recordset
	Private strKnittingOrder As String
	'Private rsKnitOrd As Recordset
	Private i
	Private KnitOrdID As Long
	'Dim rsCMA As Recordset  ' Check machine allocation
	'Dim rsCYA As Recordset
	'Dim r
	'Dim InitialOrdID As Variant

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		CheckMachineAllocation()
	End Sub
	Private Sub Prodordersumq()

	End Sub

	Private Sub CheckMachineAllocation()
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())

		Dim cmdstring = "WITH POSqry AS (
SELECT DISTINCT [KN - ProductionOrderHeader].BatchNo, 
				[KN - ProductionOrderHeader].ProductID, 
				[KN - ProductionOrderDetails].ProductionQty, 
				[KN - ProductionMachineAllocation].ComponentID, 
				[KN - ProductionOrderDetails].KnittingOrderID, 
				[KN - ProductionOrderDetails].SizeID, 
				[FG - Component Master].ComponentName, 
				([ProductionQty]*[NoOfComponents]) AS CompTot, 
				[FG - Style Size Comp Def Details].PanelDependency, 
				[FG - Pattern Component Details].KnitCombination, 
				[KN - ProductionMachineAllocation].MachineNumber,
				[KN - Knitting Machine Data].SettlingAllowance,
				[KN - Knitting Machine Data].MaxKnitWidth,
				[KN - Knitting Machine Data].CombinedComponents,
				[KN - Knitting Machine Data].ForceOneCompPerPnl,
				IIf([ForceOneCompPerPnl]=1,1,IIf([PanelDependency]='None',0,IIf([PanelDependency]='Width',([MaxKnitWidth]-[SettlingAllowance])/[ComponentWidth],([MaxKnitWidth]-[SettlingAllowance])/[ComponentLength]))) AS CompPerPnl, 
				[FG - Style Size Comp Def Details].ComponentWidth,
				[FG - Style Size Comp Def Details].ComponentLength,
				[KN - ProductionOrderHeader].TicketsPrinted, 
				[FG - End Product Codes].NoCMTReq, 
				[FG - End Product Codes].StyleID, 
				[FG - Component Master].SplitAcrossSizes,
				[FG - Style Size Comp Def Details].NoOfComponents
FROM [KN - Knitting Machine Data] INNER JOIN [KN - ProductionOrderHeader] INNER JOIN [FG - End Product Codes] ON [KN - ProductionOrderHeader].ProductID = [FG - End Product Codes].ProductID INNER JOIN [KN - ProductionOrderDetails] INNER JOIN [KN - ProductionMachineAllocation] INNER JOIN [FG - Style Size Comp Def Details] ON [KN - ProductionMachineAllocation].ComponentID = [FG - Style Size Comp Def Details].ComponentID ON [KN - ProductionOrderDetails].SizeID = [FG - Style Size Comp Def Details].SizeID ON [KN - ProductionOrderHeader].BatchNo = [KN - ProductionOrderDetails].BatchNo AND [KN - ProductionOrderHeader].BatchNo = [KN - ProductionMachineAllocation].BatchNo AND [FG - End Product Codes].StyleID = [FG - Style Size Comp Def Details].StyleID INNER JOIN [FG - Pattern Component Details] ON [FG - End Product Codes].PatternID = [FG - Pattern Component Details].PatternID INNER JOIN [FG - Component Master] ON [FG - Component Master].ComponentID = [FG - Style Size Comp Def Details].ComponentID AND [KN - ProductionMachineAllocation].ComponentID = [FG - Component Master].ComponentID ON [KN - Knitting Machine Data].MachineNumber = [KN - ProductionMachineAllocation].MachineNumber INNER JOIN [KN - ProductionYarnAllocation] ON [KN - ProductionOrderHeader].BatchNo = [KN - ProductionYarnAllocation].BatchNo
)
SELECT DISTINCT BatchNo, 
				ProductID, 
				ComponentID, 
				KnitCombination, 
				MachineNumber, 
				NoOfComponents
FROM POSqry
ORDER BY BatchNo, ComponentID;"
		Dim cmd As New SqlCommand(cmdstring)
		Dim reader As SqlDataReader
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()

		reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
		If reader.HasRows = True Then
			While reader.Read()
				Session.Add("MachineNo", reader("MachineNumber"))
			End While
			If Session("MachineNo") = 0 Then
				MsgBox("Machine Numbers not allocated to all Components")
			Else
				MsgBox("Machines allocated")
			End If

		End If

	End Sub

	Private Sub GetknittDatadb()
		Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("ShantaraDBConnection").ToString())

		Dim cmdstring = "WITH POSqry AS (
SELECT DISTINCT [KN - ProductionOrderHeader].BatchNo, 
				[KN - ProductionOrderHeader].ProductID, 
				[KN - ProductionOrderDetails].ProductionQty, 
				[KN - ProductionMachineAllocation].ComponentID, 
				[KN - ProductionOrderDetails].KnittingOrderID, 
				[KN - ProductionOrderDetails].SizeID, 
				[FG - Component Master].ComponentName, 
				([ProductionQty]*[NoOfComponents]) AS CompTot, 
				[FG - Style Size Comp Def Details].PanelDependency, 
				[FG - Pattern Component Details].KnitCombination, 
				[KN - ProductionMachineAllocation].MachineNumber,
				[KN - Knitting Machine Data].SettlingAllowance,
				[KN - Knitting Machine Data].MaxKnitWidth,
				[KN - Knitting Machine Data].CombinedComponents,
				[KN - Knitting Machine Data].ForceOneCompPerPnl,
				IIf([ForceOneCompPerPnl]=1,1,IIf([PanelDependency]='None',0,IIf([PanelDependency]='Width',([MaxKnitWidth]-[SettlingAllowance])/[ComponentWidth],([MaxKnitWidth]-[SettlingAllowance])/[ComponentLength]))) AS CompPerPnl, 
				[FG - Style Size Comp Def Details].ComponentWidth,
				[FG - Style Size Comp Def Details].ComponentLength,
				[KN - ProductionOrderHeader].TicketsPrinted, 
				[FG - End Product Codes].NoCMTReq, 
				[FG - End Product Codes].StyleID, 
				[FG - Component Master].SplitAcrossSizes,
				[FG - Style Size Comp Def Details].NoOfComponents
FROM [KN - Knitting Machine Data] INNER JOIN [KN - ProductionOrderHeader] INNER JOIN [FG - End Product Codes] ON [KN - ProductionOrderHeader].ProductID = [FG - End Product Codes].ProductID INNER JOIN [KN - ProductionOrderDetails] INNER JOIN [KN - ProductionMachineAllocation] INNER JOIN [FG - Style Size Comp Def Details] ON [KN - ProductionMachineAllocation].ComponentID = [FG - Style Size Comp Def Details].ComponentID ON [KN - ProductionOrderDetails].SizeID = [FG - Style Size Comp Def Details].SizeID ON [KN - ProductionOrderHeader].BatchNo = [KN - ProductionOrderDetails].BatchNo AND [KN - ProductionOrderHeader].BatchNo = [KN - ProductionMachineAllocation].BatchNo AND [FG - End Product Codes].StyleID = [FG - Style Size Comp Def Details].StyleID INNER JOIN [FG - Pattern Component Details] ON [FG - End Product Codes].PatternID = [FG - Pattern Component Details].PatternID INNER JOIN [FG - Component Master] ON [FG - Component Master].ComponentID = [FG - Style Size Comp Def Details].ComponentID AND [KN - ProductionMachineAllocation].ComponentID = [FG - Component Master].ComponentID ON [KN - Knitting Machine Data].MachineNumber = [KN - ProductionMachineAllocation].MachineNumber INNER JOIN [KN - ProductionYarnAllocation] ON [KN - ProductionOrderHeader].BatchNo = [KN - ProductionYarnAllocation].BatchNo
)
SELECT DISTINCT BatchNo, 
				ProductID, 
				ProductionQty, 
				ComponentID, 
				KnittingOrderID, 
				SizeID, 
				ComponentName, 
				CompTot, 
				PanelDependency, 
				KnitCombination, 
				MachineNumber, 
				ForceOneCompPerPnl,
				CompPerPnl, 
				ComponentWidth,
				ComponentLength,
				Round((([CompTot]/NULLIF([CompPerPnl],0))+0.4),0) AS TotPnls,
				TicketsPrinted, 
				NoCMTReq, 
				StyleID, 
				SplitAcrossSizes,
				NoOfComponents
FROM POSqry
ORDER BY BatchNo, ComponentID, KnittingOrderID, SizeID;"
		Dim cmd As New SqlCommand(cmdstring)
		Dim reader As SqlDataReader
		cmd.CommandType = CommandType.Text
		cmd.Connection = con
		cmd.Connection.Open()
		cmd.ExecuteNonQuery()

		reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
		If reader.HasRows = True Then
			While reader.Read
				Session.Add("Username", reader("Username"))
				Session.Add("Username", reader("Username"))
				Session.Add("Username", Reader("Username"))
			End While
		Else
			MsgBox("summary not accesible")
		End If

	End Sub

	Protected Sub ddlBatchNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlBatchNo.SelectedIndexChanged

	End Sub
End Class