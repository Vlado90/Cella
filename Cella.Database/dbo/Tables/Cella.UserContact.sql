CREATE TABLE [dbo].[Cella.UserContact] (
    [userId]         UNIQUEIDENTIFIER NOT NULL,
    [contactId]      UNIQUEIDENTIFIER NOT NULL,
    [contactType]    NVARCHAR (50)    NOT NULL,
    [contactContent] NVARCHAR (255)   NOT NULL,
    [stateCode]      BIT              NOT NULL
);

