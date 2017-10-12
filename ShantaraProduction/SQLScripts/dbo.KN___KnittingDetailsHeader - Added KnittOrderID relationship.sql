CREATE TABLE [dbo].[KN - KnittingDetailsHeader] (
    [BatchNo]         NVARCHAR (10) NOT NULL,
    [BundleNo]        NVARCHAR (15) NOT NULL,
    [ComponentID]     INT           DEFAULT ((0)) NULL,
    [SizeID]          INT           NULL,
    [PanelsToMake]    SMALLINT      DEFAULT ((0)) NULL,
    [QtyPerPanel]     SMALLINT      DEFAULT ((0)) NULL,
    [ExtraComponent]  NVARCHAR (10) NULL,
    [KnittingOrderID] INT           NULL,
    [PanelsMadeDay]   SMALLINT      DEFAULT ((0)) NULL,
    [PanelsMadeNight] SMALLINT      DEFAULT ((0)) NULL,
    [OperatorDay]     INT           DEFAULT ((0)) NULL,
    [OperatorNight]   INT           DEFAULT ((0)) NULL,
    [DateStarted]     DATETIME      NULL,
    [DateCompleted]   DATETIME      NULL,
    [Checker]         INT           DEFAULT ((0)) NULL,
    [DateChecked]     DATETIME      NULL,
    [BundleComplete]  BIT           DEFAULT ((0)) NULL,
    CONSTRAINT [aaaaaKN - KnittingDetailsHeader_PK] PRIMARY KEY NONCLUSTERED ([BatchNo] ASC, [BundleNo] ASC),
    CONSTRAINT [KN - KnittingDetailsHeade_FK00] FOREIGN KEY ([ComponentID]) REFERENCES [dbo].[FG - Component Master] ([ComponentID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [KN - KnittingDetailsHeade_FK01] FOREIGN KEY ([SizeID]) REFERENCES [dbo].[FG- Size Master] ([SizeID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [KN - KnittingDetailsHeade_FK02] FOREIGN KEY ([BatchNo]) REFERENCES [dbo].[KN - ProductionOrderHeader] ([BatchNo]) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT [KN - KnittingDetailsHeade_FK03] FOREIGN KEY ([KnittingOrderID]) REFERENCES [dbo].[KN - KnittingOrder] ([KnittingOrderID]) ON DELETE CASCADE ON UPDATE CASCADE

);


GO
CREATE NONCLUSTERED INDEX [BatchNo]
    ON [dbo].[KN - KnittingDetailsHeader]([BatchNo] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [BundleNo]
    ON [dbo].[KN - KnittingDetailsHeader]([BundleNo] ASC);


GO
CREATE NONCLUSTERED INDEX [ComponentID]
    ON [dbo].[KN - KnittingDetailsHeader]([ComponentID] ASC);


GO
CREATE NONCLUSTERED INDEX [FG - Component MasterKN - KnittingDetailsHeader]
    ON [dbo].[KN - KnittingDetailsHeader]([ComponentID] ASC);


GO
CREATE NONCLUSTERED INDEX [FG- Size MasterKN - KnittingDetailsHeader]
    ON [dbo].[KN - KnittingDetailsHeader]([SizeID] ASC);


GO
CREATE NONCLUSTERED INDEX [KN - ProductionOrderHeaderKN - KnittingDetailsHeader]
    ON [dbo].[KN - KnittingDetailsHeader]([BatchNo] ASC);


GO
CREATE NONCLUSTERED INDEX [KnittingOrderID]
    ON [dbo].[KN - KnittingDetailsHeader]([KnittingOrderID] ASC);


GO
CREATE NONCLUSTERED INDEX [OperatorDay]
    ON [dbo].[KN - KnittingDetailsHeader]([OperatorDay] ASC);


GO
CREATE NONCLUSTERED INDEX [OperatorDay1]
    ON [dbo].[KN - KnittingDetailsHeader]([OperatorNight] ASC);


GO
CREATE NONCLUSTERED INDEX [OperatorDay2]
    ON [dbo].[KN - KnittingDetailsHeader]([Checker] ASC);


GO
CREATE NONCLUSTERED INDEX [SizeID]
    ON [dbo].[KN - KnittingDetailsHeader]([SizeID] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'AlternateBackShade', @value = N'100', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'AlternateBackThemeColorIndex', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'AlternateBackTint', @value = N'100', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'BackShade', @value = N'100', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'BackTint', @value = N'100', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'DatasheetForeThemeColorIndex', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'DatasheetGridlinesThemeColorIndex', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'DateCreated', @value = N'2007/07/26 15:39:17', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'DisplayViewsOnSharePointSite', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'FilterOnLoad', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'HideNewField', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'LastUpdated', @value = N'2017/09/11 17:14:26', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DefaultView', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Filter', @value = N'(([KN - KnittingDetailsHeader].BatchNo="BTL2"))', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'MS_OrderByOn', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Orientation', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'OrderByOnLoad', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'RecordCount', @value = N'185394', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'ThemeFontIndex', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'TotalsRow', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'Updatable', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'1095', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'㟻쟇䭠ᶏ㨓ﳯ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'109', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_IMEMode', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_IMESentMode', @value = N'3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'BatchNo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'BatchNo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'UnicodeCompression', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BatchNo';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'1335', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'朷㈩᱀䫰�Ⰵ캢', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'109', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_IMEMode', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_IMESentMode', @value = N'3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'BundleNo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'15', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'BundleNo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'UnicodeCompression', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleNo';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'1275', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'DefaultValue', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'�ಞ䗴ꖽ뗘㵹⸀', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DecimalPlaces', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'109', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'ComponentID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'ComponentID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ComponentID';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'AllowValueListEdits', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'1200', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'䆕ḣ齅䓸枞乀椗偶', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_BoundColumn', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ColumnCount', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ColumnHeads', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ColumnWidths', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DecimalPlaces', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'111', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_LimitToList', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ListRows', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ListWidth', @value = N'0twip', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_RowSource', @value = N'FG- Size Master', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_RowSourceType', @value = N'Table/View/StoredProc', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'SizeID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'ShowOnlyRowSourceValues', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'SizeID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'SizeID';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'1320', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'DefaultValue', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'纫힤佫溬⨟ᝠ႗', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DecimalPlaces', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'109', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'PanelsToMake', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'PanelsToMake', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsToMake';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'1200', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'DefaultValue', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'쐍䓟뭏䁝ↅ淘퍍봋', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DecimalPlaces', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'109', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'QtyPerPanel', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'5', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'QtyPerPanel', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'QtyPerPanel';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'1320', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'퍩氀䂏캂藩凝', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'109', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'MS_IMEMode', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'MS_IMESentMode', @value = N'3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'ExtraComponent', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'6', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'ExtraComponent', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'UnicodeCompression', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'ExtraComponent';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'AllowValueListEdits', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'䢱变뗨䲒㺤⽿ό㟈', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_BoundColumn', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ColumnCount', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ColumnHeads', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ColumnWidths', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DecimalPlaces', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'111', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_LimitToList', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ListRows', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ListWidth', @value = N'0twip', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_RowSource', @value = N'KN - KnittingOrder', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_RowSourceType', @value = N'Table/View/StoredProc', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'KnittingOrderID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'7', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'ShowOnlyRowSourceValues', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'KnittingOrderID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'KnittingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'DefaultValue', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'฻ᚽǑ䒬�鹶Ᶎ䃋', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DecimalPlaces', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'109', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'PanelsMadeDay', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'PanelsMadeDay', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeDay';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'DefaultValue', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'答⎹駽䤘芯톚だ꺾', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DecimalPlaces', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'109', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'PanelsMadeNight', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'9', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'PanelsMadeNight', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'PanelsMadeNight';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'1245', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'DefaultValue', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'䱁䮐饾䳊殛⒇윑䈱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DecimalPlaces', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'109', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'OperatorDay', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'OperatorDay', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorDay';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'DefaultValue', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'榨仐䡘䄋ᆌﲼ≆뒟', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DecimalPlaces', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'109', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'OperatorNight', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'11', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'OperatorNight', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'OperatorNight';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'陗炓韣䴸沞菩椸⶧', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Format', @value = N'Short Date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'MS_IMEMode', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'MS_IMESentMode', @value = N'3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'DateStarted', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'12', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'ShowDatePicker', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'DateStarted', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateStarted';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'⫲䊂薌蹘鰍ᯭ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Format', @value = N'Short Date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'MS_IMEMode', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'MS_IMESentMode', @value = N'3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'DateCompleted', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'13', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'ShowDatePicker', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'DateCompleted', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateCompleted';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'DefaultValue', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'趣ސנּ䱃銃�ᐃ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DecimalPlaces', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'109', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'Checker', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'14', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'Checker', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'Checker';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'횬펕菂䵊ꎟ꣝룢�', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Format', @value = N'Short Date', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'MS_IMEMode', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'MS_IMESentMode', @value = N'3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'DateChecked', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'15', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'ShowDatePicker', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'DateChecked', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'DateChecked';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'DefaultValue', @value = N'No', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'┟鯁䯀䷺鲀ꕃ錮', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'106', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Format', @value = N'Yes/No', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'BundleComplete', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'16', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'BundleComplete', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'KN - KnittingDetailsHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'KN - KnittingDetailsHeader', @level2type = N'COLUMN', @level2name = N'BundleComplete';

