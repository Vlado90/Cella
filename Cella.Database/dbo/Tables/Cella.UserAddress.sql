CREATE TABLE [dbo].[Cella.UserAddress] (
    [userId]       UNIQUEIDENTIFIER NOT NULL,
    [addressId]    UNIQUEIDENTIFIER NOT NULL,
    [addressName]  NVARCHAR (255)   NOT NULL,
    [addressLine1] NVARCHAR (255)   NULL,
    [addressLine2] NVARCHAR (255)   NULL,
    [city]         NVARCHAR (255)   NULL,
    [country]      NVARCHAR (255)   NULL,
    [postCode]     INT              NULL,
    [stateCode]    BIT              NOT NULL
);

