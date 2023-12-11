CREATE TABLE [dbo].[Products] (
    [id]            INT            IDENTITY (0, 1) NOT NULL,
    [sku]           NVARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [name]          NVARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [ean]           NVARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [producer]      NVARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [category]      NVARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [shipping]      NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [is_wire]       BIT            NULL,
    [available]     BIT            NULL,
    [is_vendor]     BIT            NULL,
    [default_image] TEXT           COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [product_id]    INT            NOT NULL,
    [logistic_unit] NVARCHAR (100) NULL,
    CONSTRAINT [PK__Products__3213E83FD67DEB4D] PRIMARY KEY CLUSTERED ([id] ASC)
);

