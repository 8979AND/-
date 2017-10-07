WITH POSqry AS (
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
				--("[ComponentWidth]","[SizeID]= " & [KN - ProductionOrderDetails].[SizeID] & " AND [BatchNo]= '" & [KN - ProductionOrderHeader].[BatchNo] & "' AND [ComponentID] = 1") AS SlvWidth
				--IIf([KN - ProductionMachineAllocation].[ComponentID]=1 And [KnitCombination]="BodySlv",("[SlvFctr]","KN - ProdnOrdSummary qry","[SizeID]= " & [KN - ProductionOrderDetails].[SizeID] & " AND [BatchNo]= '" & [KN - ProductionOrderHeader].[BatchNo] & "' AND  [ComponentID] = 2"),0) AS SlvSlvFctr, 
				--IIf([ComponentID]=2 And [CombinedComponents]=1 And [KnitCombination]='BodySlv',(([MaxKnitWidth]-[SettlingAllowance])-([CompPerPnl]*[ComponentWidth])/[SlvWidth]),0) AS SlvFctr,
				--IIf([KN - ProductionMachineAllocation].[ComponentID]=1 And [SlvSlvFctr]=1,("[TotPnls]","KN - ProdnOrdSummary qry","[SizeID]= " & [KN - ProductionOrderDetails].[SizeID] & " AND [BatchNo]= '" & [KN - ProductionOrderHeader].[BatchNo] & "' AND [ComponentID] = 2 AND [KnittingOrderID] = " & [KN - ProductionOrderDetails].[KnittingOrderID] & " AND [SlvFctr]=1 "),0) AS SlvQtyMade				
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
ORDER BY BatchNo, ComponentID, KnittingOrderID, SizeID;


