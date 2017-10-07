CREATE TABLE [dbo].[YN - YarnTransactionLines] (
    [YarnTransactionID]  INT        DEFAULT ((0)) NOT NULL,
    [YarnID]             INT        DEFAULT ((0)) NULL,
    [TransactionWeight]  FLOAT (53) DEFAULT ((0)) NULL,
    [TransactionCartons] INT        DEFAULT ((0)) NULL,
    [Processed]          BIT        DEFAULT ((0)) NULL, 
    CONSTRAINT [PK_YN - YarnTransactionLines] PRIMARY KEY ([YarnTransactionID])
);


GO
CREATE NONCLUSTERED INDEX [YarnID]
    ON [dbo].[YN - YarnTransactionLines]([YarnID] ASC);


GO
CREATE NONCLUSTERED INDEX [YarnTransactionID]
    ON [dbo].[YN - YarnTransactionLines]([YarnTransactionID] ASC);


GO
CREATE NONCLUSTERED INDEX [YN - Yarn MasterYN - YarnTransactionLines]
    ON [dbo].[YN - YarnTransactionLines]([YarnID] ASC);


GO
CREATE NONCLUSTERED INDEX [YN - YarnTransactionHeaderYN - YarnTransactionLines]
    ON [dbo].[YN - YarnTransactionLines]([YarnTransactionID] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'AlternateBackShade', @value = N'100', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'AlternateBackThemeColorIndex', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'AlternateBackTint', @value = N'100', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'BackShade', @value = N'100', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'BackTint', @value = N'100', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'DatasheetForeThemeColorIndex', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'DatasheetGridlinesThemeColorIndex', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'DateCreated', @value = N'2007/05/01 17:04:39', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'DisplayViewsOnSharePointSite', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'FilterOnLoad', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'HideNewField', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'LastUpdated', @value = N'2017/09/11 17:14:26', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DefaultView', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'MS_OrderBy', @value = N'[YN - YarnTransactionLines].YarnTransactionID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'MS_OrderByOn', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Orientation', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'YN - YarnTransactionLines', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'OrderByOnLoad', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'RecordCount', @value = N'24277', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'RowHeight', @value = N'345', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'ThemeFontIndex', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'TotalsRow', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'Updatable', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'1845', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'DefaultValue', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'푴潲Ԛ䳯쾂囙㓪', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DecimalPlaces', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'109', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'YarnTransactionID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'YarnTransactionID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'YN - YarnTransactionLines', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnTransactionID';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'DefaultValue', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'冃뚥늌侳梋纄匩왲', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DecimalPlaces', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'109', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'YarnID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'True', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'YarnID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'YN - YarnTransactionLines', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'YarnID';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'DefaultValue', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'홢᪺뮎䳢䞌✶綣奏', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DecimalPlaces', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'109', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'TransactionWeight', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'3', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'8', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'TransactionWeight', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'YN - YarnTransactionLines', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'7', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionWeight';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'DefaultValue', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'긹溼䠯힙諫Ԩ蟺', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DecimalPlaces', @value = N'255', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'109', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'TransactionCartons', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'TransactionCartons', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'YN - YarnTransactionLines', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'4', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'TransactionCartons';


GO
EXECUTE sp_addextendedproperty @name = N'AggregateType', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'AllowZeroLength', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'AppendOnly', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'Attributes', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'CollatingOrder', @value = N'1033', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnHidden', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnOrder', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'ColumnWidth', @value = N'-1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'CurrencyLCID', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'DataUpdatable', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'GUID', @value = N'ֿ䜍韽䱞㲶ᾟᠾ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DisplayControl', @value = N'106', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Format', @value = N'Yes/No', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'Name', @value = N'Processed', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'OrdinalPosition', @value = N'5', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'Required', @value = N'False', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'ResultType', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'Size', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'SourceField', @value = N'Processed', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'SourceTable', @value = N'YN - YarnTransactionLines', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'TextAlign', @value = N'0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';


GO
EXECUTE sp_addextendedproperty @name = N'Type', @value = N'1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'YN - YarnTransactionLines', @level2type = N'COLUMN', @level2name = N'Processed';

