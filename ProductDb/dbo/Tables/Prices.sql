CREATE TABLE [dbo].[Prices] (
    [id]                          INT            IDENTITY (0, 1) NOT NULL,
    [warehouse_id]                NVARCHAR (MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [sku]                         VARCHAR (255)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [net_price]                   MONEY          NULL,
    [net_price_discount]          MONEY          NULL,
    [vat_rate]                    FLOAT (53)     NULL,
    [net_price_logistic_discount] MONEY          NULL
);

