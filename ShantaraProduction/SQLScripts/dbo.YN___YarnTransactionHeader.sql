CREATE TABLE [dbo].[YN - YarnTransactionHeader] (
    [YarnTransactionID] INT           IDENTITY (1, 1) NOT NULL,
    [TransactionTypeID] INT           DEFAULT ((0)) NULL,
    [TransactionDate]   DATETIME      NULL,
    [EntityID]          INT           NULL,
    [YarnDocumentNo]    NVARCHAR (30) NULL,
    [Processed]         BIT           DEFAULT ((0)) NULL,
    CONSTRAINT [aaaaaYN - YarnTransactionHeader_PK] PRIMARY KEY NONCLUSTERED ([YarnTransactionID] ASC),
    CONSTRAINT [YN - YarnTransactionHeade_FK00] FOREIGN KEY ([EntityID]) REFERENCES [dbo].[GN - EntityMaster] ([EntityID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [YN - YarnTransactionHeade_FK01] FOREIGN KEY ([TransactionTypeID]) REFERENCES [dbo].[YN - Yarn Transaction Type] ([TransactionTypeID]) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT [YN - YarnTransactionHeade_FK02] FOREIGN KEY ([YarnTransactionID]) REFERENCES [dbo].[YN - YarnTransactionLines] ([YarnTransactionID]) ON DELETE CASCADE ON UPDATE CASCADE

);


GO
CREATE NONCLUSTERED INDEX [EntityID]
    ON [dbo].[YN - YarnTransactionHeader]([EntityID] ASC);


GO
CREATE NONCLUSTERED INDEX [GN - EntityMasterYN - YarnTransactions]
    ON [dbo].[YN - YarnTransactionHeader]([EntityID] ASC);


GO
CREATE NONCLUSTERED INDEX [TransactionTypeID]
    ON [dbo].[YN - YarnTransactionHeader]([TransactionTypeID] ASC);


GO
CREATE NONCLUSTERED INDEX [YarnTransactionID]
    ON [dbo].[YN - YarnTransactionHeader]([YarnTransactionID] ASC);


GO
CREATE NONCLUSTERED INDEX [YN - Yarn Transaction TypeYN - YarnTransactions]
    ON [dbo].[YN - YarnTransactionHeader]([TransactionTypeID] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'AlternateBackShade', @value = N'100', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'AlternateBackThemeColorIndex', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'AlternateBackTint', @value = N'100', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'BackShade', @value = N'100', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'BackTint', @value = N'100', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'DatasheetForeThemeColorIndex', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'DatasheetGridlinesThemeColorIndex', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'DateCreated', @value = N'2007/04/27 12:22:34', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'DisplayViewsOnSharePointSite', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'FilterOnLoad', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'HideNewField', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'LastUpdated', @value = N'2017/09/11 17:14:26', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DefaultView', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'MS_OrderByOn', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Orientation', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'YN - YarnTransactionHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'OrderByOnLoad', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'RecordCount', @value = N'4308', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'ThemeFontIndex', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'TotalsRow', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'Updatable', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'17', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'1830', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'썳ꔵ넳䖮龉㈰햨', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'YarnTransactionID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'YarnTransactionID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'YN - YarnTransactionHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'AllowValueListEdits', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'1785', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'DefaultValue', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'ꭸ瞄䫠䙑鎰Ô䪈睂', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_BoundColumn', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ColumnCount', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ColumnHeads', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ColumnWidths', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DecimalPlaces', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'111', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_LimitToList', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ListRows', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ListWidth', @value = N'0twip', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_RowSource', @value = N'YN - Yarn Transaction Type', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_RowSourceType', @value = N'Table/View/StoredProc', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'TransactionTypeID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'ShowOnlyRowSourceValues', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'TransactionTypeID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'YN - YarnTransactionHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionTypeID';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'亲堓㝰䃯⛫Κ놩', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_IMEMode', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_IMESentMode', @value = N'3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'TransactionDate', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'5', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'ShowDatePicker', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'TransactionDate', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'YN - YarnTransactionHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'TransactionDate';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'AllowValueListEdits', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'1635', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'怃穌愚䛁鲱쁳', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_BoundColumn', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ColumnCount', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ColumnHeads', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ColumnWidths', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DecimalPlaces', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'111', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_LimitToList', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ListRows', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_ListWidth', @value = N'0twip', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_RowSource', @value = N'GN - EntityMaster', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_RowSourceType', @value = N'Table/View/StoredProc', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'EntityID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'6', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'ShowOnlyRowSourceValues', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'EntityID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'YN - YarnTransactionHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'EntityID';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'⟎팜䤼뚢敒݊ᬕ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'109', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_IMEMode', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_IMESentMode', @value = N'3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'YarnDocumentNo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'7', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'30', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'YarnDocumentNo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'YN - YarnTransactionHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'10', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'UnicodeCompression', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'YarnDocumentNo';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'狦堁尣䓹삺ᓘ釧', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'106', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Format', @value = N'Yes/No', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'Processed', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'Processed', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'YN - YarnTransactionHeader', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionHeader', @level2type = N'COLUMN', @level2name = N'Processed';

