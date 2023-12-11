CREATE TABLE [dbo].[Inventory] (
    [id]            INT           IDENTITY (0, 1) NOT NULL,
    [sku]           VARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [unit]          VARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [quantity]      FLOAT (53)    NULL,
    [manufacturer]  VARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [shipping]      VARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [shipping_cost] DECIMAL (38)  NULL,
    [product_id]    INT           NOT NULL
);

